using UnityEngine;
using System.Collections;

public enum ItemType{KEY, POTATO};

public class Item : MonoBehaviour
{
	public ItemType type;

	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

	public int maxSize;

	[SerializeField]
	private GameObject door;

	void Start ()
	{
		door = GameObject.FindGameObjectWithTag ("Door");
	}

	void Update ()
	{

	}

	public void Use()
	{
		switch (type)
		{
			case ItemType.KEY:
				if(door.GetComponent<DoorTrigger>().doorTrigger == true)
				{
					door.SetActive(false);
					door.GetComponent<DoorTrigger>().doorTrigger = false;
					Debug.Log("I just used a key");
				}
				break;
			case ItemType.POTATO:
				Debug.Log("I just used a potato");
				break;
		}
	}
}