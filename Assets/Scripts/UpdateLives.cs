using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateLives : MonoBehaviour
{

public static UpdateLives _updateLives;
private string GameOverScene = "Scenes/GameOver";


public GameObject[] Hearts;
int currentLives;

  void Start()
  {
    if (_updateLives !=null)
        GameObject.Destroy(_updateLives);
    else
        _updateLives=this;

    DontDestroyOnLoad(this);

    currentLives = 3;
    for(int i = 0; i < Hearts.Length; i++)
      {
        Hearts[i].SetActive(true);
      }
  }

public void decreaseLives()
{
  if (currentLives > 0)
  {
    Hearts[currentLives-1].SetActive(false);
    --currentLives;
  }

  if (currentLives == 0)
    {
      VolumeController._volumeController.hideVolumeSlider();
      SceneManager.LoadScene(GameOverScene);
    }

}

    public void increaseLives()
    {
        if (currentLives < 3)
        {
            Hearts[currentLives].SetActive(true);
            ++currentLives;
        }
    }



}
