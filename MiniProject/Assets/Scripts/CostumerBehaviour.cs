using UnityEngine;
using System.Collections.Generic;

public class CostumerBehaviour : MonoBehaviour
{
    public GameObject customer;
    public Transform door;
    public List<Chair> chairs = new List<Chair>();

    public float spawnInterval = 15f;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCustomer();
            timer = 0f;
        }
    }

    void SpawnCustomer()
    {
        Chair freeChair = chairs.Find(c => !c.isOccupied);
        if (freeChair == null) return;

        GameObject newCustomer = Instantiate(customer, door.position, Quaternion.identity);
        freeChair.isOccupied = true;
        Customer customerScript = newCustomer.GetComponent<Customer>();
        customerScript.AssignSeat(freeChair);

    }
}
