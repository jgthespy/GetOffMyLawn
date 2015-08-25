using UnityEngine;
using System.Collections;

public class HeroSkillTaunt : Skill {

    public int tauntDuration;

    public override void UseSkill(GameObject source, GameObject target) {
        target.GetComponent<StatusEffectManager>().AddStatusEffect(GameInfo.StatusEffect.Taunted, tauntDuration, 0, 0, 0);
    }


}
