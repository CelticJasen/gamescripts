using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class SaveData
{
	public string foo;
	public int bar;

	public void Save(string filename)
	{
		using (FileStream stream = new FileStream (string.Format ("{0}/{1}.save", Application.persistentDataPath, filename), FileMode.Create))
		{
			var formatter = new BinaryFormatter ();
			formatter.Serialize (stream, this);
		}
	}

	public static SaveData Load(string filename)
	{
		using (FileStream stream = new FileStream (string.Format ("{0}/{1}.save", Application.persistentDataPath, filename), FileMode.Open, FileAccess.Read))
		{
			var formatter = new BinaryFormatter ();
			return formatter.Deserialize (stream) as SaveData;
		}
			
	}
}