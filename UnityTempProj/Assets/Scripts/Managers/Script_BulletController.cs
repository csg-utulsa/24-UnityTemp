using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BulletController : MonoBehaviour
{

    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right*Time.deltaTime*speed;
        
    }
}
