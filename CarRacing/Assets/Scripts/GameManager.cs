using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject GameStartPanel;
    public GameObject GameOverPanel;
    public bool GameOver;
    public GameObject scorePanel;
    public Text FinalScore;
  //  public Static GameManager instance;
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
      GameOver = carManager2.instance.GameOver || CarManager.instance.GameOver ;
      if(GameOver)
      {
        GameIsOver();
      }
    }

    public void PlayBtnclicked()
    {
      CarManager.instance.GameStart = true;
      CarSpowners.instance.GameStarted();
      RoadSpowner.instance.GameStarted();
      GameStartPanel.SetActive(false);
      scorePanel.SetActive(true);
      InvokeRepeating("increaseSpeed",10.0f,10.0f);
    }
    void GameIsOver()
    {
      GameOverPanel.SetActive(true);
      FinalScore.text = "Score :"+ ScoreManager.instance.score.ToString();
    }

    public void Reset()
    {
       SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void increaseSpeed()
    {
      carManager2.instance.Speed += 0.2f;
      CarManager.instance.Speed += 0.2f;
      CarSpowners.instance.Speed += 0.2f;
    //  destroyGameObject.instance.Speed += 2.0f;
    }
    void DecreaseSpownTime()
    {


    }
}
