using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour
{

public static UpdateLives _updateLives;

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

    //Audio
    FindObjectOfType<AudioManager>().Play("LoseLifeSound");
  }

        if (currentLives == 0)
    {
      //toDo end game..
    }

}




}
