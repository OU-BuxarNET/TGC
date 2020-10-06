using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Domino1;
using System;

public class Helpp : MonoBehaviour
{
    private int a = 7; //количество элементов надо задать
    public GameObject Parent; //Родительский объект на сцене, должен находиться в Canvas
    GameObject But;

    public void Start() // сделать ход
    {
        for (int i = 0; i < a; i++)
        {
            float PosX = -300 + i * 100f ; //тут сами подгоняйте это размер смещения
            But = Instantiate(Resources.Load("Button", typeof(GameObject)), transform, false) as GameObject; //загружаем копию префаба из ресурсов.
            But.transform.SetParent(Parent.transform); //Помещаем кнопку к родителю
            But.transform.localPosition = new Vector3(PosX, -10f, 0f); //смещаем кнопки в моем случае по Х
            int j = i + 1;
            But.name = "B" + j.ToString(); //Дополняем кнопки нумерацией, чтобы потом можно скажем через EventSystem получать имя нажатой кнопки.
        }
    }
    void OnClick()
    {

    }
}
