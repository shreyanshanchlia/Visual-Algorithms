using UnityEngine;
using TMPro;
public class Height : MonoBehaviour
{
    public int size;
    public GameObject @object;
    public Gradient gradient;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = @object.transform.localScale.y.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = @object.transform.localScale.y.ToString();
    }
}
