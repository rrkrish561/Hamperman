using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text UIGameScore;

    void Update()
      {
          UIGameScore.text = "" + UpdateScore._updateScore.gameScore;
      }
}
