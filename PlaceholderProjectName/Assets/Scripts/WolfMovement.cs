using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WolfMovement : MonoBehaviour
{
    public float horizontal, vertical;
    private Rigidbody rb;
    public Animator anim;
    public float movementSpeed = 20f;
    public int movementDir = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        StartCoroutine(WaitForDirChange());
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator WaitForDirChange()
    {
        while(true)
        {
            horizontal = Random.Range(-1, 2);
            vertical = Random.Range(-1, 2);
            if (horizontal == -1)
            {
                movementDir = 4;
            }
            else if (horizontal == 1)
            {
                movementDir = 2;
            }
            else
            {
                if (vertical == -1)
                {
                    movementDir = 3;
                }
                else if (vertical == 1)
                {
                    movementDir = 1;
                }
                else
                {
                    movementDir = movementDir * -1;
                }
            }
            
            anim.SetInteger("MovementDirection", movementDir);
            yield return new WaitForSeconds(3);
        }
    }
}
