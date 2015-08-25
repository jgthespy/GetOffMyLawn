using UnityEngine;
using System.Collections;

public class MonsterActionScript : MonoBehaviour {

    public GameObject[] skillList = new GameObject[0];
    public float attackShakeAmount;
    public float attackShakeDelay;

    public int tauntTarget = 0;    // 0 mean not taunted

    private GameInfo gameInfo;
    private GameObject gameManager;
    private StatusEffectManager statusEffectManager;
    private TurnManager turnManager;
    private Timer attackShakeTimer;
    private GameObject lastHit;

    private Vector2 originalPosition;

    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        turnManager = gameManager.GetComponent<TurnManager>();
        statusEffectManager = GetComponent<StatusEffectManager>();
        gameInfo = gameManager.GetComponent<GameInfo>();
        attackShakeTimer = gameObject.AddComponent<Timer>();
        attackShakeTimer.Trigger += ShakeMe;
        originalPosition = transform.position;
    }

    public void TriggerMonsterAction(int skillNumber) {
        statusEffectManager.ActivateStatusEffects();
        if (skillNumber > skillList.Length - 1)
            Debug.Log("Invalid skill");
        else {
            // Shake!
            Vector2 newPosition = transform.position;
            newPosition.x += attackShakeAmount;
            transform.position = newPosition;
            attackShakeTimer.Go(attackShakeDelay);

            Skill triggeredSkill = skillList[skillNumber].GetComponent<Skill>();
            GameObject target = gameInfo.GetSelectedHero();
            if (tauntTarget != 0) {
                target = gameInfo.characters[tauntTarget];
            }
            lastHit = target;
            triggeredSkill.UseSkill(gameObject, target);
            turnManager.MonsterTookTurn();
        }
    }

    private void ShakeMe() {
        transform.position = originalPosition;
    }

    public GameObject GetLastHit() {
        return lastHit;
    }
}
