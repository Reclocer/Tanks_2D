namespace Corebin.Tanks.Weapons
{
    public interface IDamageDealer : IHaveTeam
    {     
        float Damage { get; }
    }
}
