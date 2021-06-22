public class EffectSpeedBoost : Effect
{
    private float _valueBoost;
    private IMovenment _movenment;

    public override void ActivateAction()
    {
        _movenment.AddSpeed(_valueBoost);
    }

    public override void DeactivateAction()
    {
        _movenment.RemoveSpeed(_valueBoost);
    }

    public EffectSpeedBoost(IMovenment movenment, float timerEffect,float valueBoost) : base(timerEffect)
    {
        _valueBoost = valueBoost;
        _movenment = movenment;
        ActivateAction();
    }
}