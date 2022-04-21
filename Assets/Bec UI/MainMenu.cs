using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int currentCurrency;
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
}
