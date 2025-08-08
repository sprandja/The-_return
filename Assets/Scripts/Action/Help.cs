using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Help")]
public class Help : Actions
{
    public override void RespondToInput(GameController controller, string verb)
    {
        controller.currentText.text = "Type a VERB followed by a noun(e.g. \"go north\")\nAllowed verbs: \nGo, Examine, Get, Use, Inventory, TalkTo, Read, Say, Help";
    }
}
