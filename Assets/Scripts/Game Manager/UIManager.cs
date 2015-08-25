using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public UnityEngine.UI.Image[] monsterSubMenu = new UnityEngine.UI.Image[4];
    public Text[] heroLastAction = new Text[4];

    void Awake() {
        turnOffAllSubmenus();
        ClearAllLastActions();
    }

    public void toggleSubmenu(int menuNumber) {
        monsterSubMenu[menuNumber].enabled = !monsterSubMenu[menuNumber].enabled;
        toggleSubmenuItems(menuNumber);
        for (int i = 0; i < monsterSubMenu.Length; i++) {
            if (i != menuNumber) {
                turnOffSubmenu(i);
            }
        }
    }

    public void toggleSubmenuItems(int menuNumber) {
        foreach (Transform child in monsterSubMenu[menuNumber].transform) {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
    }

    public void turnOffSubmenu(int menuNumber) {
        monsterSubMenu[menuNumber].enabled = false;
        foreach (Transform child in monsterSubMenu[menuNumber].transform) {
            child.gameObject.SetActive(false);
        }
    }

    public void turnOffAllSubmenus() {
        for (int i = 0; i < monsterSubMenu.Length; i++) {
            foreach (Transform child in monsterSubMenu[i].transform) {
                child.gameObject.SetActive(false);
            }
            monsterSubMenu[i].enabled = false;
        }
    }

    public void ClearLastAction(int heroNumber) {
        heroLastAction[heroNumber - 1].text = "";
    }

    public void ClearAllLastActions() {
        for (int i = 0; i < heroLastAction.Length; i++) {
            ClearLastAction(i + 1);
        }
    }


}
