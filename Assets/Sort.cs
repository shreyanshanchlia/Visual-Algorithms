using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public Color normal, highlight, sorted, reference;
	private Vector3 forSwapTransform;
	public void sort()
	{
		t = 0.0f;
		string algo = PlayerPrefs.GetString("Algorithm");
		algo = algo.Remove(algo.IndexOf('-'),1);
		print(algo);
		StartCoroutine(algo);
	}
	private void Update()
	{
		t += Time.deltaTime;
	}
	#region bubble sort
	IEnumerator BubbleSort()
	{
		int n = parentLines.transform.childCount;
		for (int i = 0; i < n - 1; i++)
		{
			for (int j = 0; j < n - i - 1; j++)
			{
				parentLines.transform.GetChild(j + 1).GetComponent<SpriteRenderer>().color = highlight;
				if (parentLines.transform.GetChild(j).localScale.y > parentLines.transform.GetChild(j + 1).localScale.y)
				{
					forSwapTransform = parentLines.transform.GetChild(j).localScale;
					parentLines.transform.GetChild(j).localScale = parentLines.transform.GetChild(j+1).localScale;
					parentLines.transform.GetChild(j + 1).localScale = forSwapTransform;
				}
				yield return new WaitForSeconds(0.0f);
				parentLines.transform.GetChild(j + 1).GetComponent<SpriteRenderer>().color = normal;
			}
		}
		Debug.Log(t);
	}
	#endregion
	#region selection sort
	IEnumerator SelectionSort()
	{
		int n = parentLines.transform.childCount;
		int min_idx;
		for (int i = 0; i < n - 1; i++)
		{
			min_idx = i;
			for (int j = i + 1; j < n; j++)
			{
				parentLines.transform.GetChild(j).GetComponent<SpriteRenderer>().color = highlight;
				if (parentLines.transform.GetChild(j).localScale.y < parentLines.transform.GetChild(min_idx).localScale.y)
				{
					min_idx = j;
				}
				yield return null;
				parentLines.transform.GetChild(j).GetComponent<SpriteRenderer>().color = normal;
			}
			forSwapTransform = parentLines.transform.GetChild(min_idx).localScale;
			/*color*/
			parentLines.transform.GetChild(min_idx).GetComponent<SpriteRenderer>().color = highlight;
			parentLines.transform.GetChild(min_idx).localScale = parentLines.transform.GetChild(i).localScale;
			parentLines.transform.GetChild(i).localScale = forSwapTransform;
			parentLines.transform.GetChild(min_idx).GetComponent<SpriteRenderer>().color = normal;
		}
		Debug.Log(t);
	}
	#endregion
}
