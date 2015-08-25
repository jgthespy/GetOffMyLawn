using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour {

    // *** Statics *** //

    // Player Stats
    static public int monsterStrength;
    static public int monsterAgility;
    static public int monsterIntelligence;
    static public int monsterWisdom;
    static public int monsterDefense;

    // Other Stuff
    static public int currentLevel = 0;

    // *************** //



    public int startStrength;
    public int startAgility;
    public int startIntelligence;
    public int startWisdom;
    public int startDefense;


    void Awake() {
        monsterStrength = startStrength;
        monsterAgility = startAgility;
        monsterIntelligence = startIntelligence;
        monsterWisdom = startWisdom;
        monsterDefense = startDefense;
    }



}
