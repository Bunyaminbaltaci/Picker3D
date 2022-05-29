using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    #region Veriables

    public GameStatus gameStatus = GameStatus.Stop;
    public event EventHandler MissionComp;
    public event EventHandler MissionFail;
    public event EventHandler Lvlup;
    public List<List<GameObject>> levelObjectlist;
    public bool GameStarted = false;

    [SerializeField]
    private LevelsSOList levelList;
    [SerializeField]
    private List<GameObject> level1_Ballobjects, level2_Ballobjects, level3_Ballobjects;

    private int _expCounter = 0;
    private int _level = 1;
    private int _score = 0;
    
    private BallHandler _ballHandler;

    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }
    private void Start()
    {
        levelObjectlist = new List<List<GameObject>>();
        _ballHandler = new BallHandler();
        levelObjectlist.Add(level1_Ballobjects);
        levelObjectlist.Add(level2_Ballobjects);
        levelObjectlist.Add(level3_Ballobjects);
        #region TEST

        //levelHandler(levelList,levelObjectlist); 
        #endregion
    }

    public int GetExp() => _expCounter % 3;
    public int GetLvl() => _level;
    public int GetScr() => _score;

 
    public void UpdateLevel()
    {
        MissionComp?.Invoke(this, EventArgs.Empty);
        gameStatus = GameStatus.Playing;
        _expCounter++;
        if (_expCounter != 0 && _expCounter % 3 == 0)
        {
            _level++;
            Lvlup?.Invoke(this, EventArgs.Empty);
        }
    }
    public void SetFailed()
    {
        gameStatus = GameStatus.Fail;
        MissionFail?.Invoke(this, EventArgs.Empty);


    }
    public void levelHandler(LevelsSOList level, List<List<GameObject>> levelBall)
    {

        //!!!!!!!!Scriptable object depolama olarak 1 kere kullanýlýyor tekrar kullanýldýðýnda herhangi bir silme iþlemi yapmadýðýmýz için üstüste-
        //ekliyor o yüzden tek sefer kullan kapat kullanman gerektiðinde level scriptable objectlerin positionlarýný ve gameobjectlerini sýfýrla!!!!!!!!.


        //_ballHandler.Poller(levelList, levelObjectlist); 




    }

    public void UpdatePoint(int Point)
    {
        _score += Point;
    }


    public void RestartGame()
    {
        _expCounter = 0;
        SceneManager.LoadScene(0);
    }

    public void OpenBall(List<GameObject> Balllist)
    {
  
    }

}
