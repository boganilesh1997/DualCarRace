using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{

    public GameObject car;
    public float offset = 4.0f;
    public static FollowCar instance;
  //  bool GameOver = false;
    void Awake()
    {
      if(instance == null)
      {
        instance = this;
      }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //follow();
    }

    public void follow()
    {
      transform.position = new Vector3(0,car.transform.position.y + offset,-10);
    }
}
