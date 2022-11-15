using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPoint;
    public float TimeReset;
    float timetoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timetoSpawn = TimeReset;
    }

    // Update is called once per frame
    void Update()
    {
        timetoSpawn -= Time.deltaTime;
        if (timetoSpawn < 0)
        {
            SpwanBall();
            timetoSpawn = TimeReset;
        }
    }





    void SpwanBall()
    {
        Instantiate(ball, spawnPoint.position, Quaternion.identity);
    }
}
