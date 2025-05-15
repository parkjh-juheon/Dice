using UnityEngine;

public class DiceDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;

    void Start()
    {
        // ���� ��ġ ����
        initialPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // �浹 üũ (�� ����)
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("E_Attack_Board") || collider.CompareTag("E_Defense_Board"))
            {
                // �� ���忡 ���� ���� ��ġ�� �ǵ���
                transform.position = initialPosition;
                return;
            }
        }

        // �巡�� ��ġ�� ���ο� �ʱ� ��ġ�� ���� (�Ʊ� ������ ���)
        initialPosition = transform.position;
    }
}
