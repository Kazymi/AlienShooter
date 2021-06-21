using UnityEngine;

[CreateAssetMenu(fileName = "New effect", menuName = "Effect config")]
public class EffectConfiguration : ScriptableObject
{
    [SerializeField] private float timeEffect;
    [SerializeField] private float valueEffect;
    [SerializeField] private TypeBuff typeEffect;

    public float TimeEffect => timeEffect;
    public float ValueEffect => valueEffect;
    public TypeBuff TypeEffect => typeEffect;
}