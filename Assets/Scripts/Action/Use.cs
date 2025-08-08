using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use item in room
        if (UseItems(controller, controller.player.currentLocation.items, noun))
            return;
        // use item in inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no "+ noun+" in possession.";
    }

    private bool UseItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanUseItem(controller,item))
                {
                    if (item.InteractionWith(controller, "use"))
                        return true;
                }
                controller.currentText.text = "The "+noun+" does nothing.";
                return true;
            }
        }
        return false;
    }
}
