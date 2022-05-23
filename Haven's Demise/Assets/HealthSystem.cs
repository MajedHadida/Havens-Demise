using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject character;
    public int health = 4;

    public void reduceHealth(int damage)
    {
        health -= damage;
        Debug.Log("Current health: "+health);
        if (health <= 0)
        {
            die();
        }
    }

    //Heal health Function needed

    public void die()
    {
        Debug.Log("You died!");
        character.GetComponent<PlayerMovement>().die();
    }
}

