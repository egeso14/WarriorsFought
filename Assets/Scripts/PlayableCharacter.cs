using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayableCharacter : MonoBehaviour
{
    private NavMeshAgent agent;
    private float maxDistanceFromNavmesh = 5.0f;
    private float clickSearchRadius = 1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        
        if (agent == null)
        {
            Debug.LogError("No NavMeshAgent component found on playable character");
        }

        DetermineSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // temporary
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            
            Debug.Log("Button was pressed");
            MoveToInputPosition();
            
        }
    }

    private void DetermineSpawnPosition()
    {
        NavMeshTriangulation triangulation = NavMesh.CalculateTriangulation();
        int vertexIndex = Random.Range(0, triangulation.vertices.Length);

        
        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(triangulation.vertices[vertexIndex], out hit, maxDistanceFromNavmesh, -1))
        {
            Vector3 spawnPosition = hit.position;
            agent.Warp(spawnPosition);
            agent.enabled = true;
        }
        else 
        {
            Debug.Log("Failed to find spawn point for character on the navmesh!");
        }
    }

    private void MoveToInputPosition()
    {

        var target = CameraManager.instance.GetScreenPointWorld(Mouse.current.position.value);

        if (NavMesh.SamplePosition(target, out var navHit, clickSearchRadius, NavMesh.AllAreas))
        {
            //validate path before committing
            var path = new NavMeshPath();
            if (NavMesh.CalculatePath(agent.transform.position, navHit.position, NavMesh.AllAreas, path)
                && path.status == NavMeshPathStatus.PathComplete)
            {
                agent.SetPath(path);
            }
        }
    }


}
