using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("피해를 줄 대상 유닛을 에디터에서 드래그하세요")]
    public Unit targetUnit;

    // UI 버튼의 OnClick()에 이 함수를 연결
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

        int finalDamage = Mathf.Max(totalAttack - totalDefense, 0); // 음수 방지

        Debug.Log($"[BattleManager] 공격: {totalAttack}, 방어: {totalDefense}, 최종 피해량: {finalDamage}");

        if (targetUnit != null)
        {
            targetUnit.TakeDamage(finalDamage);
        }
    }

}
