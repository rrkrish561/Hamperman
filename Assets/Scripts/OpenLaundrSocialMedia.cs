﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLaundrSocialMedia : MonoBehaviour
{
    public string Url;

    public void Open()
    {
        Application.ExternalEval(Url);
    }
}
