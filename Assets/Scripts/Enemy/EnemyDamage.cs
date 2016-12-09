using UnityEngine;
using System.Collections;


public class EnemyDamage : MonoBehaviour {

	// this is the script for enemy taking damage from player and giving damage to player

    public AudioClip soundDamage;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    private int frames = 0;

    
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = soundDamage;
        source.playOnAwake = false;

    }
    void Update()
    {
        frames ++;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        // when enemy hits the pigs trigger area
        if (col.CompareTag("Hitbox"))
        {
            Enemy.vihu.SetTrigger("damagetrigger");
            

            // flips the enemy to face the player
            if (!Enemy.player.facingright)
            {
                Enemy.pahiskeho.AddForce(new Vector2(-200, 0));
            }
            else
            {
                Enemy.pahiskeho.AddForce(new Vector2(200, 0));
            }
        }
        if (col.CompareTag("PlayerHitbox") && frames % 30 == 0)
        {
            Player.curHealth--;
            AudioSource.PlayClipAtPoint(soundDamage, transform.position);

        }
    }

}
