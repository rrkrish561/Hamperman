using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShareToTwitter : MonoBehaviour
{

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";
    public string descriptionParam;

    public void ShareToTw() {
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(descriptionParam));
    }
}
