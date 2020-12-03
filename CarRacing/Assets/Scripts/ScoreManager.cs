using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool GameStarted;
    public int score;
    public Text scoretxt;
    public static ScoreManager instance;
    void Awake()
    {
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
    public void StartScoreCount()
    {
      score++;
      scoretxt.text =  "Score :"+ score.ToString();
    }
}
