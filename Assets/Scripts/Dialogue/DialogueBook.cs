using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueBook : MonoBehaviour
{
    // this script is for the dialogue of some normal piggies who want 5 coins :)

    //dialogue text
    private TextMesh dialog;

    // thisis to access player- script static things
    static Player player = new Player();

    // actionkey is the key you press when near pig
    private bool actionkey = false;
    //touch is used for checking if you are in the trigger area
    private bool touch;

    // actionbutton is the mobile version equivalent of "x"-key
    private ButtonController ActionButton;

    // gamemaster controls the points/coins
    public GameMaster gm;

    private SimpleInventory inv;

    void Awake()
    {
        ActionButton = GameObject.Find("ActionButton").GetComponent<ButtonController>();
    }

    // Use this for initialization
    void Start()
    {
        dialog = GetComponent<TextMesh>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        inv = GameObject.Find("Player").GetComponent<SimpleInventory>();

    }

    // for when player enters the trigger area
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touch = true;
            dialog.text = "I've lost my favorite book!";
        }
    }

    //empty text & touch=false for when player is not in trigger area
    void OnTriggerExit2D(Collider2D other)
    {
        touch = false;
        dialog.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        // here we check if player collides with trigger and we proceed the message
        if (touch == true)
        {
            if (Input.GetKeyDown("x") || ActionButton.pressed)
            {
                if (inv.Book.activeSelf)
                {
                    dialog.text = "Reading time!!";
                    Destroy(this);
                    gm.points++;
                    gm.karma++;
                    Debug.Log(gm.karma);
                    inv.Book.SetActive(false);
                }
                else if (!inv.Book.activeSelf)
                {
                    dialog.text = "I hope someone finds it..";
                }
            }
            else
            {
                actionkey = false;
            }
        }

    }

}
