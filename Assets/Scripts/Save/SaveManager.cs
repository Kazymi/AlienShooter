using UnityEngine;

public class SaveManager
{
    private const string SaveKey = "Saves";

    public void Save(SaveData saveData)
    {
        var saveString = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SaveKey, saveString);
        PlayerPrefs.Save();
    }

    public SaveData Load()
    {
        var loadedDate = PlayerPrefs.GetString(SaveKey);
        var saveDate = JsonUtility.FromJson<SaveData>(loadedDate);
        return saveDate;
    }
}