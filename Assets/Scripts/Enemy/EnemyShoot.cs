using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public float fireDelay;
    public float accuracy;
    public float bulletForce;
    public GameObject bullet;

    void Start()
    {
        InvokeRepeating("Shoot", fireDelay, fireDelay);
    }

    void Shoot()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 shootDirection 
                = (player.transform.position - transform.position).normalized;
            Vector3 modifiedDirection 
                = (shootDirection  
                + (Vector3)(Random.insideUnitCircle * (1f - accuracy)))
                .normalized;
            GameObject bulletInstance 
                = Instantiate(bullet, 
                transform.position + modifiedDirection, 
                Quaternion.identity) as GameObject;
            bulletInstance.rigidbody.AddForce(modifiedDirection * bulletForce);

            Physics.IgnoreCollision(bulletInstance.collider, gameObject.collider);
        }
    }
}
