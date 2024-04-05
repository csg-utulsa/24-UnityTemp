/***** Created by: Leslie Graff
 * * Date Created: Feb 3, 2022*
 * * Last Edited by: Leslie Graff
 * * Last Edited:2/23/24
 * * Description: Manages the UI elements for the HUD****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components
using TMPro; //libraries for TextMeshPro components

public class HUDScript : MonoBehaviour
{
    GameManager gm; //reference to game manager

    [Header("Stats Placement")]
    public TMP_Text levelCountTextbox; //textbox for level count
    public TMP_Text livesTextbox; //textbox for the lives
    public TMP_Text healthTextbox; //textbox for highscore
    public TMP_Text scoreTextbox; //textbox for the score
    public TMP_Text highScoreTextbox; //textbox for highscore
    public TMP_Text collectableCountTextbox; //textbox for amount of collectables
    public TMP_Text TimerTextbox; //textbox for Timer display
    public TMP_Text fastestTimeTextbox; //textbox for the Fastest Time

    //GM Data
    private int level;
    private int lives;
    private int totalLevels;
    private int score;
    private int highScore;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //find the game manager
        //reference to level info
        level = gm.gameLevelsCount;
        totalLevels = gm.gameLevels.Length;

    }//end Start

    // Update is called once per frame
    void Update()
    {
        GetGameStats();
        setHUD();
    }//end Update()

    void GetGameStats()
    {
        lives = gm.Lives;
        score = gm.Score;
        highScore = gm.HighScore;
    }//end GetGameStats()

    void setHUD()
    {
        //if textbox exists update value
        if (levelCountTextbox) { levelCountTextbox.text = "level " + level + "/" + totalLevels; }
        if (livesTextbox) { livesTextbox.text = "Lives " + lives; }
        if (scoreTextbox) { scoreTextbox.text = "Score " + score; }
        if (highScoreTextbox) { highScoreTextbox.text = "High Score " + highScore; }
    } //end SetHUD
}
