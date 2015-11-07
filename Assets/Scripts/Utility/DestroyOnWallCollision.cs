using UnityEngine;
using System.Collections;

public class DestroyOnWallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
