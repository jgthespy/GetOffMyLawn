using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int maxHitpoints;
    public float damageTextTime;
    public float maximumDamageReduction;
    public float hitShakeAmount;
    public float hitShakeDelay;
    public Slider hpSlider;

    private int currentHitpoints;
    private CharacterInfo myInfo;
    private GameObject gameManager;
    private GameInfo gameInfo;
    private SpriteManager spriteManager;
    private Timer hitShakeTimer;
    private bool dead = false;

    private Vector3 originalPosition;

    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameInfo = gameManager.GetComponent<GameInfo>();
        myInfo = GetComponent<CharacterInfo>();
        spriteManager = GetComponent<SpriteManager>();
        currentHitpoints = maxHitpoints;
        hitShakeTimer = gameObject.AddComponent<Timer>();
        hitShakeTimer.Trigger += ShakeMe;
        
        originalPosition = transform.position;
        if (maximumDamageReduction < 0)
            maximumDamageReduction = 0;
        if (maximumDamageReduction > 1)
            maximumDamageReduction = 1;
    }

    public void Hit(int damageAmount, GameInfo.DamageType type) {
        // Shake!
        Vector2 newPosition = transform.position;
        newPosition.x += hitShakeAmount;
        transform.position = newPosition;
        hitShakeTimer.Go(hitShakeDelay);

        // Damage reduction
        float damageReduction = 0;
        if (type == GameInfo.DamageType.Physical)
            damageReduction = 1 - ((float)myInfo.GetDefense() / (float)gameInfo.statMax);
        else if (type == GameInfo.DamageType.Magical)
            damageReduction = 1 - ((float)myInfo.GetWisdom() / (float)gameInfo.statMax);
        damageReduction *= maximumDamageReduction;
        damageAmount = (int)Mathf.Floor(damageAmount * damageReduction);

        currentHitpoints -= damageAmount;
        if (currentHitpoints <= 0) {
            currentHitpoints = 0;
            Kill();
        }
        hpSlider.value = (float)currentHitpoints / (float)maxHitpoints;
    }

    public void Heal(int healAmount) {
        currentHitpoints += healAmount;
        if (currentHitpoints > maxHitpoints)
            currentHitpoints = maxHitpoints;
        hpSlider.value = (float)currentHitpoints / (float)maxHitpoints;
    }

    public bool IsDead() {
        return dead;
    }

    private void Kill() {
        dead = true;
        spriteManager.ChangeSprite(myInfo.deadSprite);
        if (myInfo.isHero)
            gameInfo.HeroDied(myInfo.characterNumber);
    }

    private void Ressurect(int hitpoints) {
        dead = false;
        Heal(hitpoints);
        spriteManager.ChangeSprite(myInfo.mainSprite);
        if (myInfo.isHero)
            gameInfo.HeroRevived(myInfo.characterNumber);

    }

    private void ShakeMe() {
        transform.position = originalPosition;
    }

    public int GetCurrentHP() {
        return currentHitpoints;
    }

}
