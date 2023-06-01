using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObjectSystem : MonoBehaviour
{
    public SpriteRenderer sr;

    public InventorySystem.PossibleItems thisItemIs;

    private bool isClicking;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        if (!isClicking)
        {
            sr.color = Color.yellow;
        }

    }
    private void OnMouseDown()
    {
        if (!isClicking)
        {
            isClicking = true;
            sr.color = Color.red;
            InventorySystem.Instance.SetItemRenderToEmptySlot(thisItemIs.GetHashCode());
            Destroy(gameObject);
        }

    }
    private void OnMouseUp()
    {
        sr.color = Color.green;
        isClicking = false;

    }
    private void OnMouseExit()
    {
        if (!isClicking)
            sr.color = Color.white;

    }
}
