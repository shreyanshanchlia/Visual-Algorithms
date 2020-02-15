using UnityEngine;
using TMPro;
public class HighlightText : MonoBehaviour
{
    public GameObject magnifier;
    public TextMeshProUGUI magnifiedText;
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
        //raycast and get below text;
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.down);

        if (hit != false && hit.collider != null)
        {
            try
            {
                magnifier.SetActive(true);
                magnifiedText.text = hit.collider.gameObject.GetComponent<HeightData>().size.ToString();
            }
            catch
            {
                magnifier.SetActive(false);
            }
        }
        else
        {
            magnifier.SetActive(false);
        }
    }
}