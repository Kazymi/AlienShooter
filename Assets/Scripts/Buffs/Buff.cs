public class Buff
{
    private float _timeBuff;
    private BuffConfiguration _buffConfiguration;

    public float TimeBuff
    {
        get => _timeBuff;
        set => _timeBuff = value;
    }

    public BuffConfiguration BuffConfiguration => _buffConfiguration;

    public Buff(BuffConfiguration buffConfiguration)
    {
        _timeBuff = buffConfiguration.TimerBuff;
        _buffConfiguration = buffConfiguration;
    }
}