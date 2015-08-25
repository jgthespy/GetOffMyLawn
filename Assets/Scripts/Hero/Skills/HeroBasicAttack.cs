using UnityEngine;
using System.Collections;

public class HeroBasicAttack : Skill {

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedDamage = CalculateModifiedEffect(source, damage, modifierStat, damageModifier);
        target.GetComponent<HealthManager>().Hit(modifiedDamage, damageType);
    }


}
