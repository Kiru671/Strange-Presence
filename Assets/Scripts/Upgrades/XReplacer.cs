using System;

public static class XReplacer
{
    public static string ReplaceXWithMultipliers(string description, int[] multipliers, int startIndex)
    {
        // Loop through the description and replace "X" with multipliers starting at the given index
        while (description.Contains("X") && startIndex < multipliers.Length)
        {
            // Find the first occurrence of "X"
            int xIndex = description.IndexOf("X", StringComparison.Ordinal);
            if (xIndex == -1) break;

            // Replace "X" with the current multiplier
            description = description.Substring(0, xIndex) + multipliers[startIndex] + description.Substring(xIndex + 1);

            // Increment index to use the next multiplier
            startIndex++;
        }

        return description;
    }
}