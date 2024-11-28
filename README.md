
Strange Presence
===

A rogue-lite shoother action game with a modular wave & upgrades system that was born in a game jam.

![strange-presence](assets\Gifs&Photos\Strange-Presence.png)

***Upgrade System***

![strange-presence-upgrade](Assets\Gifs&Photos\StrangePresence_Short.gif)

You an easily create new Upgrades and it will work unless the new Upgrade has a different upgrade type or is "Unique". If that's the case, you can modify the method below for the extended capability. (Unfortunately, that's how it is for now, sorry open-closed principle :pensive:).

```c#
public void UpgradeChosen(Upgrade chosenUpgrade)
    {
        switch (chosenUpgrade.UpgradeType)
        {
            //Execute a set logic for different types of upgrades
            case UpgradeType.Health:
                player.maxHealth += (int)chosenUpgrade.Increase;
                player.health = player.maxHealth;
                player.SetHealthBar();
                break;
            case UpgradeType.FireRate:
                weapon.fireRate +=  chosenUpgrade.Increase * 0.01f * weapon.fireRate;
                break;
            case UpgradeType.Magazine:
                weapon.magSize += Mathf.RoundToInt(chosenUpgrade.Increase * 0.01f * weapon.magSize);
                break;
            case UpgradeType.ReloadSpeed:
                weapon.reloadSpeed -= chosenUpgrade.Increase * 0.01f * weapon.reloadSpeed;
                break;
            case UpgradeType.MovementSpeed:
                player.moveSpeed += chosenUpgrade.Increase * 0.01f * player.moveSpeed;
                break;
            //Unique upgrades have their own logic
            case UpgradeType.Unique:
                if(chosenUpgrade.Title == "Electromagnetism")
                {
                    Debug.Log("Magnetic");
                    player.magnetic = true;
                }
                if (chosenUpgrade.Title == "LeaTech's Leaked Weapon Design")
                {
                    weapon.bulletDMG *= 2; weapon.isKnockbackEnabled = true;
                }
                if(chosenUpgrade.Title == "Dire's Vengeance")
                {
                    weapon.bulletDMG *= chosenUpgrade.Increase * 0.01f;
                    weapon.diresVengeance = true;
                }
                break;
        }
    }
```
***Wave System***

WIP