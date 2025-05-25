using UnityEngine;
using UnityEngine.UI;

public class DiceButtonManager : MonoBehaviour
{
    public Button rollButton;
    public Button resetButton;

    public PlayerDiceManager playerDiceManager; // 플레이어 주사위 관련 로직
    public EnemyDiceSpawner[] enemySpawners;    // 각 적 유닛의 주사위 스포너

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

        // 플레이어 주사위 리셋
        playerDiceManager.ResetAll();

        // 적 주사위 리스폰
        foreach (var spawner in enemySpawners)
        {
            spawner.RespawnAll();
        }

        hasRolled = false;
        rollButton.interactable = true;
        resetButton.interactable = false;
    }
}
