using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneControl : MonoBehaviour
{
    public Text UIGameScore;
    public InputField PlayerName;
    public GameObject SaveButton;


    // Start is called before the first frame update
    void Start()
    {
        UIGameScore.text = "" + UpdateScore._updateScore.gameScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     // Update is called once per frame
    public void SaveScore()
    {
        //ToDo save to database..
        Debug.Log("saved - " + PlayerName.text + "score = " + UpdateScore._updateScore.gameScore);

        UpdateScore._updateScore.gameScoreName = PlayerName.text;
        PlayerName.readOnly = true;
        PlayerName.textComponent.alignment = TextAnchor.MiddleCenter;
        PlayerName.text = PlayerName.text + ": Score = " + UpdateScore._updateScore.gameScore;
        PlayerName.image.enabled = false;
        SaveButton.SetActive(false);

    }
}
