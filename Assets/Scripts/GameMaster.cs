using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    //
	// gamemaster controls points (coins) and karma, if you need to use them get them from here
    //

    public int points;

	public int karma;

    public Text pointsText;
    public Text karmaText;

    public string karmalevel;

    void Start ()
    {
        // gets the points from the previous scene
        points = PlayerPrefs.GetInt("Player Score");
        karma = PlayerPrefs.GetInt("Player Karma");

        // finds the texts in the HUD
        pointsText = GameObject.Find("CoinsText").GetComponent<Text>();
        karmaText = GameObject.Find("KarmaText").GetComponent<Text>();
        
        
        
    }
    void Update()
    {
        // updates score and karma

        pointsText.text = (": " + points);
        karmaText.text = ("Karma: " + karmalevel);

        // sets the karma level
        if (karma >= 2)
        {
            karmalevel = "Good";
        }
        else if (karma <= -2)
        {
            karmalevel = "Bad";
        }
        else
        {
            karmalevel = "Neutral";
        }

    }

    public void keepPoints() // keeps points after level change
    {
        PlayerPrefs.SetInt("Player Score", points);
        PlayerPrefs.SetInt("Player Karma", karma);
    }
}
