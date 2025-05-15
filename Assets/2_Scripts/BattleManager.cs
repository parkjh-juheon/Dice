using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Tooltip("플레이어 유닛")]
    public Unit playerUnit;
    [Tooltip("적 유닛")]
    public Unit enemyUnit;

    public EnemyDiceSpawner enemyDiceSpawner;
    private Vector3[] initialPlayerDicePositions;
    private GameObject[] playerDiceObjects;

    [Header("UI 버튼")]
    public Button rollButton;
    public Button resetButton;

    private void Start()
    {
        InitializePlayerDice();
        EnableRollButton(true); // 처음에는 Roll 버튼 활성화
    }

    // 플레이어 주사위 위치 초기화
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
        EnableRollButton(false); // Roll 버튼 비활성화
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

        Debug.Log($"[BattleManager] 플레이어 공격: {playerAttack}, 적 방어: {enemyDefense}, 적 피해량: {damageToEnemy}");
        Debug.Log($"[BattleManager] 적 공격: {enemyAttack}, 플레이어 방어: {playerDefense}, 플레이어 피해량: {damageToPlayer}");

        if (enemyUnit != null)
        {
            enemyUnit.TakeDamage(damageToEnemy);
        }

        if (playerUnit != null)
        {
            playerUnit.TakeDamage(damageToPlayer);
        }
    }

    // Reset 버튼을 눌렀을 때 실행
    public void ResetGame()
    {
        // Player Dice 위치 초기화
        for (int i = 0; i < playerDiceObjects.Length; i++)
        {
            playerDiceObjects[i].transform.position = initialPlayerDicePositions[i];
        }

        // Enemy Dice 새로 생성
        enemyDiceSpawner.RollDice();

        // Roll 버튼 다시 활성화
        EnableRollButton(true);
    }

    // Roll 버튼 활성화/비활성화 관리
    private void EnableRollButton(bool enable)
    {
        if (rollButton != null)
        {
            rollButton.interactable = enable;
        }
    }
}
