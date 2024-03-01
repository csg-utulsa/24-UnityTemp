/***** Created by: Leslie Graff
 * * Date Created: Feb 16, 2024**
 * Last Edited by:* 
 * 
 * Last Edited:
 * ** Description: Basket moving Script and adding points for each caught apple.****/
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour

{

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
        gm = GameManager.GM;
        //Find a reference to the ScoreCounter GameObject
   
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The camera's z position sets how far to push the mouse in to 3D
        mousePos2D.z = Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this Basket to the X position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
     void OnCollisionEnter(Collision coll)
    {
        //find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy (collidedWith);

            //Parse the text of the scoreGT into an int
            int score = gm.Score;
            //add points for catching the apple
           score += 100;
            gm.Score = score;
            Debug.Log(score);
            //Convert the score back to a string and display it
         

            //track the high score
            if (score> gm.HighScore)
            {
               gm.HighScore = score;
            
            }
            if (score == 3500)
            {
                gm.LoadLevel
            }

        }

        
    }



    public void DestroyBasket()
    {
        gm.LostLife();
        Debug.Log("Lostlife");
        Destroy(this.gameObject);
    }
}
