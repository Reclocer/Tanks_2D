namespace Corebin.Tanks.Bonuses
{
    public interface IEnergyDealer
    {
        TeamIndex ForTeam { get; }

        float Energy { get; }
    }
}
