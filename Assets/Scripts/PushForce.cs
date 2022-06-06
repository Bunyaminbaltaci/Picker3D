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

            Debug.Log("girdi");
                rb.AddRelativeForce(Vector3.forward*300f,ForceMode.Force);



        
        }
        
       
    }
 
}
