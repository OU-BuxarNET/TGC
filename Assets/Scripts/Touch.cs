using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    static int a = 0;
    static bool first = true;

    public void ChooseLvlRight()
    {
        Vector2 vecxy = new Vector2(146, 405);
        Vector2 vecabroad = new Vector2(600, 400); 

        GameObject B_LeftLvl = GameObject.Find("B_LeftLvl");
        GameObject B_RightLvl = GameObject.Find("B_RightLvl");
        GameObject easy = GameObject.Find("T_Easy");
        GameObject medium = GameObject.Find("T_Medium");
        GameObject hard = GameObject.Find("T_Hard");
        if (first == true)
        {
            a = -1;
            first = false;
        }
        switch (a)
        {
            case -1:
                medium.transform.localPosition = vecxy;
                easy.transform.localPosition = vecabroad;
                hard.transform.localPosition = vecabroad;
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                a = 1;
                break;
            case 0:
                easy.transform.localPosition = vecxy;
                medium.transform.localPosition = vecabroad;
                hard.transform.localPosition = vecabroad;
                B_LeftLvl.transform.localPosition = new Vector2(615, 405); 
                B_RightLvl.transform.localPosition = new Vector2(200, 405);  
                a = 1; break;
            case 1:
                medium.transform.localPosition = vecxy;
                easy.transform.localPosition = vecabroad;
                hard.transform.localPosition = vecabroad; 
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                a = 2; break;
            case 2:
                hard.transform.localPosition = vecxy;
                medium.transform.localPosition = vecabroad;
                easy.transform.localPosition = vecabroad;
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                B_RightLvl.transform.localPosition = new Vector2(610, 405);
                a = 1;
                break;
        } 
    }
    public void ChooseLvlLeft()
    {
        GameObject B_LeftLvl = GameObject.Find("B_LeftLvl");
        GameObject B_RightLvl = GameObject.Find("B_RightLvl");

        GameObject easy = GameObject.Find("T_Easy");
        GameObject medium = GameObject.Find("T_Medium");
        GameObject hard = GameObject.Find("T_Hard");

        switch (a)
        {
            //case -2:
            //    hard.transform.localPosition = new Vector2(146, 405);
            //    easy.transform.localPosition = new Vector2(600, 300);
            //    medium.transform.localPosition = new Vector2(600, 400);
            //    B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
            //    a = 2;
            //    break;
            case 0:
                easy.transform.localPosition = new Vector2(146, 405);
                medium.transform.localPosition = new Vector2(600, 300);
                hard.transform.localPosition = new Vector2(600, 400);
                B_LeftLvl.transform.localPosition = new Vector2(630, 405);
                a = 1;
                break;
            case 1:
                medium.transform.localPosition = new Vector2(146, 405);
                easy.transform.localPosition = new Vector2(600, 300);
                hard.transform.localPosition = new Vector2(600, 400);
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                B_RightLvl.transform.localPosition = new Vector2(160, 405); 
                a = 0; break;
            case 2:
                hard.transform.localPosition = new Vector2(146, 405);
                medium.transform.localPosition = new Vector2(600, 300);
                easy.transform.localPosition = new Vector2(600, 400);
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                B_RightLvl.transform.localPosition = new Vector2(650, 405);
                a = 1; break;
        }
    }  
    public void QuitOnscene()
    {
        SceneManager.LoadScene(0);
    }
    static int index = 0;
    public void ShowIcons() // перенести в dll комнаты
    { 
        GameObject I_CopmPlayer = GameObject.Find("I_CopmPlayer");
        if (index == 0)
        {
            I_CopmPlayer.transform.localPosition = new Vector2(0, 1000);
            index = 1;
        }
        else if (index == 1)
        {
            I_CopmPlayer.transform.localPosition = new Vector2(0, 490);
            index = 0;
        }
    }
}