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
    public event EventHandler GameStart;

    public bool GameStarted = false;

    [SerializeField]
    private LevelsSOList levelList;

    private int _expCounter = 0;
    private int _level = 1;
    private int _score = 0;

    

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

        LoadSave();
        
    }

    public int GetExp() => _expCounter % 3;
    public int GetLvl() => _level;
    public int GetScr() => _score;
    public int SetLvl(int newlvl) => _level = newlvl;
    public int SetScr(int newscore) => _score = newscore;

    public void ExpCounter()
    {
        MissionComp?.Invoke(this, EventArgs.Empty);
        gameStatus = GameStatus.Playing;
        _expCounter++;
        UpdateLevel(_expCounter);
    }
    private void UpdateLevel(int expCounter)
    {
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
    public void UpdatePoint(int Point)
    {
        _score += Point;
    }
    public void RestartGame()
    {
        _expCounter = 0;
        SceneManager.LoadScene(0);
    }

    public void LoadSave()
    {
        GameStart?.Invoke(this, EventArgs.Empty);
    }




}
