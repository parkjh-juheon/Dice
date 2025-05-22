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

        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        bool snapped = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("P_Attack_Board") || collider.CompareTag("P_Defense_Board") ||
                collider.CompareTag("E_Attack_Board") || collider.CompareTag("E_Defense_Board"))
            {
                BoardSlotManager slotManager = collider.GetComponent<BoardSlotManager>();
                if (slotManager != null)
                {
                    Transform slot = slotManager.GetFirstEmptySlot();
                    if (slot != null)
                    {
                        // 주사위 위치를 슬롯 위치로 스냅
                        transform.position = slot.position;

                        // 슬롯에 부모로 넣기 (optional)
                        transform.SetParent(slot);

                        snapped = true;
                        break;
                    }
                }
            }
        }

        if (!snapped)
        {
            // 아무 보드에도 못 올렸다면 되돌리기
            transform.position = initialPosition;
            transform.SetParent(null); // 부모 해제
        }
    }

}