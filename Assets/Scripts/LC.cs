using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using LangControl;

public class LC : MonoBehaviour
{
    //объявление переменных текста, которые нужно перевести
    public Text[] T_Namegame = new Text[2];
    public Text T_BttnLang1;
    public Text T_BttnLang2;
    public Text T_ChangeLng;
    public Text[] T_Choose = new Text[2];
    public Text T_Questionlng;
    public Text[] T_Yes = new Text[3];
    public Text[] T_No = new Text[3];
    public Text T_Agree;
    public Text T_Disagree;
    public Text[] T_Back = new Text[6];
    public Text[] T_Param = new Text[2];
    public Text T_Rool;
    public Text T_Lng;
    public Text T_Delete;
    public Text T_WarningSave;
    public Text[] T_Instal = new Text[2];
    public Text T_Install;
    public Text T_Welcome;
    public Text T_WarningInstall;
    public Text T_gamecount;
    public Text T_NExist;
    public Text T_VarInst;
    public Text T_Checklvl;
    public Text T_Beginner;
    public Text T_Fan;
    public Text T_Pro;
    // конец объявления

    public static langchoose lnggg = new langchoose();
    public static lang lng = new lang();
    void Awake()
    {
        lnggg.Findlng();
    }
    void Start()
    {
        lnggg.StartMetod();
    }
    public void SwitchBttn()
    {
        lnggg.switchBttn();
        TranslateWord();
    }
    private void TranslateWord() //перевод текста в приложении
    {

        for (int i = 0; i < T_Namegame.Length; i++)
            T_Namegame[i].text = lnggg.T_Namegame;

        T_ChangeLng.text = lnggg.T_ChangeLng;
        T_BttnLang1.text = lnggg.T_BttnLang1;
        T_BttnLang2.text = lnggg.T_BttnLang2;

        for (int i = 0; i < T_Choose.Length; i++)
            T_Choose[i].text = lnggg.T_Choose;

        T_Questionlng.text = lnggg.T_Questionlng;

        for (int i = 0; i < T_Yes.Length; i++)
            T_Yes[i].text = lnggg.T_Yes;

        for (int i = 0; i < T_No.Length; i++)
            T_No[i].text = lnggg.T_No;

        T_Agree.text = lnggg.T_Agree;
        T_Disagree.text = lnggg.T_Disagree;

        for (int b = 0; b < T_Back.Length; b++)
            T_Back[b].text = lnggg.T_Back;

        for (int p = 0; p < T_Param.Length; p++)
            T_Param[p].text = lnggg.T_Param;

        T_Rool.text = lnggg.T_Rool;
        T_Lng.text = lnggg.T_Lng;
        T_Delete.text = lnggg.T_Delete;
        T_WarningSave.text = lnggg.T_WarningSave;

        for (int i = 0; i < T_Instal.Length; i++)
            T_Instal[i].text = lnggg.T_Instal;

        T_Install.text = lnggg.T_Install;
        T_Welcome.text = lnggg.T_Welcome;
        T_WarningInstall.text = lnggg.T_WarningInstall;
        T_gamecount.text = lnggg.T_gamecount;
        T_NExist.text = lnggg.T_NExist;
        T_VarInst.text = lnggg.T_VarInst;
        T_Checklvl.text = lnggg.T_Checklvl;
        T_Beginner.text = lnggg.T_Beginner;
        T_Fan.text = lnggg.T_Fan;
        T_Pro.text = lnggg.T_Pro; 
        
    }
}

