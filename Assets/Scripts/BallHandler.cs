using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    
    public void Poller(LevelsSOList _levelslist,List<List<GameObject>> BallObjects)
    {
        for (int i = 0; i < _levelslist.Levellist.Count; i++)
        {
            for (int k = 0; k < BallObjects[i].Count; k++)
            {
             
                _levelslist.Levellist[i].BallsInlevel.Add(BallObjects[i][k]);
                _levelslist.Levellist[i].BallsPos.Add(_levelslist.Levellist[i].BallsInlevel[k].transform.position);
            }
        }
    }   

    
}
