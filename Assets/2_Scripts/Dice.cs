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

            // ���콺�� ������Ʈ ���� �Ÿ� ��� (z �� ����)
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - mousePosition;
        }

        void OnMouseDrag()
        {
            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;  // 2D�ϱ� Z ����
                transform.position = mousePosition + offset;
            }
        }

        void OnMouseUp()
        {
            isDragging = false;
        }
    }
}
