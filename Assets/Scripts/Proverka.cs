using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dominos;

public class Proverka : MonoBehaviour
{
    void Start()
    {
        Dominoshki dominoshki = new Dominoshki();
        dominoshki.WriteJSON();
    }
}
