using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class MushroomFactory : IEntityFactory
{
    public EntityId Id => EntityId.Mushroom;


    private IGameFactory gameFactory;
    private EntityConfig config;
    private IConfigProvider configProvider;

    public MushroomFactory(
        IGameFactory gameFactory,
        IConfigProvider configProvider)
    {
        this.gameFactory = gameFactory;
        this.configProvider = configProvider;
    }

    public async UniTask<GameObject> CreateEntity(Vector3 position, Quaternion rotation, CancellationToken token)
    {
        config = configProvider.GetEntity(Id);

        GameObject go = await gameFactory.CreateNewAsync(config.PrefabReference, position, rotation, token);

        IEntityComponentRoot root = go.GetComponent<IEntityComponentRoot>();
        root.Initialize();

        return go;
    }
}
