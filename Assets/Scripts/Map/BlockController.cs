using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 발동");
    }
}
