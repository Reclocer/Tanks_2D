namespace Corebin.Tanks.Bonuses
{
    public interface IRecoverable : IWithHealth
    {        
        float MaxHealth { get; }

        Team Team { get; }

        void ApplyHealth(IHealthDealer healthDealer);
    }
}
