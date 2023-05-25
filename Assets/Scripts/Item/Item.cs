using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // ������ �ڵ�
    // 0 = ����
    // 1 = �Ҳ�      
    // 2 = ��        
    // 3 = ����  
    [SerializeField] private int itemCode;
    [SerializeField] private string itemName;
    [SerializeField] private Transform blockPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isMove;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player") // �÷��̾�� ����� ��
        {
            // ���ӸŴ������� GetItem �Լ� ������ �ڵ�� �Բ� ȣ��
        }
    }

}
