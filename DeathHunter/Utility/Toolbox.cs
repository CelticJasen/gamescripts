using UnityEngine;

// From http://wiki.unity3d.com/index.php/Toolbox
public class Toolbox : Singleton<Toolbox>
{
	// guarantee this will be always a singleton only - can't use the constructor!
	protected Toolbox ()
	{
		
	}

	[SerializeField] private GameManager gameManager;
	public static GameManager GameManager { get { return Instance.gameManager; } }

	[SerializeField] private UIManager uiManager;
	public static UIManager UIManager { get { return Instance.uiManager; } }

	public static Player Player
	{
		get;
		set;
	}

	// (optional) allow runtime registration of global objects
	static public T RegisterComponent<T> () where T: Component
	{
		return Instance.GetOrAddComponent<T> ();
	}
}