using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;//static point of interest
    [Header("SetDynamically")]
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
        //force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        //set the camera to the destination
        transform.position = destination;
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
