using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Tooltip("�÷��̾� ����")]
    public Unit playerUnit;
    [Tooltip("�� ����")]
    public Unit enemyUnit;

    public EnemyDiceSpawner enemyDiceSpawner;
    private Vector3[] initialPlayerDicePositions;
    private GameObject[] playerDiceObjects;

    [Header("UI ��ư")]
    public Button rollButton;
    public Button resetButton;

    private void Start()
    {
        InitializePlayerDice();
        EnableRollButton(true); // ó������ Roll ��ư Ȱ��ȭ
    }

    // �÷��̾� �ֻ��� ��ġ �ʱ�ȭ
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
        enemyDiceSpawner.RollDice();
        RollAndAttack();
        EnableRollButton(false); // Roll ��ư ��Ȱ��ȭ
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

    // Reset ��ư�� ������ �� ����
    public void ResetGame()
    {
        // Player Dice ��ġ �ʱ�ȭ
        for (int i = 0; i < playerDiceObjects.Length; i++)
        {
            playerDiceObjects[i].transform.position = initialPlayerDicePositions[i];
        }

        // Enemy Dice ���� ����
        enemyDiceSpawner.RollDice();

        // Roll ��ư �ٽ� Ȱ��ȭ
        EnableRollButton(true);
    }

    // Roll ��ư Ȱ��ȭ/��Ȱ��ȭ ����
    private void EnableRollButton(bool enable)
    {
        if (rollButton != null)
        {
            rollButton.interactable = enable;
        }
    }
}
