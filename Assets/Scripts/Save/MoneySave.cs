public class MoneySave
{
    private readonly SaveData _saveData;

    public MoneySave(SaveData saveData)
    {
        _saveData = saveData;
    }

    public int Money => _saveData.Money;

    public bool CompareMoney(int value)
    {
        return _saveData.Money >= value;
    }

    public void AddMoney(int value)
    {
        _saveData.Money += value;
    }

    public void RemoveMoney(int value)
    {
        _saveData.Money -= value;
    }
}