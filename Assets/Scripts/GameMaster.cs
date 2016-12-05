using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	// gamemaster controls points (coins) and karma, if you need to use them get them from here
    public int points = 0;

	public int karma;

    public Text pointsText;

    void Start ()
    {
        pointsText = GameObject.Find("CoinsText").GetComponent<Text>();
		karma = 0;

    }
    void Update()
    {
        pointsText.text = (": " + points);

    }
}
