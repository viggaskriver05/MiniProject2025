using UnityEngine;

public class Customer : MonoBehaviour, IInteractable
{
    private Chair assignedChair;
    public float moveSpeed = 2f;

    public Renderer rend;

    private bool seated = false;
    
    public void Interact()
    {
        Transform hand = GameObject.FindWithTag("PlayerHand").transform;
        if (hand.childCount == 0) return;

        GameObject item = hand.GetChild(0).gameObject;

        if (item.CompareTag("FullTray"))
        {
            Destroy(item); // remove tray
            rend.material.color = Color.green; // customer happy
            Destroy(gameObject, 1.5f); // customer leaves
        }
    }

    //void ClearTray(Tray tray)
    //{
    //    if (tray.bunSpot.childCount > 0)
    //        Destroy(tray.bunSpot.GetChild(0).gameObject);

    //    if (tray.burgerSpot.childCount > 0)
    //        Destroy(tray.burgerSpot.GetChild(0).gameObject);

    //    if (tray.drinkSpot.childCount > 0)
    //        Destroy(tray.drinkSpot.GetChild(0).gameObject);
    //}
    public void AssignSeat(Chair chair)
    {
        assignedChair = chair;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (assignedChair == null || seated) return;

        transform.position = Vector3.MoveTowards(transform.position, assignedChair.seat.position, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, assignedChair.seat.position) < 0.1f)
        {
            seated = true;
            assignedChair.isOccupied = true;
        }
    }
}
