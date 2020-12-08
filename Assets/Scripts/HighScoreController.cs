using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class HighScoreController : MonoBehaviour
{
    [Serializable]
    public class HighScore
    {  
        public string Name;  
        public string Score;
    }
    [Serializable]
    public class Wrapper
    {
        public HighScore[] highScores;
    }

    private Transform HSEntryContainer;
    private Transform HSEntryTemplate;
    private float entryHeight = 14f;
    private HighScore[] HighScores = new HighScore[12]; 

     // Start is called before the first frame update
    void Awake()
    {    
        StartCoroutine(GetHighScoresFromDB());   
    }

    IEnumerator GetHighScoresFromDB() {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:5000/score/top/");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);


            Wrapper wrap = JsonUtility.FromJson<Wrapper>("{\"highScores\":" + www.downloadHandler.text + "}");
            Debug.Log(wrap.highScores[0].Name);

            HighScores = wrap.highScores;
            
        }

        HSEntryContainer = transform.Find("HighScoresEntries");
        HSEntryTemplate = HSEntryContainer.Find("HighScoresTemplate");
        HSEntryTemplate.gameObject.SetActive(false);
        
        for (int i=0; i < HighScores.Length; i++)
        {  
            Transform HSEntryTransform = Instantiate(HSEntryTemplate,HSEntryContainer);
            RectTransform HSEntryRectTransform = HSEntryTransform.GetComponent<RectTransform>();
            HSEntryRectTransform.anchoredPosition = new Vector2(0,-entryHeight * i);
            HSEntryTransform.gameObject.SetActive(true); 

            HSEntryTransform.Find("PlayerName").GetComponent<Text>().text = HighScores[i].Name; 
            HSEntryTransform.Find("Score").GetComponent<Text>().text = HighScores[i].Score;
            if (HighScores[i].Name  != "")
                HSEntryTransform.Find("HighScoresTemplateBackground").gameObject.SetActive(i % 2 == 0);
            else
                HSEntryTransform.Find("HighScoresTemplateBackground").gameObject.SetActive(false);
        }

        // HighScores[10] = new HighScore();
        // HighScores[10].Name = "----------------------------------------------------";
        // HighScores[10].Score = "------------------";

        // //Current Players Last Score
        // HighScores[11] = new HighScore();
        // if (GameObject.FindObjectOfType<UpdateScore>())      
        // {
        //     HighScores[11].Name = UpdateScore._updateScore.gameScoreName;
        //     HighScores[11].Score = UpdateScore._updateScore.gameScore.ToString();
        // } 
        // else
        // {
        //     HighScores[11].Name = "";
        //     HighScores[11].Score = "";
        // }
    }
}
