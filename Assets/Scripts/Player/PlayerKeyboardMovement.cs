using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;

public class PlayerKeyboardMovement : MonoBehaviour
{
    public float speed;
    public LevelBoundary boundary;

    void Update()
    {
        // We need to store the inputs to use them.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Crate a movement vector from the inputs.
        Vector3 movement = 
            new Vector2(moveHorizontal * Time.deltaTime,
                moveVertical * Time.deltaTime);
        rigidbody.velocity = movement * speed;
        boundary.KeepInBoundary(gameObject);
    }
}
