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
        Debug.Log("콜리션엔터 발동");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("콜리션스테이 발동");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 발동");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("트리거 발동");

    }
}
