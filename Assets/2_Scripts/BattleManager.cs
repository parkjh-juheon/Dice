using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Unit player;
    public List<Unit> enemyUnits;

    public GameObject playerAttackBoard1; // Goblin ���ݿ�
    public GameObject playerAttackBoard2; // MushroomMan ���ݿ�
    public GameObject playerDefenseBoard;
    public GameObject enemyAttackBoard;
    public GameObject enemyDefenseBoard1; // Goblin
    public GameObject enemyDefenseBoard2; // MushroomMan

    public void CalculateBattle()
    {
        // Player���� ���� ���
        int enemyAttack = SumDiceValuesInBoard(enemyAttackBoard.transform);
        int playerDefense = SumDiceValuesInBoard(playerDefenseBoard.transform);
        int damageToPlayer = Mathf.Max(enemyAttack - playerDefense, 0);
        player.TakeDamage(damageToPlayer);
        Debug.Log($"Player�� {damageToPlayer}�� ���ظ� ����. ���� ü��: {player.CurrentHP}");

        // Goblin ���� ���
        int playerAttack1 = SumDiceValuesInBoard(playerAttackBoard1.transform);
        int goblinDefense = SumDiceValuesInBoard(enemyDefenseBoard1.transform);
        int damageToGoblin = Mathf.Max(playerAttack1 - goblinDefense, 0);
        enemyUnits[0].TakeDamage(damageToGoblin);
        Debug.Log($"Goblin�� {damageToGoblin}�� ���ظ� ����. ���� ü��: {enemyUnits[0].CurrentHP}");

        // MushroomMan ���� ���
        int playerAttack2 = SumDiceValuesInBoard(playerAttackBoard2.transform);
        int mushroomDefense = SumDiceValuesInBoard(enemyDefenseBoard2.transform);
        int damageToMushroom = Mathf.Max(playerAttack2 - mushroomDefense, 0);
        enemyUnits[1].TakeDamage(damageToMushroom);
        Debug.Log($"MushroomMan�� {damageToMushroom}�� ���ظ� ����. ���� ü��: {enemyUnits[1].CurrentHP}");
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
