using UnityEngine;
using UnityEngine.UI;

public class DiceButtonManager : MonoBehaviour
{
    public Button rollButton;
    public Button resetButton;

    public PlayerDiceManager playerDiceManager; // �÷��̾� �ֻ��� ���� ����
    public EnemyDiceSpawner[] enemySpawners;    // �� �� ������ �ֻ��� ������

    private bool hasRolled = false;


    public BattleManager battleManager;

    void Start()
    {
        rollButton.onClick.AddListener(OnRollClicked);
        resetButton.onClick.AddListener(OnResetClicked);

        // �ʱ� ����: Roll�� ����
        rollButton.interactable = true;
        resetButton.interactable = false;
    }

    void OnRollClicked()
    {
        if (hasRolled) return;

        // �÷��̾� �ֻ��� ������
        playerDiceManager.RollAll();

        // �� �ֻ��� ������
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

        // �÷��̾� �ֻ��� ����
        playerDiceManager.ResetAll();

        // �� �ֻ��� ������
        foreach (var spawner in enemySpawners)
        {
            spawner.RespawnAll();
        }

        hasRolled = false;
        rollButton.interactable = true;
        resetButton.interactable = false;
    }
}
