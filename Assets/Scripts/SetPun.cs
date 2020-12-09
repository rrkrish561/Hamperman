using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPun : MonoBehaviour
{
    public Text txt;
    public TextAsset dataFile;

    // Start is called before the first frame update
    void Start()
    {
        
        string[] puns = dataFile.text.Split('\n');

        int index = Random.Range(0, puns.Length);

        txt.text = puns[index];
    }
}
