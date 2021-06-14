using UnityEngine;

[CreateAssetMenu(fileName = "New player config", menuName = "PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float hp;

    public float Speed => speed;
    public float HP => hp;
}
