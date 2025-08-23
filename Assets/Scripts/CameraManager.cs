using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    private Camera cameraComponent;

    // raycast variables
    private float screenToWorldRaycastDistance = 100;
    private LayerMask terrainLayerMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }


        cameraComponent = GetComponent<Camera>();
        if (cameraComponent == null)
        {
            Debug.LogError("Camera component reference not found on manager object");
        }

        terrainLayerMask = LayerMask.GetMask("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetScreenPointWorld(Vector2 screenPosition)
    {
        Ray ray = cameraComponent.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, screenToWorldRaycastDistance, terrainLayerMask))
        {
            return hit.point;
        }
        else
        {
            Debug.Log("Couldn't find world point.");
            return Vector3.zero;
        }

    }


}
