using UnityEngine;
using System.Collections;

public class FollowMousePosition : MonoBehaviour
{
    public float offsetAmout;

    private Vector3 mousePosition;
    private Vector3 offsetVector;

    private void Update()
    {
        offsetVector = new Vector3(0f, 0f, offsetAmout);
        mousePosition = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition + offsetVector);
    }
}
