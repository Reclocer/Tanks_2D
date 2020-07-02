namespace Corebin.Tanks.Bonuses
{
    public interface IHealthDealer : IWithHealth
    {
        TeamIndex ForTeam { get; }        
    }
}