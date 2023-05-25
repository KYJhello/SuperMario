using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoombaScripts : MonoBehaviour
{
    public enum State { Idle, Active, Die}

    [SerializeField] private float moveSpeed;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] LayerMask GoombaMask;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isWallExist;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isWallExist = false;
    }

    private void Update()
    {
        Move();
        if (isWallExist)
        {
            Turn();
            isWallExist=false;
        }
    }
    public void Move()
    {
        rb.velocity = new Vector2(-transform.right.x, rb.velocity.y);
    }
    public void Turn()
    {
        Debug.Log("Turn on");
        transform.Rotate(Vector3.up, 180);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger ON");
        
        if(other.gameObject.name == "Fire")
        {
            anim.SetBool("HitFire", true);
        }
        else if(other.gameObject.tag == "Object")
        {
            isWallExist = true;
        }
        else
        {
            anim.SetBool("MonsterDie", true);
        }
        
    }
}
