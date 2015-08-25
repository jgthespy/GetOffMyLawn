using UnityEngine;
using System.Collections;

public class HeroAI : MonoBehaviour {

    public GameInfo.HeroRole role;
    public int specialRechargeTime;

    private GameObject gameManager;
    private GameInfo gameInfo;
    private UIManager uiManager;
    private HeroActionScript actionScript;
    private CharacterInfo myInfo;
    private GameObject[] characters = new GameObject[5];
    private GameObject myTarget;

    private bool specialReady = true;
    private int timeUntilNextSpecial;


    void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameInfo = gameManager.GetComponent<GameInfo>();
        uiManager = gameManager.GetComponent<UIManager>();
        actionScript = GetComponent<HeroActionScript>();
        myInfo = GetComponent<CharacterInfo>();
        characters = gameInfo.characters;
    }


    public int ChooseAction() {
        int chosenAction = 0;
        timeUntilNextSpecial--;
        if (timeUntilNextSpecial <= 0)
            specialReady = true;

        uiManager.ClearAllLastActions();
        switch (role) {
            case GameInfo.HeroRole.Tank:
                if (specialReady) {
                    specialReady = false;
                    timeUntilNextSpecial = specialRechargeTime;
                    chosenAction = 1;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Taunt!";
                }
                else {
                    chosenAction = 0;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Attack!";
                }
                 break;
            case GameInfo.HeroRole.PhysicalDamage:
                timeUntilNextSpecial--;
                if (timeUntilNextSpecial <= 0)
                    specialReady = true;
                if (specialReady) {
                    specialReady = false;
                    timeUntilNextSpecial = specialRechargeTime;
                    chosenAction = 1;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Stabstab";
                }
                else {
                    chosenAction = 0;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Attack!";
                }
                break;
            case GameInfo.HeroRole.MagicDamage:
                timeUntilNextSpecial--;
                if (timeUntilNextSpecial <= 0)
                    specialReady = true;
                if (specialReady) {
                    specialReady = false;
                    timeUntilNextSpecial = specialRechargeTime;
                    chosenAction = 1;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Fireball!";
                }
                else {
                    chosenAction = 0;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Attack!";
                }
                break;
            case GameInfo.HeroRole.Healer:
                timeUntilNextSpecial--;
                if (timeUntilNextSpecial <= 0)
                    specialReady = true;
                if (specialReady) {
                    specialReady = false;
                    timeUntilNextSpecial = specialRechargeTime;
                    chosenAction = 1;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Heal!";

                    int lowestHealth = 100;
                    int lowestHealthIndex = 1;
                    for (int i = 1; i < characters.Length; i++) {
                        if (characters[i].GetComponent<HealthManager>().GetCurrentHP() < lowestHealth)
                            lowestHealthIndex = i;
                    }
                    myTarget = characters[lowestHealthIndex];
                }
                else {
                    chosenAction = 0;
                    uiManager.heroLastAction[myInfo.characterNumber - 1].text = "Attack!";
                }
                break;
            default:
                Debug.Log("Invalid hero role");
                break;

        }

        return chosenAction;
    }


    public GameObject GetTarget() {
        return myTarget;
    }

}
