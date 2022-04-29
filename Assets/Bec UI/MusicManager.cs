using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance FMODmusic1;
    private FMOD.Studio.EventInstance FMODmusic2;
    private FMOD.Studio.EventInstance FMODmusic3;

    [Tooltip("Select 0 or 1 to choose Menu Music")]
    public int menuMusic = 0;


    public void Start()
    {
        FMODmusic1 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Cat menu");
        FMODmusic2 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/CatTwo");
        FMODmusic3 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/CatThree");


        StopMusic();

        if (menuMusic == 0)
            PlayMusic1();

        if (menuMusic == 1)
            PlayMusic2();

        if (menuMusic == 2)
            PlayMusic3();
    }

    public void StopMusic()
    {
        FMODmusic1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        FMODmusic2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        FMODmusic3.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void PlayMusic1()
    {
        FMODmusic1.start();
    }

    public void PlayMusic2()
    {
        FMODmusic2.start();
    }
    public void PlayMusic3()
    {
        FMODmusic3.start();
    }
}
