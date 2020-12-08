using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameOverSceneControl : MonoBehaviour
{
    public Text UIGameScore;
    public InputField PlayerName;
    public GameObject SaveButton;
    public string DBUrl;


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
        string playerName = PlayerName.text;
        Debug.Log("saved - " + playerName + " score = " + UpdateScore._updateScore.gameScore);

        UpdateScore._updateScore.gameScoreName = PlayerName.text;
        PlayerName.readOnly = true;
        PlayerName.textComponent.alignment = TextAnchor.MiddleCenter;
        PlayerName.text = "Score Saved!";
        PlayerName.image.enabled = false;
        SaveButton.SetActive(false);

       StartCoroutine(SaveToDB(playerName, UpdateScore._updateScore.gameScore));
    }

    IEnumerator SaveToDB(string name, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", name);
        form.AddField("Score", score);

        using (UnityWebRequest www = UnityWebRequest.Post(DBUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

}
