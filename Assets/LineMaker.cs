using UnityEngine;
using System.Collections.Generic;

public class LineMaker : MonoBehaviour
{
	public GameObject linePrefab;
	public GameObject parentLines;
	public GameObject HeightText;
	private GameObject instantiatedLine;
	private Vector3 childTransform;
	private Vector3 childScale;
	private int height;
	private float heightMultiplier;
	private float thickness;
	[HideInInspector] public static int NumberOfLines;
	public void MakeLines(float noOfLines)
	{
		if(PlayerPrefs.GetInt("Repeat", 0) == 1)
		{
			MakeLinesRepeatOn((int)noOfLines);
		}
		else
		{
			MakeLinesRepeatOff((int)noOfLines);
		}
		NumberOfLines = (int)noOfLines;
	}
	private void MakeLinesRepeatOn(int noOfLines)
	{
		Sort.instance.StopAllCoroutines();
		foreach (Transform child in parentLines.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
		childTransform = Vector3.zero;
		childScale = Vector3.zero;
		thickness = 10.0f;
		if(thickness * 1.05f * noOfLines > 472.5f)
		{
			thickness = 472.5f / (noOfLines * 1.05f);
		}
		for (int i = (int)noOfLines-1; i >= 0; i--)
		{
			height = UnityEngine.Random.Range(5, 50);
			instantiatedLine = Instantiate(linePrefab, parentLines.transform);
			GameObject heightText = Instantiate(HeightText, instantiatedLine.transform.position, Quaternion.identity);
			heightText.GetComponent<Height>().@object = instantiatedLine;
			childTransform.x = thickness * 1.05f * ((noOfLines / 2) - i);
			instantiatedLine.transform.localPosition = childTransform;
			childScale.x = thickness*100;
			childScale.y = height*250;
			instantiatedLine.transform.localScale = childScale;
		}
	}
	private void MakeLinesRepeatOff(int noOfLines)
	{
		Sort.instance.StopAllCoroutines();
		foreach (Transform child in parentLines.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
		int[] shuffledNumbers = new int[(int)noOfLines];
		List<int> numbersList = new List<int>((int)noOfLines);
		childTransform = Vector3.zero;
		childScale = Vector3.zero;
		thickness = 10.0f;
		numbersList.Add(0);
		numbersList.Clear();
		if (thickness * 1.05f * noOfLines > 472.5f)
		{
			thickness = 472.5f / (noOfLines * 1.05f);
		}
		heightMultiplier = 250.0f;
		if (15000.0f < noOfLines * 250.0f)
		{
			heightMultiplier = 15000.0f * 250.0f / (noOfLines * 250.0f);
		}
		int[] numbers = new int[(int)noOfLines];
		for (int i = 1; i <= noOfLines; i++)
		{
			numbers[i - 1] = i;
			numbersList.Add(i);
		}
		Shuffle<int>(shuffledNumbers, numbersList);
		for (int i = (int)noOfLines - 1; i >= 0; i--)
		{
			height = shuffledNumbers[i];
			instantiatedLine = Instantiate(linePrefab, parentLines.transform);
			childTransform.x = thickness * 1.05f * ((noOfLines / 2) - i);
			instantiatedLine.transform.localPosition = childTransform;
			childScale.x = thickness * 100;
			childScale.y = height * heightMultiplier;
			instantiatedLine.transform.localScale = childScale;
		}
	}

	private void Shuffle<T>(T[] shuffledNumbers, List<T> numbersList)
	{
		int n = numbersList.Count;
		int r;
		for(int i = 0; i < n; i++)
		{
			r = UnityEngine.Random.Range(0, numbersList.Count);
			shuffledNumbers[i] = numbersList[r];
			numbersList.RemoveAt(r);
		}
	}
}
