using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public float spawnRate;
    float timer;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnRate){
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(10f, -3f, 0f);
            timer = 0;
        }
    }
}
