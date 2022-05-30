using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject failedMenu;
    [SerializeField] private GameObject lvlMenu;
    [SerializeField] private TextMeshProUGUI lvlNow;
    [SerializeField] private TextMeshProUGUI lvlNext;
    [SerializeField] private TextMeshProUGUI scrTxt;
    [SerializeField] private List<Image> lvlImages;

    private void Start()
    {
        GameManager.Instance.MissionFail += _instance_MissionFail;
        GameManager.Instance.MissionComp += _instance_MissionComp;
        GameManager.Instance.Lvlup += _instance_Lvlup;
        GameManager.Instance.GameStart += Instance_GameStart;
        _updatelvlText();
        _continuousCheck();

    }

    private void Instance_GameStart(object sender, System.EventArgs e)
    {
        _updatelvlText();

    }
    private void _continuousCheck()
    {
        if (GameManager.Instance.GameStarted == true)
        {
            Play();
        }
    }
    private void _instance_Lvlup(object sender, System.EventArgs e)
    {
        Updatelvl();
    }
    private void _instance_MissionComp(object sender, System.EventArgs e)
    {
        ExpUp();
    }
    private void _instance_MissionFail(object sender, System.EventArgs e)
    {
        GameFailed();
    }
    private void _updatelvlText()
    {
        lvlNow.text = (GameManager.Instance.GetLvl()).ToString();
        lvlNext.text = (GameManager.Instance.GetLvl() + 1).ToString();
        scrTxt.text = (GameManager.Instance.GetScr()).ToString();
    }

    public void Play()
    {
        gameMenu.SetActive(false);
        lvlMenu.SetActive(true);
        GameManager.Instance.GameStarted = true;
        GameManager.Instance.gameStatus = GameStatus.Playing;
        GameManager.Instance.LoadSave();

    }
    public void GameFailed()
    {
        failedMenu.SetActive(true);
    }
    public void ExpUp()
    {

        lvlImages[GameManager.Instance.GetExp()].GetComponent<Image>().color = new Color32(190, 39, 163, 255);
        _updatelvlText();

    }
    public void Updatelvl()
    {
        foreach (var changer in lvlImages)
        {
            changer.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }
        _updatelvlText();


    }
    public void RestartBtn()
    {
        GameManager.Instance.RestartGame();
    }
    private void OnDestroy()
    {
        GameManager.Instance.MissionFail -= _instance_MissionFail;
        GameManager.Instance.MissionComp -= _instance_MissionComp;
        GameManager.Instance.Lvlup -= _instance_Lvlup;
    }


}
