using System;
using System.Collections.Generic;
using System.Linq;

public class EntityRulesProvider : IEntityRulesProvider, IDisposable
{
	public IReadOnlyDictionary<EntityId, IEntityRule> EntityRules => rules;

    private Dictionary<EntityId, IEntityRule> rules = new();

    public EntityRulesProvider(List<IEntityRule> rules)
	{
		this.rules = rules.ToDictionary(x => x.Id, x => x);
    }

	public void Initialize()
	{
		foreach (var rule in rules)
		{
			rule.Value.Initialize();
		}
	}

	public void Dispose()
	{
		foreach (var rule in rules)
		{
			rule.Value.Dispose();
		}
	}
}