using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaterialUI;

public class State : MonoBehaviour
{
	public Toggle repeat;
	public SelectionBoxConfig algorithm;
	public Text currentAlgorithmText;
    // Start is called before the first frame update
    void Start()
    {
		repeat.isOn = PlayerPrefs.GetInt("Repeat") == 1 ? true : false;
		algorithm.currentSelection = PlayerPrefs.GetInt("Algorithm");
		currentAlgorithmText.text = algorithm.listItems[algorithm.currentSelection];
    }
	public void RepeatSwitch(bool shouldRepeat)
	{
		repeat.isOn = shouldRepeat;
		PlayerPrefs.SetInt("Repeat", shouldRepeat ? 1 : 0);
	}
	public void AlgorithmChange()
	{
		int switchAlgorithm = algorithm.currentSelection;
		PlayerPrefs.SetInt("Algorithm", switchAlgorithm);
	}
}
