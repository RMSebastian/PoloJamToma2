using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAñadirse : MonoBehaviour
{
    private void Start()
    {
        InventorySystem.Instance.PatasDelPombero = this.gameObject;
    }
}
