using UnityEngine;

public class UILine : MonoBehaviour
{
    public RectTransform startRect;
    public RectTransform endRect;
    public float thickness = 5f; // Inspector���� ���� ����

    RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (startRect == null || endRect == null) return;

        Vector3 startPos = startRect.position;
        Vector3 endPos = endRect.position;
        Vector3 direction = endPos - startPos;
        float distance = direction.magnitude;

        rectTransform.sizeDelta = new Vector2(distance, thickness); // �� ���⼭ ���
        rectTransform.position = (startPos + endPos) / 2f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
