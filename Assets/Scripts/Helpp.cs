using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dominos;

public class Helpp : MonoBehaviour
{
    public Button[] ChooseDom;
    Dominoshki d = new Dominoshki();
    private int b;
    

    private void Start()
    {
        Player p = new Player();
        p.ShowHand();

        for (int i = 0; i < p.Hand.Count; i++)
        {
            ChooseDom[i].image.sprite = Resources.Load<Sprite>("Textures/" + p.Hand[i]); //путь картинки
        }
        Debug.Log(p.Hand.Count);
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
        Player p = new Player();
        switch (b)
        {
            case 0:
                moving.a = ChooseDom[0].image.sprite.name.ToString(); break;
            case 1:
                moving.a = ChooseDom[1].image.sprite.name.ToString(); break;
            case 2:
                moving.a = ChooseDom[2].image.sprite.name.ToString(); break;
            case 3:
                moving.a = ChooseDom[3].image.sprite.name.ToString(); break;
            case 4:
                moving.a = ChooseDom[4].image.sprite.name.ToString(); break;
        }
        if (b >= 0)
        {
            moving.ChooseDomino();
                Debug.Log(p.Hand.Count);
        }
        else Debug.Log("Ничего не выбрано");
    }
}
