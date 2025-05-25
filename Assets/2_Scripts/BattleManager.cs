using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Unit player;
    public List<Unit> enemyUnits;

    public GameObject playerAttackBoard1; // Goblin 공격용
    public GameObject playerAttackBoard2; // MushroomMan 공격용
    public GameObject playerDefenseBoard;
    public GameObject enemyAttackBoard;
    public GameObject enemyDefenseBoard1; // Goblin
    public GameObject enemyDefenseBoard2; // MushroomMan

    public void CalculateBattle()
    {
        // Player에게 피해 계산
        int enemyAttack = SumDiceValuesInBoard(enemyAttackBoard.transform);
        int playerDefense = SumDiceValuesInBoard(playerDefenseBoard.transform);
        int damageToPlayer = Mathf.Max(enemyAttack - playerDefense, 0);
        player.TakeDamage(damageToPlayer);
        Debug.Log($"Player가 {damageToPlayer}의 피해를 입음. 남은 체력: {player.CurrentHP}");

        // Goblin 피해 계산
        int playerAttack1 = SumDiceValuesInBoard(playerAttackBoard1.transform);
        int goblinDefense = SumDiceValuesInBoard(enemyDefenseBoard1.transform);
        int damageToGoblin = Mathf.Max(playerAttack1 - goblinDefense, 0);
        enemyUnits[0].TakeDamage(damageToGoblin);
        Debug.Log($"Goblin이 {damageToGoblin}의 피해를 입음. 남은 체력: {enemyUnits[0].CurrentHP}");

        // MushroomMan 피해 계산
        int playerAttack2 = SumDiceValuesInBoard(playerAttackBoard2.transform);
        int mushroomDefense = SumDiceValuesInBoard(enemyDefenseBoard2.transform);
        int damageToMushroom = Mathf.Max(playerAttack2 - mushroomDefense, 0);
        enemyUnits[1].TakeDamage(damageToMushroom);
        Debug.Log($"MushroomMan이 {damageToMushroom}의 피해를 입음. 남은 체력: {enemyUnits[1].CurrentHP}");
    }

    private int SumDiceValuesInBoard(Transform board)
    {
        int sum = 0;
        foreach (Transform slot in board)
        {
            if (slot.childCount > 0)
            {
                Dice dice = slot.GetChild(0).GetComponent<Dice>();
                if (dice != null)
                {
                    sum += dice.GetValue();
                }
            }
        }
        return sum;
    }
}
