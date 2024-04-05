/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: July 03, 2022
 * 
 * Last Edited by: NA
 * Last Edited: July 03, 2022
 * 
 * Description: Basic GameManager Template
****/
using System; //C# Library for system properites
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //libraries for accessing scenes

public enum GameState { gameStarted, gamePlaying, gameEnded, gameLevelEnded, gamePaused, gameExited, gameTesting };
//enum of game states (work like it's own class)


public class GameManager : MonoBehaviour
{
    #region GameManager Singleton
    static private GameManager gm; //refence GameManager
    static public GameManager GM { get { return gm; } } //public access to read only gm 

    //Check to make sure only one gm of the GameManager is in the scene
    void CheckGameManagerIsInScene()
    {

        //Check if instnace is null
        if (gm == null)
        {
            gm = this; //set gm to this gm of the game object
        }
        else //else if gm is not null a Game Manager must already exsist
        {
            Destroy(this.gameObject); //In this case you need to delete this gm
        }

        DontDestroyOnLoad(this); //Do not delete the GameManager when scenes load

    }//end CheckGameManagerIsInScene()
    #endregion

    [Header("GAME STATES")]
    public GameState currentGameState;
    public GameState targetGameState;
    public GameState lastGameState;


    [Header("SCENE SETTINGS")]
    [Tooltip("Name of the main menu (start) scene")]
    public string startScene;

    [Tooltip("Name of the game over (end) scene")]
    public string endScene;

    [Tooltip("Count and name of each Game Level (scene)")]
    public string[] gameLevels; //names of levels
    [HideInInspector]
    public int gameLevelsCount; //what level we are on
    private int loadLevel; //what level from the array to load

    public static string currentSceneName; //the current scene name;


    [Header("GENERAL SETTINGS")]
    public string gameTitle = "Untitled Game";  //name of the game
    public string gameCredits = "Made by Me"; //game creator(s)
    public string copyrightDate = "Copyright " + thisDay; //date cretaed

    //reference to system time
    private static string thisDay = System.DateTime.Now.ToString("yyyy"); //today's date as string


    [Header("GAME MESSAGES")]
    public string defaultEndMessage = "Game Over";//the end screen message, depends on winning outcome
    public string looseMessage = "You Loose"; //Message if player looses
    public string winMessage = "You Win"; //Message if player wins
    [HideInInspector] public string endMsg;//the end screen message, depends on winning outcome


    [Header("GAME SCORE")]
    static public int score;  //score value
    public int Score { get { return score; } set { score = value; } }//access to static variable score [get/set methods]

    [Tooltip("Will the high score be recoreded")]
    public bool recordHighScore = false; //is the High Score recorded

    [SerializeField] //Access to private variables in editor
    private int defaultHighScore = 1000;
    static public int highScore; // the default High Score
    public int HighScore { get { return highScore; } set { highScore = value; } }//access to private variable highScore [get/set methods]


    [Header("GAME LIVES")]
    public int defaultsLives; //set number of lives in the inspector
    private int currentLives; //number of lives remaining in level

    [Tooltip("Does the level get reset when a life is lost")]
    public bool resetLostLevel; //reset the lost level

    static public int lives; // number of lives for player 
    public int Lives { get { return lives; } set { lives = value; } }//access to static variable lives [get/set methods]


    [Header("FOR TESTING")]

    [SerializeField] //Access to private variables in editor
    [Tooltip("Check to test player lost the level")]
    private bool levelLost = false;//we have lost the level (ie. player died)

    //test next level
    [SerializeField] //Access to private variables in editor
    private bool levelBeat = false; //test for beating the level







    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        //runs the method to check for the GameManager
        CheckGameManagerIsInScene();

