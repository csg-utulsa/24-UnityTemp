/***** Created by: Leslie Graff
 * * Date Created: Feb 3, 2022*
 * * Last Edited by: Leslie Graff
 * * Last Edited:2/23/24
 * * Description: Manages the UI elements for the menu scenes****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components
using TMPro; //libraries for TextMeshPro components

public class MenuScript : MonoBehaviour
{
    GameManager gm; //refernce to game manager

    [Header("Text Boxes")] 
    public TMP_Text titleTextbox;//textbox for the title
    public TMP_Text creditsTextbox; //textbox for the credits
    public TMP_Text copyrightTextbox; //textbox for the copyright
    public TMP_Text mesageTextbox; //textbox for end message
    public TMP_Text VM1;
    public TMP_Text VM2; //VM = Bonus end messages


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //refernce to game manager
        //set the value for textboxes
        if (titleTextbox) { titleTextbox.text = gm.gameTitle; }
        if (creditsTextbox) { creditsTextbox.text = gm.gameCredits; }
        if (copyrightTextbox) { copyrightTextbox.text = gm.copyrightDate; }
        if (mesageTextbox) { mesageTextbox.text = gm.endMsg; }

    }//end start()

    public void OnGameStart() 
    { 
        Debug.Log("Game Started");
        gm.SetTargetState(GameState.gamePlaying);
    }//end OnGameStart()

    public void OnGameExit() 
    { 
        Debug.Log("Exited Game");
        gm.SetTargetState(GameState.gameExited);
    }//end OnGameExit()
}
