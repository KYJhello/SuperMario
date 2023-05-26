using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScripts : Monster
{
    public enum State { Idle, Left, Right, Die}

    private bool isDie = false;

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] LayerMask GoombaMask;
    [SerializeField] PlayerPrefs player;


    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D collider;
    public State curState;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerPrefs>();
        collider = GetComponent<Collider2D>();
        curState = State.Left;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if(curState == State.Left)
        {
            rb.velocity = new Vector2(transform.right.x * -1 * moveSpeed, rb.velocity.y);
        }
        else if(curState == State.Right)
        {
            rb.velocity = new Vector2(transform.right.x * moveSpeed, rb.velocity.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger ON");
        
        if(other.gameObject.name == "Fire")
        {
            anim.SetBool("HitFire", true);
            Die();
        }
        else if(other.gameObject.tag == "Object")
        {
            if(curState == State.Left) {
                Debug.Log("Left call");
                curState = State.Right;
            }
            else if (curState == State.Right) {
                Debug.Log("Right call");
                curState = State.Left;
            }
        }else if(other.gameObject.tag == "Player")
        {

        }
        else
        {
            anim.SetBool("MonsterDie", true);
        }
        
    }
    private void Die()
    {
        rb.gravityScale = 1.0f;
        rb.velocity = Vector2.up * 3;
        collider.enabled = false;
    }
}
