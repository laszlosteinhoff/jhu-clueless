using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject startupUI;
    public GameObject waitingUI;

    // Start is called before the first frame update
    void Start()
    {
        startupUI.SetActive(true);
    }

    public void WaitingForStart()
    {
        startupUI.SetActive(false);
        waitingUI.SetActive(true);
    }

}
