using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeManager : MonoBehaviour {

    public int statIncreaseAmount;
    public int statIncreaseRange;   // stat increases +/- this amount
    public Text resultText;


    public void BoostStat(int statNumber) {   // See enum in GameInfo for stat numbers
        int randomness = (int)Mathf.Floor(Random.Range((float)-statIncreaseRange, (float)statIncreaseRange));

        switch (statNumber) {
            case 0:
                PersistentData.monsterStrength += statIncreaseAmount + randomness;
                break;
            case 1:
                PersistentData.monsterAgility += statIncreaseAmount + randomness;
                break;
            case 2:
                PersistentData.monsterIntelligence += statIncreaseAmount + randomness;
                break;
            case 3:
                PersistentData.monsterWisdom += statIncreaseAmount + randomness;
                break;
            case 4:
                PersistentData.monsterDefense += statIncreaseAmount + randomness;
                break;
            default:
                Debug.Log("Invalid stat");
                break;
        }

        resultText.text = (GameInfo.Stat)statNumber + " increased by " + (statIncreaseAmount + randomness);
    }

    public void GoFight() {
        Application.LoadLevel(1);
    }

	
}
