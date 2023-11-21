using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    public Transform attackpoint;
    public int damage;
    public float attackRange;
    public float attackDelay;
    public float lastAttackTime;

    [HideInInspector]
    public int id;
    public Animator playerAnim;
    public Rigidbody2D rig;
    public Player photonPlayer;
    public SpriteRenderer sr;
    // public HeaderInfo headerInfo;
    public float moveSpeed;
    public int gold;
    public int currentHP;
    public int maxHP;
    public bool dead;

    public static PlayerController me;

    [PunRPC]
    public void Initialized(Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;
        GameManager.instance.players[id - 1] = this;
        if (player.IsLocal)
        {
            me = this;
        }
        else
        {
            // rig.isKinematic = false;
            rig.simulated = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;
        Move();

        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime > attackDelay)
            Attack();
    }

    private void Move()
    {
        // get the horizontal and vertical input value
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // apply the value to our velocity
        rig.velocity = new Vector2(x, y) * moveSpeed;

        if (x != 0 || y != 0)
        {
            playerAnim.SetBool("Move", true);

            if (x > 0)
            {
                photonView.RPC("FlipRight", RpcTarget.All);
            }
            else
            {
                photonView.RPC("FlipLeft", RpcTarget.All);
            }
            }
        else
        {
            playerAnim.SetBool("Move", false);
        }

    }

    private void Attack()
    {

    }

    [PunRPC]
    void FlipRight()
    {
        sr.flipX = false;
    }
    
    [PunRPC]
    void FlipLeft()
    {
        sr.flipX = true;
    }
    
    
}
