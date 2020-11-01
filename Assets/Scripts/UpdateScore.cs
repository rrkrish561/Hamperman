using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UpdateScore : MonoBehaviour
{
    public static int gameScore;
    public Text UIGameScore;

    void Start()
    {
        gameScore = 0;
    }

    void Update()
    {
      UIGameScore.text = "" + gameScore;
    }

}
