using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    // functions as the players healthbar

    // 0-5 health, 0, 1, 2, 3, 4, 5 ,6
    // controls 6 sprite images that change when the player gains/loses health

    public Sprite[] Heartsprites;

    public Image HeartUI;

    private Player player;

    void Start ()
    {
        // finds player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        



    }
    void Update()
    {
        // checks players health and updates the sprite based on that
        HeartUI.sprite = Heartsprites[Player.curHealth];
    }
}
