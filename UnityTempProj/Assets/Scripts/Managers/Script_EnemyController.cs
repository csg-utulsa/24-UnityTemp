using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("WHAT THE FUCK IS A KILOMETER");
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
        }
    }
}
