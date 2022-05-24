using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    public int health = 2;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //play hurt animation/sound

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Box broken");
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.blue;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
