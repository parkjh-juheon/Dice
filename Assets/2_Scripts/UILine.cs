using UnityEngine;

public class UILine : MonoBehaviour
{
    public RectTransform startRect;
    public RectTransform endRect;
    public float thickness = 5f; // Inspector에서 조정 가능

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

        rectTransform.sizeDelta = new Vector2(distance, thickness); // ← 여기서 사용
        rectTransform.position = (startPos + endPos) / 2f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
