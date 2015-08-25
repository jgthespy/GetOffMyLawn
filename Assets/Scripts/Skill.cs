using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

    public int skillNumber;
    public bool targetSelf;
    public int damage;
    public float damageModifier;
    public GameInfo.Stat modifierStat;
    public GameInfo.ActionType actionType;
    public GameInfo.DamageType damageType;

    public virtual void UseSkill(GameObject source, GameObject target) {
        Debug.Log("Empty skill triggered");
    }

    public int CalculateModifiedEffect(GameObject character, int initial, GameInfo.Stat stat, float modifierAmount) {
        float modifier = modifierAmount;
        CharacterInfo characterInfo = character.GetComponent<CharacterInfo>();
        switch (stat) {
            case GameInfo.Stat.Strength:
                modifier *= characterInfo.GetStrength();
                break;
            case GameInfo.Stat.Agility:
                modifier *= characterInfo.GetAgility();
                break;
            case GameInfo.Stat.Intelligence:
                modifier *= characterInfo.GetIntelligence();
                break;
            case GameInfo.Stat.Wisdom:
                modifier *= characterInfo.GetWisdom();
                break;
            case GameInfo.Stat.Defense:
                modifier *= characterInfo.GetDefense();
                break;
            default:
                break;
        }

        return (int)(initial + modifier);
    }

}
