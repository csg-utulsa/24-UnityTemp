using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; //a private singleton
    [Header("Set in Inspector")]
    public TMP_Text uitLevel;// the UIText_Level text
    public TMP_Text uitShots;// The UIText_Shots Text
    public TMP_Text uitButton;//the text on the UIButton_View
    public Vector3 castlePos; //The place to put castles
    public GameObject[] castles;//an array of the castles

    [Header("Set Dynamically")]
    public int level; //the current level
    public int levelMax;// the number of levels
    public int  shotsTaken;
    public GameObject castle; //the current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; //followcam mode
    // Start is called before the first frame update
    void Start()
    {
        S = this;//define the singleton
        level = 0;
        levelMax = castles.Length;
        StartLevel();
        
    }

    void StartLevel()
    {
        //get rid of the old castle if one exists
        if (castle != null)
        {
            Destroy(castle);
        }
        //destroy old projectiles if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        //instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;
        //reset the camera
        SwitchView("Show Both");
        ProjectileLine.S.Clear();
        //reset tge goal
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        //show the data in the Gui texts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;

    }
    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
        //check for level end
        if((mode == GameMode.playing)&& Goal.goalMet)
        {
            //change mode to stop checking for level end
            mode = GameMode.levelEnd;
            //zoomout
            SwitchView("Show Both");
            //start the next level in 2 secs
            Invoke("NextLevel", 2f);

        }
    }
    void NextLevel()
    {
        level++;
        if(level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    public void SwitchView(string eView = "")
    {
        if(eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }
    //static method that allows code anywhere to increment shots taken
    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}
