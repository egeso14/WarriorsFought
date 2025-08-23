using System;
using UnityEngine;

public class ActionEventBus
{
    // Static event for other classes to subscribe to or unsub from
    public static event Action<ActionEvent> OnActionTriggered;



    //Call this in the function responsible for executing the action like so
    //var actionEvent = new ActionEvent(someAction, playerObject, enemyObject);
    //ActionEventBus.TriggerAction(actionEvent);
    public static void TriggerAction(ActionEvent actionEvent)
    {
        OnActionTriggered?.Invoke(actionEvent);
    }
}
