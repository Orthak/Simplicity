using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GibOnDeath : MonoBehaviour
{
    public GameObject gibToSpawn;
    public int numberToSpawn;
    public float spawnRadius;
    public float explosionForce;

    public void ExplodeIntoGibs()
    {
        for (int i = 1; i < numberToSpawn; i++)
        {
            GameObject gibInstance = Instantiate(gibToSpawn,
                    transform.position + Random.insideUnitSphere * spawnRadius,
                    transform.rotation) 
                    as GameObject;
            gibInstance.rigidbody.AddExplosionForce(explosionForce, transform.position, spawnRadius);
        }
    }
}
