using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void UpdateText(float value)
    {
        text.text = ((int)value).ToString();
    }
}
