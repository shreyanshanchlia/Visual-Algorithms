using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaterialUI;

public class State : MonoBehaviour
{
	public Toggle repeat;
	public SelectionBoxConfig algorithm;
    // Start is called before the first frame update
    void Start()
    {
		repeat.isOn = PlayerPrefs.GetInt("Repeat") == 1 ? true : false;
		algorithm.currentSelection = PlayerPrefs.GetInt("Algorithm");
    }
	public void RepeatSwitch(bool shouldRepeat)
	{
		repeat.isOn = shouldRepeat;
		PlayerPrefs.SetInt("Repeat", shouldRepeat ? 1 : 0);
	}
	public void AlgorithmChange(int switchAlgorithm)
	{
		algorithm.currentSelection = switchAlgorithm;
		PlayerPrefs.SetInt("Algorithm", switchAlgorithm);
	}
}
