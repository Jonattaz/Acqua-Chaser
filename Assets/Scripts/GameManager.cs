using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public int score;

    public static GameManager gameManager;

    public Text scoreText;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("", 0).ToString();
    }


    // Update the player's score and set the highest score value
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        
        if (score > PlayerPrefs.GetInt("", 0))
        {

            PlayerPrefs.SetInt("", score);
            highScore.text = score.ToString();

        }
    }


}












