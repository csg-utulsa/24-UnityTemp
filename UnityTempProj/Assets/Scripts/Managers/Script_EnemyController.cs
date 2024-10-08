using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed + new Vector3(0f, Mathf.Sin(transform.position.x)/15, 0);
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("WHAT THE FUCK IS A KILOMETER");
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
        }
        if(other.tag == "Player"){
            Object.Destroy(this.gameObject);
            //TODO: add player damage logic
            Debug.Log("The player doesnt get hurt yet");
        }
        if(other.tag == "Deleter"){
            Debug.Log("Hit Deleter, removing object");
            Object.Destroy(this.gameObject);
        }
    }
}
