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
    DominoshkiMoving moving = new DominoshkiMoving();
    public Text t ;
    private void Start()
    {
        p.ShowHand();
        for (int i = 0; i < p.Hand.Count; i++)
        {
            ChooseDom[i].image.sprite = Resources.Load<Sprite>("Textures/" + p.Hand[i]); //путь картинки
        }
        moving.PosGoHand();
    }
    public void Pos() // сделать ход
    {
        moving.PutDomino();
        moving.goPos[moving.startpos].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + moving.bak[0]);
        
    }
    void Secund()
    {
        Board board = new Board();
        board.Secundomer();
    }
    void Update()
    {
        Secund();
       // WayTrue();
    }
    public void WayTrue()// присваиваю картинки куда можно положить след. кость
    {
        Color color = new Color(1f, 1f, 1f, 0.5f);
        for (int i = 0; i < moving.goPos.Length; i++)
        {
            if (moving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true)
            {
                moving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                moving.goPos[i].GetComponent<Image>().color = color;
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
            moving.ChooseBone();
        }
        else Debug.Log("Ничего не выбрано");
    }
}
