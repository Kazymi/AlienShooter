using UnityEngine;

[CreateAssetMenu(fileName = "New enemy config", menuName = "EnemyConfiguration")]
public class EnemyConfiguration : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float hp;
    [SerializeField] private float damage;
    [SerializeField] private int score;
    [SerializeField] private GameObject enemyGameObject;

    public float Speed => speed;
    public float Damage => damage;
    public float HP => hp;
    public GameObject EnemyGameObject => enemyGameObject;
    public int Score => score;
}
