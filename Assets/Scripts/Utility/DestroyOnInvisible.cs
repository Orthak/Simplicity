using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
