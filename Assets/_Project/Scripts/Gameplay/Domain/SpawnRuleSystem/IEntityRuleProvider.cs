using System.Collections.Generic;

public interface IEntityRuleProvider
{
	IReadOnlyDictionary<EntityId, IEntityRule> EntityRules { get; }

    void Initialize();
}