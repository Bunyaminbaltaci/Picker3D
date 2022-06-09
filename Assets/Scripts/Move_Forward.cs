using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Movement/MoveForward")]

public class Move_Forward : Movement
{
    #region Veriables
    public float MoveSpeed;
 
    #endregion


    public override void DoMovement(Transform transform, Rigidbody rb)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, MoveSpeed);
    }
}
