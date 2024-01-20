using UnityEngine;

/// <summary>
/// This class provides Singleton pattern implementation for MonoBehaviour-derived classes.
/// The Singleton pattern is a design pattern that restricts a class to a single instance.
/// It may be useful for classes that provide some sort of global state for your application.
/// For instance, you may have a game manager class that handles high-level game state.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Component {

	// Singleton instance (null if not set)
	private static T instance;

	// Accessor for the singleton instance, creates a new GameObject with the needed component if it does not exist yet
	public static T Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<T>();
				if (instance == null) {
					SetupInstance();
				}
			}
			return instance;
		}
	}

	public virtual void Awake() {
		RemoveDuplicates();
	}

	/// <summary>
	/// Method to setup a singleton instance by creating a new GameObject and attach the needed component to it
	/// </summary>
	private static void SetupInstance() {
		if (instance == null) {
			GameObject obj = new GameObject();
			obj.name = typeof(T).Name;
			instance = obj.AddComponent<T>();
			DontDestroyOnLoad(obj);
		}
	}

	/// <summary>
	/// Method to ensure that only a single instance of this object exists in the game world,
	/// all others are destroyed, and the single instance is not destroyed between scenes.
	/// </summary>
	private void RemoveDuplicates() {
		if (instance == null) {
			instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}
}
