using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class WorkerFactory : IEntityFactory
{
    public EntityId Id => EntityId.AntWorker;


    private IGameFactory gameFactory;
    private EntityConfig config;
    private IConfigProvider configProvider;
    private IStrategiesProvider strategyProvider;

    public WorkerFactory(
        IGameFactory gameFactory,
        IConfigProvider configProvider,
        IStrategiesProvider strategyProvider)
    {
        this.gameFactory = gameFactory;
        this.configProvider = configProvider;
        this.strategyProvider = strategyProvider;
    }

    public async UniTask<GameObject> CreateEntity(Vector3 position, Quaternion rotation, CancellationToken token)
    {
        config = configProvider.GetEntity(Id);

        GameObject go = await gameFactory.CreateNewAsync(config.PrefabReference, position, rotation, token);

        IEntityComponentRoot root = go.GetComponent<IEntityComponentRoot>();
        root.Initialize();
        if (root.TryGetCapability(out IControllerAI controller))
        {
            if (strategyProvider.TargetingStrategy.ContainsKey(config.TargetingStrategy))
                controller.SetStrategy(strategyProvider.TargetingStrategy[config.TargetingStrategy]);
        }

        return go;
    }
}
