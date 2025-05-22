using UnityEngine;
using System.Collections.Generic;

public class BoardSlotManager : MonoBehaviour
{
    public Transform[] slots; // 보드의 슬롯들

    // 슬롯 중 비어있는 위치를 찾아 반환
    public Transform GetFirstEmptySlot()
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0) // 비어 있는 슬롯
                return slot;
        }
        return null;
    }
}
