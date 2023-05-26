using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private GameObject myChildObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 시작");
    }

}
