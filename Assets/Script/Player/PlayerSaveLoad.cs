using UnityEngine;
using System.IO;
public static class PlayerSaveLoad
{
    //private static string filePath = Application.persistentDataPath + "/playerData.json";
    public static void SavePlayerData(PlayerData playerData)
    {
        //string json = JsonUtility.ToJson(playerData, true);  // Pretty Print 옵션을 true로 설정
        //File.WriteAllText(filePath, json);  // 파일로 저장
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", json);
    }
    public static PlayerData LoadPlayerData()
    {
        //if (File.Exists(filePath))  // 파일이 존재하는지 확인
        //{
        //    string json = File.ReadAllText(filePath);  // 파일에서 JSON 문자열 읽기    
        //    return JsonUtility.FromJson<PlayerData>(json);
        //}
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string json = PlayerPrefs.GetString("PlayerData");
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return null;
        }
    }
}
