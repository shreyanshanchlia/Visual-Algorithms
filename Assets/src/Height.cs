using UnityEngine;
using TMPro;
public class Height : MonoBehaviour
{
    public int size;
    public GameObject @object;
    public Gradient gradient;
    public TextMeshProUGUI text;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        if(@object==null)
        {
            Destroy(this.gameObject);
            return;
        }
        size = @object.GetComponent<HeightData>().size;
        scale = @object.transform.localScale.y/size;
        text.text = size.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(@object == null)
        {
            Destroy(this.gameObject);
            return;
        }
        size = (int)(@object.transform.localScale.y / scale);
        text.text = size.ToString();
    }
}
