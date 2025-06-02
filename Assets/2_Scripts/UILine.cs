using UnityEngine;

public class UILine : MonoBehaviour
{
    public RectTransform startRect;
    public RectTransform endRect;

    void Update()
    {
        Vector2 start = startRect.anchoredPosition;
        Vector2 end = endRect.anchoredPosition;
        Vector2 center = (start + end) / 2;

        RectTransform rt = GetComponent<RectTransform>();
        rt.anchoredPosition = center;

        float length = Vector2.Distance(start, end);
        rt.sizeDelta = new Vector2(length, 3f);

        float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * Mathf.Rad2Deg;
        rt.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
