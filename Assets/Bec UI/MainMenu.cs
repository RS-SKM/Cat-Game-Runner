using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*Public void PlayGame ()
    {
        SceneManager.LoadScene(1);

    }*/
 
        
    
    public void CreditsMenu ()
    {
        SceneManager.LoadScene(2);

    }

    public void Menu ()
    {
        SceneManager.LoadScene(0);
        
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
