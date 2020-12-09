using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShareToTwitter : MonoBehaviour
{

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";
    public string descriptionParam;

    public void ShareToTw() {
        int gameScore = UpdateScore._updateScore.gameScore;
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL("I just scored " + gameScore + " points in Laundr's Hamperman game!" + " " + descriptionParam));
    }
}
