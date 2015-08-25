using UnityEngine;
using System.Collections;

public class HeroSkillHeal : Skill {

    public int healAmount;

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedAmount = CalculateModifiedEffect(source, healAmount, modifierStat, damageModifier);
        target = source.GetComponent<HeroAI>().GetTarget();
        target.GetComponent<HealthManager>().Heal(modifiedAmount);
    }

}
