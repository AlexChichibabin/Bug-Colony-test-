using System.Collections.Generic;

public interface IEntityRulesProvider
{
	IReadOnlyDictionary<EntityId, IEntityRule> EntityRules { get; }

    void Initialize();
}