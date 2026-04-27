using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StrategiesProvider : IStrategiesProvider
{
    public IReadOnlyDictionary<TargetingStrategyType, ITargetingStrategy> TargetingStrategy => targetingStrategy;

    private Dictionary<TargetingStrategyType, ITargetingStrategy> targetingStrategy = new();

    public StrategiesProvider(
        List<ITargetingStrategy> targetingStrategy)
    {
        this.targetingStrategy = targetingStrategy.ToDictionary(x => x.Type, x => x);
    }
}
