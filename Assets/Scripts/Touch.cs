using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    public void QuitOnscene()
    {
        SceneManager.LoadScene(0);
    }
}
