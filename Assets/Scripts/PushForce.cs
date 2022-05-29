using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Movement/PushAndForce")]

public class PushForce : Movement
{
    public override void DoMovement(Transform transform, Rigidbody rb)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.z <= 45f)
            {
                rb.AddForce(0, 0, 15f, ForceMode.Impulse);
                rb.velocity = new Vector3(0, 0, Mathf.Clamp(rb.velocity.z, 0, 45));
            }

        
        }
    }
}
