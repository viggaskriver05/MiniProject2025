using UnityEngine;

public class PickUpOrDispense : MonoBehaviour, IInteractable
{
    public enum Mode { Pickup, Dispense, Both }
    public Mode mode;

    public GameObject itemPrefab; // only used in dispense mode

    public void Interact()
    {
        Transform hand = GameObject.FindWithTag("PlayerHand").transform;

        if (hand.childCount > 0)
            Destroy(hand.GetChild(0).gameObject);

        if (mode == Mode.Dispense || mode == Mode.Both)
        {
            if (itemPrefab != null)
            {
                GameObject newItem = Instantiate(itemPrefab, hand);
                newItem.transform.localPosition = Vector3.zero;
                newItem.transform.localRotation = Quaternion.identity;
                return;
            }
        }

        if (mode == Mode.Pickup || mode == Mode.Both)
        {
            transform.SetParent(hand);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
