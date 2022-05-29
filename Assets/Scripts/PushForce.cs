using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Movement/PushAndForce")]

public class PushForce : Movement
{
    public override void DoMovement(Transform transform, Rigidbody rb)
    {
        //karakter hareketi düzgün saðlanamadý.
        if (Input.GetMouseButtonDown(0))
        {
           

                rb.AddRelativeForce(new Vector3(0,1f,20f*rb.mass),ForceMode.Impulse);



        
        }
        
       
    }
 
}
