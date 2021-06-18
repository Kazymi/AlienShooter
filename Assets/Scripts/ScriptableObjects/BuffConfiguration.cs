using UnityEngine;

[CreateAssetMenu(fileName = "New buff", menuName = "buff")]
    public class BuffConfiguration : ScriptableObject
    {
        [SerializeField] private float timeBuff;
        [SerializeField] private TypeBuff typeBuff;

        public float TimerBuff => timeBuff;
        public TypeBuff TypeBuff => typeBuff;
    }