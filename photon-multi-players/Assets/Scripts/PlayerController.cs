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

    }

    private void Attack()
    {

    }
}
