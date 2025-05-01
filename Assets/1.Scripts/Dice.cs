using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 �̹���
    public SpriteRenderer spriteRenderer;

    public int currentValue { get; private set; }

    // ��ư���� �� �Լ��� ȣ��
    public void RollDice()
    {
        currentValue = Random.Range(1, 7);
        spriteRenderer.sprite = diceFaces[currentValue - 1];
        Debug.Log("�ֻ��� ��: " + currentValue);
    }
}
