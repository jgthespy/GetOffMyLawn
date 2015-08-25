using UnityEngine;
using System.Collections;

public class Burn : StatusEffect {

    public override void TriggerEffectSpecificAction() {
        transform.parent.GetComponent<HealthManager>().Hit(magnitude, damageType);
    }

}
