/*****
 * Created by: Leslie Graff
 * * Date Created: Feb 16, 2024**
 * Last Edited by:* Last Edited:**
 * Description: Apple Script.
 * ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            //get a refrence to the applepickercomponent of main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Call the public apple destroyed() method of apScript
            apScript.AppleDestroyed();
        }
    }
}
