
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //[SerializeField] SaveData data;

    private int _score=0;
    private int _level=1;



    private void Awake()
    {
    }
    private void Start()
    {

        GameManager.Instance.LoadSave();
        GameManager.Instance.Lvlup += _instance_Lvlup;
        GameManager.Instance.GameStart += _instance_GameStart;
        
    }

    private void _instance_GameStart(object sender, EventArgs e)
    {
        Load();
        GameManager.Instance.SetLvl(_level);
        GameManager.Instance.SetScr(_score);
    }

    private void _instance_Lvlup(object sender, EventArgs e)
    {
        _score = GameManager.Instance.GetScr();
        _level = GameManager.Instance.GetLvl();
        Save();
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            _level = data.Level;
            _score = data.Score;

            file.Close();
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.Level = _level;
        data.Score = _score;



        bf.Serialize(file, data);
        file.Close();

    }
    private void OnDestroy()
    {
        GameManager.Instance.Lvlup -= _instance_Lvlup;
        GameManager.Instance.GameStart -= _instance_GameStart;
    }
}

[Serializable]
class PlayerData_Storage
{
    public int Score;
    public int Level;

}
