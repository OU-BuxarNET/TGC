using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationForDomino : MonoBehaviour
{
    public void StartT_TheOpponentHasNoBones()
    {
        Animation T_TheOpponentHasNoBones = GetComponent<Animation>();

        T_TheOpponentHasNoBones.Play("T_TheOpponentHasNoBones_Animation");
    } 
    public void StartT_T_NoBonesInTheBar()
    {
        Animation T_NoBonesInTheBar = GetComponent<Animation>();

        T_NoBonesInTheBar.Play("T_NoBonesInTheBar_Animation");
    }
}