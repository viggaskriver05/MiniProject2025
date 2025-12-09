using UnityEngine;

public class SodaDispenser : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Transform hand = GameObject.FindWithTag("PlayerHand").transform;
        if (hand.childCount == 0) return;

        GameObject item = hand.GetChild(0).gameObject;

        if (item.CompareTag("Cup"))
        {
            foreach (Transform child in item.transform)
            {
                child.gameObject.SetActive(true);
            }
            item.tag = "FilledCup";
        }
    }
}
