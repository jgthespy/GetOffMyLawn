using UnityEngine;
using System.Collections;

public class MonsterChargeAgility : Skill {

    public int buffDuration;
    public int buffAmount;
    public GameInfo.Stat buffedStat;

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedAmount = CalculateModifiedEffect(source, buffAmount, modifierStat, damageModifier);
        source.GetComponent<StatusEffectManager>().AddStatusEffect(GameInfo.StatusEffect.BuffAgility, buffDuration, modifiedAmount, 0, 0);
    }

}
