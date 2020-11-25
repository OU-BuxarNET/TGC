using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public int sceneID;
    public Image I_Procent;
    public Text T_Procent;

    void Start()
    {
        StartCoroutine(AsyncLoad()); //вызов корутины (загрузка следующей сцены)
    } 
    IEnumerator AsyncLoad() //создание корутины - загрузка следующей сцены (анимация картинки + проценты загрузки)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            I_Procent.fillAmount = progress; // анимация загрузки
            T_Procent.text = string.Format("{0:0}%", progress * 100); // проценты загрузки
            yield return null;
        }
    }
}