using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


public class SaveAndLoad : MonoBehaviour
{
    public SaveDataModel loadItInHere;
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveData()
    {
        SaveDataModel model = new SaveDataModel();
        model.positie = transform.position;

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
            cube.transform.position = loadItInHere.positie;
            cube.transform.rotation = loadItInHere.rotate;
            if (loadItInHere != null)
            {
                Debug.Log("Data loaded successfully!");
            }
            else
            {
                Debug.LogError("Failed to deserialize JSON data into SaveDataModel!");
            }
        }
        else
        {
            Debug.LogError("Save data file not found!");
        }
        //loadItInHere moet worden wat je in laad, als een "SaveDataModel".

    }

    public class SaveDataModel
    {
        public Vector3 positie;
        public Vector3 rotate;
    }
}
