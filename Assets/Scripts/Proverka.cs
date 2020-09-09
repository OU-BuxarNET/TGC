using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dominos;

public class Proverka : MonoBehaviour
{
    void Start()
    {
        Board dominos = new Board();
        dominos.ShowAllDominos();
        for(int i = 0; i < dominos.image.Length; i++)
        Debug.Log(dominos.image[i]);
    }
}
