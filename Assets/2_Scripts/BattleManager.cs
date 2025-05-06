using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("�÷��̾� ����")]
    public Unit playerUnit;
    [Tooltip("�� ����")]
    public Unit enemyUnit;

    public EnemyDiceSpawner enemyDiceSpawner;

    public void OnRollButtonClick()
    {
        enemyDiceSpawner.RollDice();
    }

public void RollAndAttack()
    {
        Dice[] allDice = FindObjectsOfType<Dice>();

        int playerAttack = 0;
        int playerDefense = 0;
        int enemyAttack = 0;
        int enemyDefense = 0;

        foreach (var dice in allDice)
        {
            if (dice.CompareTag("P_Attack_Dice"))
            {
                dice.RollDice();
                playerAttack += dice.value;
            }
            else if (dice.CompareTag("P_Defense_Dice"))
            {
                dice.RollDice();
                playerDefense += dice.value;
            }
            else if (dice.CompareTag("E_Attack_Dice"))
            {
                dice.RollDice();
                enemyAttack += dice.value;
            }
            else if (dice.CompareTag("E_Defense_Dice"))
            {
                dice.RollDice();
                enemyDefense += dice.value;
            }
        }

        int damageToEnemy = Mathf.Max(playerAttack - enemyDefense, 0);
        int damageToPlayer = Mathf.Max(enemyAttack - playerDefense, 0);

        Debug.Log($"[BattleManager] �÷��̾� ����: {playerAttack}, �� ���: {enemyDefense}, �� ���ط�: {damageToEnemy}");
        Debug.Log($"[BattleManager] �� ����: {enemyAttack}, �÷��̾� ���: {playerDefense}, �÷��̾� ���ط�: {damageToPlayer}");

        if (enemyUnit != null)
        {
            enemyUnit.TakeDamage(damageToEnemy);
        }

        if (playerUnit != null)
        {
            playerUnit.TakeDamage(damageToPlayer);
        }
    }
}
