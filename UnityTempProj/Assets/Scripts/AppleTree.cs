/***** Created by: 
 * Leslie Graff*
 * Date Created: Feb 16, 2024*
 * * Last Edited by:*
 * Last Edited:** 
 * Description: AppleTree movement Script.
 * ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the apple tree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which Apples will be instatiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject Apple = Instantiate<GameObject>( applePrefab );
        Apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
    }
    void FixedUpdate()
    {
        //changing directions randomly is now time based because of Fixed update
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //ChangeDirection
        }
    }
}