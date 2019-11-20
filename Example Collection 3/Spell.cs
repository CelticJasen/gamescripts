using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

/// <summary>
/// The base class for all spells.
/// </summary>
public abstract class Spell {

    /// <summary>
    /// Initializes the spell, giving it all of the data that it needs.
    /// </summary>
    /// <param name="name">The name of the spell.</param>
    /// <param name="damage">The damage for the spell.</param>
    public Spell(string name, float damage) {
        Name = name;
        this.damage = damage;
    }

    #region Variables
    private string name;
    public string Name {
        get {
            return name;
        }
        set {
            if (value != null)
                SetName(value);
        }
    }

    private void SetName(string name) { this.name = name; }

    [Header("Stats")]
    /// <summary>
    /// How long the spell can channel.
    /// </summary>
    public float castTime = 0;

    /// <summary>
    /// How many seconds to wait after the spell has been initially casted.
    /// </summary>
    public float cooldown = 0;

    /// <summary>
    /// How many times the spell can stack up.
    /// </summary>
    public float charges, maxCharges;

    /// <summary>
    /// How much of a base damage modifier the spell has.
    /// </summary>
    public float damage;

    /// <summary>
    /// How much armor the spell can penetrate (ignore) through.
    /// </summary>
    public float armorPen;

    [Header("Graphics")]
    /// <summary>
    /// The spell objects that should be instantiated and manipulated.
    /// </summary>
    public Dictionary<string, GameObject> assets;

    /// <summary>
    /// The name of the dictionary index and the path for assets to be loaded relative to the Resources folder.
    /// </summary>
    public string[][] assetsPath = new string[][] { /* new string[] { "DICTIONARY_KEY_NAME", "SPRITE_LOCATION" } */ };

    /// <summary>
    /// The already instantiated spells for cleanup.
    /// </summary>
    public List<GameObject> pool;
    #endregion

    #region Methods
    /// <summary>
    /// Casts the spell.
    /// </summary>
    public abstract void Cast();

    /// <summary>
    /// Loads all of the asetts in the assetsPath array.
    /// </summary>
    public void LoadAssets() {
        if(assets == null) {
            assets = new Dictionary<string, GameObject>();
        }

        for(int i = 0; i < assetsPath.Length; i++) {
            assets.Add(
                assetsPath[i][0],
                ((GameObject)Resources.Load(assetsPath[i][1], typeof(GameObject)))
                );
        }
    }

    /// <summary>
    /// Puts the spell on a cooldown.
    /// </summary>
    public void Cooldown()
	{
		Timing.RunCoroutine (cooldown);
	}

	public IEnumerator<float> CoolCheck(float cooldownTime)
	{
		float timer = 0.0f;

		while (timer < cooldownTime)
		{
			timer += Time.deltaTime;
			yield return WaitForSeconds (0.1);
		}
	}

    /// <summary>
    /// Modifies the charge variable and the game.
    /// </summary>
    /// <param name="change">How much to change the value by.</param>
    /// <param name="setMax"></param>
    public void ModifyCharge(int change, bool setMax) {
        charges = Mathf.Clamp(charges + change, 0, maxCharges);

        if(setMax)
        {
            charges = change;
            maxCharges = change;
        }
    }
    #endregion
}
