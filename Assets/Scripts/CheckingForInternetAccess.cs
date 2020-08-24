using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckingForInternetAccess : MonoBehaviour
{
    private bool Internet = false;
    public GameObject P_Warning;
    private string m_ReachabilityText;
    void Start()
    {
       /* CheckInternet();
        if (Internet == false)
        {
            P_Warning.SetActive(true);
        }
        else
            Debug.Log("Есть подкллючениe");*/
    }
    private bool CheckInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            m_ReachabilityText = "Not Reachable.";
            Internet = false;
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            m_ReachabilityText = "Reachable via carrier data network.";
            return Internet = true;
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            m_ReachabilityText = "Reachable via Local Area Network.";
            return Internet = true;
        }
        Debug.Log("Internet : " + m_ReachabilityText);
        return Internet;
    }
}

