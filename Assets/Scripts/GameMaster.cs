using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	// gamemaster controls points (coins) and karma, if you need to use them get them from here
    public int points;

	public int karma;

    public Text pointsText;
    public Text karmaText;


    void Start ()
    {
        points = PlayerPrefs.GetInt("Player Score");
        karma = PlayerPrefs.GetInt("Player Karma");

        pointsText = GameObject.Find("CoinsText").GetComponent<Text>();
        karmaText = GameObject.Find("KarmaText").GetComponent<Text>();


    }
    void Update()
    {
        pointsText.text = (": " + points);
        karmaText.text = ("Karma: " + karma);

    }

    public void keepPoints()
    {
        PlayerPrefs.SetInt("Player Score", points);
        PlayerPrefs.SetInt("Player Karma", karma);
    }
}
