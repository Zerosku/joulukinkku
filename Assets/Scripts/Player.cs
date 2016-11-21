using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : GameController {

	public static GameObject player;
    private Rigidbody2D possukeho;
    private GameMaster gm;
    private Animator possu;
    private bool facingright = true;
    private bool dead = false;
	// pelaajan nopeus
	public float playerSpeed = 0.03f;

    // terveys
    public int curHealth;
    public int maxHealth = 5;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        possu = GetComponent<Animator>();
        possukeho = GetComponent<Rigidbody2D>();
        player.transform.SetAsLastSibling();
        curHealth = maxHealth;

	}

	// Update is called once per frame
	void Update () {
		Movement (playerSpeed);
        transform.rotation = Quaternion.identity;
        
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            if(!dead){
                dead = true;
                possukeho.gravityScale=-15;
                StartCoroutine(Die());
            }
        }
	}

	// player movements
	public void Movement (float playerSpeed){

		if (Input.GetKey("up")) {
            //Debug.Log ("Move up");
            //player.transform.Translate (0, playerSpeed, 0);
            possukeho.velocity = new Vector2(0, 1);
            possu.SetBool("walking", true);
            

        }
        else if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow))){ 
                //Debug.Log ("Move up/left");
                //player.transform.Translate (-playerSpeed, playerSpeed, 0);
                possukeho.velocity = new Vector2(-1, 1);
                possu.SetBool("walking", true);
            Debug.Log("morjenttes vaan");

            
        }
        else if (Input.GetKey("down")) {
            //Debug.Log ("Move down");
            //player.transform.Translate (0, -playerSpeed, 0);
            possukeho.velocity = new Vector2(0, -1);
            possu.SetBool("walking", true);


        }
        else if (Input.GetKey("left")) {
            //Debug.Log ("Move left");
            //player.transform.Translate (-playerSpeed, 0, 0);
            possukeho.velocity = new Vector2(-1, 0);
            RotatePig(-1);
            possu.SetBool("walking", true);


        }
        else if (Input.GetKey("right")) {
            //Debug.Log ("Move right");
            //player.transform.Translate (playerSpeed, 0, 0);
            possukeho.velocity = new Vector2(1, 0);
            RotatePig(1);
            possu.SetBool("walking", true);


        }
        else
        {
            possukeho.velocity = new Vector2(0, 0);
            possu.SetBool("walking", false);

        }
    }
    void RotatePig(int abs)
    {
        
        if (abs>0 && !facingright || abs<0 && facingright)
        {
            facingright = !facingright;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    

    }
        // kolikkosettii
        void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
        }
    }

    IEnumerator Die ()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
        yield return new WaitForSeconds(1);
        possukeho.gravityScale = 15;
        //restart
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
