﻿using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {


    //this code has no meaning in the game but we are too scared to delete it

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("EnemyHitbox"))
        {
            // col.SendMessageUpwards("Damage", dmg);
            Debug.Log("Enemy ottaa hittii");
        }
    }
}
