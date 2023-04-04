using StatsSystem.Enum;

namespace StatsSystem.Interfaces
{
    public interface IStatValueGiver
    {
        float GetStatValue(StatType statType);
    }
}