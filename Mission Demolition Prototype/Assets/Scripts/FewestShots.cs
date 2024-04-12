using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FewestShots : MonoBehaviour
{

    static public int recordedShots = 0;
    private int shotsTaken;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("fewestShots"))
        {
            recordedShots = PlayerPrefs.GetInt("fewestShots");
                       }
        PlayerPrefs.SetInt("fewestShots", recordedShots);

    }
    // Start is called before the first frame update
    void Start()
    {
        shotsTaken = Camera.main.GetComponent<MissionDemolition>().shotsTaken;
    }

    // Update is called once per frame
    void Update()
    {
        shotsTaken = Camera.main.GetComponent<MissionDemolition>().shotsTaken;
        Debug.Log(shotsTaken);
        if (recordedShots == 0)
        {
            recordedShots = shotsTaken;
            PlayerPrefs.SetInt("fewestShots", recordedShots);
        }
        else if(shotsTaken < PlayerPrefs.GetInt("fewestShots") && shotsTaken > 0)
        {
            recordedShots = shotsTaken;
            PlayerPrefs.SetInt("fewestShots", recordedShots);
        }        

    }
}
