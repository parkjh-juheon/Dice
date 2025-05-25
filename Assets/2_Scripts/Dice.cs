using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 이미지
    public SpriteRenderer spriteRenderer;
    public int value = 0;
    void Start()
    {
        // 현재 sprite에 따라 value 설정
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

    // 버튼에서 이 함수를 호출
    public void RollDice()
    {
        currentValue = Random.Range(1, 7);
        value = currentValue;  // ← 이 줄을 추가해줘야 함!
        spriteRenderer.sprite = diceFaces[currentValue - 1];
        Debug.Log("주사위 눈: " + currentValue);
    }

    public int GetValue()
    {
        return value;
    }
}
