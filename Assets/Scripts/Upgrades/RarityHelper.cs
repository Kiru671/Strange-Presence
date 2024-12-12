using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RarityHelper
{
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Unique
    }
    
    public static Rarity GetRandomRarity()
    {
        // Define weights for each rarity (higher weight = more likely)
        int[] weights = { 50, 30, 15, 5 }; // Common: 50%, Rare: 30%, Epic: 15%, Legendary: 5%
        int totalWeight = 0;

        // Calculate total weight
        foreach (int weight in weights)
            totalWeight += weight;

        // Get a random value between 0 and total weight
        int randomValue = UnityEngine.Random.Range(0, totalWeight);

        // Determine which rarity corresponds to the random value
        int cumulativeWeight = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue < cumulativeWeight)
                return (Rarity)i;
        }

        // Fallback (should never hit if weights are defined correctly)
        return Rarity.Common;
    }
}

