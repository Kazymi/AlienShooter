public class Buff
{
    private float _timeBuff;
    private Effect _buffConfiguration;

    public float TimeBuff
    {
        get => _timeBuff;
        set => _timeBuff = value;
    }

    public Buff(Effect buffConfiguration)
    {
        _buffConfiguration = buffConfiguration;
    }
}