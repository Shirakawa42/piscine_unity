using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentUpgradeScript : MonoBehaviour {

	public SpellScript			spellscript;
	public Text					talent_text;
	public PlayerSpellScript	player;

	public void 	onclick() {
		if (player.talent_points > 0 && spellscript.level < 5) {
			player.useTalentPoint();
			spellscript.levelUp();
			talent_text.text = spellscript.level + "/5";
		}
	}
}