        //store the current scene
        currentSceneName = SceneManager.GetActiveScene().name;

    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        //if we run play the game from the level instead of start scene (PLAYTESTING ONLY)
        if (currentSceneName != startScene)
        {
            SetTargetState(GameState.gameTesting); //set the game state for testing
        }
        else
        {
            SetTargetState(GameState.gameStarted); //set the game state to game start
        }
    }//end Start()

    // Update is called once per frame
    void Update()
    {

        //If ESC is pressed quit game
        if (Input.GetKey("escape")) { SetTargetState(GameState.gameExited); }
        
        //Game logic run every frame of current state
        UpdateCurrentState();

    }//end Update()


    //Set the targeted game state
    public void SetTargetState(GameState gState)
    {
        targetGameState = gState;
        if (targetGameState != currentGameState)
        {
            lastGameState = currentGameState; //set the last game state to the current state
            UpdateTargetState();//run the target state update
        }

    }//end SetTargetState()


    //Record the current game state
    public GameState GetCurrentState()
    {
        return currentGameState;
    }//end GetCurrentState()


    //Update the target game state 
    public void UpdateTargetState()
    {
        // Do not run if state has not changed
        if (targetGameState == currentGameState) { return; }

        //Run once when target game state is set
        switch (targetGameState)
        {
            case GameState.gameStarted:
                Debug.Log("Game Starting");
                break;

            case GameState.gamePlaying:
                Debug.Log("Game Playing");
                if(lastGameState == GameState.gameStarted) { SetGameDefaults();}
                StartGame();
                break;

            case GameState.gamePaused:
                break;

            case GameState.gameLevelEnded:
                Debug.Log("Level Ended");
                LoadLevel();//load next level
                break;

            case GameState.gameEnded:
                Debug.Log("Game Ended");

                //if end scene does not exists
                if (endScene == null || endScene == "") { return; }
                SetGameDefaults(); //rest game defaults 
                SceneManager.LoadScene(endScene);//load the end scene 
                break;

            case GameState.gameExited:
                Debug.Log("Game Exited");
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
                break;

            case GameState.gameTesting:
                Debug.Log("Game Testing");
                SetGameDefaults();
                StartGame();
                break;

            default:
                break;
        }

        //Update the current state to the target state
        currentGameState = targetGameState;
        Debug.Log(currentGameState);

    }//end UpdateTargetState()

    //Update the current game state
    public void UpdateCurrentState()
    {
        //Looping logic for current game state
        switch (currentGameState)
        {
            case GameState.gameStarted:
                Debug.Log("Game is currently on title menu");
                break;

            case GameState.gamePlaying:
                Debug.Log("Game is currently running");
                break;

            case GameState.gamePaused:
                Debug.Log("Game is paused");
                break;

            case GameState.gameLevelEnded:
                Debug.Log("Game is currently level ended");
                break;

            case GameState.gameEnded:
                Debug.Log("Game is currently on end menu");
                break;

            case GameState.gameExited:
                Debug.Log("Game is exiting");
                break;

            case GameState.gameTesting:
                Debug.Log("Game is currently in test mode");
                RunTest();
                break;

            default:
                break;
        }
    }//end UpdateCurrentState()


    //called when we start the first game level
    void StartGame()
    {
        //get first game level
        gameLevelsCount = 1; //set the count for the game levels
        loadLevel = gameLevelsCount - 1; //the level from the array

        //load first game level
        SceneManager.LoadScene(gameLevels[loadLevel]);
    }//end StartGame()


    //Set default stats for game start
    void SetGameDefaults()
    {
        Debug.Log("Set Defaults");
      
        //SET ALL GAME LEVEL VARIABLES FOR START OF GAME

        lives = defaultsLives; //set the number of lives
        score = 0; //set starting score
        Debug.Log(defaultHighScore);
        //set High Score
        if (recordHighScore) //if we are recording highscore
        {
            //if the high score, is less than the default high score
            if (highScore <= defaultHighScore)
            {
                highScore = defaultHighScore; //set the high score to defulat
                PlayerPrefs.SetInt("HighScore", highScore); //update high score PlayerPref
            }//end if (highScore <= defaultHighScore)
        }//end  if (recordHighScore) 

    }//end SetGameDefaults()



    public void LostLife()
    {

        if (lives == 1) //if there is one life left and it is lost
        {
            Lives = 0; //set lives to zero
            endMsg = looseMessage;
            SetTargetState(GameState.gameEnded); //set the state to Lost Level

        }
        else
        {
            lives--; //subtract from lives reset level lost 

            //if this level resets when life is lost
            if (resetLostLevel)
            {
                currentLives = lives; //set current lives to remaining for level reload


                //Check if we are testing
                if (currentGameState == GameState.gameTesting)
                {
                    SetTargetState(GameState.gameTesting); //if testing we are still testing
                }
                else
                {
                    SetTargetState(GameState.gamePlaying);//if not we are playing
                }


            }//end if (resetLostLevel)
        }
    }//end LostLife()


    //Level has been beat
    public void BeatLevel()
    {
        endMsg = winMessage;
        SetTargetState(GameState.gameLevelEnded);
    }//end BeatLevel()

    //Load Next Level
    void LoadLevel()
    {
        Debug.Log("Levels " + gameLevelsCount);
        //as long as our level count is not more than the amount of levels
        if (gameLevelsCount < gameLevels.Length)
        {
            gameLevelsCount++; //add to level count for next level
            loadLevel = gameLevelsCount - 1; //find the next level in the array
            SceneManager.LoadScene(gameLevels[loadLevel]); //load next level

            SetTargetState(GameState.gamePlaying);//if not we are playing

        }
        else
        { //if we have run out of levels go to game over
            SetTargetState(GameState.gameEnded);//if not we are playing
        } //end if (gameLevelsCount <=  gameLevels.Length)

    }//end NextLevel()

    //Run tests for game manager
    void RunTest()
    {
        Debug.Log("Run Test");

        //test for lossing level
        if (levelLost) { levelLost = false; LostLife(); }

        //test for winning level
        if (levelBeat) { levelBeat = false; BeatLevel(); }

    }//end RunTest()


}
