using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level2end : MonoBehaviour {

    public GameMaster gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {  //If the collider collides with a gameobject tagged "Player"...
            gm.keepPoints();
            SceneManager.LoadScene(3);             //The next scene begins
            
        }
    }

}
