using System;
using UnityEngine;

[Serializable]
public class MoneySave
{
    [SerializeField] private int _money;

    public int Money
    {
        get => _money;
        set => _money = value;
    }

    public bool CompareMoney(int value)
    {
        return _money >= value;
    }

    public void AddMoney(int value)
    {
        _money += value;
    }

    public void RemoveMoney(int value)
    {
        _money -= value;
    }
}