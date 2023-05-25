using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public abstract void Turn();
    public abstract void Move();
    public abstract bool IsForwardExist();

}
