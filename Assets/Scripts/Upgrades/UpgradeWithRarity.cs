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
        }
    }
}