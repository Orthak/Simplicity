using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour 
{
	private void Start()
	{
		Destroy(this.gameObject, 5f);
	}
}
