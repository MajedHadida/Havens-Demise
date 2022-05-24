using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public GameObject weaponPrefab; // references the weapon prefab
    public GameObject character;
    public GameObject enemy;
    public GameObject breakableObj;
    public AnimationClip swingAction;

    public int attackDamage = 1;
    int cooldown = 0;
    float lastHitTime = 0;
    public bool isDead = false;




    // Update is called once per frame
    void Update()
    {
        isDead = character.GetComponent<PlayerMovement>().getDeathState();
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetButtonDown("Fire1") && cooldown == 0 && !isDead)
        {
            lastHitTime = Time.time;
            weaponPrefab.GetComponent<Renderer>().enabled = true;
            weaponPrefab.GetComponent<BoxCollider2D>().enabled = true;
            //Cooldown of attack
            cooldown = 500;
        }
        if (Time.time - lastHitTime >= swingAction.length)
        {
            weaponPrefab.GetComponent<Renderer>().enabled = false;
            weaponPrefab.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (cooldown != 0)
        {
            cooldown--;
        }
    }

    public void damageEnemy(int damage)
    {
        enemy.GetComponent<EnemyStats>().TakeDamage(damage);
    }

    public void damageBox(int damage)
    {
        breakableObj.GetComponent<BoxBehaviour>().TakeDamage(damage);
    }






}
