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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack_Board"))
        {
            gameObject.tag = "Attack_Dice";
        }

        if (other.CompareTag("Defense_Board"))
        {
            gameObject.tag = "Defense_Board";
        }
    }

    public class DiceDrag : MonoBehaviour
    {
        private bool isDragging = false;
        private Vector3 offset;

        void OnMouseDown()
        {
            isDragging = true;

            // 마우스와 오브젝트 사이 거리 계산 (z 값 포함)
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - mousePosition;
        }

        void OnMouseDrag()
        {
            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;  // 2D니까 Z 고정
                transform.position = mousePosition + offset;
            }
        }

        void OnMouseUp()
        {
            isDragging = false;
        }
    }
}
