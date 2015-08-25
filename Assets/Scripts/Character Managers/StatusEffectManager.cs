using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatusEffectManager : MonoBehaviour {

    private GameInfo gameInfo;
    private List<GameObject> statusEffectList = new List<GameObject>();

    private void Awake() {
        gameInfo = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameInfo>();
    }

    public List<GameInfo.StatusEffect> GetListOfStatusEffects() {
        List<GameInfo.StatusEffect> theList = new List<GameInfo.StatusEffect>();
        foreach(GameObject effect in statusEffectList) {
            theList.Add(effect.GetComponent<StatusEffect>().GetEffectName());
        }
        return theList;
    }

    public void ActivateStatusEffects() {
        foreach(GameObject effect in statusEffectList) {
            StatusEffect currentEffect = effect.GetComponent<StatusEffect>();
            currentEffect.TriggerStatusEffect();
            if (currentEffect.GetNumberOfTicks() >= currentEffect.GetDuration())
                RemoveStatusEffect(currentEffect.GetEffectName());
        }
    }


    public void AddStatusEffect(GameInfo.StatusEffect effectName, int duration, int magnitude, int addMagnitude, int removeMagnitude) {
        bool hasDuplicate = false;
        GameObject duplicate = null;
        StatusEffect duplicateEffect = null;

        for (int i = 0; i < statusEffectList.Count; i++) {
            if (statusEffectList[i].GetComponent<StatusEffect>().GetEffectName() == effectName) {
                hasDuplicate = true;
                duplicate = statusEffectList[i];
                duplicateEffect = duplicate.GetComponent<StatusEffect>();
                break;
            }
        }
        if (hasDuplicate && duplicateEffect.maxStacks > 0 && (duplicateEffect.GetNumberOfStacks() < duplicateEffect.GetMaxStacks())) {
            duplicateEffect.AddStack(duration, magnitude);
        }

        else {
            GameObject newEffect = (GameObject)Instantiate(gameInfo.statusEffectList[(int)effectName], transform.position, Quaternion.identity);
            newEffect.GetComponent<StatusEffect>().Initialize(duration, magnitude, addMagnitude, removeMagnitude);
            newEffect.transform.parent = transform;
            statusEffectList.Add(newEffect);
            newEffect.GetComponent<StatusEffect>().AddStatusEffect();
        }
    }

    public void RemoveStatusEffect(GameInfo.StatusEffect effectName) {
        List<GameObject> tempList = new List<GameObject>();
        foreach (GameObject effect in statusEffectList) {
            if (effect.GetComponent<StatusEffect>().GetEffectName() == effectName) {
                tempList.Remove(effect);
                effect.GetComponent<StatusEffect>().RemoveStatusEffect();
                Destroy(effect);
            }
        }
        statusEffectList = tempList;
    }

}
