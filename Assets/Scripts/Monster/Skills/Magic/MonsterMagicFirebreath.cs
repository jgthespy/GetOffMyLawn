using UnityEngine;
using System.Collections;

public class MonsterMagicFirebreath : Skill {

    public int burnDamage;
    public int burnDuration;
    public int burnAddDamage;
    public int burnRemoveDamage;

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedDamage = CalculateModifiedEffect(source, damage, modifierStat, damageModifier);
        target.GetComponent<HealthManager>().Hit(modifiedDamage, damageType);
        target.GetComponent<StatusEffectManager>().AddStatusEffect(GameInfo.StatusEffect.Burn, burnDuration, burnDamage, burnAddDamage, burnRemoveDamage);
    }

}
