using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_game : MonoBehaviour //скрип взаиможействия с играми (пока ни к чему не подключен)
{
    private List<GameCount> GameCount = new List<GameCount>();

    private void GameList()
    {
       // GameCount.Add(new GameCount(sqlreader[4].ToString()));
    }
}
public class GameCount
{
    public string gamename { get; set; }
    public GameCount(string g)
    {
        gamename = g;
    }
}
