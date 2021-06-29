using UnityEngine;

[CreateAssetMenu(fileName = "New player config", menuName = "PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float health;

    public float Speed => speed;
    public float Health => health;
}