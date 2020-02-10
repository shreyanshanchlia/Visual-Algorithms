using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorState
{
	normal, highlight, sorted, reference
};
public enum CompareResult
{
	greater, equal, smaller
};
public class Sort : MonoBehaviour
{
	float t = 0.0f;
	public static Sort instance;
	private int algorithm = 1;
	private WaitForSeconds wait;
	public GameObject parentLines;
	public Color normalcolor, highlightcolor, sortedcolor, referencecolor;
	private Vector3 forSwapTransform;
	public float waitingTime;

	private void Start()
	{
		instance = this;
		wait = new WaitForSeconds(waitingTime);
	}

	public void sort()
	{
		StopAllCoroutines();
		t = 0.0f;
		string algo = PlayerPrefs.GetString("Algorithm");
		if (algo.Contains("-"))
		{
			algo = algo.Remove(algo.IndexOf('-'), 1);
		}
		else if (algo.Contains(" "))
		{
			algo = algo.Remove(algo.IndexOf(' '), 1);
		}
		//Debug.Log(algo);
		try
		{
			StartCoroutine(algo);
		}
		catch(Exception e)
		{
			Debug.LogError("No such algorithm in list! Try filling an issue." + e.Message);
		}
	}
	private void Update()
	{
		t += Time.deltaTime;
	}
	#region utilities
	void Swap(int unit1, int unit2)
	{
		forSwapTransform = parentLines.transform.GetChild(unit1).localScale;
		parentLines.transform.GetChild(unit1).localScale = parentLines.transform.GetChild(unit2).localScale;
		parentLines.transform.GetChild(unit2).localScale = forSwapTransform;
	}
	void ApplyHighlightColor(int unit)
	{
		parentLines.transform.GetChild(unit).GetComponent<SpriteRenderer>().color = highlightcolor;
	}
	void ApplyNormalColor(int unit)
	{
		parentLines.transform.GetChild(unit).GetComponent<SpriteRenderer>().color = normalcolor;
	}
	void ApplySortedColor(int unit)
	{
		parentLines.transform.GetChild(unit).GetComponent<SpriteRenderer>().color = sortedcolor;
	}
	void ApplyReferenceColor(int unit)
	{
		parentLines.transform.GetChild(unit).GetComponent<SpriteRenderer>().color = referencecolor;
	}
	CompareResult CompareYScale(int unit1, int unit2)
	{
		if (parentLines.transform.GetChild(unit1).localScale.y > parentLines.transform.GetChild(unit2).localScale.y)
		{ return CompareResult.greater; }
		else if(parentLines.transform.GetChild(unit1).localScale.y < parentLines.transform.GetChild(unit2).localScale.y)
		{ return CompareResult.smaller; }
		else
			return CompareResult.equal;

	}
	#endregion
	#region bubble sort
	IEnumerator BubbleSort()
	{
		int n = LineMaker.NumberOfLines;
		for (int i = 0; i <= n - 1; i++)
		{
			for (int j = 0; j < n - i - 1; j++)
			{
				ApplyHighlightColor(j);
				ApplyReferenceColor(j + 1);
				if (CompareYScale(j, j + 1) == CompareResult.greater)
				{
					Swap(j, j + 1);
				}
				yield return new WaitForSeconds(0.0f);
				ApplyNormalColor(j);
			}
			ApplySortedColor(n - i - 1);
		}
		Debug.Log(t);
	}
	#endregion
	#region selection sort
	IEnumerator SelectionSort()
	{
		int n = LineMaker.NumberOfLines;
		int min_idx;
		for (int i = 0; i < n; i++)
		{
			min_idx = i;
			for (int j = i + 1; j < n; j++)
			{
				ApplyHighlightColor(j);
				ApplyReferenceColor(min_idx);
				if (CompareYScale(j, min_idx) == CompareResult.smaller)
				{
					ApplyNormalColor(min_idx);
					min_idx = j;
					ApplyReferenceColor(min_idx);
				}
				yield return new WaitForSeconds(0.0f);
				ApplyNormalColor(j);
			}
			ApplyNormalColor(min_idx);
			Swap(min_idx, i);
			ApplySortedColor(i);
		}
		Debug.Log(t);
	}
	#endregion
	#region insertion sort
	IEnumerator InsertionSort()
	{
		int n = LineMaker.NumberOfLines, j;
		for (int i = 0; i < n; i++)
		{
			j = i;
			while(j>=1 && CompareYScale(j, j-1) == CompareResult.smaller)
			{
				ApplyHighlightColor(j);
				ApplyReferenceColor(j - 1);
				Swap(j, j - 1);
				j--;
				yield return null;
				ApplySortedColor(j + 1);
				ApplySortedColor(j);
			}
		    ApplySortedColor(0);
		}
	}
	#endregion
	#region merge sort
	IEnumerator Merge(int l, int m, int r)
	{
		print($"merge l = {l}, m = {m}, r = {r}");
		int i, j, k;
		int n1 = m - l + 1;
		int n2 = r - m;
		Vector3[] L = new Vector3[n1];
		Vector3[] R = new Vector3[n2];
		for (i = 0; i < n1; i++)
		{
			/*
			 * requires adding visual for temp array.
			*/
			L[i] = parentLines.transform.GetChild(l + i).transform.localScale;
			print($"i={l+1} "+L[i].y);
		}
		//print(L.Length);
		for (j = 0; j < n2; j++)
		{
			R[j] = parentLines.transform.GetChild(m + 1 + j).transform.localScale;
		}
		//yield return wait;
		//merge them back.
		i = 0; // Initial index of first subarray 
		j = 0; // Initial index of second subarray 
		k = l; // Initial index of merged subarray 
		while (i < n1 && j < n2)
		{
			if (L[i].y <= R[j].y)
			{
				parentLines.transform.GetChild(k).transform.localScale = L[i];
				i++;
			}
			else
			{
				parentLines.transform.GetChild(k).transform.localScale = R[j];
				j++;
			}
			k++;
			//yield return wait;
		}
		while (i < n1)
		{
			parentLines.transform.GetChild(k).transform.localScale = L[i];
			i++;
			k++;
			//yield return wait;
		}
		while (j < n2)
		{
			parentLines.transform.GetChild(k).transform.localScale = R[j];
			j++;
			k++;
		}
			yield return wait;
	}
	IEnumerator MergeSortDivide(int l, int r)
	{
		//n = n<0?LineMaker.NumberOfLines:n;
		if (l < r)
		{
			int m = (l + r) / 2;
			//yield return wait;
			yield return StartCoroutine(MergeSortDivide(l, m));
			//yield return wait;
			yield return StartCoroutine(MergeSortDivide(m + 1, r));
			//yield return wait;
			yield return StartCoroutine(Merge(l, m, r));
		}
		//yield return wait;
	}
	IEnumerator MergeSort()
	{
		int l = 0, n = LineMaker.NumberOfLines-1;
		StartCoroutine(MergeSortDivide(l, n));
		yield return null;
	}
	#endregion
}
