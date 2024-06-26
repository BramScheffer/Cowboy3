using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using TMPro;


public class SaveAndLoad : MonoBehaviour
{
    public SaveDataModel loadItInHere;
    public Transform character;
    public ScoreManager scoreManager;
    public PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveData()
    {
        SaveDataModel model = new SaveDataModel();
        model.positie = transform.position;
        model.rotatie = transform.rotation;
        model.score = scoreManager.score;
        model.scoreText = scoreManager.scoreText;
        model.health = playerHealth.health;
       

        string json = JsonUtility.ToJson(model);

        string bestandsPad = Application.persistentDataPath + "/Savedata.json";
        print(bestandsPad);
        File.WriteAllText(bestandsPad, json);
    }
    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            loadItInHere = JsonUtility.FromJson<SaveDataModel>(json);
            character.transform.position = loadItInHere.positie;
            character.transform.rotation = loadItInHere.rotatie;
            scoreManager.score = loadItInHere.score;
            scoreManager.scoreText = loadItInHere.scoreText;
            playerHealth.health = loadItInHere.health;
       
        }

    }

    public class SaveDataModel
    {
        public Vector3 positie;
        public Quaternion rotatie;
        public int score;
        public TextMeshProUGUI scoreText;
        public float health;


    }
}
