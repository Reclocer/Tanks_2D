namespace Corebin.Tanks.Weapons
{
    public interface IDamagable : IHaveTeam 
    {    
        void ApplyDamage(IDamageDealer damageDealer);
    }
}  
