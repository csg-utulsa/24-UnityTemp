using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour

{
    [Header("Set in Inspector")]
    public int numClouds = 40; // the # of clouds to make
    public GameObject cloudPrefab; //the prefab for the clouds
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1; //Min scale of each cloud
    public float cloudScaleMax = 3; //max scale of each cloud
    public float cloudSpeedMult = 0.5f; //adjusts speed of cloud
    private GameObject[] cloudInstances;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        //make an array large enough to hold all the cloud_instances
        cloudInstances = new GameObject[numClouds];
        //find the cloudanchor parent gameobject
        GameObject anchor = GameObject.Find("CloudAnchor");
        //iterate though and make cloud_s
        GameObject cloud;
        for(int i=0; i<numClouds; i++)
        {
            //make an instance of cloud prefab
            cloud = Instantiate<GameObject>(cloudPrefab);
            //position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            //scale cloud
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            //smaller clouds with smaller scaleU should be nearer the ground
            cPos.z = 100 - 90 * scaleU;
            //apply these transforms to the cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            //Make cloud a child of the anchor
            cloud.transform.SetParent(anchor.transform);
            //add the cloud to cloudInstances
            cloudInstances[i] = cloud;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //iterate over each cloud that was created
        foreach(GameObject cloud in cloudInstances{
            //Get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // if a cloud has moved too far to the left...
            if(cPos.x <= cloudPosMin.x)
            {
                cPos.x = cloudPosMax.x;
            }
            //Apply the new position to cloud
            cloud.transform.position = cPos;
        }
        
    }
}
