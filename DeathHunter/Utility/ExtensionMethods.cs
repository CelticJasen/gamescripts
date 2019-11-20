using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods
{
	// From http://wiki.unity3d.com/index.php/Toolbox
	static public T GetOrAddComponent<T> (this Component child) where T: Component
	{
		T result = child.GetComponent<T> ();
		if (result == null)
		{
			result = child.gameObject.AddComponent<T> ();
		}
		return result;
	}
}