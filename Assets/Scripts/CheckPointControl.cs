using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    [SerializeField]
    private GameObject counter;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameManager.Instance.gameStatus = GameStatus.Stop;
            counter.SetActive(true);

        }

    }
}
