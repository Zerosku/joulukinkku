using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

// this script is for the enemy, it contains all essential stats like health and animator-things

	private static GameObject enemy;

	public static Rigidbody2D pahiskeho;

    private bool facingright = false;

    public static Animator vihu;

    private int enemyHealth;

    public static Player player;

    public static bool enemyhasdied;

    private EnemyTrigger trigger;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
        vihu = GetComponent<Animator>();
		enemy = GameObject.Find ("EnemyBox");
		pahiskeho = GetComponent<Rigidbody2D>();
        enemyHealth = 100;
        enemyhasdied = false;
    }
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
        RotateEnemy(EnemyTrigger.goX);
        //EnemyTrigger.EnemyAggro ();
        enemydeath();
	}

	void FixedUpdate(){
		EnemyTrigger.EnemyAggro ();
	}


    void enemydeath()
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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hitbox"))
        {
            enemyHealth--;
        }
    }
}
    
