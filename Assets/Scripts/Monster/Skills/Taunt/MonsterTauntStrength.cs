using UnityEngine;
using System.Collections;

public class MonsterTauntStrength : Skill {

    public int debuffDuration;
    public int debuffAmount;
    public GameInfo.Stat debuffedStat;

    public override void UseSkill(GameObject source, GameObject target) {
        int modifiedAmount = CalculateModifiedEffect(source, debuffAmount, modifierStat, damageModifier);
        GameObject[] heroList = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < heroList.Length; i++) {
            heroList[i].GetComponent<StatusEffectManager>().AddStatusEffect(GameInfo.StatusEffect.DebuffStrength, debuffDuration, modifiedAmount, 0, 0);
        }
    }


}
