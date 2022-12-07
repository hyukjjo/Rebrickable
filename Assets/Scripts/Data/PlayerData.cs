using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public PlayerData data;

    public int _gold = 0;
    public int _level = 0;

    public static PlayerData GetPlayerData()
    {
        var filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "Data\\PlayerData.json");
        var json = System.IO.File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject(json) as PlayerData;
    }

    public static void SetPlayerData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.streamingAssetsPath + "/Data/PlayerData.json", json);
    }
}
