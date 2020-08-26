using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LangControl : MonoBehaviour
{
    public Sprite [] flags; // картинки флагов из ресурсов
    public Image I_Flags; // картинка, на которой изменяется флаг языка
    //объявление переменных текста, которые нужно перевести
    public Text [] T_Namegame = new Text[2]; 
    public Text T_BttnLang1; 
    public Text T_BttnLang2; 
    public Text T_ChangeLng; 
    public Text [] T_Choose = new Text [2];
    public Text T_Questionlng;
    public Text [] T_Yes = new Text[3];
    public Text [] T_No = new Text[3];
    public Text T_Agree;
    public Text T_Disagree;
    public Text [] T_Back = new Text [6];
    public Text [] T_Param = new Text [2];
    public Text T_Rool;
    public Text T_Lng;
    public Text T_Delete;
    public Text T_WarningSave;
    public Text [] T_Instal = new Text[2];
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
#if UNITY_ANDROID && !UNITY_EDITOR
        string path = Path.Combine(Application.streamingAssetsPath, "Languages" + PlayerPrefs.GetString("Language") + ".json");
        WWW reader = new WWW(path);
        while (!reader.isDone) { }
        json = reader.text;
#else
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");
#endif
        lng = JsonUtility.FromJson<lang>(json);
        TranslateWord();
    }

    private void TranslateWord() //перевод текста в приложении
    {
        for (int i = 0; i < T_Namegame.Length; i++)
              T_Namegame[i].text = lng.namegame;

        T_ChangeLng.text = lng.changelng;
        T_BttnLang1.text = lng.language[0];
        T_BttnLang2.text = lng.language[1];

        for (int i = 0; i < T_Choose.Length; i++)
            T_Choose[i].text = lng.choose;

        T_Questionlng.text = lng.questionlng;

        for (int i = 0; i < T_Yes.Length; i++)
            T_Yes[i].text = lng.yesno[0];

        for (int i = 0; i < T_No.Length; i++)
            T_No[i].text = lng.yesno[1];

        T_Agree.text = lng.accord[0];
        T_Disagree.text = lng.accord[1];

        for (int b = 0; b < T_Back.Length; b++)
            T_Back[b].text = lng.back;

        for (int p = 0; p < T_Param.Length; p++)
            T_Param[p].text = lng.parametrs;

        T_Rool.text = lng.rool;
        T_Lng.text = lng.lng;
        T_Delete.text = lng.delete;
        T_WarningSave.text = lng.warningsave;

        for (int i = 0; i < T_Instal.Length; i++)
            T_Instal[i].text = lng.instal;

        T_Welcome.text = lng.welcome;
        T_WarningInstall.text = lng.warninginstall;
        T_gamecount.text = lng.gamecount;
        T_NExist.text = lng.nexist;
        T_VarInst.text = lng.varinst;
        T_Checklvl.text = lng.checklvl;
        T_Beginner.text = lng.beginner;
        T_Fan.text = lng.fan;
        T_Pro.text = lng.pro;
        T_Install.text = lng.installvar;
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
    public string [] yesno = new string [2];
    public string changelng;
    public string [] language = new string[2];
    public string choose;
    public string [] accord = new string [2];
    public string back;
    public string parametrs;
    public string rool;
    public string lng;
    public string delete;
    public string warningsave;
    public string instal;
    public string installvar;
    public string welcome;
    public string warninginstall;
    public string gamecount;
    public string nexist;
    public string varinst;
    public string checklvl;
    public string beginner;
    public string fan;
    public string pro;
}