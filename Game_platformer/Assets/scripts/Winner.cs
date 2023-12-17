using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Winner : MonoBehaviour
{
    [SerializeField] GameObject VictoryT;
    [SerializeField] GameObject BMenu;
    [SerializeField] GameObject BResp;

    private void Start ()
    {
        VictoryT.SetActive(false);
        Time.timeScale = 1;
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            VictoryT.SetActive(true);
            BMenu.SetActive(true);
            BResp.SetActive(true);
            Time.timeScale = 0;
        }
    }
}


