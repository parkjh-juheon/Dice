using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 이미지
    public SpriteRenderer spriteRenderer;
    public int CurrentValue { get; private set; } = 0;  // 기본값 1로 설정 (0은 주사위 값으로 부적절)

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
    }

    public int GetValue()
    {
        return CurrentValue;
    }
}
