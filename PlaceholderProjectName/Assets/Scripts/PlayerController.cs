/*
Written by Max Logan, August 2nd, 2020
Starter Code from https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float horizontal, vertical;
    Rigidbody2D rb;

    public BoxCollider2D swordCollider;
    public Image healthBarFG;
    public SpriteRenderer playerSprite;
    public float runSpeed = 20f;
    //public float meleeDamage = 10f;
    public Animator playerAnimator;
    public float health = 100, fullHealth = 100, healthFill;

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
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) 
            && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
        {
            MeleeAttack();
        }
    }

    void FixedUpdate()
    {
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
        {
            rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal * runSpeed));
        if (horizontal < 0f)
        {
            // Facing Left
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontal > 0f)
        {
            // Facing Right
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void MeleeAttack()
    {
        // start animation
        playerAnimator.SetTrigger("Attack");
        // check for collision
        swordCollider.enabled = true;
        StartCoroutine(WaitForAnimation(playerAnimator, DisableSwordCollider, "PlayerAttack"));
        // maybe add stun effect on hit enemies
        //StartCoroutine(WaitForSecs(1.0f, DisableSwordCollider));
    }

    public void PlayerReduceHealth(float damageReceived)
    {
        health -= damageReceived;
        healthFill = health / fullHealth;
        healthBarFG.fillAmount = healthFill;
        StartCoroutine(redFromHit());
        if (health <= 0)
        {
            Debug.Log("Player died.");
            Application.Quit();
        }
    }

    public void DisableSwordCollider()
    {
        swordCollider.enabled = false;
    }

    private IEnumerator WaitForAnimation(Animator anim, Action doAfter, string currentAnimName)
    {
        do
        {
            yield return null;
        }
        while (anim.GetCurrentAnimatorStateInfo(0).IsName(currentAnimName));
        doAfter();
    }

    private IEnumerator WaitForSecs(float waitTime, Action doAfter)
    {
        yield return new WaitForSeconds(waitTime);
        doAfter();
    }

    private IEnumerator redFromHit()
    {
        playerSprite.color = new Color(1f, 0.2f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        playerSprite.color = new Color(1f, 1f, 1f);
    }
}
