using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    
    public void doorOpen()
    {
        transform.DOLocalRotateQuaternion(Quaternion.identity, 2f).SetEase(Ease.Linear);
    }
}
