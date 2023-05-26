using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource backGroundMusic;

    [SerializeField] AudioSource gameWin;

    [SerializeField] AudioSource monsterHit;

    [SerializeField] AudioSource playerJump;
    [SerializeField] AudioSource playerDeath;
    [SerializeField] AudioSource playerAttack;
    [SerializeField] AudioSource playerHit;
    [SerializeField] AudioSource playerSizeUp;
    [SerializeField] AudioSource playerSizeDown;

    [SerializeField] AudioSource coinBlockHit;
    [SerializeField] AudioSource itemBlockHit;

    [SerializeField] AudioSource pipeEnter;
    [SerializeField] AudioSource pipeExit;

}
