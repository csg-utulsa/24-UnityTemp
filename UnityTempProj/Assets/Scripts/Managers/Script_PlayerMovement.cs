using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Script_PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;

    GameObject newBullet;
    public float moveFactor;

    public float cooldown;
    Vector3 pos;
    InputAction moveAction;
    InputAction shootAction;

    
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        transform.position = new Vector3(-9.5f, 0.0f, 0.0f);
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveVal = moveAction.ReadValue<Vector2>();
        Debug.Log(moveVal.x);
        pos.x += moveVal.x*moveFactor*Time.deltaTime;
        pos.y += moveVal.y*moveFactor*Time.deltaTime;
        transform.position = pos;

        if(shootAction.IsPressed()){
            newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
        }



    }
}
