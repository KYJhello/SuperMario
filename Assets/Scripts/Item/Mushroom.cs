using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Item, IMoveable, IBornToBlock
{
    private Rigidbody2D rb;
    private bool doMove;
    [SerializeField] private Transform forwardCheckPoint;
    [SerializeField] private Transform upperCheckPoint;
    [SerializeField] private LayerMask wallMask;

    private void Awake()
    {
        itemInfo = Items.mushroom;
        doMove = false;
    } 

    private void Start()
    {
    }

    private void Update()
    {
        if (doMove)
        {
            Move();
        }
        else
        {
            Rise();
        }
    }

    private void FixedUpdate()
    {
        if (doMove)
        {
            if (IsForwardExist())
            {
                Turn();
            }
        }
    }

    public bool IsForwardExist()
    {
        Debug.DrawRay(forwardCheckPoint.position, Vector2.down, Color.red);
        return Physics2D.Raycast(forwardCheckPoint.position, Vector2.down, 1f, wallMask);
    }

    public override void Move()
    {
        rb.velocity = new Vector2(transform.right.x * moveSpeed, rb.velocity.y);
    }

    public void Rise()
    {
        transform.Translate(Vector2.up * 1 * Time.deltaTime); 
        Debug.Log("ø√∂Û∞°¡‡");
        if (transform.position.y > upperCheckPoint.position.y)
            DoneRise();
        
    }

    public void DoneRise()
    {
        Debug.Log("ø√∂Û∞°¡‡2");
        gameObject.AddComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        doMove = true;
    }
    
    public override void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }


}
