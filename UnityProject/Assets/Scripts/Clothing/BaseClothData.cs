
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Base class for the different types of cloth data.
/// </summary>
public abstract class BaseClothData : ScriptableObject
{
	/// <summary>
	/// Prefab variant to use to spawn this cloth rather than the default
	/// for this cloth type.
	/// </summary>
	public GameObject PrefabVariant;
	/// <summary>
	/// Various attributes of this cloth
	/// </summary>
	public ItemAttributesData ItemAttributes;


	/// <summary>
	/// Return the sprite to show for this in the dev spawner
	/// </summary>
	/// <returns></returns>
	public abstract Sprite SpawnerIcon();

	private void Awake()
	{

#if UNITY_EDITOR
		{
			if (BaseClothDataSOs.Instance == null)
			{
				Resources.LoadAll<BaseClothDataSOs>("ScriptableObjects/SOs singletons");
			}
			if (!BaseClothDataSOs.Instance.BaseClothData.Contains(this))
			{
				BaseClothDataSOs.Instance.BaseClothData.Add(this);
			}

		}

#endif
		//Logger.Log(name + " Awake");
		//if (name == "test"){
		//	Logger.LogError("noooooooooo");
		//}
		InitializePool();
	}

	private void OnEnable()
	{
		//Logger.Log(name + " OnEnable");
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		InitializePool();
	}

	public abstract void InitializePool();


}
