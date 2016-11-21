using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public GameObject PauseUI;

    private Button PauseButton;
  
    private bool Paused = false;


	// Use this for initialization
	void Start () {
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
    public void Resume ()
    {
        Paused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);

    }
    public void Quit()
    {
        Application.Quit();

    }
}
