using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToOne : MonoBehaviour
{
    public Transform parentTransform;
    public Transform fixTransform;
    [SerializeField] float referenceScale = 1000.0f;
    private void Start()
    {
        Vector3 scale = fixTransform.localScale;
        scale.x *= referenceScale / parentTransform.localScale.x;
        scale.y *= referenceScale / parentTransform.localScale.y;
        scale.z = referenceScale;
        fixTransform.localScale = scale;
    }
}
