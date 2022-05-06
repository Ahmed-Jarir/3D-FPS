using System;
using UnityEngine;

public class PositionWorkAround : MonoBehaviour
{
    public Transform parentObjectTransform;
    public GameObject objectToResetPosition;

    private void Update()
    {
        if (objectToResetPosition.transform.position != parentObjectTransform.position)
        {
            objectToResetPosition.transform.position = parentObjectTransform.position;
        }
    }
}