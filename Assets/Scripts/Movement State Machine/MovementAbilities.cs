using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.InputSystem;

public abstract class MovementAbilities
{
    public virtual void MovePlayer() { }
    public virtual void Dash() { }
}
