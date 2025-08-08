using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use item in room
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
            return;
        // use item in inventory
        if (ReadItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun + " in possession.";
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractionWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "The " + noun + " doesn't display anything to be read.";
                return true;
            }
        }
        return false;
    }

}
