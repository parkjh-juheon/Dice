using UnityEngine;

public class EnemyDiceSpawner : MonoBehaviour
{
    [Header("프리팹 설정")]
    public GameObject dicePrefab;

    [Header("보드 오브젝트")]
    public Transform attackBoard;
    public Transform defenseBoard;

    [Header("주사위 설정")]
    public int numberOfDice = 6;
    public int columns = 3;
    public Vector2 spacing = new Vector2(1.2f, 1.2f);

    private void Start()
    {
        RollDice(); // 처음에도 호출
    }

    public void RollDice()
    {
        // 기존 주사위 제거
        ClearBoard(attackBoard);
        ClearBoard(defenseBoard);

        // 공격/방어 주사위 수 랜덤 분배
        int attackCount = Random.Range(0, numberOfDice + 1); // 0 ~ numberOfDice
        int defenseCount = numberOfDice - attackCount;

        // 새로 배치
        SpawnDiceOnBoard(attackBoard, attackCount, "E_Attack_Dice");
        SpawnDiceOnBoard(defenseBoard, defenseCount, "E_Defense_Dice");
    }

    void SpawnDiceOnBoard(Transform board, int count, string tag)
    {
        int rows = Mathf.CeilToInt((float)count / columns);

        Vector2 startOffset = new Vector2(
            -((columns - 1) * spacing.x) / 2f,
            ((rows - 1) * spacing.y) / 2f
        );

        for (int i = 0; i < count; i++)
        {
            int row = i / columns;
            int col = i % columns;

            Vector2 localPos = new Vector2(
                col * spacing.x,
                -row * spacing.y
            );

            GameObject dice = Instantiate(dicePrefab, board);
            dice.transform.localPosition = startOffset + localPos;
            dice.tag = tag;
        }
    }

    void ClearBoard(Transform board)
    {
        foreach (Transform child in board)
        {
            Destroy(child.gameObject);
        }
    }
}
