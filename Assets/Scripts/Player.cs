using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //possun osia
	public static GameObject player;
    private Rigidbody2D possukeho;

    //possun animaatio
    private Animator possu;
    public bool facingright = true;

    public GameObject DeadUI;

    // pelaajan nopeus
    public float playerSpeed = 0.03f;

    // pisteet ja karma
    public GameMaster gm;
    public AudioClip soundCoin;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public int karma = 0;

    // terveys
    public static int curHealth;
    public int maxHealth = 5;
    public bool kuolema = false;
    public GameObject Paussi;
   

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        possu = GetComponent<Animator>();
        possukeho = GetComponent<Rigidbody2D>();
        player.transform.SetAsLastSibling();
        curHealth = maxHealth;
        DeadUI.SetActive(false);


        //kolikko äänet
        gameObject.AddComponent<AudioSource>();
        source.clip = soundCoin;
        source.playOnAwake = false;

    }

	// Update is called once per frame
	void Update () {
        

        goodbadkarma();

        Movement (playerSpeed);
        transform.rotation = Quaternion.identity;
        
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        

        if (curHealth <= 0)
        {
            Die();
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
    //possun animaation kääntö
    void RotatePig(int abs)
    {
        
        if (abs>0 && !facingright || abs<0 && facingright)
        {
            facingright = !facingright;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    

    }
        // pelaaja ja osumat vihollisiin tai esineisiin
        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        { 
            Destroy(col.gameObject);
            source.PlayOneShot(soundCoin);
            gm.points += 1;
        }
        if (col.CompareTag("Health") && curHealth != maxHealth)
        {
            Destroy(col.gameObject);

            curHealth++;
        }


    }
    // kuolema
    void Die ()
    {
        kuolema = !kuolema;
        //pysäyttää peliajan kun kuolema on 
        Paussi.GetComponent<PauseMenu>().enabled = false;

        DeadUI.SetActive(true);
        Time.timeScale = 0;




    }
    // karma mittari
    void goodbadkarma()
    {
        if (karma > 5)
        {
            possu.SetBool("good", true);
        }
        if (karma < -5)
        {
            possu.SetBool("bad", true);
        }
    }

    // terveyden menetys

}
