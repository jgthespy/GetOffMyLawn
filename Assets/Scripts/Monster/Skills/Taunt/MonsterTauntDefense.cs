using UnityEngine;
using System.Collections;

public class MonsterTauntDefense : Skill {

    public int debuffDuration;
    public int debuffAmount;
    public GameInfo.Stat debuffedStat;

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedAmount = CalculateModifiedEffect(source, debuffAmount, modifierStat, damageModifier);
        target.GetComponent<StatusEffectManager>().AddStatusEffect(GameInfo.StatusEffect.DebuffDefense, debuffDuration, modifiedAmount, 0, 0);
       
    }

}
