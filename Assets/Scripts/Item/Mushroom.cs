using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Item, IMoveable, IBornToBlock
{
    private Rigidbody2D rb;
    [SerializeField] private Transform forwardCheckPoint;
    [SerializeField] private LayerMask wallMask;

    private void Awake()
    {
        itemInfo = Items.mushroom;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (IsForwardExist())
        {
            Turn(); 
        }
    }
    public bool IsForwardExist()
    {
        Debug.DrawRay(forwardCheckPoint.position, Vector2.down, Color.red);
        return Physics2D.Raycast(forwardCheckPoint.position, Vector2.down, 1f, wallMask);
    }

    public override void Move()
    {
        rb.velocity = new Vector2(transform.right.x * -moveSpeed, rb.velocity.y);
    }

    public void Rise()
    {
    }

    public override void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }


}
