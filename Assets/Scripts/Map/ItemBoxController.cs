using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBoxController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject item;
    private void Awake()
    {
       anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       AnimationPlay();
    }

    private void AnimationPlay()
    {
        if (anim.GetInteger("BlockLife") <= 0) return;
        anim.SetInteger("BlockLife", (anim.GetInteger("BlockLife") - 1));
    }

    public void PopItem()
    {
        Debug.Log("¿À¸¶ÀÌ°«");
        item.SetActive(true);
    }
}
