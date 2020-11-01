using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string SceneToLoad;
    public bool _Additive;

      void start()
      {
        Debug.Log("made it start");
          if (_Additive)
          {
          SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
          }
          else
          {
          SceneManager.LoadScene(SceneToLoad);
          }
      }

      public void OpenAScene()
      {
          if (_Additive)
          {
          SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
          }
          else
          {
          SceneManager.LoadScene(SceneToLoad);
          }
      }

  }
