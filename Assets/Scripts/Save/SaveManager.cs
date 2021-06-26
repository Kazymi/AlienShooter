using UnityEngine;

public class SaveManager
{
    public void Save(SaveData saveData)
    {
        var saveString = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("Save",saveString);   
    }

    public SaveData Load()
    {
        var loadedDate = PlayerPrefs.GetString("Save");
        var saveDate = JsonUtility.FromJson<SaveData>(loadedDate);
        if (saveDate == null) return new SaveData();
        return saveDate;
    }
}
