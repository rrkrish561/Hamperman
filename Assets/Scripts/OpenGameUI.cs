using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGameUI : MonoBehaviour
  {
      // Start is called before the f
      public string SceneToLoad;
      void Start()
      {
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
      }

  }
