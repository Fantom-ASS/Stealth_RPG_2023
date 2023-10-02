using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayList : MonoBehaviour
{
    public List<int>[] arrayOfLists;
    public List<int> arrayOfLists2;
    [SerializeField]public List<List<int>> multiList = new List<List<int>>();

    void Start()
    {
        // Initialize the array and create lists in each element
        InitializeArray();

        // Add values to the lists
        AddValueToList(0, 42);
        AddValueToList(1, 15);

        // Access and print values from the lists
        Debug.Log("Value at index 0, list 0: " + GetValueFromList(0, 0));
        Debug.Log("Value at index 1, list 0: " + GetValueFromList(1, 0));
        Debug.Log("Value at index 0, list 1: " + GetValueFromList(0, 1));
        Debug.Log("Value at index 1, list 1: " + GetValueFromList(1, 1));
    }

    void InitializeArray()
    {
        // Initialize the array with two lists
        arrayOfLists = new List<int>[2];

        // Create lists in each element of the array
        arrayOfLists[0] = new List<int>();
        arrayOfLists[1] = new List<int>();
    }

    void AddValueToList(int listIndex, int value)
    {
        // Check if the listIndex is valid
        if (listIndex >= 0 && listIndex < arrayOfLists.Length)
        {
            // Add the value to the specified list
            arrayOfLists[listIndex].Add(value);
        }
        else
        {
            Debug.LogError("Invalid list index.");
        }
    }

    int GetValueFromList(int listIndex, int elementIndex)
    {
        // Check if the listIndex and elementIndex are valid
        if (listIndex >= 0 && listIndex < arrayOfLists.Length && elementIndex >= 0 && elementIndex < arrayOfLists[listIndex].Count)
        {
            // Retrieve the value from the specified list and element
            return arrayOfLists[listIndex][elementIndex];
        }
        else
        {
            Debug.LogError("Invalid indices.");
            return -1; // or any other error value
        }
    }
}
