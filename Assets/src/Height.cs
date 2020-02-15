using UnityEngine;
using TMPro;
public class Height : MonoBehaviour
{
    public int size;
    public GameObject @object;
    public Gradient gradient;
    public TextMeshProUGUI text;
    float scale;
    private int prevSize;
    // Start is called before the first frame update
    void Start()
    {
        if(@object==null)
        {
            Destroy(this.gameObject);
            return;
        }
        size = @object.GetComponent<HeightData>().size;
        prevSize = size;
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
        if (size != prevSize)
        {
            @object.GetComponent<HeightData>().size = size;
            prevSize = size;
        }
        text.text = size.ToString();
    }
}
