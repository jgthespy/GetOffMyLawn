using UnityEngine;
using System.Collections;

public class MonsterMagicStorm : Skill {

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedDamage = CalculateModifiedEffect(source, damage, modifierStat, damageModifier);
        GameObject[] heroList = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < heroList.Length; i++) {
            heroList[i].GetComponent<HealthManager>().Hit(modifiedDamage, damageType);
        }
    }

}
