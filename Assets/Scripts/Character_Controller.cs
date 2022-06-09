using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField]
    private MovementList movement;// 0.swerve 1.pushforce 2.moveforward
    [SerializeField]
    private GameObject screen;
    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        GameManager.Instance.MissionComp += Instance_MissionComp;


    }

    void Update()
    {

        if (GameManager.Instance.gameStatus == GameStatus.Playing)
        {
            movement.MovementsList[0].DoMovement(transform, _rb);
            movement.MovementsList[2].DoMovement(transform, _rb);


        }
        else if (GameManager.Instance.gameStatus == GameStatus.Stop)
        {
            _rb.velocity = Vector3.zero;
        }
        else if (GameManager.Instance.gameStatus == GameStatus.End)
        {

            movement.MovementsList[1].DoMovement(transform, _rb);

        }


    }



    private void Instance_MissionComp(object sender, System.EventArgs e)
    {
        StartCoroutine(Perfect());
    }
    IEnumerator Perfect()
    {
        screen.SetActive(true);

        yield return new WaitForSeconds(1f);
        screen.SetActive(false);
        StopAllCoroutines();
    }
    private void OnDestroy()
    {
        GameManager.Instance.MissionComp -= Instance_MissionComp;
    }

}
