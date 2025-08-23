using UnityEngine;

public class ActionEvent
{

    public BaseAction ActionData;
    public GameObject Initiator;
    public GameObject Target;

    public ActionEvent(BaseAction action, GameObject initiator, GameObject target)
    {
        ActionData = action;
        Initiator = initiator;
        Target = target;
    }

}
