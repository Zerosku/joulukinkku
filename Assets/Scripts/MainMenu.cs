using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // this code controls all the buttons of the main menu

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
        
        if (credits)
        {
            CreditsUI.SetActive(true);
            


        }
        if (!credits)
        {
            CreditsUI.SetActive(false);
            


        }
    }
    public void PlayGame()  // sets the players karma and coins to 0 and starts the first level
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Player Score", 0);
        PlayerPrefs.SetInt("Player Karma", 0);
    }

    public void ExitGame()  // exits the application
    {
        Application.Quit();
    }
    public void Credits()  // activates credits canvas
    {
        credits = true;
    }
    public void CloseCredits() // deactivates credits canvas
    {
        credits = false;
    }
}
