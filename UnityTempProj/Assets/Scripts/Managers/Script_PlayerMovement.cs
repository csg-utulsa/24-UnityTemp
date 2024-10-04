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
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x += moveFactor;
        transform.position = pos;

    }
}
