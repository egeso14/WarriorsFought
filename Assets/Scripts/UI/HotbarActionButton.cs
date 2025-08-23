using UnityEngine;

public class HotbarActionButton : MonoBehaviour
{

    [SerializeField] private BaseAction action;

    public void OnClick(GameObject initiator, GameObject target)
    {
        Debug.Log($"[{name}] Button clicked with action: {action.name}, initiator: {initiator.name}, target: {target.name}");
        if (action == null)
        {
            Debug.LogWarning($"[{name}] No action assigned to this button.");
            return;
        }

        if (initiator == null || target == null)
        {
            Debug.LogError($"[{name}] Missing initiator or target.");
            return;
        }

        Debug.Log($"[{name}] Triggering action: {action.name} from {initiator.name} to {target.name}");

        var actionEvent = new ActionEvent(action, initiator, target);
        ActionEventBus.TriggerAction(actionEvent);
    }
}
