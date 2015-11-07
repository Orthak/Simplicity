using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float minTimeBeforeChange;
    public float maxTimeBeforeChange;
    public float shipSpeed;

    private Vector3 moveDirection;
    
    private void Start()
    {
        ChangeDirection();
    }

    private void Update()
    {
        transform.position += moveDirection * shipSpeed * Time.deltaTime;
    }

    private void ChangeDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;
        Invoke("ChangeDirection", Random.Range(minTimeBeforeChange, maxTimeBeforeChange));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            moveDirection = -moveDirection;
    }
}
