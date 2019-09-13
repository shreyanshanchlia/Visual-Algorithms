using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LineMaker : MonoBehaviour
{
	public GameObject linePrefab;
	public GameObject parentLines;
	private GameObject instantiatedLine;
	private Vector3 childTransform;
	private Vector3 childScale;
	private int height;
	private float thickness;
	private int[] shuffledNumbers = new int[50];
	List<int> numbersList = new List<int>(50);
	
	public void MakeLines(float noOfLines)
	{
		Sort.instance.StopAllCoroutines();
		foreach (Transform child in parentLines.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
		childTransform = Vector3.zero;
		childScale = Vector3.zero;
		thickness = 10.0f;
		for (int i = (int)noOfLines-1; i >= 0; i--)
		{
			height = UnityEngine.Random.Range(5, 50);
			instantiatedLine = Instantiate(linePrefab, parentLines.transform);
			childTransform.x = thickness * 1.05f * ((noOfLines / 2) - i);
			instantiatedLine.transform.localPosition = childTransform;
			childScale.x = 1000;
			childScale.y = height*250;
			instantiatedLine.transform.localScale = childScale;
		}
	}
	public void MakeLinesRepeatOff(float noOfLines)
	{
		Sort.instance.StopAllCoroutines();
		foreach (Transform child in parentLines.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
		childTransform = Vector3.zero;
		childScale = Vector3.zero;
		thickness = 10.0f;
		numbersList.Add(0);
		numbersList.Clear();
		int[] numbers = new int[(int)noOfLines];
		for (int i = 1; i <= noOfLines; i++)
		{
			numbers[i-1] = i;
			numbersList.Add(i);
		}
		Shuffle<int>(numbers);
		for (int i = (int)noOfLines - 1; i >= 0; i--)
		{
			height = shuffledNumbers[i];
			instantiatedLine = Instantiate(linePrefab, parentLines.transform);
			childTransform.x = thickness * 1.05f * ((noOfLines / 2) - i);
			instantiatedLine.transform.localPosition = childTransform;
			childScale.x = 1000;
			childScale.y = height * 250;
			instantiatedLine.transform.localScale = childScale;
		}
	}

	private void Shuffle<T>(T[] numbers)
	{
		int n = numbers.Length;
		int r;
		for(int i = 0; i < n; i++)
		{
			r = UnityEngine.Random.Range(0, numbersList.Count);
			shuffledNumbers[i] = numbersList[r];
			numbersList.RemoveAt(r);
		}
	}
}
