using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BulletDeleter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other){
    if(other.tag == "Bullet"){
        Object.Destroy(other.gameObject);
        gameManager.GetComponent<Script_GameManager>().misses += 1;
    }
    }

}
