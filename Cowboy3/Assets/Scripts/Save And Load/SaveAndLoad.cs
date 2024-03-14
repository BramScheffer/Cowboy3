using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class SaveAndLoad : MonoBehaviour
{
    public SaveDataModel loadItInHere;
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
             = File.ReadAllText(filePath);
            //loadItInHere moet worden wat je in laad, als een "SaveDataModel".

        }
    }
    public class SaveDataModel
    {
        public Vector3 positie;
    }
}
