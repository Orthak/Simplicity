using UnityEngine;
using System.Collections;

public class PlayerMouseShoot : MonoBehaviour
{
    #region Public Properties
    public GameObject toShoot;
    public float shootDelay;
    public float shootVelocity;
    public float positionOffset;
    #endregion

    #region Private Properties
    private Transform thisTransform;
    private Vector3 mousePosition;
    #endregion

    #region Unity Methods
    void Start()
    {
        thisTransform = gameObject.transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ReturnInstance();
    }
    #endregion

    void ReturnInstance()
    {
        audio.Play();

        mousePosition = Input.mousePosition;
        mousePosition.z = thisTransform.position.z - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Quaternion quaternionRotation = 
            Quaternion.FromToRotation(Vector3.up, mousePosition - thisTransform.position);
        GameObject bulletInstance = 
            Instantiate(toShoot,
            thisTransform.position,
            quaternionRotation) as GameObject;
        bulletInstance.rigidbody.AddForce(bulletInstance.transform.up * shootVelocity);

        Physics.IgnoreCollision(bulletInstance.collider, gameObject.collider);
    }
}
