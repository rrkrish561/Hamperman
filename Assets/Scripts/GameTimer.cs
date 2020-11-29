using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float gameTimeLimit;
    float gameTimeLeft;
    public Text UITimeLeft;
    bool RunTimer;
    private string GameOverScene = "Scenes/GameOver";

    void Start()
    {
        gameTimeLeft = gameTimeLimit*60;
        RunTimer = true;
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
        VolumeController._volumeController.hideVolumeSlider();
        SceneManager.LoadScene(GameOverScene);
      }

    }
  }

}
