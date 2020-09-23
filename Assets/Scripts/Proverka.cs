using UnityEngine;
using Dominos;
using UnityEngine.UI;

public class Proverka : MonoBehaviour
{
    public Button[] ChooseDom;
    Dominoshki d = new Dominoshki();
    private int b;

    void Start() //метод отображения картинок домино
    {
        
        Player p = new Player();
        p.ShowHand();

        for (int i = 0; i < p.Hand.Count; i++)
        {
            ChooseDom[i].image.sprite = Resources.Load<Sprite>("Textures/" + p.Hand[i]); //путь картинки
        }
    }

    public void B1()
    {
        b = 0;
        Pr();
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
        switch(b)
        {
            case 0:
                d.a = ChooseDom[0].image.sprite.name.ToString(); break;
            case 1:
                d.a = ChooseDom[1].image.sprite.name.ToString(); break;
            case 2:
                d.a = ChooseDom[2].image.sprite.name.ToString(); break;
            case 3:
                d.a = ChooseDom[3].image.sprite.name.ToString(); break;
            case 4:
                d.a = ChooseDom[4].image.sprite.name.ToString(); break;
        }
        d.WriteJSON();
        DominoshkiMoving dominoshkiMoving = new DominoshkiMoving();
        dominoshkiMoving.ChooseDomino();
        Debug.Log(dominoshkiMoving.flag);
    }
}