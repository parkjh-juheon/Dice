using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 �̹���
    public SpriteRenderer spriteRenderer;
    public int value = 0;
    void Start()
    {
        // ���� sprite�� ���� value ����
        for (int i = 0; i < diceFaces.Length; i++)
        {
            if (spriteRenderer.sprite == diceFaces[i])
            {
                value = i + 1;
                currentValue = value;
                break;
            }
        }
    }

    public int currentValue { get; private set; }

    // ��ư���� �� �Լ��� ȣ��
    public void RollDice()
    {
        currentValue = Random.Range(1, 7);
        value = currentValue;  // �� �� ���� �߰������ ��!
        spriteRenderer.sprite = diceFaces[currentValue - 1];
        Debug.Log("�ֻ��� ��: " + currentValue);
    }

    public int GetValue()
    {
        return value;
    }
}
