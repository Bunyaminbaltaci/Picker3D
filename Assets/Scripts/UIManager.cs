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
    [SerializeField] private List<Image> lvlImages;

    private void Start()
    {
        GameManager.Instance.MissionFail += Instance_MissionFail;
        GameManager.Instance.MissionComp += Instance_MissionComp;
        GameManager.Instance.Lvlup += Instance_Lvlup;
        UpdatelvlText();
    }

    private void Instance_Lvlup(object sender, System.EventArgs e)
    {
        updatelvl();
    }

    private void Instance_MissionComp(object sender, System.EventArgs e)
    {
        ExpUp();
    }

    private void Instance_MissionFail(object sender, System.EventArgs e)
    {
        GameFailed();
    }

    public void Play()
    {
        gameMenu.SetActive(false);
        lvlMenu.SetActive(true);

        GameManager.Instance.gameStatus = GameStatus.Playing;
      
    }
    public void GameFailed()
    {
        failedMenu.SetActive(true);
    }

    public void ExpUp()
    {
       
        lvlImages[GameManager.Instance.GetExp()].GetComponent<Image>().color=new Color32(255, 231,0,255);
        
    }
    public void updatelvl()
    {
        foreach (var changer in lvlImages)
        {
            changer.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }
        UpdatelvlText();


    }
    public void UpdatelvlText()
    {
        lvlNow.text = (GameManager.Instance.GetLvl()).ToString();
        lvlNext.text = (GameManager.Instance.GetLvl() + 1).ToString();
    }

}
