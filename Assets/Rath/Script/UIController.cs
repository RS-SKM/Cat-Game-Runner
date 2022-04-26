using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    Player player;
    Text distanceText;

    GameObject results;
    Text finalDistanceText;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        results = GameObject.Find("Results");
        finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<Text>();

        results.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            Invoke("RetryScreen", 0.1f);
        }
    }

    void RetryScreen()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";
        results.SetActive(true);
        finalDistanceText.text = distance + " m";
    }


    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("mainGame");
    }

    
}
