using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObjectSystem : MonoBehaviour
{
    public Vector3 endPosition;
    public SpriteRenderer sr;
    public GameObject keyObject;
    private bool isClicking;
    private bool done = false;

    [Header("Movement")]
    public float time = 1f;
    public float speed = 5f;
    public AnimationCurve accelerationCurve;
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        keyObject.GetComponent<Collider2D>().enabled = false;
    }
    public void ActivateKey()
    {
        keyObject.GetComponent<Collider2D>().enabled = true;
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
        if (!isClicking && !done)
        {
            done = true;
            isClicking = true;
            StartCoroutine(Movement());
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
    private IEnumerator Movement()
    {
        Vector3 finalPosition = endPosition + transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < time)
        {
            transform.position = Vector2.Lerp(this.transform.position, finalPosition, accelerationCurve.Evaluate(speed * Time.deltaTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ActivateKey();
    }
}
