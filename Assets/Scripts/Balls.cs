using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private Vector3 _firstPos;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _firstPos = transform.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            _rigidbody.constraints=RigidbodyConstraints.None;
        }
        if (other.gameObject.CompareTag("Cover"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        transform.position = _firstPos;
    }
}
