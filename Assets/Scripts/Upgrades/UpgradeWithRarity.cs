using System;
using Upgrades;

public class UpgradeWithRarity
{
    public Upgrade upgrade;
    public RarityHelper.Rarity rarity;

    public UpgradeWithRarity(Upgrade upgrade, RarityHelper.Rarity rarity)
    {
        this.upgrade = upgrade;
        this.rarity = upgrade.isUnique ? RarityHelper.Rarity.Unique : rarity;
    }

    public string UpgradeName => upgrade.upgradeNames[rarity == RarityHelper.Rarity.Unique ? 0 : (int)rarity];
    public string Description
    {
        get
        {
            if(upgrade.multipliers.Length == 0)
                return upgrade.description;
            return XReplacer.ReplaceXWithMultipliers(upgrade.description, upgrade.multipliers, rarity == RarityHelper.Rarity.Unique ? 0 : (int)rarity);
            /*return upgrade.description.Replace("X",
                upgrade.multipliers[rarity == RarityHelper.Rarity.Unique ? 0 : (int)rarity].ToString());*/
        }
    }

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
}