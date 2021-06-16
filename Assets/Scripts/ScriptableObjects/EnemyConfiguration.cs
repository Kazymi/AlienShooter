using UnityEngine;

[CreateAssetMenu(fileName = "New enemy config", menuName = "EnemyConfiguration")]
public class EnemyConfiguration : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float hp;
    [SerializeField] private GameObject enemyGameObject;

    public float Speed => speed;
    public float HP => hp;
    public GameObject EnemyGameObject => enemyGameObject;
}
