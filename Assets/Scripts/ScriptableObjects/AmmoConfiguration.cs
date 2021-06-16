using UnityEngine;
[CreateAssetMenu(fileName = "New ammo config", menuName = "AmmoConfiguration")]
public class AmmoConfiguration : ScriptableObject
{
    [SerializeField] private GameObject ammoGameObject;
    [SerializeField] private float speedAmmo;
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime;

    public float Damage => damage;
    public float SpeedAmmo => speedAmmo;
    public GameObject AmmoGameObject => ammoGameObject;
    public float LifeTime => lifeTime;
}
