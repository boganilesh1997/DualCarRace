using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carManager2 : MonoBehaviour
{
  public float Speed = 4.0f;
  Rigidbody2D rb;
  public bool GameOver;
  public static carManager2 instance;
   // Start is called before the first frame update
   void Awake(){
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

   }

   public void GameStarted()
   {
     MoveCar();
     CarDirectionChange();
   }
   void MoveCar()
   {
      rb.velocity = new Vector2(0.0f, Speed);
   }
   void CarDirectionChange()
   {
     if(Input.GetMouseButtonDown(0))
     {
         Vector2 touchpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       if(touchpos.x > 0)
       {
           if(transform.position.x == 2.0f)
         {
           transform.position = new Vector2(0.6f,transform.position.y);
         }
         else
         {
           transform.position = new Vector2(2.0f,transform.position.y);
         }
       }
     }
   }
   void OnCollisionEnter2D(Collision2D collision)
   {
     if(collision.gameObject.tag =="gameObj")
     {
       GameIsOver();
       CarManager.instance.GameIsOver();
     }
   }
   public void GameIsOver()
   {
      GameOver = true;
      rb.velocity = Vector2.zero;
   }

}
