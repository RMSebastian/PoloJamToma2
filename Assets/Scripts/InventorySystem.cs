using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    private static InventorySystem instance;
    public GameObject PatasDelPombero;
    private float yOffset;
    private float xOffset;
    public GameObject[] slotItems;
    private void Start()
    {
        yOffset = this.transform.position.y;
        xOffset = this.transform.position.x;
    }
    public enum PossibleItems
    {
        Pipe,
        Tabaco,
        Honey
    }
    public void MoveInventoryPositionTo(Vector3 v3)
    {

        this.transform.position = new Vector3(v3.x + xOffset ,v3.y + yOffset, 0);
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
        GotAllItems();
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
        if(activedSlots >= 3)
        {
            GameManager.Instance.objetosIsComplete = true;
        }
        else
        {
            PatasDelPombero.gameObject.GetComponent<Animator>().SetBool($"Patas{activedSlots}", true);
        }
    }
}
