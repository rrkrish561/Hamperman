using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMainUIOpen : MonoBehaviour
{
    public static bool MainUILoaded;
    // Start is called before the first frame update
    void Start()
    {
           DontDestroyOnLoad(this);
           MainUILoaded = true;
    }

}
