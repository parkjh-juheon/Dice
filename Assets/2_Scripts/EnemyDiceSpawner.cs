using UnityEngine;

public class EnemyDiceSpawner : MonoBehaviour
{
    public GameObject dicePrefab;               // ������ �ֻ��� ������
    public Transform[] diceSlots;               // �� ���� ����� ���Ե� (��: 6ĭ)
    public int diceToSpawn = 3;                 // ������ �ֻ��� ����

    private void Start()
    {
        SpawnRandomDice();
    }

    public void SpawnRandomDice()
    {
        // ���� ���� ���� ����
        System.Random rng = new System.Random();
        Transform[] shuffledSlots = (Transform[])diceSlots.Clone();
        for (int i = 0; i < shuffledSlots.Length; i++)
        {
            int swapIndex = rng.Next(i, shuffledSlots.Length);
            (shuffledSlots[i], shuffledSlots[swapIndex]) = (shuffledSlots[swapIndex], shuffledSlots[i]);
        }

        // �ֻ��� ���� �� ���Կ� ��ġ
        int spawned = 0;
        foreach (Transform slot in shuffledSlots)
        {
            if (spawned >= diceToSpawn)
                break;

            GameObject dice = Instantiate(dicePrefab, slot.position, Quaternion.identity);
            dice.transform.SetParent(slot); // ���Կ� �ڽ����� ���̱� (�ɼ�)
            dice.tag = "E_Attack_Dice";     // �±� ���� ��
            spawned++;
        }
    }
}
