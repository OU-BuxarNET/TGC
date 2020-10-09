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
    static GameObject [] But;
    private int b;
    private int j;
    bool per;
    Game game;
    Check check;
    Moving moving;
  
    public void Start() // сделать ход
    {
        game = new Game();
        check = new Check(); 
        game.StartGame();
        But = new GameObject[a];
        for (int i = 0; i < a; i++)
        {
            float PosX = -300 + i * 100f; // размер смещения
            But[i] = Instantiate(Resources.Load("Button", typeof(GameObject)), transform, false) as GameObject; //загружаем копию префаба из ресурсов.
            But[i].transform.SetParent(Parent.transform); //Помещаем кнопку к родителю
            But[i].transform.localPosition = new Vector3(PosX, -10f, 0f); //смещаем кнопки по Х
            j = i + 1;
            But[i].name = "B" + j.ToString(); //Дополняем кнопки нумерацией, чтобы потом можно скажем через EventSystem получать имя нажатой кнопки.
            But[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Board.Hand[i]); // присваиваем спрайты кнопкам  
        }
        ButD();
        Butr();
    }
    void ButD()
    {
        But[0].GetComponent<Button>().onClick.AddListener(() => b = 0);
        But[1].GetComponent<Button>().onClick.AddListener(() => b = 1);
        But[2].GetComponent<Button>().onClick.AddListener(() => b = 2);
        But[3].GetComponent<Button>().onClick.AddListener(() => b = 3);
        But[4].GetComponent<Button>().onClick.AddListener(() => b = 4);
        But[5].GetComponent<Button>().onClick.AddListener(() => b = 5);
        But[6].GetComponent<Button>().onClick.AddListener(() => b = 6);
    }
    void Butr()
    {
        But[0].GetComponent<Button>().onClick.AddListener(() => Pr());
        But[1].GetComponent<Button>().onClick.AddListener(() => Pr());
        But[2].GetComponent<Button>().onClick.AddListener(() => Pr());
        But[3].GetComponent<Button>().onClick.AddListener(() => Pr());
        But[4].GetComponent<Button>().onClick.AddListener(() => Pr());
        But[5].GetComponent<Button>().onClick.AddListener(() => Pr());
        But[6].GetComponent<Button>().onClick.AddListener(() => Pr());
    }
    public void WayTrue() // присваиваю картинки куда можно положить след. кость
    {
        Color color = new Color(1f, 1f, 1f, 0.5f);
        for (int i = 0; i < moving.goPos.Length; i++)
        {
            if (moving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true && moving.goPos[i].GetComponent<Image>().sprite.name != Moving.namespritebutt)
            {
                moving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                moving.goPos[i].GetComponent<Image>().color = color;
            }
        }
    }
    private void Update()
    { 
    }
    public void Move1()
    {
        moving = new Moving();
        game.MakeMove();
        moving.PosGoHand();
        if (Move.next_move == false)
        {
            moving.goPos[Moving.startpos].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.namespritebutt);
            Board.HandComp.RemoveAt(b);
            Destroy(But[b]);
            game.MakeMove();
        }

        if (Move.next_move == true)
        {
            moving.goPos[Moving.startpos].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Board.HandComp[Check.kolforCom]);
            Board.HandComp.RemoveAt(Check.kolforCom);
            Check.flag = false;
            WayTrue(); 
        } 
    }
    void Pr()
    {  
        switch (b)
        {
            case 0: 
                Moving.namespritebutt = But[0].GetComponent<Image>().sprite.name.ToString(); break;
            case 1:
                Moving.namespritebutt = But[1].GetComponent<Image>().sprite.name.ToString(); break;
            case 2:
                Moving.namespritebutt = But[2].GetComponent<Image>().sprite.name.ToString(); break;
            case 3:
                Moving.namespritebutt = But[3].GetComponent<Image>().sprite.name.ToString(); break;
            case 4:
                Moving.namespritebutt = But[4].GetComponent<Image>().sprite.name.ToString(); break;
            case 5:
                Moving.namespritebutt = But[5].GetComponent<Image>().sprite.name.ToString(); break;
            case 6:
                Moving.namespritebutt = But[6].GetComponent<Image>().sprite.name.ToString(); break;
        }
        if (b >= 0)
        {
            check.ChooseBone();
        }
        else Debug.Log("Ничего не выбрано");
    } 
}