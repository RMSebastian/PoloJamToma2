using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseSpriteSystem : MonoBehaviour
{
    [Header("Change Image Of Cursor")]

    public SpriteRenderer sr;

    public Sprite[] hands;

    private bool canLook;
    private void Start()
    {
        canLook = true;
        Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = hands[0];
    }
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position= new Vector3(this.transform.position.x, this.transform.position.y, 0);

        bool check = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Interactable"));
        if(check && canLook)
        {
            sr.sprite = sr.sprite = hands[2];
        } else if(!check && sr.sprite == hands[2])
        {
            sr.sprite = hands[0];
        }
    }
    public void OnClick(InputAction.CallbackContext ctx)

    {
        switch (ctx.phase)
        { 
            case InputActionPhase.Performed:
                canLook = false;
                sr.sprite = hands[1];
                break;
            case InputActionPhase.Canceled:
                canLook = true;
                sr.sprite = hands[0];
                break;
            default:
                break;
        }
    }
}
