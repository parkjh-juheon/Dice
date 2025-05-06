using UnityEngine;

public class EnemyDiceSpawner : MonoBehaviour
{
    [Header("������ ����")]
    public GameObject dicePrefab;

    [Header("���� ������Ʈ")]
    public Transform attackBoard;
    public Transform defenseBoard;

    [Header("�ֻ��� ����")]
    public int numberOfDice = 6;
    public int columns = 3;
    public Vector2 spacing = new Vector2(1.2f, 1.2f);

    private void Start()
    {
        RollDice(); // ó������ ȣ��
    }

    public void RollDice()
    {
        // ���� �ֻ��� ����
        ClearBoard(attackBoard);
        ClearBoard(defenseBoard);

        // ����/��� �ֻ��� �� ���� �й�
        int attackCount = Random.Range(0, numberOfDice + 1); // 0 ~ numberOfDice
        int defenseCount = numberOfDice - attackCount;

        // ���� ��ġ
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
