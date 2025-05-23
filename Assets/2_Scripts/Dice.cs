using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 이미지
    public SpriteRenderer spriteRenderer;
    public int value = 0;

    public int currentValue { get; private set; }

    // 버튼에서 이 함수를 호출
    public void RollDice()
    {
        currentValue = Random.Range(1, 7);
        value = currentValue;  // ← 이 줄을 추가해줘야 함!
        spriteRenderer.sprite = diceFaces[currentValue - 1];
        Debug.Log("주사위 눈: " + currentValue);
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
