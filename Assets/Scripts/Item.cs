using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;

    public bool itemEnabled=true;

    public Item targetItem = null;

    public Interaction[] interactions;

    public bool playerCanTalkTo = false;

    public bool playerCanGiveTo = false;

    public bool playerCanRead = false;

    public bool InteractionWith(GameController controller, string actionKeyword, string noun="")
    {
        foreach(Interaction interaction in interactions)
        {
            if(interaction.action.keyword == actionKeyword)
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                    continue;
                foreach (Item disableItem in interaction.itemsToDisable)
                    disableItem.itemEnabled = true;

                foreach(Item enableItem in interaction.itemsToEnable)
                    enableItem.itemEnabled = true;

                foreach(Connection disableConnectionItem in interaction.connectionsToDisable)
                    disableConnectionItem.connectionEnabled = false;

                foreach (Connection enableConnectionItem in interaction.connectionsToEnable)
                    enableConnectionItem.connectionEnabled = false;
                if (interaction.teleportLocation != null)
                    controller.player.Teleport(controller, interaction.teleportLocation);
                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
            }
        }
        return false;
    }
}
