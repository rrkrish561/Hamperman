using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore
{  
    public string name;  
    public string score;
}

public class HighScoreController : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private float entryHeight = 14f;
    private HighScore[] HighScores = new HighScore[12]; 

     // Start is called before the first frame update
    void Awake()
    {
        entryContainer = transform.Find("HighScoresEntries");
        entryTemplate = entryContainer.Find("HighScoresTemplate");
        entryTemplate.gameObject.SetActive(false);
        GetHighScores();
        
        for (int i=0; i < HighScores.Length; i++)
        {  
            Transform entryTransform = Instantiate(entryTemplate,entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0,-entryHeight * i);
            entryTransform.gameObject.SetActive(true); 

            entryTransform.Find("PlayerName").GetComponent<Text>().text = HighScores[i].name; 
            entryTransform.Find("Score").GetComponent<Text>().text = HighScores[i].score;
            if (HighScores[i].name  != "")
                entryTransform.Find("HighScoresTemplateBackground").gameObject.SetActive(i % 2 == 0);
            else
                entryTransform.Find("HighScoresTemplateBackground").gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void GetHighScores()
    {
    
        for (int i=0; i < 10; i++)
        {   
            HighScores[i] = new HighScore();
            HighScores[i].name = "name"+i; 
            HighScores[i].score= (i*i).ToString();
        }

        HighScores[10] = new HighScore();
        HighScores[10].name = "----------------------------------------------------";
        HighScores[10].score = "------------------";

        //Current Players Last Score
        HighScores[11] = new HighScore();
        if (GameObject.FindObjectOfType<UpdateScore>())      
        {
            HighScores[11].name = UpdateScore._updateScore.gameScoreName;
            HighScores[11].score = UpdateScore._updateScore.gameScore.ToString();
        }else
        {
            HighScores[11].name = "";
            HighScores[11].score = "";
        }

    }
}
