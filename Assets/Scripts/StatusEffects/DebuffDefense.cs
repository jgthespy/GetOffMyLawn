using UnityEngine;
using System.Collections;

public class DebuffDefense : StatusEffect {

    public override void AddStatusEffect() {
        transform.parent.GetComponent<CharacterInfo>().RemoveDefense(magnitude);
    }

    public override void RemoveStatusEffect() {
        transform.parent.GetComponent<CharacterInfo>().AddDefense(magnitude);
    }

}
