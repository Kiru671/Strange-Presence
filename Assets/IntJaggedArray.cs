using System;
using UnityEngine;

[Serializable]
public class IntJaggedArray
{
    public int[] outerArrayLengths; // Stores the lengths of inner arrays
    public int[][] jaggedArray;    // The actual jagged array

    public IntJaggedArray(int outerSize = 1)
    {
        jaggedArray = new int[outerSize][];
        outerArrayLengths = new int[outerSize];
        for (int i = 0; i < outerSize; i++)
        {
            jaggedArray[i] = new int[1]; // Initialize with one element
            outerArrayLengths[i] = 1;    // Store initial length
        }
    }
    
}