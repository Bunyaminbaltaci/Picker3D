using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField]
    private MovementList _movement;
    [SerializeField]
    private GameObject screen;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        GameManager.Instance.MissionComp += Instance_MissionComp;


    }

    void Update()
    {

        if (GameManager.Instance.gameStatus == GameStatus.End)
        {
            _movement.MovementsList[1].DoMovement(transform, _rb);

        }
        else
        {
            _movement.MovementsList[0].DoMovement(transform, _rb);
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
