using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Counter : MonoBehaviour
{
    #region Veriables

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private LevelsSOList levelsSOList;
    [SerializeField] private Door doorRigth, doorLeft;
    [SerializeField] private CoverCont coverCont;
    private int _level;
    private int _counter = 0;

    #endregion


    private void OnEnable()
    {
        _level = GameManager.Instance.GetExp();
        score.text = (levelsSOList.Levellist[_level].TargerScore + " / " + _counter).ToString();

        StartCoroutine(Waiter());
    }


    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5f);
        _limitCheck();

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ball"))
        {
            _counter++;

            score.text = (levelsSOList.Levellist[_level].TargerScore + " / " + _counter).ToString();

        }
    }

    private void _limitCheck()
    {
        if (_counter >= levelsSOList.Levellist[_level].TargerScore)
        {
            gameObject.SetActive(false);
            doorRigth.doorOpen();
            doorLeft.doorOpen();
            coverCont.OpenCover();
            GameManager.Instance.UpdatePoint(_counter);
            GameManager.Instance.UpdateLevel();
        }
        else
        {
            GameManager.Instance.SetFailed();
        }

    }

}
