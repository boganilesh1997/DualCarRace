using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarManager : MonoBehaviour
{
   public float Speed = 4.0f;
   Rigidbody2D rb;
   public bool GameOver;
   public bool GameStart;
   // public bool GameOver2;
   public static CarManager instance;
    // Start is called before the first frame update
    void Awake()
    {
      rb = GetComponent<Rigidbody2D>();
      if(instance == null)
      {
        instance = this;
      }
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
      if(GameStart)
      {
        GameStarted();

      }

    }
    void GameStarted()
    {
      MoveCar();
      CarDirectionChange();
      carManager2.instance.GameStarted();
      destroyGameObject.instance.GameStarted(Speed);
      FollowCar.instance.follow();
      ScoreManager.instance.StartScoreCount();
    }
    void MoveCar()
    {
        rb.velocity = new Vector2(0.0f,Speed);
    }
    void CarDirectionChange()
    {
      // on tocuh this method changes the car position from left to right
      if(Input.GetMouseButtonDown(0))
      {
          Vector2 touchpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(touchpos.x < 0)
        {
            if(transform.position.x == -2.0f)
          {
            transform.position = new Vector2(-0.6f,transform.position.y);
          }
          else
          {
            transform.position = new Vector2(-2.0f,transform.position.y);
          }
        }
      }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

      if(col.gameObject.tag =="gameObj")
      {

          GameIsOver();
          carManager2.instance.GameIsOver();
      }
    }
    public void GameIsOver()
    {
      GameOver = true;
      GameStart = false;
      rb.velocity = Vector2.zero;
    }
}
