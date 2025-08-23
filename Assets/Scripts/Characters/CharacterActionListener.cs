using UnityEngine;

public class CharacterActionListener : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log($"[{name}] Subscribed to ActionEventBus.");
        ActionEventBus.OnActionTriggered += HandleAction;
    }

    private void OnDisable()
    {
        Debug.Log($"[{name}] Unsubscribed from ActionEventBus.");
        ActionEventBus.OnActionTriggered -= HandleAction;
    }

    private void HandleAction(ActionEvent actionEvent)
    {
        if (actionEvent.Target != gameObject)
        {
            Debug.Log($"[{name}] Ignored action: {actionEvent.ActionData.name}, not the target.");
            return;
        }

        // Execute the action on this character
        Debug.Log($"{name} received action: {actionEvent.ActionData.name}");

        // Example: Play reaction animation, reduce health, etc.
    }
}
