using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    private void Awake()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�ݸ��ǿ��� �ߵ�");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("�ݸ��ǽ����� �ߵ�");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ʈ���� �ߵ�");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Ʈ���� �ߵ�");

    }
}
