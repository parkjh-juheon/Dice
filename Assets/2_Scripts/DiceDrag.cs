using UnityEngine;

public class DiceDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;

    void Start()
    {
        // 시작 위치 저장
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

        // 충돌 체크 (적 보드)
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("E_Attack_Board") || collider.CompareTag("E_Defense_Board"))
            {
                // 적 보드에 들어가면 원래 위치로 되돌림
                transform.position = initialPosition;
                return;
            }
        }

        // 드래그 위치를 새로운 초기 위치로 저장 (아군 보드일 경우)
        initialPosition = transform.position;
    }
}
