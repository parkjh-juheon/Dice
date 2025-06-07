using UnityEngine;

public class PlayerDiceManager : MonoBehaviour
{
    public Dice[] playerDice;
    public Transform[] originalPositions;

    public void RollAll()
    {
        foreach (var dice in playerDice)
        {
            dice.RollDice();
        }
    }

    public void ResetAll()
    {
        for (int i = 0; i < playerDice.Length; i++)
        {
            playerDice[i].transform.position = originalPositions[i].position;
        }
    }
}
