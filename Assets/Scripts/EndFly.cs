using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFly : MonoBehaviour
{
    private Rigidbody _rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.gameStatus = GameStatus.End;
            _rb=other.gameObject.GetComponent<Rigidbody>();
            _rb.constraints = RigidbodyConstraints.None;
            _rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            _rb.constraints = RigidbodyConstraints.FreezeRotationY;

        }
    }
}
