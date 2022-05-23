using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    string enemy = "Enemy";
    private bool isDead = false;
    public float moveSpeed = 5f;
    public Rigidbody2D rb; // Makes a rigidbody2D so we can link it to this file
    Vector2 movement; // Vector2 stores both x and y
    Vector2 mousePos; // position of mouse
    public Camera cam; //we need to reference the camera so we can find mouse location
    public Rigidbody2D bat;
    public HealthSystem healthScript;



    // Called on a fixed timer, more reliable when using physics as Update function may fluctuate but this won't
    void Update()
    {
        if (!isDead)
        {
            // Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


            //Movement
            // Moves character by adding current position with the movement inputed (times by speed)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            Vector2 lookDir = mousePos - rb.position; // subtract two vectors to find the direction that the player must look at
            float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f; // Atan2 is a math function that returns the angle between the x-axis and the 2d vectors, then converted to degrees
            rb.rotation = angle;

            bat.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            bat.rotation = angle;
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Checking with whoever we collided with to be an enemy
        if (col.gameObject.name == enemy)
        {
            healthScript.reduceHealth(1);
        }
    }

    public void die()
    {
        isDead = true;
    }

    public bool getDeathState()
    {
        return isDead;
    }




}
