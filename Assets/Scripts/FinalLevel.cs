using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour {
    public GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }
    void OnTriggerEnter2D(Collider2D col)
{
    if (Enemy.enemyhasdied)
    {
            if (gm.karma > 3)
            {
                SceneManager.LoadScene(4);             //good ending

            }
            if (gm.karma < -3)
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
