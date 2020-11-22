using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenGameUI : MonoBehaviour
  {
      // Start is called before the f
      public string SceneToLoad;
      public Text UIGameScore;

      void Start()
      {
            VolumeController._volumeController.hideVolumeSlider();
            if (GameObject.FindObjectOfType<UpdateScore>()) 
            {
              UpdateScore._updateScore.gameScore = 0;
              UpdateScore._updateScore.gameScoreName = "";
            }
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
      }

     

  }
