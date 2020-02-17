using UnityEngine;
using TMPro;
public class HighlightText : MonoBehaviour
{
    public GameObject magnifier;
    public TextMeshProUGUI magnifiedText;
    public GameObject line;
    GameObject lineobject;

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
                if(lineobject == null)
                    lineobject = Instantiate(line, screenPos, Quaternion.identity);
            }
            catch
            {
                magnifier.SetActive(false);
                Destroy(lineobject);
            }
        }
        else
        {
            magnifier.SetActive(false);
            Destroy(lineobject);
        }
    }
}