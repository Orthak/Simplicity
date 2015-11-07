using UnityEngine;
using System.Collections;

/// <summary>
/// This script is used to have the camera follow the position of the player. 
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 offset;

    private void Update()
    {
        if(!targetObject.Equals(null))
            gameObject.transform.position = targetObject.transform.position + offset;
    }
}
