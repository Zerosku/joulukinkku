using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private static GameObject enemy;

	public static Rigidbody2D pahiskeho;

    public  static bool facingright = false;

    public static Animator vihu;

    public static int enemyHealth;

    public static Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        vihu = GetComponent<Animator>();
		enemy = GameObject.Find ("EnemyBox");
		pahiskeho = GetComponent<Rigidbody2D>();
        enemyHealth = 5;
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
}
    
