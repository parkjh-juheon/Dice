using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("피해를 줄 대상 유닛을 에디터에서 드래그하세요")]
    public Unit targetUnit;

    // UI 버튼의 OnClick()에 이 함수를 연결
    public void RollAndAttack()
    {
        // Unity 2023.1 이하에서는 이걸로 충분함
        Dice[] allDice = FindObjectsOfType<Dice>();
        int totalDamage = 0;

        foreach (var dice in allDice)
        {
            if (dice.CompareTag("Attack_Dice"))
            {
                // 2) 굴리고
                dice.RollDice();
                // 3) 값을 합산
                totalDamage += dice.value;
            }
        }

        Debug.Log($"[BattleManager] 총 피해량: {totalDamage}");

        // 4) 목표 유닛에 적용
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(totalDamage);
        }
    }
}
