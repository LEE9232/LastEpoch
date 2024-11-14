using UnityEngine;
using System.IO;
public static class PlayerSaveLoad
{
    //private static string filePath = Application.persistentDataPath + "/playerData.json";
    public static void SavePlayerData(PlayerData playerData)
    {
        //string json = JsonUtility.ToJson(playerData, true);  // Pretty Print �ɼ��� true�� ����
        //File.WriteAllText(filePath, json);  // ���Ϸ� ����
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", json);
    }
    public static PlayerData LoadPlayerData()
    {
        //if (File.Exists(filePath))  // ������ �����ϴ��� Ȯ��
        //{
        //    string json = File.ReadAllText(filePath);  // ���Ͽ��� JSON ���ڿ� �б�    
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
