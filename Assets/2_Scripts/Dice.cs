using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 �̹���
    public SpriteRenderer spriteRenderer;
    public int CurrentValue { get; private set; } = 1;  // �⺻�� 1�� ���� (0�� �ֻ��� ������ ������)

    void Start()
    {
        for (int i = 0; i < diceFaces.Length; i++)
        {
            if (spriteRenderer.sprite == diceFaces[i])
            {
                CurrentValue = i + 1;
                break;
            }
        }
    }

    public void RollDice()
    {
        CurrentValue = Random.Range(1, 7);
        spriteRenderer.sprite = diceFaces[CurrentValue - 1];
        Debug.Log("�ֻ��� ��: " + CurrentValue);
    }

    public int GetValue()
    {
        return CurrentValue;
    }
}
