using UnityEngine;
using System.Collections;

public class MonsterChargeStrength : Skill {

    public int buffDuration;
    public int buffAmount;
    public GameInfo.Stat buffedStat;

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedAmount = CalculateModifiedEffect(source, buffAmount, modifierStat, damageModifier);
        source.GetComponent<StatusEffectManager>().AddStatusEffect(GameInfo.StatusEffect.BuffStrength, buffDuration, modifiedAmount, 0, 0);
    }

}
