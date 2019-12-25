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
	private void Start()
	{
		instance = this;
	}
	public GameObject parentLines;
	public Color normalcolor, highlightcolor, sortedcolor, referencecolor;
	private Vector3 forSwapTransform;
	public void sort()
	{
		t = 0.0f;
		string algo = PlayerPrefs.GetString("Algorithm");
		algo = algo.Remove(algo.IndexOf('-'),1);
		//Debug.Log(algo);
		StartCoroutine(algo);
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
				//ApplyNormalColor(j + 1);
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
		for (int i = 0; i < n - 1; i++)
		{
			min_idx = i;
			for (int j = i + 1; j < n; j++)
			{
				ApplyHighlightColor(j);
				if (CompareYScale(j, min_idx) == CompareResult.smaller)
				{
					min_idx = j;
				}
				ApplyNormalColor(j);
			}
			yield return new WaitForSeconds(0.1f);
			Swap(min_idx, i);
		}
		Debug.Log(t);
	}
	#endregion
	#region insertion sort
	IEnumerator InsertionSort()
	{
		int n = LineMaker.NumberOfLines, j;
		float key;
		for (int i = 0; i < n; i++)
		{
			key = parentLines.transform.GetChild(i).localScale.y;
			for (j = i - 1; j >= 0 && parentLines.transform.GetChild(j).localScale.y > key;)
			{
				ApplyHighlightColor(j);
				parentLines.transform.GetChild(j + 1).localScale = parentLines.transform.GetChild(j).localScale;
				j--;
				yield return null;
				ApplyNormalColor(j + 1);
			}
			forSwapTransform = parentLines.transform.GetChild(j + 1).localScale;
			forSwapTransform.y = key;
			parentLines.transform.GetChild(j + 1).localScale = forSwapTransform;
		}
		Debug.Log(t);
	}
	#endregion
	#region quick sort
	IEnumerator QuickSort()
	{
        int n = LineMaker.NumberOfLines;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
				ApplyHighlightColor(j + 1);
                if (CompareYScale(j, j + 1) == CompareResult.greater)
                {
					Swap(j, j + 1);
                }
                yield return new WaitForSeconds(0.0f);
				ApplyNormalColor(j + 1);
            }
        }
        Debug.Log(t);
    }
	#endregion
}
