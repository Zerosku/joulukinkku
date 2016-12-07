using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // tämä koodi hallitsee pause menua ja kaikkia sen toimintoja

    Player possu;

    public GameObject PauseUI;

    private Button PauseButton;
  
    private bool Paused = false;


	// Use this for initialization
	void Start () {
        possu = GameObject.Find("Player").GetComponent<Player>();


        //laittaa pelin aloituksessa pausen pois päältä
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
        //pysäyttää peliajan kun pause on true
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
    //resume nappi joka jatkaa peliä siitä mihin jäätin
    public void Resume ()
    {
        Paused = false;
    }
    //aloittaa kyseisen kentän alusta
    public void Restart()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Player Score", 0);
        PlayerPrefs.SetInt("Player Karma", 0);
    }
    //palaa päävalikkoon
    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    //lopettaa pelin
    public void Quit()
    {
        Application.Quit();

    }
}
