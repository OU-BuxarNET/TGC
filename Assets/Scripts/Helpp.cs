using Domino1;
using System;
using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic;

public class Helpp : MonoBehaviour
{
    public GameObject Parent; //Родительский объект на сцене
    static GameObject[] But; // костяшки игрока
    private static int but = -1; // номер кости для выбора
    private static int j;
    Game game; // главный класс библиотеки 
    public static string play = "comp";
    public Transform Game1;
    GameObject P_EndOfRound;
    GameObject P_Win;

    public GameObject T_NoBonesInTheBar;
    public GameObject T_TheOpponentHasNoBones;

    private AnimationForDomino AnimationForDomino;
    private AnimationNoBonesInTheBar AnimationNoBonesInTheBar;


    static int kolactivekube = 1; // количество активных 
   

    public void Start()
    {
        AnimationNoBonesInTheBar = T_NoBonesInTheBar.GetComponent<AnimationNoBonesInTheBar>();
        AnimationForDomino = T_TheOpponentHasNoBones.GetComponent<AnimationForDomino>();

        P_EndOfRound = GameObject.Find("P_EndOfRound");
        P_Win = GameObject.Find("P_Win");
        if (LogicComp.difficutlylvl != "easy")
            Debug.Log(LogicComp.difficutlylvl);
        else
        {
            game = new Game();
            game.StartGame();
            ButHandPlayer();
            GameObject B_TakeBar = GameObject.Find("B_TakeBar");
            B_TakeBar.GetComponent<Button>().interactable = false;

            if (Touch.point != "100")
            {
                Statistic.maxpoint = Int32.Parse(Touch.point);
                StatisticGoat.maxpoint = Int32.Parse(Touch.point);
            }
            else
            {
                Statistic.maxpoint = 100;
                StatisticGoat.maxpoint = 100;
            }
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

    public void WayTrue() // присваиваю картинки куда можно положить след. кость 3
    {
        Color color = new Color(1f, 1f, 1f, 0.5f);

        if (Moving.first == false)
        {
            Game.moving.WhenCube();
            for (int i = 0; i < Game.moving.goPos.Length; i++)
            {
                if (Game.moving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true)
                {
                    Game.moving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                    Game.moving.goPos[i].GetComponent<Image>().color = color;
                    kolactivekube = 2; // активно 2 варианта хода слева и справа 
                }
            }
        }
    }
    void OneDomOnTable()
    {
        if (Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<BoxCollider2D>().isTrigger == true
                    && Game.moving.goPos[Moving.linkedList.tail.Data].GetComponent<Image>().sprite.name != "WhiteSquare")
        {
            if (Moving.linkedList.head.Data >= 0 && Moving.linkedList.head.Data <= 7)
                Game.moving.goPos[Moving.linkedList.head.Data + 1].GetComponent<BoxCollider2D>().isTrigger = false;

            else if (Moving.linkedList.head.Data == 24 || Moving.linkedList.head.Data == 16 || Moving.linkedList.head.Data == 8)
                Game.moving.goPos[Moving.linkedList.head.Data - 8].GetComponent<BoxCollider2D>().isTrigger = false;

            else Game.moving.goPos[Moving.linkedList.head.Data - 1].GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<BoxCollider2D>().isTrigger == true
            && Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite.name != "WhiteSquare")
        {
            if (Moving.linkedList.tail.Data <= 47 && Moving.linkedList.tail.Data > 40)
                Game.moving.goPos[Moving.linkedList.tail.Data - 1].GetComponent<BoxCollider2D>().isTrigger = false;

            else if (Moving.linkedList.tail.Data == 31 || Moving.linkedList.tail.Data == 39 || Moving.linkedList.tail.Data == 40 || Moving.linkedList.tail.Data == 48)
                Game.moving.goPos[Moving.linkedList.tail.Data + 8].GetComponent<BoxCollider2D>().isTrigger = false;

            else Game.moving.goPos[Moving.linkedList.tail.Data + 1].GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    void DoubleDom() // чтобы игрок мог положить только с одной стороны цепи 
    {
        if (Moving.first == false && Move.next_move == "player")
        {
            if (Game.check.DoubleDomino(Board.Hand) == false)
            {
                OneDomOnTable();
                But[but].SetActive(false);
            }
            else
            {
                Debug.Log("Возможен дубль");
                if (Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite.name == Moving.CheckDomino[0].Name
                    && Moving.CheckDomino[0].Head == Moving.CheckDomino[0].Tail)
                { }
                else OneDomOnTable();
            }
        }
    }
    static bool animat = true;
    private void Update()
    {
        Timer();

        if (P_EndOfRound.transform.localPosition != new Vector3(0, 0, 0) && P_Win.transform.localPosition != new Vector3(0, 0, 0))
        {
            if (Game.statisticClassic.Fish() == true)
            {
                EndGame();
            } 

            //Interactivity(); // не дает нажать на кость если она не подходит.
             
            if (Moving.linkedList.head.Data == 6 || Moving.linkedList.tail.Data == 62)
            { 
                Endoffield();
            }

            if (Moving.first == false && Move.next_move == "player" && but >= 0) 
            {
                if (Game.moving.ChangePos(But) == false)
                {
                    if (animat == true)
                        Invoke("Anim", 0.80f);
                }
                else
                {
                    kolactivekube = 1;
                    animat = false;
                    SpriteDomino1(); // ставим спрайт домино на поле    
                    Game.moving.goPos[Moving.CheckId].transform.rotation = Quaternion.Euler(0, 0, 0);
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
            if (but >= 0 && Moving.CheckDomino1 != null && kolactivekube == 1)
            {
                game.MakeMove();
                for (int i = 0; i < But.Length; i++)
                    Destroy(But[i]);
                Board.Hand.RemoveAt(but);
                ButHandPlayer();
                Game.moving.Move();
                SpriteDomino();
                animat = true;
                //Game.logicComp.Fill();
                Move.next_move = "comp";
            }
            else
            {
                Rattle();
                Debug.Log("Ничего не выбрано");
            }
        }
        WayTrue();
        switch (Touch.version)
        {
            case "classic": Game.statisticClassic.EndRound(); break;
            case "goat": Game.statisticGoat.EndRound(); break;
        }

        GameObject T_TheOpponentHasNoBones = new GameObject();
        if (P_EndOfRound.transform.localPosition != new Vector3(0, 0, 0))
        {
            if (Move.next_move == "comp")
            {
                game.MakeMove();
                if (Game.TheOpponentHasNoBones == true) // если компу нечем ходить и в баре 0 костей
                {
                    AnimationForDomino.StartT_TheOpponentHasNoBones();
                    Move.next_move = "player";
                }
                else
                {
                    SpriteDomino();
                    if (Board.HandComp.Count > 0)
                        Board.HandComp.RemoveAt(LogicComp.kolforCom);
                    //Game.logicComp.Fill();
                    WayTrue();
                    Move.next_move = "player";
                }
            }
            but = -1;

            switch (Touch.version)
            {
                case "classic": Game.statisticClassic.EndRound(); break;
                case "goat": Game.statisticGoat.EndRound(); break;
            }
        }
        ToTake();
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
    void SpriteDomino() // кость кладется на выбранный квадрат (для последующих ходов) 
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
    void SpriteDomino1() // кость кладется на выбранный квадрат (для первого хода игрока)
    {
        Color color = new Color(1f, 1f, 1f, 0.7f);
        if (Moving.LorR == false)         
        {
            Game.moving.goPos[Moving.CheckId].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.CheckDomino1);
            Game.moving.goPos[Moving.CheckId].GetComponent<Image>().color = color; 
        }
        else
        {
            Game.moving.goPos[Moving.CheckId].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + Moving.CheckDomino1);
            Game.moving.goPos[Moving.CheckId].GetComponent<Image>().color = color;
        }
    }
    void Pr(int b) // нажатие на кость из руки
    {  
        but = b;  

        if (Moving.first == true && Moving.bak.head != null)
            Moving.bak.Remove(Moving.bak.head.Data);
        Moving.CheckDomino1 = new Domino(But[but].GetComponent<Image>().sprite.name.ToString());

        if (Moving.CheckDomino1 != null && Moving.first == true)
        {
            int CountDoubleInHand = 0; 
            for(int i = 0; i> Board.Hand.Count;i++)
            { 
                if (Board.Hand[i].Head == Board.Hand[i].Tail)
                    CountDoubleInHand++;
            }

            if (/*CountDoubleInHand != 0 &&*/ Moving.CheckDomino1.Head == Moving.CheckDomino1.Tail && Moving.CheckDomino1.Head != 0)
            { 
                Moving.bak.Add(Moving.CheckDomino1);
                DeleteDom();
                //But[but].transform.position = new Vector2(But[but].transform.position.x, 0.5f); // поднятие выбранной доминошки but

            }
            else  Rattle();
            {
                int MaxIndex = MaxDomino();

                if (Moving.CheckDomino1 == Board.Hand[MaxIndex])
                {
                    Moving.bak.Add(Moving.CheckDomino1);
                    DeleteDom();
                }
                else Rattle(); // дребезжание
            }
        }
    }
    int MaxDomino() // кость с максимальной суммой
    {
        int SumBone = 0;
        int MaxBone = Board.Hand[0].Head + Board.Hand[0].Tail;
        int MaxIndex = 0;
        for (int i = 0; i > Board.Hand.Count; i++)
        {
            SumBone = Board.Hand[i].Head + Board.Hand[i].Tail;
            if (MaxBone < SumBone)
            {
                MaxBone = SumBone;
                MaxIndex = i;
            }
        }
        return MaxIndex;
    }
    void Rattle() // дребезжание
    {
        AminPlay();
        Invoke("Anim", 0.12f);
        //Game.check.NotDouble();
        Move.next_move = "player";
        //if (Moving.CheckDomino1.Name != Check.playerMin)
        //{

        //}
        //else Moving.bak.Add(Moving.CheckDomino1);
    }
    void DeleteDom()
    {
        if (Moving.first == false)
        {
            Color color = new Color(1f, 1f, 1f, 0.5f);
            for (int i = 0; i < But.Length; i++)
                Destroy(But[i]);
            ButHandPlayer();
            for (int i = 0; i < Game.moving.goPos.Length; i++)
            {
                if (Game.moving.goPos[i].GetComponent<BoxCollider2D>().isTrigger == true && Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite.name != "WhiteSquare")
                {
                    Game.moving.goPos[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/WhiteSquare");
                    Game.moving.goPos[i].GetComponent<Image>().color = color;
                }
            }
            Game.moving.WhenCube();
        }
    }
    public void Interactivity()
    {
        if (Move.next_move == "player")
        for(int i = 0; i > Board.Hand.Count; i++)
        {
            if (Game.check.CheckOnCO(Board.Hand[i]) == false)
            {
                But[i+1].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void TakeBar() // взять из бара
    {
        if (Board.bar.Count == 0)
        {
            AnimationNoBonesInTheBar.StartT_T_NoBonesInTheBar();
            Move.next_move = "comp";
            Move1();
        }
        else
        {
            Game.board.TakeBar(true); 

            if (Board.bar.Count == 0)
            {
                Move.next_move = "comp";
                Move1();
            } 
            else
            {
                for (int i = 0; i < But.Length; i++)
                    Destroy(But[i]);
                ButHandPlayer();
                ToTake();
            }
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
        P_Win.transform.localPosition = new Vector2(-859, 773);
        kolactivekube = 1;
        Game.TheOpponentHasNoBones = false;
    }
    public void Trans() // скрытие панели "Конец раунда"
    {
        switch (Touch.version)
        {
            case "classic": Statistic.endround = false; break;
            case "goat": StatisticGoat.endround = false; break;
        }
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
    void Endoffield() // конец поля
    {
        Domino[] mas = new Domino[Moving.bak.Count];

        if (Moving.linkedList.head.Data == 6)
        {
            for (int i = 0; i < mas.Length; i++) // все доминошки, которые лежат на поле
            {
                mas[i] = Moving.bak.head.Data;
                Moving.bak.Remove(Moving.bak.head.Data);
            }

            // добавляем + 1 к хвосту
            if (Moving.linkedList.tail.Data == 31 || Moving.linkedList.tail.Data == 38)
                Moving.linkedList.Add(Moving.linkedList.tail.Data + 8);

            else if (Moving.linkedList.tail.Data == 40 || Moving.linkedList.tail.Data == 48)
                Moving.linkedList.Add(Moving.linkedList.tail.Data + 8);

            else if (Moving.linkedList.tail.Data > 40 && Moving.linkedList.tail.Data <= 47)
                Moving.linkedList.Add(Moving.linkedList.tail.Data - 1);

            else if (Moving.linkedList.tail.Data >= 27 && Moving.linkedList.tail.Data < 31)
                Moving.linkedList.Add(Moving.linkedList.tail.Data + 1);

            Moving.linkedList.Remove(Moving.linkedList.head.Data);

            Shift(mas);
        }
        else if (Moving.linkedList.tail.Data == 62)
        {
            for (int i = 0; i < mas.Length; i++) // все доминошки, которые лежат на поле
            {
                mas[i] = Moving.bak.tail.Data;
                Moving.bak.Remove(Moving.bak.tail.Data);
            }
            // добавляем + 1 к голове
            if (Moving.linkedList.tail.Data == 31 || Moving.linkedList.tail.Data == 38)
                Moving.linkedList.Add(Moving.linkedList.tail.Data - 8);

            else if (Moving.linkedList.tail.Data == 40 || Moving.linkedList.tail.Data == 48)
                Moving.linkedList.Add(Moving.linkedList.tail.Data - 8);

            else if (Moving.linkedList.tail.Data > 40 && Moving.linkedList.tail.Data <= 47)
                Moving.linkedList.Add(Moving.linkedList.tail.Data + 1);

            else if (Moving.linkedList.tail.Data > 27 && Moving.linkedList.tail.Data < 31)
                Moving.linkedList.Add(Moving.linkedList.tail.Data - 1); 

            Shift(mas);
        }

        Debug.Log(Moving.linkedList.Count);
    }
    void Shift(Domino[] mas)
    {
        Color color1 = new Color(1f, 1f, 1f, 0.7f);
        int[] mas1 = new int[Moving.linkedList.Count];

        for (int i = 0; i < mas1.Length; i++) // все квадратики, на которых лежат доминошки
        {
            mas1[i] = Moving.linkedList.head.Data;
            Moving.linkedList.Remove(Moving.linkedList.head.Data);
        }

        for (int i = 0; i < mas1.Length; i++) // убираем все домино с поля 
        {
            Moving.linkedList.Add(mas1[i]);
        }


        for (int i = 0; i < mas.Length; i++) // выкладываем на поле домино со сдвигом
        {
            Game.moving.goPos[Moving.linkedList.head.Data].GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/" + mas[i].ToString());
            Moving.linkedList.Remove(Moving.linkedList.head.Data);
        }

        if (Moving.linkedList.Count != 0)
        {
            Moving.linkedList.Clear();
        }

        Debug.Log(mas1.Length + " " + Moving.linkedList.Count);

        for (int i = 0; i < mas1.Length; i++) // убираем все домино с поля
        {
            Game.moving.goPos[mas1[i]].GetComponent<Image>().color = color1;
            Moving.linkedList.Add(mas1[i]);
        }

        for (int i = 0; i < mas.Length; i++) // заново заполняем список с домино
        {
            Moving.bak.Add(mas[i]);
        }

        WayTrue();
        RotateDomino();
    }
    void RotateDomino()
    {
        int[] masLinked = new int[Moving.linkedList.Count];

        for (int i = 0; i < masLinked.Length; i++)
        {
            masLinked[i] = Moving.linkedList.head.Data;
            Moving.linkedList.Remove(Moving.linkedList.head.Data);
        }

        for (int i = 0; i < masLinked.Length; i++)
        { 
            if (masLinked[i] == 5)
            {
                int rotate = Rotate(masLinked[i], new Domino(Game.moving.goPos[masLinked[i]].GetComponent<Image>().sprite.name), new Domino(Game.moving.goPos[masLinked[i]].GetComponent<Image>().sprite.name));
                Game.moving.goPos[masLinked[i]].transform.rotation = Quaternion.Euler(0, 0, rotate);
            }
            else if (i >= 1)
            {
                int rotate = Rotate(masLinked[i], new Domino(Game.moving.goPos[masLinked[i]].GetComponent<Image>().sprite.name), new Domino(Game.moving.goPos[masLinked[i - 1]].GetComponent<Image>().sprite.name));
                Game.moving.goPos[masLinked[i]].transform.rotation = Quaternion.Euler(0, 0, rotate);
            }
        }

        for (int i = 0; i < masLinked.Length; i++)
        {
            Moving.linkedList.Add(masLinked[i]);  
        }
    }
    int Rotate(int index, Domino domino, Domino lastdomino)
    {
        if (index == 16 || index == 8 || index == 39 || index == 48)
        {
            if (domino.Head == domino.Tail)
                return 90;
            else
            {
                if (domino.Tail == lastdomino.Tail || domino.Head == lastdomino.Tail)
                    return 180;
                else if (domino.Tail == lastdomino.Head || domino.Head == lastdomino.Head)
                    return 0;
            }
        }
        else if (index >= 24 && index <= 31 || index >= 56 && index <= 62 || index >= 0 && index <= 7)
        {
            if (domino.Head == domino.Tail)
                return 0;
            else
            {
                if (domino.Tail == lastdomino.Tail || domino.Head == lastdomino.Tail)
                    return 90;
                else if (domino.Tail == lastdomino.Head || domino.Head == lastdomino.Head)
                    return -90;
            }
        }
        else if (index >= 40 && index <= 47)
        {
            if (domino.Head == domino.Tail)
                return 0;
            else
            {
                if (domino.Tail == lastdomino.Tail || domino.Head == lastdomino.Tail)
                    return -90;
                else if (domino.Tail == lastdomino.Head || domino.Head == lastdomino.Head)
                    return 90;
            }
        }
        return 0;
    }
}