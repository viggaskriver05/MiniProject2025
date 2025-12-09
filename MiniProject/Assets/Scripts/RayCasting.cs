using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public float rayDistance = 3f;
    public LayerMask interactableLayer;
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, rayDistance, interactableLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var interact = hit.collider.GetComponent<IInteractable>();
                if (interact != null)
                {
                    interact.Interact();
                }
            }
        }
    }
}
