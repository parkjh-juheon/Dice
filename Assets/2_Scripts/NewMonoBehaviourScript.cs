using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MultiEnemyBattleManager : MonoBehaviour
{
    [Tooltip("플레이어 유닛")]
    public Unit playerUnit;

    [Tooltip("적 유닛 리스트")]
    public List<Unit> enemyUnits = new List<Unit>();

    public EnemyDiceSpawner enemyDiceSpawner;
    private Vector3[] initialPlayerDicePositions;
    private GameObject[] playerDiceObjects;

    [Header("UI 버튼")]
    public Button rollButton;
    public Button resetButton;

    private void Start()
    {
        InitializePlayerDice();
        EnableRollButton(true);
    }

    private void InitializePlayerDice()
    {
        playerDiceObjects = GameObject.FindGameObjectsWithTag("Player_Dice");
        initialPlayerDicePositions = new Vector3[playerDiceObjects.Length];

        for (int i = 0; i < playerDiceObjects.Length; i++)
        {
            initialPlayerDicePositions[i] = playerDiceObjects[i].transform.position;
        }
    }

    public void OnRollButtonClick()
    {
        EnableRollButton(false);
        enemyDiceSpawner.RollDiceForEnemies(enemyUnits);
        RollAndAttack();
    }

    public void RollAndAttack()
    {
        foreach (var enemy in enemyUnits)
        {
            int playerAttack = 0;
            int playerDefense = 0;
            int enemyAttack = 0;
            int enemyDefense = 0;

            Dice[] allDice = FindObjectsOfType<Dice>();

            foreach (var dice in allDice)
            {
                if (dice.CompareTag("P_Attack_Dice"))
                    playerAttack += dice.RollDice();
                else if (dice.CompareTag("P_Defense_Dice"))
                    playerDefense += dice.RollDice();
                else if (dice.CompareTag($"E_Attack_Dice_{enemy.name}"))
                    enemyAttack += dice.RollDice();
                else if (dice.CompareTag($"E_Defense_Dice_{enemy.name}"))
                    enemyDefense += dice.RollDice();
            }

            int damageToEnemy = Mathf.Max(playerAttack - enemyDefense, 0);
            int damageToPlayer = Mathf.Max(enemyAttack - playerDefense, 0);

            Debug.Log($"플레이어 -> {enemy.name}: 공격 {playerAttack}, 방어 {enemyDefense}, 피해 {damageToEnemy}");
            Debug.Log($"{enemy.name} -> 플레이어: 공격 {enemyAttack}, 방어 {playerDefense}, 피해 {damageToPlayer}");

            enemy.TakeDamage(damageToEnemy);
            playerUnit.TakeDamage(damageToPlayer);
        }

        EnableRollButton(true);
    }

    public void ResetGame()
    {
        for (int i = 0; i < playerDiceObjects.Length; i++)
        {
            playerDiceObjects[i].transform.position = initialPlayerDicePositions[i];
        }

        enemyDiceSpawner.RollDiceForEnemies(enemyUnits);
        EnableRollButton(true);
    }

    private void EnableRollButton(bool enable)
    {
        if (rollButton != null)
            rollButton.interactable = enable;
    }
}
