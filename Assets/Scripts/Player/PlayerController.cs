using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float runSpeed;
    [SerializeField] private float runRepeat;

    [SerializeField] Transform jumpBoxCheckPoint;
    [SerializeField] Transform itemBoxPoint;

    [SerializeField] LayerMask groundLayer;
    

    private Rigidbody2D rb;
    private Vector2 inputDir;
    private bool isGround;
   
    private Transform target;

    public enum State { BigMario, SmallMario, FireMario, Death, Size }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Move();

    }
    private void FixedUpdate()
    {
        //GetCoin();
    }

    public void Move()
    {
        if (rb.velocity.x > moveSpeed)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (inputDir.x < 0 && rb.velocity.x > -moveSpeed)
            rb.AddForce(Vector2.right * inputDir.x * moveSpeed, ForceMode2D.Force);
        else if (inputDir.x > 0 && rb.velocity.x < moveSpeed)
            rb.AddForce(Vector2.right * inputDir.x * moveSpeed, ForceMode2D.Force);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower * (moveSpeed * 1.2f), ForceMode2D.Impulse);
    }

    public void Run()
    { 
       
    }

    private void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        
    }

    private void OnJump(InputValue value)
    {
        GroundCheck();
        if (!isGround)
            return;
        Jump();
    }

    private void OnRun(InputValue value)
    {   
        
         if (value.isPressed)
         {
             if (rb.velocity.x > runSpeed)
                 rb.velocity = new Vector2(runSpeed, rb.velocity.y);
             if (inputDir.x < 0 && rb.velocity.x > -runSpeed)
                 rb.AddForce(Vector2.right * inputDir.x * runSpeed, ForceMode2D.Impulse);
             else if (inputDir.x > 0 && rb.velocity.x < runSpeed)
                 rb.AddForce(Vector2.right * inputDir.x * runSpeed, ForceMode2D.Impulse);
         }
         
         else
         { 
             return;
         }
        
    }   
    
    private void GroundCheck()
    {

        RaycastHit2D hit = Physics2D.Raycast(jumpBoxCheckPoint.position, Vector2.down, 1.05f, groundLayer);
        if (hit.collider != null)
        {
            isGround = true;
            Debug.DrawRay(transform.position, new Vector3(hit.point.x, hit.point.y, 0) - transform.position, Color.red);
        }
        else
        {
            isGround = false;
            Debug.DrawRay(transform.position, Vector3.down * 1.05f, Color.green);
        }
    }

    /*
    private void GetCoin()
    {
        RaycastHit2D hit = Physics2D.Raycast(itemBoxPoint.position,Vector2.right, 1.05f, coinLayer);
        if (hit.collider != null)
        {
            isCoin = true;
            Debug.Log("ÄÚÀÎÈ¹µæ");
            Debug.DrawRay(transform.position, new Vector3(hit.point.x, hit.point.y, 0) - transform.position, Color.red);
        }
        else
        {
            isCoin = false;
            Debug.Log("ÄÚÀÎ¹ÌÈ¹µæ");
            Debug.DrawRay(transform.position, Vector3.right * 1.05f, Color.green);
        }
    }
    */

    // Ãæµ¹
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Coin")   // ÄÚÀÎ
        {

            // ÄÚÀÎÀÌ 1 Áõ°¡ÇÑ´Ù
            Destroy(collision.gameObject);
            GameManager.Data.AddCoinCount(1);
            GameManager.Data.AddScoreCount(1000);
            Debug.Log("ÄÚÀÎÈ¹µæ");
        }

        if (collision.collider.gameObject.name == "Mushroom")   // ¹ö¼¸
        {
            // smallMario°¡ bigMario·Î »óÅÂ ÀüÈ¯
            Destroy(collision.gameObject);
            Debug.Log("¹ö¼¸È¹µæ");
        }
        if (collision.collider.gameObject.name == "Flower")   // ²É
        {
            // smallMario°¡ bigMario·Î »óÅÂ ÀüÈ¯
            // bigMario°¡ fireMario·Î »óÅÂ ÀüÈ¯
            Destroy(collision.gameObject);
            Debug.Log("²ÉÈ¹µæ");
        }

    }

    
    private void playersit()
    {

    }

    private void sizeUp()
    {

    }

    private void sizeDown()
    {

    }

    private void powerUp()
    {

    }

    private void powerDown()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{collision.collider.name} ºÎ‹HÈû");
    }
}
