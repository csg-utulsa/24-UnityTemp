/***** Created by: Leslie Graff
 * * Date Created: Feb 16, 2024**
 * Last Edited by: Leslie Graff
 * Last Edited:
 * ** Description: Highscore script.****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    private void Awake()
    {
        //if the player prefs highscore already exists read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //assign the high score to highscore
        PlayerPrefs.SetInt("HighScore", score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score" + score;
        //update the playerprefs highscore if necessary
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("HighScore", score); 
        }
    }
}
