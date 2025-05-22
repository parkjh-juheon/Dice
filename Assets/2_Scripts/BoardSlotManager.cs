using UnityEngine;
using System.Collections.Generic;

public class BoardSlotManager : MonoBehaviour
{
    public Transform[] slots; // ������ ���Ե�

    // ���� �� ����ִ� ��ġ�� ã�� ��ȯ
    public Transform GetFirstEmptySlot()
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0) // ��� �ִ� ����
                return slot;
        }
        return null;
    }
}
