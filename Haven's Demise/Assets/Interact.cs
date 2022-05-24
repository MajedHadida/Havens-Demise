using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interacted with the door!");
        }
    }
}
