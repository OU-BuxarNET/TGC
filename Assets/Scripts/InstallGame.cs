using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class InstallGame : MonoBehaviour //скрип установки
{
    private int a; //количество элементов надо задать
    private string Text; //название кнопки надо задать
    public GameObject Parent; //Родительский объект на сцене, должен находиться в Canvas
    void Awake()
    {
        a = UnityEngine.Random.Range(0, 1000);
    }
    void Start()
    {
        bool RakNaGoreSvistit = false;
        int i = 0;
        while (RakNaGoreSvistit == false)
        {
            float PosX = 232f + i * 60f; //тут сами подгоняйте это размер смещения
            GameObject But = Instantiate(Resources.Load<GameObject>(Text), transform, false); //загружаем копию префаба из ресурсов.
           // But.transform.SetParent(Parent); //Помещаем кнопку к родителю
            But.transform.localPosition = new Vector3(PosX, -25f, 0f); //смещаем кнопки в моем случае по Х
            int j = i + 1;
            But.name = j.ToString(); //Дополняем кнопки нумерацией, чтобы потом можно скажем через EventSystem получать имя нажатой кнопки.
            But.GetComponentInChildren<Text>().text = j.ToString(); //меняем текст на кнопке
        }
    }
}

public class GameName
{
    public string namegame { get; set; }

    public GameName(string g)
    {
        namegame = g;
    }
}


