using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject character;
        // function that is called on collision
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.name)
        {
            case "Enemy":
                character.GetComponent<Attack>().damageEnemy(1);
                break;
            case "Box":
                character.GetComponent<Attack>().damageBox(1);
                break;
        }

    }

}
