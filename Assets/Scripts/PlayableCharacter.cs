using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayableCharacter : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        if (agent == null)
        {
            Debug.LogError("No NavMeshAgent component found on playable character");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var target = CameraManager.instance.GetScreenPointWorld(Mouse.current.position.value);
            agent.SetDestination(target);
        }
    }


}
