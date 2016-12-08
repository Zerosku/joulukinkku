using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour { 

    // triggers the different endings based on the players karma

    // the final trigger only works if the final boss is killed



    public GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }
    void OnTriggerEnter2D(Collider2D col)
{
    if (Enemy.enemyhasdied)                             // checks if the enemy is dead before activating the trigger to the final scene
    {
            if (gm.karma >= 2)
            {
                SceneManager.LoadScene(4);             //good ending

            }
            if (gm.karma <= -2)
            {
                SceneManager.LoadScene(5);             //bad ending

            }
            else
            {
                SceneManager.LoadScene(6);             //neutral ending

            }
    }
}
}
