using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNoBonesInTheBar : MonoBehaviour
{
    public void StartT_T_NoBonesInTheBar()
    {
        Animation T_NoBonesInTheBar = GetComponent<Animation>();

        T_NoBonesInTheBar.Play("T_NoBonesInTheBar_Animation");
    }
}
