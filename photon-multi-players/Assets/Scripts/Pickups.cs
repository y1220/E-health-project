using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum PickupTypes
{
    Gold,
    Health
}

public class Pickups : MonoBehaviour
{
    public PickupTypes types;
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!PhotonNetwork.IsMasterClient)
            return;

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (types == PickupTypes.Gold)
            {
                Debug.Log("hi");
                player.photonView.RPC("GetGold", player.photonPlayer, value);
            }else if (types == PickupTypes.Health)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "IndoDoors");
            }
            
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
