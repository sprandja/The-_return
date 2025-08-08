using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(controller.player.HasItemByName(noun))
        {
            if (GiveToItem(controller, controller.player.currentLocation.items, noun))
                return;
            controller.currentText.text = "Nothing accepts the " + noun + "!";
            return;
        }

        controller.currentText.text = "You don't have the " + noun + "!";



    }

    private bool GiveToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanGiveToItem(controller, item))
                {
                    if (item.InteractionWith(controller, "give", noun))
                        return true;
                }
            }

        }
        return false;
    }
}
