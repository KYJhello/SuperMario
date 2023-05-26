using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController player;

    public PlayerState(PlayerController player)
    {
        this.player = player;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

public class BigMarioState : PlayerState
{
    public BigMarioState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // BigMario로 변환
    }

    public override void Update()
    {
 
    }

    public override void Exit()
    {
        // BigMario에서 풀릴때
        // 몬스터피격, 아이템(버섯) 획득
    }
}

public class SmallMarioState : PlayerState
{
    public SmallMarioState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // SmallMario로 변환
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        // SmallMario에서 풀릴때
        // 몬스터피격
    }
}

public class FireMarioState : PlayerState
{
    public FireMarioState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // FireMario로 변환
    }

    public override void Update()
    {
        // FireMario
    }

    public override void Exit()
    {
        // FireMario에서 풀릴떄
    }
}

public class DeathState : PlayerState
{
    public DeathState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // 죽음
    }
    public override void Update()
    {
        
    }

    public override void Exit()
    {
         
    }
}

