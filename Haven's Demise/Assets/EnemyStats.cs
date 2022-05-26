using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyStats : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public int health = 4;
    private AIDestinationSetter movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<AIDestinationSetter>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        rb.isKinematic = false;
        Vector2 difference = transform.position - player.transform.position;
        difference = difference.normalized * 5;
        rb.AddForce(difference, ForceMode2D.Impulse);
        rb.isKinematic = true;

        //play hurt animation/sound

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //play die animation/sound

        //disable enemy
        //Disables the boxcollider
        GetComponent<Collider2D>().enabled = false;
        //Disables the pathfinding movement
        movement.enabled = false;
        //Disables "EnemyStats" script
        this.enabled = false;
    }
}
