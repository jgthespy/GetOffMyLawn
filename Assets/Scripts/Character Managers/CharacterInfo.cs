using UnityEngine;
using System.Collections;

public class CharacterInfo : MonoBehaviour {

    // General Info
    public bool isHero;
    public int characterNumber;

    // Art and Effects
    public Sprite mainSprite;
    public Sprite deadSprite;

    // Inherent Stats
    public int strength;
    public int agility;
    public int intelligence;
    public int wisdom;
    public int defense;

    // Modified Stats
    private int modifiedStrength;
    private int modifiedAgility;
    private int modifiedIntelligence;
    private int modifiedWisdom;
    private int modifiedDefense;


    // Get modified stats
    public int GetStrength() {
        return modifiedStrength;
    }
    public int GetAgility() {
        return modifiedAgility;
    }
    public int GetIntelligence() {
        return modifiedIntelligence;
    }
    public int GetWisdom() {
        return modifiedWisdom;
    }
    public int GetDefense() {
        return modifiedDefense;
    }

    // Increase stats
    public void AddStrength(int amount) {
        modifiedStrength += amount;
    }
    public void AddAgility(int amount) {
        modifiedAgility += amount;
    }
    public void AddIntelligence(int amount) {
        modifiedIntelligence += amount;
    }
    public void AddWisdom(int amount) {
        modifiedWisdom += amount;
    }
    public void AddDefense(int amount) {
        modifiedDefense += amount;
    }

    // Decrease stats
    public void RemoveStrength(int amount) {
        modifiedStrength -= amount;
        if (modifiedStrength < 0)
            modifiedStrength = 0;
    }
    public void RemoveAgility(int amount) {
        modifiedAgility -= amount;
        if (modifiedAgility < 0)
            modifiedAgility = 0;
    }
    public void RemoveIntelligence(int amount) {
        modifiedIntelligence -= amount;
        if (modifiedIntelligence < 0)
            modifiedAgility = 0;
    }
    public void RemoveWisdom(int amount) {
        modifiedWisdom -= amount;
        if (modifiedWisdom < 0)
            modifiedWisdom = 0;
    }
    public void RemoveDefense(int amount) {
        modifiedDefense -= amount;
        if (modifiedDefense < 0)
            modifiedDefense = 0;
    }


    // Reset stats
    public void ResetStrength() {
        modifiedStrength = strength;
    }
    public void ResetAgility() {
        modifiedAgility = agility;
    }
    public void ResetIntelligence() {
        modifiedIntelligence = intelligence;
    }
    public void ResetWisdom() {
        modifiedWisdom = wisdom;
    }
    public void ResetDefense() {
        modifiedDefense = defense;
    }
    public void ResetAllStats() {
        modifiedStrength = strength;
        modifiedAgility = agility;
        modifiedIntelligence = intelligence;
        modifiedWisdom = wisdom;
        modifiedDefense = defense;
    }


    void Awake() {
        /*if (characterNumber == 0) {
            strength = PersistentData.monsterStrength;
            agility = PersistentData.monsterAgility;
            intelligence = PersistentData.monsterIntelligence;
            wisdom = PersistentData.monsterWisdom;
            defense = PersistentData.monsterDefense;
        }*/
        ResetAllStats();
    }



}
