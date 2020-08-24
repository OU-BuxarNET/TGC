using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Output_info : MonoBehaviour
{
    public GameObject P_LoadApp;
    public GameObject P_CameCount;
    public GameObject P_Welcome;
    public GameObject [] DestrButtons;
    private void Start()
    {
      PlayerPrefs.DeleteAll();
        Camera.main.aspect = 480f / 800f;
        IsActive();
        DestrButtons = GameObject.FindGameObjectsWithTag("ShowButton"); // возвращает МАССИВ!
    }
   public void ShowButtons()
    {
        try
        {
            for (int i = 0; i < DestrButtons.Length; i++)
                Destroy(DestrButtons[i]);
            print("удалилось");
        }
        catch 
        {
            print("ошибка удаления");
        }
       
        
        /*if (P_Welcome.activeSelf == true)
        {
            for (int i = 0; i < DestrButtons.Length; i++)
            {
                DestrButtons[i].SetActive(false);
            }
        }*/
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void IsActive()
    {
      /*  if (PlayerPrefs.GetInt("Entering", 1) == 1)
        {
            P_LoadApp.SetActive(true);
            PlayerPrefs.SetInt("Entering", 0);
        }
        else P_CameCount.SetActive(true);*/
    }
}
