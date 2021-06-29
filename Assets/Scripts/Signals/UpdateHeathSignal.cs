public class UpdateHeathSignal
{
    public float CurrentHealth { get; }

    public UpdateHeathSignal(float currentHealth)
    {
        CurrentHealth = currentHealth;
    }
}