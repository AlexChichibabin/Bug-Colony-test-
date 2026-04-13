using UniRx;
using UnityEngine;

public class Feedable : MonoBehaviour, IFeedable
{
	public IEntityComponentRoot Root => root;
	public IReactiveProperty<int> EatenCount => eatenCount;

	private ReactiveProperty<int> eatenCount = new();
	private IEntityComponentRoot root;


	public void AddFood(int foodCount)
	{
		if (foodCount <= 0) return;

		eatenCount.Value += foodCount;
	}

	public void Initialize(IEntityComponentRoot value)
	{
		root = value;
	}

	public void ResetFood()
	{
		eatenCount.Value = 0;
	}

	private void OnDisable()
	{
		ResetFood();
	}
}
