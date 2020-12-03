using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpowners : MonoBehaviour
{
  Rigidbody2D rb ;
  public float Speed = 4.0f;
  public GameObject[] selector = new GameObject[6];
  public static CarSpowners instance;
  public bool GameOver;
  public float invokeRepTime = 15.0f;
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
        rb = GetComponent<Rigidbody2D>();
       // InvokeRepeating("spownCar",3.0f,2.0f);

    }
    void spownCar()
    {
      InvokeRepeating("spownCarLeft",0.5f,invokeRepTime);
      InvokeRepeating("spownCarRight",2.0f,invokeRepTime);
    }
    // Update is called once per frame
    void Update()
    {
      GameOver = carManager2.instance.GameOver || CarManager.instance.GameOver;
      if(GameOver)
      {
        GameIsOver();
      }

      if(CarManager.instance.GameStart)
      {
              rb.velocity = new Vector2(0.0f, Speed);
      }
    }
    void GameIsOver()
    {
      CancelInvoke("spownCarLeft");
      CancelInvoke("spownCarRight");
      rb.velocity = Vector2.zero;
    }

    public void GameStarted()
    {
      spownCar();
    }

    void spownCarLeft()
    {
      Vector2 pos = transform.position;
      int rand = Random.Range(0,6);
      if(rand>=3)
        {
          pos.x = -2.0f;
          Instantiate(selector[rand],pos, Quaternion.identity);
          //Debug.Log(rand);
        }
        else
        {
          pos.x = -0.6f;
          Instantiate(selector[rand],pos, Quaternion.identity);
          //  Debug.Log(rand);
        }
    }
    void spownCarRight()
    {
      Vector2 pos = transform.position;
      int rand = Random.Range(0,6);
      if(rand>=3)
        {
          pos.x = 2.0f;
          Instantiate(selector[rand],pos, Quaternion.identity);
            //Debug.Log(rand);
        }
        else
        {
          pos.x = 0.6f;
          Instantiate(selector[rand],pos, Quaternion.identity);
            //Debug.Log(rand);
        }
    }
}
