using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameInfo : MonoBehaviour {

    public enum Stat { Strength, Agility, Intelligence, Wisdom, Defense };
    public enum ActionType { Attack, Magic, Taunt, Charge };
    public enum DamageType { Physical, Magical };
    public enum StatusEffect { Burn, BuffStrength, DebuffDefense, BuffAgility, DebuffStrength, Taunted};
    public enum HeroRole { Tank, PhysicalDamage, MagicDamage, Buff, Debuff, Healer };

    public GameObject[] characters = new GameObject[5];
    public UnityEngine.UI.Toggle[] selectionArrows = new UnityEngine.UI.Toggle[4];
    public GameObject[] statusEffectList = new GameObject[0];
    public int statMax;

    private int selectedHero;
    private bool[] deadHero = new bool[4];
    private int numberOfDeadHeroes = 0;
    public float selectionArrowVisibleY;
    public float selectionArrowHiddenY;

    private void Awake() {
        selectedHero = 1;
        for (int i = 0; i < deadHero.Length; i++) {
            deadHero[i] = false;
        }
    }

    public GameObject[] GetCharacters() {
        return characters;
    }

    public GameObject GetSelectedHero() {
        return characters[selectedHero];
    }

    public void ChangeSelectedHero (int newSelectedHero) {
        if (newSelectedHero > characters.Length - 1)
            Debug.Log("Invalid Hero");
        else {
            selectedHero = newSelectedHero;
        }
    }

    public GameObject GetTheMonster() {
        return characters[0];
    }

    public void HeroDied(int heroNumber) {
        deadHero[heroNumber - 1] = true;
        numberOfDeadHeroes++;
        if (numberOfDeadHeroes >= 4)
            Debug.Log("All heroes are dead!");
        else {
            for (int i = 0; i < deadHero.Length; i++) {
                if (!deadHero[i]) {
                    selectedHero = i + 1;
                    selectionArrows[i].isOn = true;
                    break;
                }
            }
        }
    }

    public void HeroRevived(int heroNumber) {
        deadHero[heroNumber - 1] = false;
        numberOfDeadHeroes--;
    }

}
