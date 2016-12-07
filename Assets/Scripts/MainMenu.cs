using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // tämä koodi hallitsee main menun kaikkia nappeja ja toimintoja
    public GameMaster gm;
    
    public GameObject CreditsUI;

    private bool credits = false;

    private Button CreditsButton;

    void start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            credits = !credits;
        }
        //pysäyttää peliajan kun pause on true
        if (credits)
        {
            CreditsUI.SetActive(true);
            


        }
        if (!credits)
        {
            CreditsUI.SetActive(false);
            


        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Player Score", 0);
        PlayerPrefs.SetInt("Player Karma", 0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        credits = true;
    }
    public void CloseCredits()
    {
        credits = false;
    }
}
