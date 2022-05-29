using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.gameStatus = GameStatus.End;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
