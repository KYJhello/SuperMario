using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
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

    public PlayerState currentState;
    private Rigidbody2D rb;
    private Vector2 inputDir;
    private bool isGround;
   
    private Transform target;

    public enum State { BigMario, SmallMario, FireMario, Death, Size }

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
      

    }

    

    private void OnRunPerformed(InputAction.CallbackContext context)
    {
        float runInput = context.ReadValue<float>();

        if (runInput != 0)
        {
            if (rb.velocity.x > runSpeed && runInput > 0)
                rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            else if (rb.velocity.x < -runSpeed && runInput < 0)
                rb.velocity = new Vector2(-runSpeed, rb.velocity.y);

            rb.AddForce(Vector2.right * runInput * runSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnRunCanceled(InputAction.CallbackContext context)
    {
        // Run ¾×¼Ç Ãë¼Ò ½Ã ½ÇÇàÇÒ ÄÚµå (¿©±â¼­´Â ¾Æ¹« ÀÛ¾÷µµ ¼öÇàÇÏÁö ¾ÊÀ½)
    }

    private void Start()
    {
        currentState = new SmallMarioState(this);
    }

    private void Update()
    {
        Move();
        currentState.Update();

    }
    private void FixedUpdate()
    {
        //GetCoin();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
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
        float runInput = value.Get<float>();

        if (runInput != 0)
        {
            if (rb.velocity.x > runSpeed && runInput > 0)
                rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            else if (rb.velocity.x < -runSpeed && runInput < 0)
                rb.velocity = new Vector2(-runSpeed, rb.velocity.y);

            rb.AddForce(Vector2.right * runInput * runSpeed, ForceMode2D.Impulse);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
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
