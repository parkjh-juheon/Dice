using UnityEngine;

public class DiceDrag : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;

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
            mousePosition.z = -1f;  
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}

