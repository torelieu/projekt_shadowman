using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHrace : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Get input from the WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Update the player's position based on the input and speed
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
