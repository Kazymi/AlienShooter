public class EffectFreeze : Effect
{
    private IMovenment _movenment;
    private float _valueSpeed;
    public EffectFreeze(float timerEffect,IMovenment movenment,float valueSpeed) : base(timerEffect)
    {
        _movenment = movenment;
        _valueSpeed = valueSpeed;
        ActivateAction();
    }

    public override void ActivateAction()
    {
        _movenment.RemoveSpeed(_valueSpeed);
    }

    public override void DeactivateAction()
    {
        _movenment.AddSpeed(_valueSpeed);
    }
}