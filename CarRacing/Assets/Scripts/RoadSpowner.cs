using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpowner : MonoBehaviour
{
    public GameObject road;
    Vector2 lastPos;
    bool GameOver ;
    public static RoadSpowner instance;
    public float invokeRepRoad = 3.0f;
    void Awake()
    {
       lastPos= road.transform.position;
       lastPos.y += 9.90f;
       Instantiate(road, lastPos, Quaternion.identity);
       if(instance == null)
       {
         instance = this;
       }
    }
    // Start is called before the first frame update
    void Start()
    {
      //InvokeRepeating("RoadInstantiate",2.0f,1.0f);
    }
    // Update is called once per frame
    void Update()
    {
       GameOver = carManager2.instance.GameOver || CarManager.instance.GameOver ;

        if(GameOver)
        {
            CancelInvoke("RoadInstantiate");
        }
    }

    public void GameStarted()
    {
        InvokeRepeating("RoadInstantiate",1.0f,invokeRepRoad);
    }

    void RoadInstantiate()
    {
      lastPos.y += 9.90f;
        Instantiate(road, lastPos, Quaternion.identity);
    }

}
