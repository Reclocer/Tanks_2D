using Corebin.Tanks.Bonuses;

namespace Corebin.Tanks.UnitSystems
{
    public interface IWeaponSystem : IHaveTeam
    {   
        void ReductionWeaponCoolDownTime(IEnergyDealer energyDealer);
    }
}
