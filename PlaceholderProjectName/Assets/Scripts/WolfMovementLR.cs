using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfMovementLR : MonoBehaviour
{
    public float horizontal, vertical;
    private Rigidbody2D rb;
    public Animator anim;
    public float movementSpeed = 20f;
    public int movementDir = 0;
    public GameObject player;
    public NavMeshAgent agent;
    private Vector3 oldPosition;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //StartCoroutine(WaitForDirChange());
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.GetComponentInChildren<NavMeshAgent>().isOnNavMesh);
        // Moves the sprite with the agent.
        velocity = oldPosition - transform.position;
        oldPosition = transform.position;
        horizontal = 0;
        vertical = 0;
        if (velocity.x > 0f)
        {
            // Moving left
            horizontal = -1;
        }
        else if (velocity.x < 0f)
        {
            // Moving right
            horizontal = 1;
        }
        if (velocity.y > 0f)
        {
            // Moving down
            vertical = -1;
        }
        else if (velocity.y < 0f)
        {
            // Moving up
            vertical = 1;
        }

        // TODO: Clean code below, it's mostly redundant because of the above.
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
            movementDir = movementDir * -1;
        }

        anim.SetInteger("MovementDirection", movementDir);

        transform.position = agent.transform.position;
        agent.destination = player.transform.position;
        //rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
        //localVelocity = transform.InverseTransformDirection(rb.velocity);
        //Debug.Log(localVelocity);
    }

    void FixedUpdate()
    {
        
    }

    // TODO: Change sprite direction based on movement direction
    IEnumerator WaitForDirChange()
    {
        while(true)
        {
            horizontal = Random.Range(-1, 2);
            vertical = Random.Range(-1, 2);
            
            yield return new WaitForSeconds(3);
        }
    }
}
