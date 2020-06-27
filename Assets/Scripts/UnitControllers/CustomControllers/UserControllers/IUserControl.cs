using Corebin.Core;

namespace Corebin.Tanks.UnitControllers
{
    public interface IUserControl : IUnityComponent
    {
        float Forward { get; }
        float Right { get; }
        
        bool Key { get; }
    }
}
