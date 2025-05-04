using UnityEngine;

public class RollDiceButton : MonoBehaviour
{
    public Unit targetUnit; // ���ظ� ���� ���� (�����Ϳ��� ����)

    public void RollAllDiceAndAttack()
    {
        Dice[] allDice = FindObjectsOfType<Dice>();

        int totalDamage = 0;

        foreach (Dice dice in allDice)
        {
            if (dice.CompareTag("Attack_Dice"))
            {
                totalDamage += dice.value; // Dice ��ũ��Ʈ�� value�� �־�� ��
            }
        }

        if (targetUnit != null)
        {
            targetUnit.TakeDamage(totalDamage);
        }

        Debug.Log($"�� {totalDamage} ���ظ� ����");
    }
}
