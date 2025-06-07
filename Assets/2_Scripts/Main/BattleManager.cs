using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Unit player;
    public List<Unit> enemyUnits;

    public GameObject playerDefenseBoard;
    public GameObject enemyAttackBoard;

    public List<GameObject> playerAttackBoards; // 플레이어의 공격 보드들
    public List<GameObject> enemyDefenseBoards; // 각 적의 방어 보드들

    public void CalculateBattle()
    {
        Debug.Log("[BattleManager] CalculateBattle 호출됨");

        // 플레이어 피해 계산
        int enemyAttack = SumDiceValuesInBoard(enemyAttackBoard.transform);
        int playerDefense = SumDiceValuesInBoard(playerDefenseBoard.transform);
        int damageToPlayer = Mathf.Max(enemyAttack - playerDefense, 0);
        Debug.Log($"[Player 피해 계산] 적 공격 합: {enemyAttack}, 플레이어 방어 합: {playerDefense}, 최종 피해량: {damageToPlayer}");
        player.TakeDamage(damageToPlayer);
        Debug.Log($"Player가 {damageToPlayer}의 피해를 입음. 남은 체력: {player.CurrentHP}");

        // 각 적 유닛 피해 계산
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            int playerAttack = i < playerAttackBoards.Count
                ? SumDiceValuesInBoard(playerAttackBoards[i].transform)
                : 0;

            int enemyDefense = i < enemyDefenseBoards.Count
                ? SumDiceValuesInBoard(enemyDefenseBoards[i].transform)
                : 0;

            int damageToEnemy = Mathf.Max(playerAttack - enemyDefense, 0);
            Debug.Log($"[Enemy {i}] 공격: {playerAttack}, 방어: {enemyDefense}, 피해량: {damageToEnemy}");

            enemyUnits[i].TakeDamage(damageToEnemy);
            Debug.Log($"Enemy {i}가 {damageToEnemy}의 피해를 입음. 남은 체력: {enemyUnits[i].CurrentHP}");
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
                    if (value > 0) // 굴려진 주사위만 합산
                        sum += value;
                }
            }
        }
        return sum;
    }
}
