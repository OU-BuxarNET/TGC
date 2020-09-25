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
    Player p = new Player();
    

    private void Start()
    {
        p.ShowHand();
        for (int i = 0; i < p.Hand.Count; i++)
        {
            ChooseDom[i].image.sprite = Resources.Load<Sprite>("Textures/" + p.Hand[i]); //путь картинки
        }
    } 
    void fd()
    {
        Board board = new Board();
        board.Secundomer();
    }
    void Update()
    {
        fd();
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
        DominoshkiMoving moving = new DominoshkiMoving();
        switch (b)
        {
            case 0:
                moving.namespritebutt = ChooseDom[0].image.sprite.name.ToString(); break;
            case 1:
                moving.namespritebutt = ChooseDom[1].image.sprite.name.ToString(); break;
            case 2:
                moving.namespritebutt = ChooseDom[2].image.sprite.name.ToString(); break;
            case 3:
                moving.namespritebutt = ChooseDom[3].image.sprite.name.ToString(); break;
            case 4:
                moving.namespritebutt = ChooseDom[4].image.sprite.name.ToString(); break;
        }
        if (b >= 0)
        {
            moving.ChooseDomino();
        }
        else Debug.Log("Ничего не выбрано");
    }
}
