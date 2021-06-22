using UnityEngine;

[CreateAssetMenu(menuName = "VFX/NewVFXEffect")]
public class VFXConfiguration : ScriptableObject
{
    [SerializeField] private VisualEffect visualEffect;
    [SerializeField] private int countElement;
    [SerializeField] private bool onlyPlayer;

    public int CountElement => countElement;
    public bool OnlyPlayer => onlyPlayer;
    public VisualEffect VisualEffect => visualEffect;
}
