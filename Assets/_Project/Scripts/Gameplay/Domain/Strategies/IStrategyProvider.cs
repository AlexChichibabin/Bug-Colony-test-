using System.Collections.Generic;

public interface IStrategyProvider
{
    IReadOnlyDictionary<TargetingStrategyType, ITargetingStrategy> TargetingStrategy { get; }
}