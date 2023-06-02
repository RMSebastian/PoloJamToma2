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
    public Sprite notHoveredSprite;
    public Sprite hoveredSprite;

    [Header("Movement")]
    public float time = 1f;
    public float speed = 5f;
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
        if (!isClicking && !done)
        {
            sr.sprite = hoveredSprite;
        }

    }
    private void OnMouseDown()
    {
        if (!isClicking && !done)
        {
            sr.sprite = notHoveredSprite;
            done = true;
            isClicking = true;
            StartCoroutine(Movement());
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
    private IEnumerator Movement()
    {
        Vector3 finalPosition = endPosition + transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < time)
        {
            transform.position = Vector2.Lerp(this.transform.position, finalPosition, speed * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ActivateKey();

    }
}
