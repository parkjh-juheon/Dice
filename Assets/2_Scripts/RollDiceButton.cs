using UnityEngine;

public class RollDiceButton : MonoBehaviour
{
    public Unit targetUnit; // 피해를 받을 유닛 (에디터에서 연결)

    public void RollAllDiceAndAttack()
    {
        Dice[] allDice = FindObjectsOfType<Dice>();

        int totalDamage = 0;

        foreach (Dice dice in allDice)
        {
            if (dice.CompareTag("Attack_Dice"))
            {
                totalDamage += dice.value; // Dice 스크립트에 value가 있어야 함
            }
        }

        if (targetUnit != null)
        {
            targetUnit.TakeDamage(totalDamage);
        }

        Debug.Log($"총 {totalDamage} 피해를 가함");
    }
}
