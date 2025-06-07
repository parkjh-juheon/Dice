using System.Collections.Generic;
using UnityEngine;

public class EnemyDiceSpawner : MonoBehaviour
{
    public GameObject dicePrefab;
    public Transform[] diceSlots;
    public int diceToSpawn = 3;
    public Color diceColor = Color.red;

    private List<Dice> spawnedDice = new List<Dice>();

    private Unit unit; 

    private void Start()
    {
        unit = GetComponent<Unit>(); 
        SpawnRandomDice();
    }

    public void SpawnRandomDice()
    {
        if (!enabled || (unit != null && unit.Isdead)) return;

        spawnedDice.Clear();

        HashSet<Transform> slotSet = new HashSet<Transform>(diceSlots);
        Transform[] uniqueSlots = new Transform[slotSet.Count];
        slotSet.CopyTo(uniqueSlots);

        // 셔플
        System.Random rng = new System.Random();
        Transform[] shuffledSlots = (Transform[])uniqueSlots.Clone();
        for (int i = 0; i < shuffledSlots.Length; i++)
        {
            int swapIndex = rng.Next(i, shuffledSlots.Length);
            (shuffledSlots[i], shuffledSlots[swapIndex]) = (shuffledSlots[swapIndex], shuffledSlots[i]);
        }

        int spawned = 0;
        foreach (Transform slot in shuffledSlots)
        {
            if (spawned >= diceToSpawn)
                break;

            if (slot.childCount > 0)
                continue;

            GameObject diceObj = Instantiate(dicePrefab, slot.position, Quaternion.identity);
            diceObj.transform.SetParent(slot);
            diceObj.tag = "E_Attack_Dice";

            SpriteRenderer sr = diceObj.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = diceColor;

            Dice dice = diceObj.GetComponent<Dice>();
            if (dice != null)
                spawnedDice.Add(dice);

            spawned++;
        }
    }

    public void RespawnAll()
    {
        if (!enabled || (unit != null && unit.Isdead)) return;

        foreach (var dice in spawnedDice)
        {
            if (dice != null)
                Destroy(dice.gameObject);
        }

        spawnedDice.Clear();
        SpawnRandomDice();
    }


    public void RollAll()
    {
        foreach (var dice in spawnedDice)
        {
            dice.RollDice();
        }
    }

}
