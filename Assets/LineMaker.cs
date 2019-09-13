using UnityEngine;

public class LineMaker : MonoBehaviour
{
	public GameObject linePrefab;
	public GameObject parentLines;
	private GameObject instantiatedLine;
	private Vector3 childTransform;
	private Vector3 childScale;
	private int height;
	private float thickness;

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
		for (int i = 0; i < noOfLines; i++)
		{
			height = Random.Range(5, 50);
			instantiatedLine = Instantiate(linePrefab, parentLines.transform);
			childTransform.x = thickness * ((noOfLines / 2) - i);
			instantiatedLine.transform.localPosition = childTransform;
			childScale.x = 1000;
			childScale.y = height*250;
			instantiatedLine.transform.localScale = childScale;
		}
	}
}
