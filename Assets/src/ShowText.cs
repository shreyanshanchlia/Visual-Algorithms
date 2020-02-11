using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour
{
    public TMP_InputField textValue;
    public Slider NValueSlider;
    public Image WarningImage;
    public void updateText(float value)
    {
        textValue.text = ((int)value).ToString();
    }
    public void UpdateSlider(string value)
    {
        NValueSlider.value = int.Parse(value);
    }
}