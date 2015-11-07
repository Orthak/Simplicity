using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class GUIFollowObject : MonoBehaviour
{
    public Transform targetTransform;

    private void LateUpdate()
    {
        Vector3 wantedPosition = Camera.main.WorldToViewportPoint(targetTransform.position);
        transform.position = wantedPosition;
    }
}
