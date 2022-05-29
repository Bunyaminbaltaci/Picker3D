using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoverCont : MonoBehaviour
{
  public void OpenCover()
    {
        gameObject.SetActive(true);
        transform.DOMoveY(-3f, 0.65f);
        transform.DOScale(new Vector3(40f, 8f, 30f),0.65f);
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
