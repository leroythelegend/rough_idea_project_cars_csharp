using System;
namespace pcars
{
    public enum TyreFlags
    {
        TYRE_ATTACHED = (1 << 0),
        TYRE_INFLATED = (1 << 1),
        TYRE_IS_ON_GROUND = (1 << 2)
    }
}
