using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonamiCode : MonoBehaviour
{
    private bool[] code;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        code = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            code[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && code[0] == false)
        {
            Debug.Log("First Input");
            code[0] = true;
        }
        else if (Input.GetKeyDown("up") && code[0] == true && code[1] == false)
        {
            Debug.Log("Second Input");
            code[1] = true;
        }
        else if (Input.GetKeyDown("down") && code[1] == true && code[2] == false)
        {
            Debug.Log("Third Input");
            code[2] = true;
        }
        else if (Input.GetKeyDown("down") && code[2] == true && code[3] == false)
        {
            Debug.Log("Fourth Input");
            code[3] = true;
        }
        else if (Input.GetKeyDown("left") && code[3] == true && code[4] == false)
        {
            Debug.Log("Fifth Input");
            code[4] = true;
        }
        else if (Input.GetKeyDown("right") && code[4] == true && code[5] == false)
        {
            Debug.Log("Sixth Input");
            code[5] = true;
        }
        else if (Input.GetKeyDown("left") && code[5] == true && code[6] == false)
        {
            Debug.Log("Seventh Input");
            code[6] = true;
        }
        else if (Input.GetKeyDown("right") && code[6] == true && code[7] == false)
        {
            Debug.Log("Eighth Input");
            code[7] = true;
        }
        else if (Input.GetKeyDown("b") && code[7] == true && code[8] == false)
        {
            Debug.Log("Nineth Input");
            code[8] = true;
        }
        else if (Input.GetKeyDown("a") && code[8] == true && code[9] == false)
        {
            Debug.Log("Tenth Input");
            code[9] = true;
        }
        else if (code[9])
        {
            checkCode();
            clearCode();
        }
        else if (Input.anyKeyDown)
        {
            if (!checkCode())
            {
                clearCode();
            }
        }
    }
    bool checkCode()
    {
        bool pass = true;
        for (int i = 0; i < 10; i++)
        {
            if (!code[i])
            {
                pass = false;
            }
        }
        if (pass)
        {
            player.GetComponent<PlayerController>().shotNum = 1;
            Debug.Log("Konami Code has been entered");

        }
        return pass;
    }
    void clearCode()
    {
        for (int i = 0; i < 10; i++)
        {
            code[i] = false;
        }
    }
}
