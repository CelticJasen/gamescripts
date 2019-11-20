using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Variables: Name, castTime, cooldown, charges, maxCharges, damage, armorPen, assets, assetsPath, pool

 /// <summary>
 /// Summons 5 meteors from the sky by default that comes crashing down and creating craters where they land.
 /// Anyone 3 tiles from the center of the impact point takes full damage.
 /// Anyone 6 tiles from the center of the impact point takes half damage.
 /// </summary>
public class Meteor : Spell {

    public Meteor() : base("Meteor", 1.5f) {
        castTime = 5;
        cooldown = 10;
        ModifyCharge(5, true);

        assetsPath = new string[][] {
            new string[] { "Meteor", "Spells/Meteor" },
            new string[] { "Crater", "Spells/Meteor" } /* should be Spells/Crater, but it isn't a sprite yet */
        };
    }

    public override void Cast() {
        if(assets == null) {
            LoadAssets();
        }

        if(pool == null) {
            pool = new List<GameObject>();
        }

        pool.Add(GameObject.Instantiate(assets["Meteor"]));
        return;
    }
}
