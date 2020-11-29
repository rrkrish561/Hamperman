using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UpdateScore : MonoBehaviour
{
  public static UpdateScore _updateScore;
  [HideInInspector]
  public int gameScore;
  [HideInInspector]
  public string gameScoreName;
  

  void Start()
  {
    if (_updateScore !=null)
      GameObject.Destroy(_updateScore);
      else
      _updateScore=this;

      DontDestroyOnLoad(this);
    gameScore = 0;
  }

}
