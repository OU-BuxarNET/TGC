using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Domino1;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    static string lvl = "easy";
    public static string version = "classic"; 
    static string point = "100";
    static bool lvlfirst = true;
    //static bool versionfirst = true;
    static bool pointfirst = true;
    public void ChooseLvlRight()
    {
        Vector2 vecxy = new Vector2(146, 405);
        Vector2 vecabroad = new Vector2(600, 400); 

        GameObject B_LeftLvl = GameObject.Find("B_LeftLvl");
        GameObject B_RightLvl = GameObject.Find("B_RightLvl");
        GameObject easy = GameObject.Find("T_Easy");
        GameObject medium = GameObject.Find("T_Medium");
        GameObject hard = GameObject.Find("T_Hard"); 

        if (lvlfirst == true)
        {
            lvl = "medium";
            lvlfirst = false;
        }
        switch (lvl)
        {
            case "easy":
                easy.transform.localPosition = vecxy;
                medium.transform.localPosition = vecabroad;
                hard.transform.localPosition = vecabroad;
                B_LeftLvl.transform.localPosition = new Vector2(615, 405); 
                B_RightLvl.transform.localPosition = new Vector2(325, 405);
                lvl = "medium"; break;
            case "medium":
                medium.transform.localPosition = vecxy;
                easy.transform.localPosition = vecabroad;
                hard.transform.localPosition = vecabroad; 
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                lvl = "hard"; break;
            case "hard":
                hard.transform.localPosition = vecxy;
                medium.transform.localPosition = vecabroad;
                easy.transform.localPosition = vecabroad;
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                B_RightLvl.transform.localPosition = new Vector2(610, 405);
                lvl = "medium";
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
       
        switch (lvl)
        { 
            case "easy":
                easy.transform.localPosition = new Vector2(146, 405);
                medium.transform.localPosition = new Vector2(600, 300);
                hard.transform.localPosition = new Vector2(600, 400);
                B_LeftLvl.transform.localPosition = new Vector2(630, 405);
                lvl = "medium";
                break;
            case "medium":
                medium.transform.localPosition = new Vector2(146, 405);
                easy.transform.localPosition = new Vector2(600, 300);
                hard.transform.localPosition = new Vector2(600, 400);
                B_LeftLvl.transform.localPosition = new Vector2(-36, 405);
                B_RightLvl.transform.localPosition = new Vector2(325, 405);
                lvl = "easy"; break;
            case "hard":
                easy.transform.localPosition = new Vector2(146, 405);
                medium.transform.localPosition = new Vector2(600, 300);
                hard.transform.localPosition = new Vector2(600, 400);
                B_LeftLvl.transform.localPosition = new Vector2(630, 405);
                lvl = "medium";
                break; 
        }
    }
    public void ChooseVersionL()
    { 
        GameObject B_LeftVersion = GameObject.Find("B_LeftVersion");
        GameObject B_RightVersion = GameObject.Find("B_RightVersion");

        GameObject classic = GameObject.Find("T_ClassicVersion");
        GameObject goat = GameObject.Find("T_GoatVersion");

        B_LeftVersion.transform.localPosition = new Vector2(700, 580);
        B_RightVersion.transform.localPosition = new Vector2(325, 250);
        classic.transform.localPosition = new Vector2(146, 250);
        goat.transform.localPosition = new Vector2(720, 405);
        version = "classic"; 
    }
    public void ChooseVersionR()
    { 
        GameObject B_LeftVersion = GameObject.Find("B_LeftVersion");
        GameObject B_RightVersion = GameObject.Find("B_RightVersion");

        GameObject classic = GameObject.Find("T_ClassicVersion");
        GameObject goat = GameObject.Find("T_GoatVersion");

        B_RightVersion.transform.localPosition = new Vector2(700, 580);
        B_LeftVersion.transform.localPosition = new Vector2(-36, 250);
        goat.transform.localPosition = new Vector2(146, 250);
        classic.transform.localPosition = new Vector2(720, 405);
        version = "goat"; 
    } 
    public void ChooseMaxPoints()
    {
        GameObject B_LeftPoint = GameObject.Find("B_LeftPoint");
        GameObject B_RightPoint = GameObject.Find("B_RightPoint");

        GameObject T_100 = GameObject.Find("T_100");
        GameObject B_Set = GameObject.Find("B_Set");

        if (pointfirst == true)
        {
            lvl = "set";
            pointfirst = false;
        }
        switch (point)
        {
            case "100":
                B_LeftPoint.transform.localPosition = new Vector2(700, 580);
                B_RightPoint.transform.localPosition = new Vector2(325, 90);
                T_100.transform.localPosition = new Vector2(146, 90);
                B_Set.transform.localPosition = new Vector2(720, 405);
                point = "set";
                break;
            case "set":
                B_RightPoint.transform.localPosition = new Vector2(700, 580);
                B_LeftPoint.transform.localPosition = new Vector2(-36, 90);
                B_Set.transform.localPosition = new Vector2(146, 90);
                T_100.transform.localPosition = new Vector2(720, 405);
                point = "100";
                break;
        } 
    }
    public void Create()
    {
        LogicComp.difficutlylvl = "easy";
        //switch(lvl)
        //{
        //    case "easy": LogicComp.difficutlylvl = "easy"; break;
        //    case "medium": LogicComp.difficutlylvl = "medium"; break;
        //    case "hard": LogicComp.difficutlylvl = "hard"; break;
        //}
        switch (version)
        {
            case "classic": LogicComp.versionGame = version; break;
            case "goat": LogicComp.versionGame = version; break;
        }
        switch (point)
        {
            case "100":
                { 
                    if (version == "classic")
                    Statistic.maxpoint = Int32.Parse(point); 
                    else if (version == "goat")
                        StatisticGoat.maxpoint = Int32.Parse(point);
                    break; 
                }
            case "set":
                {
                    if (version == "classic")
                        Statistic.maxpoint = Int32.Parse(point);
                    else if (version == "goat")
                        StatisticGoat.maxpoint = Int32.Parse(point);
                    break;
                }
        }
    }
    public void PointSet()
    {
        GameObject T_Set = GameObject.Find("BT_Set");
        if (T_Set.GetComponent<Text>().text != null)
        point = T_Set.GetComponent<Text>().text;
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