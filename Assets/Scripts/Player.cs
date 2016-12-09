using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //pigs parts
	public static GameObject player;
    private Rigidbody2D possukeho;

    //pigs animation
    private Animator possu;
    public bool facingright = true;

    public GameObject DeadUI;

    // players movement
    public float playerSpeedJoy = 0.1f;
    public float playerSpeedBut = 0.1f;
    public Joystick movePig;

    // points and karma are fetched from gamemaster
    public GameMaster gm;

    // sounds

    public AudioClip soundDeath;
    private AudioSource sourceDeath { get { return GetComponent<AudioSource>(); } }

    public AudioClip soundCoin;
    private AudioSource sourceCoin { get { return GetComponent<AudioSource>(); } }

    // health
    public static int curHealth;
    public int maxHealth = 5;
    public bool kuolema = false;
    public GameObject Paussi;


	/* old movement ignore
    private ButtonController upButton;
    private ButtonController downButton;
    private ButtonController leftButton;
    private ButtonController rightButton;
    private ButtonController upRight;
    private ButtonController upLeft;
    private ButtonController downLeft;
    private ButtonController downRight;
    */


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

        //old movement
        /* upButton = GameObject.Find("ButtonUp").GetComponent<ButtonController>();
         downButton = GameObject.Find("ButtonDown").GetComponent<ButtonController>();
         leftButton = GameObject.Find("ButtonLeft").GetComponent<ButtonController>();
         rightButton = GameObject.Find("ButtonRight").GetComponent<ButtonController>();
         upRight = GameObject.Find("UpRight").GetComponent<ButtonController>();
         upLeft = GameObject.Find("UpLeft").GetComponent<ButtonController>();
         downLeft = GameObject.Find("DownLeft").GetComponent<ButtonController>();
         downRight = GameObject.Find("DownRight").GetComponent<ButtonController>();
         */

        //sounds
            //coins
        gameObject.AddComponent<AudioSource>();
        sourceCoin.clip = soundCoin;
        sourceCoin.playOnAwake = false;
            //enemies
        gameObject.AddComponent<AudioSource>();
        sourceDeath.clip = soundDeath;
        sourceDeath.playOnAwake = false;

    }
    
	// Update is called once per frame
	void Update () {

        //makes sounds
        Soundmaster();

        //checks karma
        goodbadkarma();

        //movement
        MovementJoy(playerSpeedJoy);
        MovementBut(playerSpeedBut);
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
	public void MovementJoy (float playerSpeedJoy){

        possukeho.velocity = movePig.InputDirection;

        
        if (Input.GetKey("up")||movePig.InputDirection.y > 0) {
            //Debug.Log ("Move up");
            //player.transform.Translate (0, playerSpeed, 0);
            //possukeho.velocity = new Vector2(0, 1);
            possu.SetBool("walking", true);
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
    public void MovementBut (float playerSpeedBut)
    {
        if (Input.GetKey("up"))
        {
            //Debug.Log ("Move up");
            //player.transform.Translate (0, playerSpeed, 0);
            possukeho.velocity = new Vector2(0, 1);
            possu.SetBool("walking", true);
        }

        else if (Input.GetKey("down"))
        {
            //Debug.Log ("Move down");
            //player.transform.Translate (0, -playerSpeed, 0);
            possukeho.velocity = new Vector2(0, -1);
            possu.SetBool("walking", true);


        }
        else if (Input.GetKey("left"))
        {
            //Debug.Log ("Move left");
            //player.transform.Translate (-playerSpeed, 0, 0);
            possukeho.velocity = new Vector2(-1, 0);
            RotatePig(-1);
            possu.SetBool("walking", true);


        }
        else if (Input.GetKey("right"))
        {
            //Debug.Log ("Move right");
            //player.transform.Translate (playerSpeed, 0, 0);
            possukeho.velocity = new Vector2(1, 0);
            RotatePig(1);
            possu.SetBool("walking", true);
        }

        else
        {
           //possu.SetBool("walking", false);

        }
    }
    //pig animation rotate
    void RotatePig(int abs)
    {
        
        if (abs>0 && !facingright || abs<0 && facingright)
        {
            facingright = !facingright;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    

    }
        // player collidings with things or enemies
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

    // sounds
    void Soundmaster()
    {
        if (Enemy.enemyhasdied == true)
        {
            sourceCoin.PlayOneShot(soundDeath);
        }

    }
    // death
    void Die ()
    {
        kuolema = !kuolema;
        //stops the game time when dead
        Paussi.GetComponent<PauseMenu>().enabled = false;

        DeadUI.SetActive(true);
        Time.timeScale = 0;




    }
		

    // karma meter
    void goodbadkarma()
    {
        if (gm.karma >= 2)
        {
            possu.SetBool("good", true);
        }
        if (gm.karma <= -2)
        {
            possu.SetBool("bad", true);
        }
    }
	

}
