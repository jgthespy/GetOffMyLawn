using UnityEngine;
using System.Collections;

public class BuffAgility : StatusEffect {

    public override void AddStatusEffect() {
        transform.parent.GetComponent<CharacterInfo>().AddAgility(magnitude);
    }

    public override void RemoveStatusEffect() {
        transform.parent.GetComponent<CharacterInfo>().RemoveAgility(magnitude);
    }

}
