using UnityEngine;
using System.Collections;

public class EnemyMerged : MonoBehaviour {
    
    
    // enemydamage
    public AudioClip soundDamage;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    private int frames = 0;

    // enemy
    private GameObject enemy;

    private Rigidbody2D pahiskeho;

    private bool facingright = false;

    private Animator vihu;

    private int enemyHealth;

    public static Player player;

    private bool enemyhasdied;

    private EnemyTrigger trigger;

    int dist = 3;

    // enemytrigger
    private static GameObject EnemyCollider;

    private bool touching = false;

    // enemy
    private static Transform enemyTrans;

    private static Vector2 enemyVector;

    private float enemyX;

    private float enemyY;


    //player
    private GameObject pelaaja;

    private Vector2 pelaajaVector;

    private float pelaajaX;

    private float pelaajaY;

    //player - enemy
    private float goX;

    private float goY;

    // vihollisen nopeus
    private float enemySpeed = 0.5f;

 
    void Start () {
        // enemydamage
        gameObject.AddComponent<AudioSource>();
        source.clip = soundDamage;
        source.playOnAwake = false;

        // enemy
        player = FindObjectOfType<Player>();
        vihu = GetComponent<Animator>();
        enemy = GameObject.Find("EnemyBox");
        pahiskeho = GetComponent<Rigidbody2D>();
        enemyHealth = 15;
        enemyhasdied = false;

        // enemytrigger
        // enemy = GameObject.Find("Butcher");
        enemy = this.gameObject;
        pelaaja = GameObject.Find("Player");


    }
	
	// Update is called once per frame
	void Update () {
        // enemydamage
        frames++;
        if (frames % 80 == 0)
        {
            vihu.SetTrigger("normal");
        }
        // enemy
        transform.rotation = Quaternion.identity;
        if (pahiskeho.velocity.x > 0)
        {
            RotateEnemy(1);
        }
        else
        {
            RotateEnemy(-1);
        }
        //EnemyTrigger.EnemyAggro ();
        enemydeath();
        // Pelaajan ja pahiksen välinen etäisyys
        Vector2 aa = (player.transform.position - transform.position);

        // Pelaajan ja pahiksen välinen etäisyys muutetaan yksikkövektoriksi
        Vector2 bb = aa.normalized;


        // Jos pelaajan etäisyys pahiksesta on distance verran laita pahis liikkumaan pelaajaa päin
        if (aa.magnitude < dist)
        {
            // antaa pahikselle oikean nopeuden
            pahiskeho.velocity = new Vector2(bb.x * enemySpeed, bb.y * enemySpeed);
        }
        else
        {
            // pysäittää pahiksen kun pelaaja on tarpeeksi kaukana
            pahiskeho.velocity = new Vector2(0, 0);
        }

        
    }

    // enemydamage
        private void OnTriggerStay2D(Collider2D col)
        {
            //kun enemy osuu possun potkaisualueelle
            if (col.CompareTag("Hitbox"))
            {
                vihu.SetTrigger("damagetrigger");
                enemyHealth--;
            

            //kääntää enemyn animaation pelaajan suuntaan
            if (!player.facingright)
                {
                    pahiskeho.AddForce(new Vector2(-210, 0));
                }
                else
                {
                    pahiskeho.AddForce(new Vector2(210, 0));
                }
            
            }
            if (col.CompareTag("PlayerHitbox") && frames % 30 == 0)
            {
                Player.curHealth--;
                AudioSource.PlayClipAtPoint(soundDamage, transform.position);

            }
            if (col.gameObject.tag == "Player")
            {
                touching = true;
        }
    }
    // enemy
    void FixedUpdate()
    {
        EnemyAggro();
    }


    private void enemydeath()
    {
        if (enemyHealth <= 0)
        {
            enemyhasdied = true;
            Destroy(gameObject);
                
        }
    }
    public void RotateEnemy(float abs)
    {
        if (abs > 0 && facingright || abs < 0 && !facingright)
        {
            facingright = !facingright;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
   
    // enemytrigger
    // enemysettii
    private void EnemyWalk()
    {
        //transform.LookAt (lookAtPlayer);
        pahiskeho.velocity = new Vector2(goX, goY);
    }

    private void EnemyAggro()
    {

        if (touching)
        {
            // Debug.Log ("enemy triggered");
            EnemyWalk();
        }
        else
        {
            //pahiskeho.velocity = new Vector2(0, 0);
        }
    }


    // hieman turha, yläolevan vastakohta
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            touching = false;
        }
    }
}
