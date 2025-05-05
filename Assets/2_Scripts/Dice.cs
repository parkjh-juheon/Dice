using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 �̹���
    public SpriteRenderer spriteRenderer;
    public int value = 1;

    public int currentValue { get; private set; }

    // ��ư���� �� �Լ��� ȣ��
    public void RollDice()
    {
        currentValue = Random.Range(1, 7);
        value = currentValue;  // �� �� ���� �߰������ ��!
        spriteRenderer.sprite = diceFaces[currentValue - 1];
        Debug.Log("�ֻ��� ��: " + currentValue);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("E_Attack_Board"))
        {
            gameObject.tag = "E_Attack_Dice";
        }

        if (other.CompareTag("P_Attack_Board"))
        {
            gameObject.tag = "P_Attack_Dice";
        }

        if (other.CompareTag("E_Defense_Board"))
        {
            gameObject.tag = "E_Defense_Dice";
        }

        if (other.CompareTag("P_Defense_Board"))
        {
            gameObject.tag = "P_Defense_Dice";
        }
    }
}
