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
        StartCoroutine(Knockback(100, 1, player.transform));
        Debug.Log("Hello");

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

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (this.transform.position - obj.transform.position).normalized;
            rb.AddForce(direction * knockbackPower);
        }
        yield return 0;
    }
}
