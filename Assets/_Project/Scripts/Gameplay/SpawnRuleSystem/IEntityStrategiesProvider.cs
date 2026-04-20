using System.Collections.Generic;

public interface IEntityStrategiesProvider
{
	IReadOnlyDictionary<EntityId, IEntityRule> EntityRules { get; }
    //IReadOnlyDictionary<EntityId, IEntityFactory> EntityFactories { get; }
    IReadOnlyDictionary<TargetingStrategyType, ITargetingStrategy> TargetingStrategy { get; }

    void Initialize();
}