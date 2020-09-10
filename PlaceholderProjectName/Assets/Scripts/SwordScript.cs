using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwordScript : MonoBehaviour
{
    public int damage = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.parent.CompareTag("Enemy"))
        {
            col.gameObject.GetComponentInParent<WolfStats>().ReduceHealth(damage, transform.parent.transform.position);
            //StartCoroutine(WaitForEOF(GetComponentInParent<PlayerController>().DisableSwordCollider));
        }
    }

    IEnumerator WaitForEOF(Action doAfter)
    {
        yield return new WaitForEndOfFrame();
        doAfter();
    }
}
