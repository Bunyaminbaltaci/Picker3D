using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField]
    private Movement _movement;
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

        _movement.DoMovement(transform,_rb);
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
