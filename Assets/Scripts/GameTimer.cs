using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float gameTimeLimit;
    float gameTimeLeft;
    public Text UITimeLeft;
    bool RunTimer;
    bool testLives;//For testing, remove later


    void Start()
    {
        gameTimeLeft = gameTimeLimit*60;
        RunTimer = true;
        testLives = true;//For testing, remove later
    }


  string formatTime(float timeIn)
  {
    int intTime = (int)(timeIn * 100.0f);
    int minutes = intTime / (60 * 100);
    int seconds = (intTime % (60 * 100)) / 100;
    return string.Format("{0:00}:{1:00}", minutes, seconds);
  }


    void Update()
    {
      if (RunTimer)
      {
      gameTimeLeft -= Time.deltaTime;
      UITimeLeft.text = formatTime(gameTimeLeft).TrimStart(new char[] { '0' } );

        if(gameTimeLeft <= 0)
        {
          RunTimer = false;
          //todo save score, end game, go to score screen?
        }

        //test UpdateLives Remove when lives update is added
        if ((gameTimeLeft % 40) > 1.0)
          testLives = true;      

        if (RunTimer && testLives && ((gameTimeLeft % 40) < 0.1))
        {
        UpdateLives._updateLives.decreaseLives();
        testLives = false;
        }


      }
    }

}
