using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenFirstScene : MonoBehaviour
{
    public static int NumberPreviousScene = 1; // номер предыдущей сцены
    public GameObject P_LoadApp;
    public GameObject P_Rools;
    public GameObject P_Welcome;
    public GameObject P_GameCount;

    // Start is called before the first frame update
    void Start()
    {
        if (NumberPreviousScene == 2)
        {
            P_LoadApp.SetActive(false);
            P_Rools.SetActive(false);
            P_Welcome.SetActive(true);
            P_GameCount.SetActive(true);
            NumberPreviousScene = 1;
        }
    }
}
