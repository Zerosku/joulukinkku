using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /*public Canvas CreditsUI;

    private bool credits = false;

    private bool creditBool = false;
    private Button CreditsButton;


    void Start()
    {
        //laittaa creditsin kiinni
        CreditsUI.transform.

    }
    void Update()
    {
        if (credits)
        { 
            creditBool = !creditBool;
            CreditsUI.SetActive(creditBool);
        }
    }*/
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        //credits = true;
    }
    public void CloseCredits()
    {
        //credits = false;
    }
}
