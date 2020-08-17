/*
Written by Max Logan, August 2nd, 2020
Starter Code from https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal, vertical;
    Rigidbody2D rb; 

    public float runSpeed = 20f;
    public float meleeDamage = 10f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // melee attack
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal * runSpeed));
    }

    void MeleeAttack()
    {
        // start animation
        playerAnimator.SetTrigger("Attack");
        // check for collision
        // do damage
    }
}
