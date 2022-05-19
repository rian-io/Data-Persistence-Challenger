using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    class Data {
        public string PlayerName;
        public int Score;
    }

    public static DataManager Instance;

    public string PlayerName;

    public string RecordPlayerName;

    public int Score;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        LoadData();
    }

    private void SaveData()
    {
        Data data = new Data();
        data.PlayerName = PlayerName;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            this.RecordPlayerName = data.PlayerName;
            this.Score = data.Score;
        }
    }

    public void SetNewRecord(int score)
    {
        if (this.Score < score)
        {
            this.Score = score;
            this.RecordPlayerName = this.PlayerName;
            
            SaveData();
        }
    }
}
