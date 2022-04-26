using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance1;
    private FMOD.Studio.EventInstance instance2;

    public float sceneNumber = 0f;
   

    /*Public void PlayGame ()
    {
        SceneManager.LoadScene(1);

    }*/
    public void Start()
    {
        instance1 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Cat menu");
        instance2 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/CatTwo");
        MusicCheck();
    }

    public void MusicCheck()
    {
        
        if (sceneNumber == 2) 
        {
            instance2.start();
            instance1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }      

        if (sceneNumber == 0)
        {
            instance1.start();
            instance2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            
        }
        
    }
    public void CreditsMenu ()
    {
        SceneManager.LoadScene(2);
        sceneNumber = 2;
        MusicCheck();
        
    }

    public void Menu ()
    {
        SceneManager.LoadScene(0);
        
        sceneNumber = 0;
        MusicCheck();
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
