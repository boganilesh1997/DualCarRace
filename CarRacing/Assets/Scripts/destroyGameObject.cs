using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    //public float Speed = 4.0f;
    public bool GameOver;
    public static destroyGameObject instance;
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
    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "gameObj")
      {
        Destroy(col.gameObject);
      }
    }
    // Update is called once per frame
    void Update()
    {
      GameOver = carManager2.instance.GameOver || CarManager.instance.GameOver ;
      if(GameOver){
        rb.velocity = Vector2.zero;
      }
    }
    public void GameStarted(float Speed)
     {
         rb.velocity = new Vector2(0.0f, Speed);
     }


}
