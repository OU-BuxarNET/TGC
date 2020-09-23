using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class Interaction_game : MonoBehaviour //скрип взаиможействия с играми (пока ни к чему не подключен)
{
   // public static GameCount gamecount = new GameCount(ref g);
    private string json;
    private int a;
    private string Button;
    public GameObject Parent;
    
    public void ChooseObj() //выбор предмета
    {

    }
    void Awake()
    {
        //a = UnityEngine.Random.Range(0, 100);
    }
    private void GameList()
    {
        //список игр
    }
    public class GameCount
    {
        public string gamename { get; set; }

        public GameCount(string g)
        {
            gamename = g;
        }
    }
}
