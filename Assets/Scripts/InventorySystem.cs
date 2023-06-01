using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    private static InventorySystem instance;

    public GameObject[] slotItems;
    public enum PossibleItems
    {
        Pipe,
        Tabaco,
        Honey
    }
    public void MoveInventoryPositionTo(Vector3 v3)
    {
        this.transform.position = new Vector3(v3.x,v3.y + this.transform.position.y, 0);
    }
    public static InventorySystem Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetItemRenderToEmptySlot(int i)
    {
        slotItems[i].SetActive(true);
    }
    public void GotAllItems()
    {
        int activedSlots = 0;
        foreach (var item in slotItems)
        {
            if(item.gameObject.activeSelf == true)
            {
                activedSlots++;
            }
        }
        if(activedSlots > 3)
        {
            print("congratulations");
        }
    }
}
