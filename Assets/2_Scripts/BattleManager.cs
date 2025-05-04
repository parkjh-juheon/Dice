using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("���ظ� �� ��� ������ �����Ϳ��� �巡���ϼ���")]
    public Unit targetUnit;

    // UI ��ư�� OnClick()�� �� �Լ��� ����
    public void RollAndAttack()
    {
        // Unity 2023.1 ���Ͽ����� �̰ɷ� �����
        Dice[] allDice = FindObjectsOfType<Dice>();
        int totalDamage = 0;

        foreach (var dice in allDice)
        {
            if (dice.CompareTag("Attack_Dice"))
            {
                // 2) ������
                dice.RollDice();
                // 3) ���� �ջ�
                totalDamage += dice.value;
            }
        }

        Debug.Log($"[BattleManager] �� ���ط�: {totalDamage}");

        // 4) ��ǥ ���ֿ� ����
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(totalDamage);
        }
    }
}
