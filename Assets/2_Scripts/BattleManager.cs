using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("���ظ� �� ��� ������ �����Ϳ��� �巡���ϼ���")]
    public Unit targetUnit;

    // UI ��ư�� OnClick()�� �� �Լ��� ����
    public void RollAndAttack()
    {
        Dice[] allDice = FindObjectsOfType<Dice>();

        int totalAttack = 0;
        int totalDefense = 0;

        foreach (var dice in allDice)
        {
            if (dice.CompareTag("Attack_Dice"))
            {
                dice.RollDice();
                totalAttack += dice.value;
            }
            else if (dice.CompareTag("Defense_Dice"))
            {
                dice.RollDice();
                totalDefense += dice.value;
            }
        }

        int finalDamage = Mathf.Max(totalAttack - totalDefense, 0); // ���� ����

        Debug.Log($"[BattleManager] ����: {totalAttack}, ���: {totalDefense}, ���� ���ط�: {finalDamage}");

        if (targetUnit != null)
        {
            targetUnit.TakeDamage(finalDamage);
        }
    }

}
