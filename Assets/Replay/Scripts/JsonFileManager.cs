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
            Debug.Log($"セーブ完了:パス({GetSavePath()})");
        }
    }

    public static RecordedObjectsData Load()
    {
        RecordedObjectsData data = new RecordedObjectsData();
        // 見つからない時は新規作成
        if (!File.Exists(GetSavePath()))
        {
            Save(data);
        }

        using (StreamReader reader = File.OpenText(GetSavePath()))
        {
            string jsonData = File.ReadAllText(GetSavePath());
            JsonUtility.FromJsonOverwrite(jsonData, data);
            Debug.Log("ロード完了");
            return data;
        }
    }

    private static string GetSavePath()
    {
        return Path.Combine(Application.dataPath, SaveFileName);
    }
}