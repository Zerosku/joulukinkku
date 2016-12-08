using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // this code funcions as the in-games pause menu

    Player possu;

    public GameObject PauseUI;

    private Button PauseButton;
  
    private bool Paused = false;


	// Use this for initialization
	void Start () {
        possu = GameObject.Find("Player").GetComponent<Player>();


        // sets the pause off when the game starts
        PauseUI.SetActive(false);

        PauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        PauseButton.onClick.AddListener(() => Paused = true);
       
        

    }

    // Update is called once per frame
    void Update () {

        
        if (Input.GetButtonDown("Pause"))
        {
            Paused = !Paused;
        }
        // stops gametime when paused
        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            
           
        }
        if (!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            

        }
    }
    // deactivates pause
    public void Resume ()
    {
        Paused = false;
    }
    //restarts the game
    public void Restart()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Player Score", 0);
        PlayerPrefs.SetInt("Player Karma", 0);
    }
    // returns to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    // quits game
    public void Quit()
    {
        Application.Quit();

    }
}
