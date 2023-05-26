using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private GameObject _particleSystem;
    [SerializeField] private bool isRepeat;
    private Animator anim;
    private void Awake()
    {
        if(isRepeat)
            anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isRepeat)
        {
            Particle_Play();
        }
        else
        {
            AnimationPlay();
        }
    }

    private void AnimationPlay()
    {
        if (anim.GetInteger("BlockLife") <= 0) return;
        anim.SetBool("Up",true);
        anim.SetInteger("BlockLife",(anim.GetInteger("BlockLife") - 1));
    }

    public void AnimationStop()
    {
        anim.SetBool("Up", false);
    }
    private void Particle_Play()
    {
        Instantiate(_particleSystem, transform.position, transform.rotation);
            Destroy(gameObject, 0.15f);
    }

}
