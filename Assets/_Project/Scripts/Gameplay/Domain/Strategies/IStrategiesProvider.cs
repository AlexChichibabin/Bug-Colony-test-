using System.Collections.Generic;

public interface IStrategiesProvider
{
    IReadOnlyDictionary<TargetingStrategyType, ITargetingStrategy> TargetingStrategy { get; }
}