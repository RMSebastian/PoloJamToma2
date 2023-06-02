using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObjectSystem : MonoBehaviour
{
    public SpriteRenderer sr;

    public InventorySystem.PossibleItems thisItemIs;

    private bool isClicking;

    public Sprite hoveredSprite;

    public Sprite notHoveredSprite;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        if (!isClicking)
        {
            sr.sprite = hoveredSprite;
        }

    }
    private void OnMouseDown()
    {
        if (!isClicking)
        {
            isClicking = true;
            sr.sprite = notHoveredSprite;
            InventorySystem.Instance.SetItemRenderToEmptySlot(thisItemIs.GetHashCode());
            Destroy(gameObject);
        }

    }
    private void OnMouseUp()
    {
        isClicking = false;

    }
    private void OnMouseExit()
    {
        if (!isClicking)
            sr.sprite = notHoveredSprite;

    }
}
