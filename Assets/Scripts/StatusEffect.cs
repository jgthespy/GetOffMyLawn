using UnityEngine;
using System.Collections;

public class StatusEffect : MonoBehaviour {

    public int maxStacks;
    public GameInfo.ActionType actionType;
    public GameInfo.DamageType damageType;
    public GameInfo.StatusEffect statusEffectName;

    protected int duration;
    protected int magnitude;
    protected int addMagnitude;
    protected int removeMagnitude;

    protected int numberOfTicks;
    protected int numberOfStacks;

    void Awake() {
        numberOfTicks = 0;
        numberOfStacks = 0;
    }

    public void Initialize(int myDuration, int myMagnitude, int myAddMagnitude, int myRemoveMagnitude) {
        duration = myDuration;
        magnitude = myMagnitude;
        addMagnitude = myAddMagnitude;
        removeMagnitude = myRemoveMagnitude;
    }

    public GameInfo.StatusEffect GetEffectName() {
        return statusEffectName;
    }

    public GameInfo.ActionType GetActionType() {
        return actionType;
    }

    public GameInfo.DamageType GetDamageType() {
        return damageType;
    }

    public int GetDuration() {
        return duration;
    }

    public int GetNumberOfTicks() {
        return numberOfTicks;
    }

    public int GetMaxStacks() {
        return maxStacks;
    }

    public int GetNumberOfStacks() {
        return numberOfStacks;
    }

    public void TriggerStatusEffect() {
        numberOfTicks++;
        TriggerEffectSpecificAction();
    }

    public virtual void AddStatusEffect() {
        Debug.Log(gameObject.name + " added");
    }

    public virtual void RemoveStatusEffect() {
        Debug.Log(gameObject.name + " removed");
    }

    public virtual void TriggerEffectSpecificAction() {
        Debug.Log(gameObject.name + " triggered");
    }

    public virtual void AddStack(int durationAmount, int magnitudeAmount) {
        duration += durationAmount;
        magnitude += magnitudeAmount;
        numberOfStacks++;
    }

    
}
