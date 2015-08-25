using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    public UnityEngine.UI.Button[] buttonList = new UnityEngine.UI.Button[4];

    private GameInfo gameInfo;
    private UIManager uiManager;
    private GameObject[] characters;
    private CharacterInfo[] characterStats = new CharacterInfo[5];
    private int[] charactersNextTurn = new int[5];
    private int currentTurn;

    void Start() {
        gameInfo = GetComponent<GameInfo>();
        uiManager = GetComponent<UIManager>();
        characters = gameInfo.GetCharacters();
        for (int i = 0; i < 5; i++) {
            characterStats[i] = characters[i].GetComponent<CharacterInfo>();
        }
        FirstTurn();
    }

    private void FirstTurn() {
        for (int i = 0; i < 5; i++) {
            charactersNextTurn[i] = gameInfo.statMax - characterStats[i].GetAgility();
            while (CheckForDuplicateTurn(i))
                charactersNextTurn[i]++;
        }

        currentTurn = 0;
        NextTurn();
    }

    private void NextTurn() {
        bool noTurnTaken = true;
        for (int i = 0; i < 5; i++) {
/*            if (charactersNextTurn[i] < currentTurn) {
                charactersNextTurn[i] = currentTurn;
                while (CheckForDuplicateTurn(i))
                    charactersNextTurn[i]++;
            }*/
            if (charactersNextTurn[i] == currentTurn) {
                noTurnTaken = false;
                if (i == 0)
                    MonsterTurn();
                else
                    HeroTurn(i);
                break;
            }
        }
        if (noTurnTaken) {
            currentTurn++;
            NextTurn();
        }
    }

    private bool CheckForDuplicateTurn(int index) {
        for (int i = 0; i < 5; i++) {
            if (charactersNextTurn[index] == charactersNextTurn[i] && i != index)
                return true;
        }
        return false;
    }


    private void MonsterTurn() {
        foreach (UnityEngine.UI.Button button in buttonList) {
            button.interactable = true;
        }
    }


    private void HeroTurn(int heroNumber) {
        if (characters[heroNumber].GetComponent<HealthManager>().IsDead()) {
            charactersNextTurn[heroNumber] += gameInfo.statMax - characterStats[heroNumber].GetAgility();
            while (CheckForDuplicateTurn(heroNumber)) {
                charactersNextTurn[heroNumber]++;
            }
            Debug.Log("Skipping dead hero");
            currentTurn++;
            NextTurn();
        }
        else {
            characters[heroNumber].GetComponent<HeroActionScript>().TakeTurn();
        }
    }


    public void MonsterTookTurn() {
        uiManager.turnOffAllSubmenus();
        foreach (UnityEngine.UI.Button button in buttonList) {
            button.interactable = false;
        }
        charactersNextTurn[0] += gameInfo.statMax - characterStats[0].GetAgility();
        while (CheckForDuplicateTurn(0)){
            charactersNextTurn[0]++;
        }
        currentTurn++;
        NextTurn();
    }

    public void HeroTookTurn(int heroNumber) {
        charactersNextTurn[heroNumber] += gameInfo.statMax - characterStats[heroNumber].GetAgility();
        while (CheckForDuplicateTurn(heroNumber)){
            charactersNextTurn[heroNumber]++;
        }
        currentTurn++;
        NextTurn();
    }

}
