﻿using Domino1;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Helpp : MonoBehaviour
{
    public GameObject Parent; //Родительский объект на сцене
    static GameObject[] But;
    private static int but = -1;
    private static int j;
    Game game;
    public static string play = "comp";
    public Transform Game1;
    GameObject P_EndOfRound;

    public void Start() // сделать ход
    {
        P_EndOfRound = GameObject.Find("P_EndOfRound");
        if (LogicComp.difficutlylvl != "easy") 
            Debug.Log(LogicComp.difficutlylvl); 
        else
        {
            game = new Game();
            game.StartGame();
            ButHandPlayer();
            GameObject B_TakeBar = GameObject.Find("B_TakeBar"); 
            B_TakeBar.GetComponent<Button>().interactable = false; 
        }
    }
    void ButHandPlayer() // создание кнопок (кости) в руке
    {
        But = new GameObject[Board.Hand.Count];
        for (int i = 0; i < Board.Hand.Count; i++)
        {
            float PosX = -300 + i * 100f; // размер смещения
            But[i] = Instantiate(Resources.Load("Button", typeof(GameObject)), transform, false) as GameObject; //загружаем копию префаба из ресурсов
            But[i].transform.SetParent(Parent.transform); //Помещаем кнопку к родителю
            But[i].transform.localPosition = new Vector3(PosX, -10f, 0f); //смещаем кнопки по Х
            j = i;
            But[i].name = "B" + (j + 1).ToString(); // дополняем кнопки нумерацией 
            But[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Board.Hand[i]); // присваиваем спрайты кнопкам  
            int j2 = j;
            But[i].GetComponent<Button>().onClick.AddListener(() => Pr(j2));
        }
    }
    public void WayTrue() // присваиваю картинки куда можно положить след. кость
    {
        Color color = new Color(1f, 1f, 1f, 0.5f);

        if (Moving.first == true)
        {
            Game.moving.goPos[27].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
            Game.moving.goPos[27].GetComponent<Image>().color = color;
        }
        else
        {
            Game.moving.WhenCube();
            for (int i = 0; i < Game.moving.goPos.Length; i++)
            {
                if (Game.moving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true)
                {
                    Game.moving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                    Game.moving.goPos[i].GetComponent<Image>().color = color;
                }
            }
        } 
    }
    void DoubleDom() // чтобы игрок мог положить только с одной стороны цепи 
    {
        if (Moving.first == false && Move.next_move == "player")
        {
            if (Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<BoxCollider2D>().isTrigger == true
                && Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().sprite.name != "WhiteSquare")
            {
                if (Moving.linkedList.head.Data > 40 && Moving.linkedList.head.Data <= 47)
                    Game.moving.goPos[Moving.linkedList.head.Data + 1].GetComponent<BoxCollider2D>().isTrigger = false;
                else
                    Game.moving.goPos[Moving.linkedList.head.Data - 1].GetComponent<BoxCollider2D>().isTrigger = false;
            } 
            else if (Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<BoxCollider2D>().isTrigger == true
                && Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite.name != "WhiteSquare") 
            {
                if (Moving.linkedList.head.Data >= 0 && Moving.linkedList.head.Data <= 7)
                    Game.moving.goPos[Moving.linkedList.tail.Data - 1].GetComponent<BoxCollider2D>().isTrigger = false;
                else
                    Game.moving.goPos[Moving.linkedList.tail.Data + 1].GetComponent<BoxCollider2D>().isTrigger = false;
            } 
        }
    } 
    void DeleteDom() // если игрок выбрал кость и поставил на поле, он может убрать её
    {
        int layerMask = 1 << 8;
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0)) 
        {
            var hit = Physics2D.Raycast(CurMousePos, Vector2.zero); 
            if (Physics2D.Raycast(CurMousePos, Vector2.zero, Mathf.Infinity, layerMask) && hit.collider.isTrigger == true &&
                Game.moving.goPos[Int32.Parse(hit.collider.name)].GetComponent<Image>().sprite.name != "WhiteSquare")
            {
                WayTrue();
                Game.moving.MovePos();
            }
        }
    }
    private void Update()
    {
        Timer();
       
        if (P_EndOfRound.transform.localPosition != new Vector3(0, 0, 0))
        { 
            if (Moving.first == false && Move.next_move == "player" && but >= 0)
            {
                DeleteDom();
                if (Game.moving.ChangePos() == false)
                {
                    //AminPlay();
                    //Invoke("Anim", 0.12f); 
                }
                else
                {
                    SpriteDomino(); // ставим спрайт домино на поле  
                    Game.moving.MovePos();
                    DoubleDom();
                }     
            }
            else
            {
                if (Move.next_move == "comp")
                    Move1();
            }
        }
        GameObject T_RorLDominos = GameObject.Find("T_RorLDominos");
        GameObject I_RorLDominos = GameObject.Find("I_RorLDominos");
        if (But.Length <= 7)
        { 
            I_RorLDominos.transform.localPosition = new Vector2(830, -400);
            T_RorLDominos.GetComponent<Text>().text = 0.ToString();
        }
        else
        {
            double t = (Board.Hand.Count * 100 - 750) / 100;
            I_RorLDominos.transform.localPosition = new Vector2(330, -400);
            T_RorLDominos.GetComponent<Text>().text = (t + 1).ToString();
        }
    }
    float GameSeconds = 0;
    float GameMinutes = 0;
    void Timer() // секундомер
    {
        GameObject timetext = GameObject.Find("T_Time");
        GameSeconds += Time.deltaTime;
        timetext.GetComponent<Text>().text = (Math.Round(GameMinutes, 0) + ":" + Math.Round(GameSeconds, 0)).ToString();
        if (GameSeconds > 60.0f)
        {
            GameMinutes += 1.0f;
            GameSeconds = 0.0f;
        }
    }
    public void Move1() // сделать ход
    {
        Game.moving.PosGoHand();
        if (Move.next_move == "player")
        {
            if (but >= 0 && Moving.CheckDomino[0] != null)
            {
                game.MakeMove(); 
                for (int i = 0; i < But.Length; i++)
                    Destroy(But[i]);
                Board.Hand.RemoveAt(but);
                ButHandPlayer();
                SpriteDomino();
                Move.next_move = "comp";
            }
            else Debug.Log("Ничего не выбрано");
        }
        WayTrue();
        Game.statistic.EndRound();
        if (P_EndOfRound.transform.localPosition != new Vector3(0, 0, 0))
        {
            if (Move.next_move == "comp")
            {
                game.MakeMove();
                SpriteDomino();
                if (Board.HandComp.Count > 0)
                    Board.HandComp.RemoveAt(LogicComp.kolforCom);
                WayTrue();
                Move.next_move = "player";
            }
            but = -1;
        }
        ToTake();
        Game.statistic.EndRound(); 
    }
    void ToTake() // активация кнопки взять из бара
    {
        if (Move.next_move == "player" && Moving.first == false && Board.Hand.Count != 0)
        {
            GameObject B_TakeBar = GameObject.Find("B_TakeBar");

            if (Move.next_move == "player" && Game.check.TakeBar(Board.Hand) == false)
            {
                B_TakeBar.GetComponent<Button>().interactable = true;
            }
            else if (Move.next_move == "player" && Game.check.TakeBar(Board.Hand) == true)
                B_TakeBar.GetComponent<Button>().interactable = false; 
        }
    }
    void SpriteDomino() // кость кладется на выбранный квадрат
    {
        Color color = new Color(1f, 1f, 1f, 0.7f);
        if (Moving.LorR == false)
        {
            Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.bak.tail.Data);
            Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().color = color; 
        }
        else
        {
            Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.bak.head.Data);
            Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().color = color; 
        } 
    }
    void Pr(int b) // нажатие на кость из руки
    { 
        but = b;

        if (Moving.first == true && Moving.bak.head != null)
            Moving.bak.Remove(Moving.bak.head.Data);

        Moving.CheckDomino.Insert(0, new Domino(But[but].GetComponent<Image>().sprite.name.ToString()));

        if (Moving.CheckDomino[0] != null && Moving.first == true)
        { 
            if (Moving.CheckDomino[0].Head == Moving.CheckDomino[0].Tail && Moving.CheckDomino[0].Head != 0)
            {  
                Moving.bak.Add(Moving.CheckDomino[0]);  
            }                
            else
            {
                Moving.bak.Delete_Index(0);
                AminPlay();
                Invoke("Anim", 0.12f); 
            }
        }
    }
    public void TakeBar() // взять из бара 
    {
        Game.board.TakeBar(true);
        Moving.bak.Remove(Moving.CheckDomino[1]);
        if (Board.bar.Count == 0) 
            Move1(); 
        else
        {
            for (int i = 0; i < But.Length; i++)
                Destroy(But[i]);
            ButHandPlayer(); 
            ToTake();
        }
    }
    public void EndGame() // конец игры
    {
        Color color = new Color(0, 0, 0, 0);
        game.EndGame();
        for (int i = 0; i < Game.moving.goPos.Length; i++)
        {
            Game.moving.goPos[i].GetComponent<Image>().sprite = null;
            Game.moving.goPos[i].GetComponent<Image>().color = color;
        }
        for (int i = 0; i < But.Length; i++)
            Destroy(But[i]);
        GameObject P_Win = GameObject.Find("P_Win"); 
        P_Win.transform.localPosition = new Vector2(-859, 773);
    }
    public void Trans() // скрытие панели "Конец раунда"
    {
        Statistic.endround = false;
        P_EndOfRound.transform.localPosition = new Vector3(-800, 0, 0);
    }
    void AminPlay() // для анимации дребезжания
    {
        for (int i = 0; i < But.Length; i++) 
            But[i].transform.rotation = Quaternion.Euler(0, 0, 10);  
    }
    void Anim() // для анимации дребезжания
    {
        for (int i = 0; i < But.Length; i++) 
            But[i].transform.rotation = Quaternion.Euler(0, 0, 0); 
    }  
}