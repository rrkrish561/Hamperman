using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainUI : MonoBehaviour
{
    // Start is called before the f
    public string SceneToLoad;
    void Start()
    {
          if  (!KeepMainUIOpen.MainUILoaded)
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
    }

}
