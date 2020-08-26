using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Output_info : MonoBehaviour // вывод данных
{
    public GameObject P_LoadApp;
    public GameObject P_Welcome;
    public GameObject P_Rool;
    public Animator T_Welcome;
    public GameObject Prefab;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        Camera.main.aspect = 480f / 800f;
        IsActive();
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
        }
        else P_Rool.SetActive(true);
    }
    public void StartAnim()
    {
        T_Welcome.Play("WelcomeTextAnim");
    }
}
