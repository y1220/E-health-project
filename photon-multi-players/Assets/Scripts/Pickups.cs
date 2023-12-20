using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum PickupTypes
{
    Gold,
    Door,
    Discussion,
    Library,
    CryingPlant,
    CryingWater,
    CryingFire,
    Postoffice,
    Bird
    
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
            }else if (types == PickupTypes.Door)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "HeldaDoors");
            }else if (types == PickupTypes.Discussion)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "IndoIndication");
            }else if (types == PickupTypes.Library)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "IndoLibrary");
            }else if (types == PickupTypes.CryingPlant)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCarePlant");
            }else if (types == PickupTypes.CryingWater)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCareWater");
            }else if (types == PickupTypes.CryingFire)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCareFire");
            }else if (types == PickupTypes.Postoffice)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "PostOffice");
            }else if (types == PickupTypes.Bird)
            {
                NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "LetterBird");
            }
            
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
