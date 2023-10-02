using System.Collections.Generic;
using UnityEngine;

public class EqualValuesFinder : MonoBehaviour
{
    void Start()
    {
        List<int> numberList = new List<int> { 3, 5, 2, 5, 8, 3, 6, 2, 3 };

        int targetValue = 3;

        List<int> equalValues = numberList.FindAll(number => number == targetValue);

        foreach (int value in equalValues)
        {
            Debug.Log("Found equal value: " + value);
        }
    }
}