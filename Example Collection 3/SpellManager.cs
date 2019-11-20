using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spells for the mob.
/// </summary>
public class SpellManager {

    public Dictionary<string, Spell> spells = new Dictionary<string, Spell>();

    /// <summary>
    /// Calls on a spell to be casted.
    /// </summary>
    /// <param name="spell">The name of the spell to cast.</param>
    /// <returns>True if the spell exists. False if the spell does not exist.</returns>
    public bool Cast(string spell) {
        if (spells.ContainsKey(spell))
        {
            spells[spell].Cast();
        }
        else { return false; }

        return true;
    }

    /// <summary>
    /// Teaching the mob how to cast this spell.
    /// </summary>
    /// <param name="spell">The name of the spell to learn.</param>
    public void Learn(string spell) {
        if (!spells.ContainsKey(spell)) {
            Type type = Type.GetType(spell);

            if (type != null)
            {
                object instance = Activator.CreateInstance(type);
                if (instance is Spell)
                {
                    spells.Add(spell, (Spell)instance);
                }
            }
        }
    }

    /// <summary>
    /// Removes a certain spell from a mob.
    /// </summary>
    /// <param name="spell">The name of the spell to discard.</param>
    public void Discard(string spell) {
        if (spells.ContainsKey(spell))
        {
            spells.Remove(spell);
        }
    }
}
