using UnityEngine;
using Dominos;

public class Proverka : MonoBehaviour
{
    void Start()
    {
        DominoshkiMoving dom = new DominoshkiMoving();
        dom.ChooseDomino();
    }
}
