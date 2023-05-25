using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // 아이템 코드
    // 0 = 버섯
    // 1 = 불꽃      
    // 2 = 별        
    // 3 = 코인  
    [SerializeField] private int itemCode;
    [SerializeField] private string itemName;
    [SerializeField] private Transform blockPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isMove;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player") // 플레이어에게 닿았을 때
        {
            // 게임매니저에서 GetItem 함수 아이템 코드와 함께 호출
        }
    }

}
