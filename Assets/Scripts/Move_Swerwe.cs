using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Movement/Swerve")]
public class Move_Swerwe : Movement
{
    #region Veriables
    //public float MoveSpeed;
    public float SwerveSpeed;
    public float MaxRL;


    private float _firstPos;
    private float _direction;
    private float _swerveAmount;

    #endregion


    public override void DoMovement(Transform transf, Rigidbody rb)
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {

            #region Test
            //transf.position = (Mathf.Clamp(transf.position.x, -maxRL, maxRL),0,0);
            //transf.Translate(new Vector3(_swerveAmount, 0, 0));
            //rb.velocity = new Vector3((Mathf.Clamp( SwerveSpeed*_direction, -maxRL, maxRL)),0,0);
            //transf.Translate((SwerveSpeed * Time.deltaTime * _direction), 0,0);
            //rb.velocity = new Vector3(_swerveAmount, 0, 0); 
            //transf.position = new Vector3(Mathf.Clamp(Time.deltaTime * SwerveSpeed, -maxRL, maxRL), transf.position.y, transf.position.z);
            //rb.velocity = new Vector3((SwerveSpeed* _direction), 0, rb.velocity.z);
            #endregion

            _direction = Input.mousePosition.x - _firstPos;

            _swerveAmount = SwerveSpeed * _direction;
            _swerveAmount = _limitter(_swerveAmount, transf.position.x);
            _move(transf, rb);


        }
        else 
        {
            _direction = 0;
            _swerveAmount = 0;
            _move(transf, rb);


        }


    }


    private void _move(Transform transf, Rigidbody rb)
    {
        rb.velocity = new Vector3(_swerveAmount * Time.fixedDeltaTime, 0, rb.velocity.z);
        rb.transform.position = new Vector3(Mathf.Clamp(rb.transform.position.x, -MaxRL, MaxRL), rb.transform.position.y, rb.transform.position.z);
        //transf.position = new Vector3(Mathf.Clamp(transf.position.x, -MaxRL, MaxRL), transf.position.y, transf.position.z);

    }
    #region _move0.1
    //if (GameManager.Instance.gameStatus==GameStatus.Playing)
    //{
    //rb.velocity = new Vector3(_swerveAmount * Time.fixedDeltaTime, 0, rb.velocity.z);
    //transf.position = new Vector3(Mathf.Clamp(transf.position.x, -MaxRL, MaxRL), transf.position.y, transf.position.z); 

    //}
    //else
    //{
    //    rb.velocity =Vector3.zero;
    //} 
    #endregion
    private float _limitter(float swerveAmount, float xPosition)
    {
        if (xPosition <= -MaxRL)
        {
            swerveAmount = Mathf.Clamp(swerveAmount, 0, MaxRL); ;
            return swerveAmount;
        }
        else if (xPosition >= MaxRL)
        {
            swerveAmount = Mathf.Clamp(swerveAmount, -MaxRL, 0);
            return swerveAmount;
        }
        return swerveAmount;

    }
}
