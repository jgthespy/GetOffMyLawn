using UnityEngine;
using System.Collections;

public class HeroActionScript : MonoBehaviour {

    public GameObject[] skillList = new GameObject[0];
    public float attackDelay;
    public float attackShakeAmount;
    public float attackShakeDelay;

    private CharacterInfo myInfo;
    private GameInfo gameInfo;
    private StatusEffectManager statusEffectManager;
    private GameObject gameManager;
    private TurnManager turnManager;
    private HeroAI myAI;
    private Timer attackDelayTimer;
    private Timer attackShakeTimer;

    private int triggeredSkillNumber;
    private Vector2 originalPosition;

    private void Awake() {
        myInfo = GetComponent<CharacterInfo>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        turnManager = gameManager.GetComponent<TurnManager>();
        statusEffectManager = GetComponent<StatusEffectManager>();
        gameInfo = gameManager.GetComponent<GameInfo>();
        myAI = GetComponent<HeroAI>();
        attackDelayTimer = gameObject.AddComponent<Timer>();
        attackDelayTimer.Trigger += ExecuteHeroAction;
        attackShakeTimer = gameObject.AddComponent<Timer>();
        attackShakeTimer.Trigger += ShakeMe;
        originalPosition = transform.position;
    }

    public void TakeTurn() {
        TriggerHeroAction(myAI.ChooseAction());
    }

    public void TriggerHeroAction(int skillNumber) {
        statusEffectManager.ActivateStatusEffects();
        triggeredSkillNumber = skillNumber;
        attackDelayTimer.Go(attackDelay);
    }

    private void ExecuteHeroAction() {
        // Shake!
        Vector2 newPosition = transform.position;
        newPosition.y += attackShakeAmount;
        transform.position = newPosition;
        attackShakeTimer.Go(attackShakeDelay);

        if (triggeredSkillNumber > skillList.Length - 1)
            Debug.Log("Invalid skill");
        else {
            Skill triggeredSkill = skillList[triggeredSkillNumber].GetComponent<Skill>();
            triggeredSkill.UseSkill(gameObject, gameInfo.GetTheMonster());
            turnManager.HeroTookTurn(myInfo.characterNumber);
        }

    }

    private void ShakeMe() {
        transform.position = originalPosition;
    }

}
