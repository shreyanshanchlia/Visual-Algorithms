using UnityEngine;
using UnityEngine.UI;
using MaterialUI;
using System;
using TMPro;

public class State : MonoBehaviour
{
	public Toggle repeat;
	public SelectionBoxConfig algorithm;
	public TextMeshProUGUI currentAlgorithmText;
    // Start is called before the first frame update
    void Start()
    {
		repeat.isOn = PlayerPrefs.GetInt("Repeat") == 1 ? true : false;
		algorithm.currentSelection = Array.IndexOf(algorithm.listItems, PlayerPrefs.GetString("Algorithm", "Bubble-Sort"));
		currentAlgorithmText.text = algorithm.listItems[algorithm.currentSelection];
    }
	public void RepeatSwitch(bool shouldRepeat)
	{
		repeat.isOn = shouldRepeat;
		PlayerPrefs.SetInt("Repeat", shouldRepeat ? 1 : 0);
	}
	public void AlgorithmChange()
	{
		PlayerPrefs.SetString("Algorithm", algorithm.listItems[algorithm.currentSelection]);
	}
}
