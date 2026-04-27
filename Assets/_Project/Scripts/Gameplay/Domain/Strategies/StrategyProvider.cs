using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StrategyProvider : IStrategyProvider
{
    public IReadOnlyDictionary<TargetingStrategyType, ITargetingStrategy> TargetingStrategy => targetingStrategy;

    private Dictionary<TargetingStrategyType, ITargetingStrategy> targetingStrategy = new();

    public StrategyProvider(
        List<ITargetingStrategy> targetingStrategy)
    {
        this.targetingStrategy = targetingStrategy.ToDictionary(x => x.Type, x => x);
    }
}
