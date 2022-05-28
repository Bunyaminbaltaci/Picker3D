using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : ScriptableObject
{
    public abstract void DoMovement(Transform transform,Rigidbody rb);

   }
