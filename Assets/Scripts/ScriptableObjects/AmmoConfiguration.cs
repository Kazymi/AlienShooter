using UnityEngine;

public class AmmoConfiguration : ScriptableObject
{
    [SerializeField] private GameObject ammoGameObject;
    [SerializeField] private float speedAmmo;

    public float SpeedAmmo => speedAmmo * Time.deltaTime;
    public GameObject AmmoGameObject => ammoGameObject;
}
