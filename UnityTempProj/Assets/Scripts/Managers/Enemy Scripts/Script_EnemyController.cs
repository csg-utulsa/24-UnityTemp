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
        transform.position += Vector3.left*Time.deltaTime*speed;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(transform.position.x)*2, 0);
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("WHAT THE FUCK IS A KILOMETER");
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
        }
        if(other.tag == "Player"){
            Object.Destroy(this.gameObject);
            other.gameObject.GetComponent<Script_PlayerMovement>().damage();
        }
        if(other.tag == "Deleter"){
            Debug.Log("Hit Deleter, removing object");
            Object.Destroy(this.gameObject);
        }
    }
}
