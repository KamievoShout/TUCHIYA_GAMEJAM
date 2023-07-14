using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class JsonFileManager
{
    private const string SaveFileName = "SaveData.json";

    public static async void Save(RecordedObjectsData datas)
    {
        using (StreamWriter writer = File.CreateText(GetSavePath()))
        {
            string dataJson = JsonUtility.ToJson(datas);
            await writer.WriteAsync(dataJson);
            Debug.Log($"�Z�[�u����:�p�X({GetSavePath()})");
        }
    }

    public static RecordedObjectsData Load()
    {
        RecordedObjectsData data = new RecordedObjectsData();
        // ������Ȃ����͐V�K�쐬
        if (!File.Exists(GetSavePath()))
        {
            Save(data);
        }

        using (StreamReader reader = File.OpenText(GetSavePath()))
        {
            string jsonData = File.ReadAllText(GetSavePath());
            JsonUtility.FromJsonOverwrite(jsonData, data);
            Debug.Log("���[�h����");
            return data;
        }
    }

    private static string GetSavePath()
    {
        return Path.Combine(Application.dataPath, SaveFileName);
    }
}