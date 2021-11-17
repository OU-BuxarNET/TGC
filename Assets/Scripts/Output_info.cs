using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Output_info : MonoBehaviour // вывод данных
{

    public GameObject P_LoadApp;
    public GameObject P_Welcome;
    public GameObject P_Param;
    public GameObject P_Rool;
    public Animator T_Welcome;
    public GameObject T_Wel;
    public GameObject Prefab;

    public GameObject P_GameCount;
    public GameObject P_PanelParametrs;

    string NameScene;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        IsActive();
        NameScene = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if (NameScene == "MainScene") // возврат через кнопку на телефоне
        {
            EscapeMainScene();
        }
    }
    public void QuitApp() // метод выхода из приложения
    {
        Application.Quit();
    }
    private void IsActive() // метод проверки какой раз пользователь вошел в игру
    {
        if (PlayerPrefs.GetInt("Entering", 1) == 1)
        { 
            P_LoadApp.SetActive(true);
            PlayerPrefs.SetInt("Entering", 0);
        }
        else P_Welcome.SetActive(true);
    }
    public void BackParam() 
    { 
        if (P_Welcome.activeSelf == true)
        {
            P_Welcome.SetActive(true);
            P_Param.SetActive(true);
        }
        else P_Rool.SetActive(true);
    }
    public void StartAnim()
    {
        T_Welcome.Play("WelcomeTextAnim");
    }
    public void EscapeMainScene() // возврат через кнопку на телефоне
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                P_Welcome.SetActive(true);
                P_GameCount.SetActive(true);
 
                P_PanelParametrs.SetActive(false);
            }
        }
    }
}