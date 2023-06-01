using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickSystem : MonoBehaviour
{
    public SpriteRenderer sr;

    [Header("Come Back To Place")]
    public float time = 1f;
    public  Vector2 initialPosition;
    public float speed = 5f;
    public AnimationCurve accelerationCurve;

    private bool isClicking;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDrag()
    {
        Vector2 mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mouseDragStartPosition;
    }
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
           initialPosition = transform.position;
        }
        
    }
    private void OnMouseUp()
    {
        StartCoroutine(ComeBackToPlace());
        sr.color = Color.green;
        isClicking = false;

    }
    private void OnMouseExit()
    {
        if (!isClicking)
            sr.color = Color.white;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isClicking && collision.gameObject.CompareTag("TrashBag")) 
        { 
            Destroy(this.gameObject);
        }
        //LÓGICA PARA CLICKEAR FLECHAS DEL PISO
        if (isClicking && collision.gameObject.CompareTag("Arrow"))
        {
            collision.gameObject.SendMessage("GoToScene");
        }
    }
    private IEnumerator ComeBackToPlace()
    {
        float timeElapsed = 0f;

        while (timeElapsed< time)
        {
            transform.position=  Vector2.Lerp(this.transform.position, initialPosition, accelerationCurve.Evaluate(speed*Time.deltaTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
