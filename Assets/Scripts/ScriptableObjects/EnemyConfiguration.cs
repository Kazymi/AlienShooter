using UnityEngine;

[CreateAssetMenu(fileName = "New enemy config", menuName = "EnemyConfiguration")]
public class EnemyConfiguration : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private int score;
    [SerializeField] private GameObject enemyPrefab;

    public float Speed => speed;
    public float Damage => damage;
    public float Health => health;
    public GameObject EnemyPrefab => enemyPrefab;
    public int Score => score;
}