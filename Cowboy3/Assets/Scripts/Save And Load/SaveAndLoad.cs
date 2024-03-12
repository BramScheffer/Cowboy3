using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveData();
    }

    void SaveData()
    {
        SaveDataModel model = new SaveDataModel();
        model.positie = transform.position;

        string json = JsonUtility.ToJson(model);

        string bestandsPad = Application.persistentDataPath + "/Savedata.json";
        print(bestandsPad);
        File.WriteAllText(bestandsPad, json);
    }
}
public class SaveDataModel
{
    public Vector3 positie;

}