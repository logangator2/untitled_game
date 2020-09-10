using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfStats : MonoBehaviour
{
    public float health = 20, damage = 3;
    private float fullHealth = 20;
    private float speed, healthFill;
    public Image healthBarFG;
    // For red hit animation
    public SpriteRenderer wolfSprite;
    public Rigidbody2D rb;
    public float knockback;
    //private Vector2 currentLoc;

    // Start is called before the first frame update
    void Start()
    {
        healthFill = health / fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(int damageReceived, Vector2 hittersVect)
    {
        //Debug.Log(hittersVect);
        //Debug.Log(transform.position + transform.GetChild(0).position);
        healthBarFG.transform.parent.gameObject.SetActive(true);
        health -= damageReceived;
        healthFill = health / fullHealth;
        healthBarFG.fillAmount = healthFill;
        //currentLoc = new Vector2(transform.position.x, transform.position.y);
        //rb.bodyType = RigidbodyType2D.Dynamic;
        //rb.gravityScale = 0;
        if ((transform.GetChild(0).position.x) > hittersVect.x)
        {
            Debug.Log("Force right");
            rb.AddForce(new Vector2(knockback, 0));
        }
        else
        {
            Debug.Log("Force left");
            rb.AddForce(new Vector2(-knockback, 0));
        }
        StartCoroutine(redFromHit());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator redFromHit()
    {
        wolfSprite.color = new Color(1f, 0.2f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        wolfSprite.color = new Color(1f, 1f, 1f);
    }
}
