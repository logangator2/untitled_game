using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAlert : MonoBehaviour
{
    public BoxCollider2D alertBox;
    public GameObject player;
    public WolfMovementLR wolfMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            wolfMoveScript.enabled = true;
        }
    }
}
