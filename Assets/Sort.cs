using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
	public static Sort instance;
	private void Start()
	{
		instance = this;
	}
	public GameObject parentLines;
	public Color normal, highlight, sorted, reference;
	private Vector3 forSwapTransform;
    public void BubbleSort()
	{
		StartCoroutine(BubbleSortCoroutine());
	}
	IEnumerator BubbleSortCoroutine()
	{
		int n = parentLines.transform.childCount;
		for (int i = 0; i < n - 1; i++)
		{
			for (int j = 0; j < n - i - 1; j++)
			{
				if (parentLines.transform.GetChild(j).localScale.y > parentLines.transform.GetChild(j + 1).localScale.y)
				{
					forSwapTransform = parentLines.transform.GetChild(j).localScale;
					parentLines.transform.GetChild(j).GetComponent<SpriteRenderer>().color = highlight;
					parentLines.transform.GetChild(j).localScale = parentLines.transform.GetChild(j+1).localScale;
					parentLines.transform.GetChild(j + 1).localScale = forSwapTransform;
					yield return null;
					parentLines.transform.GetChild(j).GetComponent<SpriteRenderer>().color = normal;
				}
			}
			parentLines.transform.GetChild(i).GetComponent<SpriteRenderer>().color = normal; ;
		}
	}
}
