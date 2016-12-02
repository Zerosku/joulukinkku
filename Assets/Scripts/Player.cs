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

    // pelaajan liikkuminen
    public float playerSpeed = 0.1f;
    public Joystick movePig;

    // pisteet ja karma
    public GameMaster gm;
    public int karma = 0;

    // äänet

    public AudioClip soundDeath;
    private AudioSource sourceDeath { get { return GetComponent<AudioSource>(); } }

    public AudioClip soundCoin;
    private AudioSource sourceCoin { get { return GetComponent<AudioSource>(); } }

    // terveys
    public static int curHealth;
    public int maxHealth = 5;
    public bool kuolema = false;
    public GameObject Paussi;

    private ButtonController upButton;
    private ButtonController downButton;
    private ButtonController leftButton;
    private ButtonController rightButton;
    private ButtonController upRight;
    private ButtonController upLeft;
    private ButtonController downLeft;
    private ButtonController downRight;


    // Use this for initialization
    void Start () {
		player = GameObject.Find ("Player");
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        possu = GetComponent<Animator>();
        possukeho = GetComponent<Rigidbody2D>();
        player.transform.SetAsLastSibling();
        curHealth = maxHealth;
        DeadUI.SetActive(false);


        movePig = FindObjectOfType<Joystick>();

        //vanha liikkuminen
        /* upButton = GameObject.Find("ButtonUp").GetComponent<ButtonController>();
         downButton = GameObject.Find("ButtonDown").GetComponent<ButtonController>();
         leftButton = GameObject.Find("ButtonLeft").GetComponent<ButtonController>();
         rightButton = GameObject.Find("ButtonRight").GetComponent<ButtonController>();
         upRight = GameObject.Find("UpRight").GetComponent<ButtonController>();
         upLeft = GameObject.Find("UpLeft").GetComponent<ButtonController>();
         downLeft = GameObject.Find("DownLeft").GetComponent<ButtonController>();
         downRight = GameObject.Find("DownRight").GetComponent<ButtonController>();
         */

        //äänet
            //kolikko
        gameObject.AddComponent<AudioSource>();
        sourceCoin.clip = soundCoin;
        sourceCoin.playOnAwake = false;
            //vihollinen
        gameObject.AddComponent<AudioSource>();
        sourceDeath.clip = soundDeath;
        sourceDeath.playOnAwake = false;

    }
    
	// Update is called once per frame
	void Update () {

        //tekee ääniä
        Soundmaster();

        //karma tarkistus
        goodbadkarma();

        //liikkuminen
        Movement(playerSpeed);
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

        possukeho.velocity = movePig.InputDirection;

        
        if (Input.GetKey("up")||movePig.InputDirection.y > 0) {
            //Debug.Log ("Move up");
            //player.transform.Translate (0, playerSpeed, 0);
            //possukeho.velocity = new Vector2(0, 1);
            possu.SetBool("walking", true);

            Debug.Log(movePig);
        }
        
        else if (Input.GetKey("down")|| movePig.InputDirection.y < 0) {
            //Debug.Log ("Move down");
            //player.transform.Translate (0, -playerSpeed, 0);
            //possukeho.velocity = new Vector2(0, -1);
            possu.SetBool("walking", true);


        }
        if (Input.GetKey("left") || movePig.InputDirection.x < 0)
        {
            //Debug.Log ("Move left");
            //player.transform.Translate (-playerSpeed, 0, 0);
            //possukeho.velocity = new Vector2(-1, 0);
            RotatePig(-1);
            possu.SetBool("walking", true);


        }
        else if (Input.GetKey("right") || movePig.InputDirection.x > 0)
        {
            //Debug.Log ("Move right");
            //player.transform.Translate (playerSpeed, 0, 0);
            //possukeho.velocity = new Vector2(1, 0);
            RotatePig(1);
            possu.SetBool("walking", true);
        }

        else
        {
            //possukeho.velocity = new Vector2(0, 0);
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
            gm.points++;
            Destroy(col.gameObject);
            sourceCoin.PlayOneShot(soundCoin);
            
        }
        if (col.CompareTag("Health") && curHealth != maxHealth)
        {
            Destroy(col.gameObject);

            curHealth++;
        }

    }

    // Äänet
    void Soundmaster()
    {
        if (Enemy.enemyhasdied == true)
        {
            sourceCoin.PlayOneShot(soundDeath);
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
	

}
