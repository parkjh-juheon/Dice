using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceButtonManager : MonoBehaviour
{
    public Button rollButton;
    public Button resetButton;

    public PlayerDiceManager playerDiceManager; // 플레이어 주사위 관련 로직
    public List<EnemyDiceSpawner> enemySpawners = new List<EnemyDiceSpawner>(); 

    private bool hasRolled = false;


    public BattleManager battleManager;

    void Start()
    {
        rollButton.onClick.AddListener(OnRollClicked);
        resetButton.onClick.AddListener(OnResetClicked);

        // 초기 상태: Roll만 가능
        rollButton.interactable = true;
        resetButton.interactable = false;
    }

    void OnRollClicked()
    {
        if (hasRolled) return;

        // 플레이어 주사위 굴리기
        playerDiceManager.RollAll();

        // 적 주사위 굴리기
        foreach (var spawner in enemySpawners)
        {
            spawner.RollAll();
        }

        battleManager.CalculateBattle();

        hasRolled = true;
        rollButton.interactable = false;
        resetButton.interactable = true;
    }


    void OnResetClicked()
    {
        if (!hasRolled) return;

        playerDiceManager.ResetAll();

        foreach (var spawner in enemySpawners)
        {
            if (spawner == null) continue;

            Unit enemyUnit = spawner.GetComponent<Unit>();
            if (enemyUnit != null && !enemyUnit.Isdead)
            {
                spawner.RespawnAll();
            }
        }

        hasRolled = false;
        rollButton.interactable = true;
        resetButton.interactable = false;
    }

    public void RemoveEnemySpawner(EnemyDiceSpawner spawner)
    {
        if (enemySpawners.Contains(spawner))
        {
            enemySpawners.Remove(spawner);
        }
    }
}
