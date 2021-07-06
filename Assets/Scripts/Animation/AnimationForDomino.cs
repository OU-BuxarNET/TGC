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
  
}