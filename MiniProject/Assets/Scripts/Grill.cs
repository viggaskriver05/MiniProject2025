using UnityEngine;
using System.Collections;

public class Grill : MonoBehaviour, IInteractable
{
    public Transform[] grillSpots;
    public Material cookedMaterial;
    public float cookTime = 5f;

    public void Interact()
    {
        Transform hand = GameObject.FindWithTag("PlayerHand").transform;

        if (hand.childCount == 0) return;

        GameObject item = hand.GetChild(0).gameObject;

        if (!item.CompareTag("Patty")) return;

        foreach (Transform spot in grillSpots)
        {
            if (spot.childCount == 0)
            {
                item.transform.SetParent(spot);
                item.transform.localPosition = Vector3.zero;

                StartCoroutine(Cook(item));

                return;
            }
        }
    }

    private IEnumerator Cook(GameObject patty)
    {
        yield return new WaitForSeconds(cookTime);

        patty.GetComponent<MeshRenderer>().material = cookedMaterial;
        patty.tag = "CookedPatty";
    }
}
