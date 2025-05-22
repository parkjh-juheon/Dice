using UnityEngine;

public class EnemyDiceSpawner : MonoBehaviour
{
    public GameObject dicePrefab;               // 생성할 주사위 프리팹
    public Transform[] diceSlots;               // 이 적이 사용할 슬롯들 (예: 6칸)
    public int diceToSpawn = 3;                 // 생성할 주사위 개수

    private void Start()
    {
        SpawnRandomDice();
    }

    public void SpawnRandomDice()
    {
        // 슬롯 순서 랜덤 섞기
        System.Random rng = new System.Random();
        Transform[] shuffledSlots = (Transform[])diceSlots.Clone();
        for (int i = 0; i < shuffledSlots.Length; i++)
        {
            int swapIndex = rng.Next(i, shuffledSlots.Length);
            (shuffledSlots[i], shuffledSlots[swapIndex]) = (shuffledSlots[swapIndex], shuffledSlots[i]);
        }

        // 주사위 생성 및 슬롯에 배치
        int spawned = 0;
        foreach (Transform slot in shuffledSlots)
        {
            if (spawned >= diceToSpawn)
                break;

            GameObject dice = Instantiate(dicePrefab, slot.position, Quaternion.identity);
            dice.transform.SetParent(slot); // 슬롯에 자식으로 붙이기 (옵션)
            dice.tag = "E_Attack_Dice";     // 태그 설정 등
            spawned++;
        }
    }
}
