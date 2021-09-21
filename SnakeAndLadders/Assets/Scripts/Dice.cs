using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    
    public void RollDice()
    {
        StartCoroutine("rollDice");

    }

    public IEnumerable rollDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;
        yield return new WaitForSeconds(4f);
    }
}
