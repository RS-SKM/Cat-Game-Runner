using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{

    public enum ItemType
    {
        Skin,
        Hat,
        Gun
    }

    public enum Skin 
    { 
        Yellow,
        Blue,
        Red,
        Green
    }
    public enum Hat
    {
        None,
        Tophat,
        Witchhat
    }
    public enum Gun
    {
        Default,
        Water,
        Ray,
        Bubble
    }

    [Tooltip("Stores the skin to be applied to the PC")]
    public Skin skin;
    [Tooltip("Stores the hat to be applied to the PC")]
    public Hat hat;
    [Tooltip("Stores the gun to be applied to the PC")]
    public Gun gun;

    //these variables hold which items need to be applied to the player character on start of the game level. assets are not yet attached!


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); //this will make this object stick around whenever we change scenes (Will be put in it's own scene called "Dontdestroyonload" but the FindObjefct will still be able to find it)
    }

    public void SetAppearance(ItemType itemType, int itemIndex)
    {
        switch (itemType) //this is better than running an if statement for each of the values we need
        {
            case ItemType.Skin:
                skin = (Skin)itemIndex; //putting into brackets in the start of the thing is "casting" to a different variable type
                break;

            case ItemType.Hat:
                hat = (Hat)itemIndex; //putting into brackets in the start of the thing is "casting" to a different variable type
                break;

            case ItemType.Gun:
                gun = (Gun)itemIndex; //putting into brackets in the start of the thing is "casting" to a different variable type
                break;

            default: //stops it from breaking if it doesn't know what the input is (or is given an invalid input) by not doing anything
                break;
        }
    }
}
