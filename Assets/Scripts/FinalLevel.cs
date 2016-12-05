using UnityEngine;
using System.Collections;

public class FinalLevel : MonoBehaviour {

void OnTriggerEnter2D(Collider2D col)
{
    if (Enemy.enemyhasdied)
    {
            Debug.Log("Enemy ottaa hittii");
    }
}
}
