using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dominos;
using System;

public class Helpp : MonoBehaviour
{
    public Button[] ChooseDom;
    private int b;
    Game game;
    LogicComp logicComp;
    public Text t ;
    private void Start()
    {
         game = new Game();
         logicComp = new LogicComp();
        game.StartGame();
        for (int i = 0; i < game.board.Hand.Count; i++)
        {
            ChooseDom[i].image.sprite = Resources.Load<Sprite>("Textures/" + game.board.Hand[i]); //путь картинки
        }
        game.next_move = true; 
    }
    public void Pos() // сделать ход
    {
        game.MakeaMove();
        if (game.dominoshkiMoving.flag == true) // ставим
        {
            game.dominoshkiMoving.goPos[game.dominoshkiMoving.startpos].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + game.dominoshkiMoving.namespritebutt);
        }
    }
    public void Comp()
    {
        game.dominoshkiMoving.goPos[game.dominoshkiMoving.startpos].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + game.board.HandComp[0]);
    }
    void Update()
    {
        WayTrue();
    }
    public void WayTrue() // присваиваю картинки куда можно положить след. кость
    {
        Color color = new Color(1f, 1f, 1f, 0.5f);
        for (int i = 0; i < game.dominoshkiMoving.goPos.Length; i++)
        {
            if (game.dominoshkiMoving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true)
            {
                game.dominoshkiMoving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                game.dominoshkiMoving.goPos[i].GetComponent<Image>().color = color;
            }
        }
    }
    public void B1()
    {
        b = 0; Pr();
    }
    public void B2()
    {
        b = 1; Pr();
    }
    public void B3()
    {
        b = 2; Pr();
    }
    public void B4()
    {
        b = 3; Pr();
    }
    public void B5()
    {
        b = 4; Pr();
    }
    void Pr()
    {
        switch (b)
        {
            case 0:
                game.dominoshkiMoving.namespritebutt = ChooseDom[0].image.sprite.name.ToString(); break;
            case 1:
                game.dominoshkiMoving.namespritebutt = ChooseDom[1].image.sprite.name.ToString(); break;
            case 2:
                game.dominoshkiMoving.namespritebutt = ChooseDom[2].image.sprite.name.ToString(); break;
            case 3:
                game.dominoshkiMoving.namespritebutt = ChooseDom[3].image.sprite.name.ToString(); break;
            case 4:
                game.dominoshkiMoving.namespritebutt = ChooseDom[4].image.sprite.name.ToString(); break;
        }
        if (b >= 0)
        {
            game.dominoshkiMoving.ChooseBone();
        }
        else Debug.Log("Ничего не выбрано");
    }
    
}
