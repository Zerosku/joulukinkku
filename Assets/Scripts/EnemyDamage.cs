using UnityEngine;
using System.Collections;


public class EnemyDamage : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        //kun enemy osuu possun potkaisualueelle
        if (col.CompareTag("Hitbox"))
        {
            Enemy.vihu.SetTrigger("damagetrigger");


            //kääntää enemyn animaation pelaajan suuntaan
            if (!Enemy.player.facingright)
            {
                Enemy.pahiskeho.AddForce(new Vector2(-200, 0));
            }
            else
            {
                Enemy.pahiskeho.AddForce(new Vector2(200, 0));
            }
        }
        if (col.CompareTag("PlayerHitbox"))
        {
            Player.curHealth--;
        }
    }

}
