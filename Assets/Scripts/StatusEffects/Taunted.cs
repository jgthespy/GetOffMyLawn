using UnityEngine;
using System.Collections;

public class Taunted : StatusEffect {

    public override void AddStatusEffect() {
        transform.parent.GetComponent<MonsterActionScript>().tauntTarget = 1;
    }

    public override void RemoveStatusEffect() {
        transform.parent.GetComponent<MonsterActionScript>().tauntTarget = 0;
    }


}
