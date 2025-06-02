using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Unit player;
    public List<Unit> enemyUnits;

    public GameObject playerDefenseBoard;
    public GameObject enemyAttackBoard;

    public List<GameObject> playerAttackBoards; // �÷��̾��� ���� �����
    public List<GameObject> enemyDefenseBoards; // �� ���� ��� �����

    public void CalculateBattle()
    {
        Debug.Log("[BattleManager] CalculateBattle ȣ���");

        // �÷��̾� ���� ���
        int enemyAttack = SumDiceValuesInBoard(enemyAttackBoard.transform);
        int playerDefense = SumDiceValuesInBoard(playerDefenseBoard.transform);
        int damageToPlayer = Mathf.Max(enemyAttack - playerDefense, 0);
        Debug.Log($"[Player ���� ���] �� ���� ��: {enemyAttack}, �÷��̾� ��� ��: {playerDefense}, ���� ���ط�: {damageToPlayer}");
        player.TakeDamage(damageToPlayer);
        Debug.Log($"Player�� {damageToPlayer}�� ���ظ� ����. ���� ü��: {player.CurrentHP}");

        // �� �� ���� ���� ���
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            int playerAttack = i < playerAttackBoards.Count
                ? SumDiceValuesInBoard(playerAttackBoards[i].transform)
                : 0;

            int enemyDefense = i < enemyDefenseBoards.Count
                ? SumDiceValuesInBoard(enemyDefenseBoards[i].transform)
                : 0;

            int damageToEnemy = Mathf.Max(playerAttack - enemyDefense, 0);
            Debug.Log($"[Enemy {i}] ����: {playerAttack}, ���: {enemyDefense}, ���ط�: {damageToEnemy}");

            enemyUnits[i].TakeDamage(damageToEnemy);
            Debug.Log($"Enemy {i}�� {damageToEnemy}�� ���ظ� ����. ���� ü��: {enemyUnits[i].CurrentHP}");
        }
    }

    public void ResetAllEnemyDice()
    {
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            Unit enemy = enemyUnits[i];

            if (enemy == null || enemy.CurrentHP <= 0)
                continue;
        }
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
                    int value = dice.GetValue();
                    if (value > 0) // ������ �ֻ����� �ջ�
                        sum += value;
                }
            }
        }
        return sum;
    }
}
