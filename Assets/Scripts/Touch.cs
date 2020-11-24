using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    public void QuitOnscene()
    {
        SceneManager.LoadScene(0);
    }
    static int index = 0;
    public void ShowIcons() // перенести в dll
    { 
        GameObject I_CopmPlayer = GameObject.Find("I_CopmPlayer");
        if (index == 0)
        {
            I_CopmPlayer.transform.localPosition = new Vector2(0, 1000);
            index = 1;
        }
        else if (index == 1)
        {
            I_CopmPlayer.transform.localPosition = new Vector2(0, 530);
            index = 0;
        } 
    }
} 