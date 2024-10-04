using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 pos;
    public float moveFactor;
    void Start()
    {
        transform.position = new Vector3(-9.5f, 0.0f, 0.0f);
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x += moveFactor*Time.deltaTime;
        transform.position = pos;

    }
}
