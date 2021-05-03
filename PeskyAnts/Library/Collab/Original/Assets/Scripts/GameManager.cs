using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float maxLevelTime = 100; 
    public float timeLeft = 0; 
    public bool isGameOver = false; 

    public GameObject player;
    public Text timerText;
    public Sugar sugar;

    public GameObject gameWonScreen; 
    public GameObject gameLostScreen; 
    
    void Start()
    {
        timeLeft = maxLevelTime; 
        // player = GameObject.Find("Player");
        timerText = GameObject.Find("TimeLeftIndicator").GetComponent<Text>();
        // gameWonScreen = GameObject.Find("GameWonScreen");
        // gameLostScreen = GameObject.Find("GameLostScreen");

        // make sure game is not paused 
        Time.timeScale = 1;
        isGameOver = false; 
    }

    void Update()
    {
        // determine if game is over 
        // game is over when an ant reaches the sugar 
        if (sugar.hasAntReachedSugar)
        {
            isGameOver = true;
            // pause game
            Time.timeScale = 0f; 
            GameLost();
        }

        if (!isGameOver)
        {
            // determine if game won 
            if (timeLeft <= 0)
            {
                isGameOver = true; 
                // pause game
                Time.timeScale = 0f; 
                GameWon();
                return ; 
            }
            // calc new time
            timeLeft -= Time.deltaTime; 
            // display time 
            timerText.text = Mathf.FloorToInt(timeLeft).ToString();
        }
    }

    void GameWon()
    {
        Debug.Log("Congrats! You stopped the ants!");
        // re-enable mouse so player can interact with menu 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        gameWonScreen.SetActive(true);
    }

    void GameLost()
    {
        // re-enable mouse so player can interact with menu 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        gameLostScreen.SetActive(true);
    }
}
