using UnityEngine;

public class Tray : MonoBehaviour, IInteractable
{
    public Transform bunSpot;
    public Transform burgerSpot;
    public Transform drinkSpot;

    public GameObject fullTrayPrefab; // your completed tray prefab

    public void Interact()
    {
        Transform hand = GameObject.FindWithTag("PlayerHand").transform;
        if (hand.childCount == 0) return;

        GameObject item = hand.GetChild(0).gameObject;

        if (item.CompareTag("Bun") && bunSpot.childCount == 0)
        {
            Place(item, bunSpot);
            TryCompleteTray(hand);
            return;
        }

        if (item.CompareTag("CookedPatty") && burgerSpot.childCount == 0)
        {
            Place(item, burgerSpot);
            TryCompleteTray(hand);
            return;
        }

        if (item.CompareTag("FilledCup") && drinkSpot.childCount == 0)
        {
            Place(item, drinkSpot);
            TryCompleteTray(hand);
            return;
        }
    }

    private void Place(GameObject item, Transform spot)
    {
        item.transform.SetParent(spot);
        item.transform.localPosition = Vector3.zero;

        Transform hand = GameObject.FindWithTag("PlayerHand").transform;
        hand.DetachChildren();
    }

    public bool IsComplete()
    {
        return bunSpot.childCount > 0 &&
               burgerSpot.childCount > 0 &&
               drinkSpot.childCount > 0;
    }

    private void TryCompleteTray(Transform hand)
    {
        if (!IsComplete()) return;

        Destroy(bunSpot.GetChild(0).gameObject);
        Destroy(burgerSpot.GetChild(0).gameObject);
        Destroy(drinkSpot.GetChild(0).gameObject);

        GameObject fullTray = Instantiate(fullTrayPrefab, hand);
        fullTray.transform.localPosition = Vector3.zero;
        fullTray.transform.localRotation = Quaternion.identity;
    }
}