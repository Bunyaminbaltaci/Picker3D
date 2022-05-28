using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Levels/New Level")]

public class LevelsSO : ScriptableObject
{
    public int TargerScore;
    public List<GameObject> BallsInlevel;
    public List<Vector3> BallsPos;
    

}
