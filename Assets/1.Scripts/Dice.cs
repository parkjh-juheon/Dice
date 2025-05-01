using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceFaces;  // 1~6 이미지
    public SpriteRenderer spriteRenderer;

    public int currentValue { get; private set; }

    // 버튼에서 이 함수를 호출
    public void RollDice()
    {
        currentValue = Random.Range(1, 7);
        spriteRenderer.sprite = diceFaces[currentValue - 1];
        Debug.Log("주사위 눈: " + currentValue);
    }
}
