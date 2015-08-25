using UnityEngine;
using System.Collections;

public class BuffStrength : StatusEffect {

    public override void AddStatusEffect() {
        transform.parent.GetComponent<CharacterInfo>().AddStrength(magnitude);
    }

    public override void RemoveStatusEffect() {
        transform.parent.GetComponent<CharacterInfo>().RemoveStrength(magnitude);
    }

}
