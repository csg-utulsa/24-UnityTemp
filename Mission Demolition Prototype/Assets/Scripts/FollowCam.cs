using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    static public GameObject POI;//static point of interest
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    [Header("Set Dynamically")]
    public float camZ; // the desired z poze

    void Awake()
    {
        camZ = this.transform.position.z;
    }

     void FixedUpdate()
    {
        //if theres only one line following an if  it doesnt need braces
        if (POI == null) return; //return if there is no pool
        //get the position of the poi
        Vector3 destination = POI.transform.position;
        //limit the x&Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //Interpolate from the current Camea position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        //set the camera to the destination
        transform.position = destination;
        //set the orthographic size of the camera to keep ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
