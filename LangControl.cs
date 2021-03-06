﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LangControl : MonoBehaviour
{
    public Button B_LangSwitch; // кнопка подтвержения выбора
    public Button [] B_Lang; // кнопки выбора языка 

    public Sprite [] flags; // картиноки флагов из ресурсов
    public Image I_Flags; // картинка, на которой изменяется флаг языка
    //объявление переменных текста, которые нужно перевести
    public Text T_Namegame; 
    public Text T_BttnLang1; 
    public Text T_BttnLang2; 
    public Text T_ChangeLng; 
    public Text T_Choose;
    public Text T_Questionlng;
    public Text T_Yes;
    public Text T_No;
    // конец объявления

    private string json;  // файл json
    public static lang lng = new lang(); // объявление класса json
    private int langIndex = 1; // индекс языка
    private string [] langArray = { "ru_RU", "en_US" }; // существующие языки

    void Awake()
    { 
        //проверка какой язык используется системой ANDROID
        if (!PlayerPrefs.HasKey("Language"))
        { //если используемый язык : русский, украинский или белорусский, то выбираем русский перевод 
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
                PlayerPrefs.SetString("Language", "ru_RU");
            else PlayerPrefs.SetString("Language", "en_US"); //иначе английский
        }
        LangLoad();
    }

    void Start()
    {
        //Camera.main.aspect = 800f / 480f;
        // проверка при вхождении в приложение. присваиваем выранный язык или язык по-умолчанию и его флаг 
        for (int i = 0; i < langArray.Length; i++)
        {
            if (PlayerPrefs.GetString("Language") == langArray[i])
            {
                langIndex = i + 1;
                I_Flags.sprite = flags[i];
                break;
            }
        }
    }

    void LangLoad() // метод перевода
    {
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");
        lng = JsonUtility.FromJson<lang>(json);
        T_Namegame.text = lng.namegame;
        T_ChangeLng.text = lng.changelng;
        T_BttnLang1.text = lng.language[0];
        T_BttnLang2.text = lng.language[1];
        T_Choose.text = lng.choose;
        T_Questionlng.text = lng.questionlng;
        T_Yes.text = lng.yes;
        T_No.text = lng.no;
    }
    public void switchBttn()//метод смены языка
    {
        if (langIndex != langArray.Length) langIndex++;
        else langIndex = 1;
        PlayerPrefs.SetString("Language", langArray[langIndex - 1]); // выбор языка
        I_Flags.sprite = flags[langIndex - 1]; //выбор картинки
        LangLoad();
    }
}
public class lang //класс для json
{
    public string namegame;
    public string questionlng;
    public string yes;
    public string no;
    public string changelng;
    public string [] language = new string[2];
    public string choose;
}