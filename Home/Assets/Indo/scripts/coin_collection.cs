using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class counting_coins : MonoBehaviour
{
    private float coins = 0;
    public TMP_Text coinsText;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "COIN")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(coll.gameObject);
        }
    }
}
