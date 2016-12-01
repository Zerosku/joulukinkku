using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int points = 0;

    public Text pointsText;

    void Start ()
    {
        pointsText = GameObject.Find("CoinsText").GetComponent<Text>();

    }
    void Update()
    {
        pointsText.text = (": " + points);

    }
}
