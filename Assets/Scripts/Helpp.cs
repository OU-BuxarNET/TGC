using Domino1;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Helpp : MonoBehaviour
{
    public GameObject Parent; //Родительский объект на сцене, должен находиться в Canvas
    static GameObject [] But;
    private int b = 0;
    private int j;
    Game game; 
    public static string play = "comp";
    //Animation RuttleBones = new Animation();   
  
    public void Start() // сделать ход
    { 
        if (LogicComp.difficutlylvl != "easy")
        {
            Debug.Log(LogicComp.difficutlylvl);
        }
        else
        {
            game = new Game();
            game.StartGame();
            ButHandPlayer();
            game.Met();
        } 
    }
    void ButHandPlayer()
    {
        But = new GameObject[Board.Hand.Count];
        for (int i = 0; i < Board.Hand.Count; i++)
        {
            float PosX = -300 + i * 100f; // размер смещения
            But[i] = Instantiate(Resources.Load("Button", typeof(GameObject)), transform, false) as GameObject; //загружаем копию префаба из ресурсов
            But[i].transform.SetParent(Parent.transform); //Помещаем кнопку к родителю
            But[i].transform.localPosition = new Vector3(PosX, -10f, 0f); //смещаем кнопки по Х
            j = i + 1;
            But[i].name = "B" + j.ToString(); // дополняем кнопки нумерацией 
            But[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Board.Hand[i]); // присваиваем спрайты кнопкам    
        }
        ButD();
        Butr();
    }
    void ButD()
    {
        But[0].GetComponent<Button>().onClick.AddListener(() => b = 1);
        But[1].GetComponent<Button>().onClick.AddListener(() => b = 2);
        But[2].GetComponent<Button>().onClick.AddListener(() => b = 3);
        But[3].GetComponent<Button>().onClick.AddListener(() => b = 4);
        But[4].GetComponent<Button>().onClick.AddListener(() => b = 5);
        But[5].GetComponent<Button>().onClick.AddListener(() => b = 6);
        But[6].GetComponent<Button>().onClick.AddListener(() => b = 7);
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

        if (Moving.first == true)
        {
            Game.moving.goPos[27].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
            Game.moving.goPos[27].GetComponent<Image>().color = color;
        }
        for (int i = 0; i < Game.moving.goPos.Length; i++)
        {
            if (Game.moving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true && Game.moving.goPos[i].GetComponent<Image>().sprite.name != Moving.namespritebutt)
            {
                Game.moving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                Game.moving.goPos[i].GetComponent<Image>().color = color;
            }
        }
    }
    float GameSeconds = 0;
    float GameMinutes = 0;
    private void Update()
    {
        //GameObject gameScene = GameObject.Find("P_Game1");
        //RuttleBones.Play(); 
        GameObject timetext = GameObject.Find("T_Time");
        GameSeconds += Time.deltaTime;
        timetext.GetComponent<Text>().text = (Math.Round(GameMinutes, 0) + ":" + Math.Round(GameSeconds, 0)).ToString();
        if (GameSeconds > 60.0f)
        {
            GameMinutes += 1.0f;
            GameSeconds = 0.0f;
        }
        if (Moving.first == false && Move.next_move == "player")
        {
            Game.moving.ChangePos();
        }
        else
        {
            if (Move.next_move == "comp")
                Move1();
        }
    }
    public void Move1()
    {
        Color color = new Color(1f, 1f, 1f, 0.7f);
        Game.moving.PosGoHand();
        if (b > 0)
        {
            game.MakeMove();
            if (Move.next_move == "player")
            {
                if (Moving.LorR == false)
                {
                    Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.namespritebutt);
                    Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().color = color;
                }
                else
                {
                    Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.namespritebutt);
                    Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().color = color;
                }
                Board.HandComp.RemoveAt(b - 1);
                Destroy(But[b - 1]);
                WayTrue();
                Move.next_move = "comp";
                game.MakeMove();
            }
        }
        else Debug.Log("Ничего не выбрано");

        if (Move.next_move == "comp")
        {
            game.MakeMove();
            if (Moving.LorR == false)
            {
                Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.namespritebutt);
                Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().color = color;
            }
            else
            {
                Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.namespritebutt);
                Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().color = color;
            }
            Board.HandComp.RemoveAt(LogicComp.kolforCom);
            Game.moving.WhenCube();
            WayTrue();
            Move.next_move = "player";
        }
        b = 0;
        Moving.namespritebutt = null;
    }
    void Pr()
    {
        switch (b)
        {
            case 1:
                Moving.namespritebutt = But[0].GetComponent<Image>().sprite.name.ToString(); break;
            case 2:
                Moving.namespritebutt = But[1].GetComponent<Image>().sprite.name.ToString(); break;
            case 3:
                Moving.namespritebutt = But[2].GetComponent<Image>().sprite.name.ToString(); break;
            case 4:
                Moving.namespritebutt = But[3].GetComponent<Image>().sprite.name.ToString(); break;
            case 5:
                Moving.namespritebutt = But[4].GetComponent<Image>().sprite.name.ToString(); break;
            case 6:
                Moving.namespritebutt = But[5].GetComponent<Image>().sprite.name.ToString(); break;
            case 7:
                Moving.namespritebutt = But[6].GetComponent<Image>().sprite.name.ToString(); break;
        }
        if (b > 0)
        {
            Game.check.ChooseBone();
        }
    }
    public void TakeBar()
    {
        Game.board.TakeBar(true);
        for (int i = 0; i < But.Length; i++)
            Destroy(But[i]);
        ButHandPlayer();
        // шт = (количество домино на руке * размер домино - размер скрола) / размер домино
        GameObject T_RorLDominos = GameObject.Find("T_RorLDominos");
        GameObject I_RorLDominos = GameObject.Find("I_RorLDominos");
        double t = (Board.Hand.Count * 100 - 750) / 100;
        I_RorLDominos.transform.localPosition = new Vector2(330,-400);
        T_RorLDominos.GetComponent<Text>().text = (t + 1).ToString();
    }
}