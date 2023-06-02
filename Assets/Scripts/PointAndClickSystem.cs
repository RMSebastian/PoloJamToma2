using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PointAndClickSystem : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] everyTrashSprite;
    private Sprite[] thisTrashSprites;
    public TypeOfTrash thisTypeOfTrash;
    private AudioSource touchEmit;
    public AudioClip[] touchSound;
    
    public enum TypeOfTrash
    {
        vaso,
        lata,
        botella,
        botellaAbollada,
        lataAplastada,
        bolsa,
        bolsaAplastada
    }

    

    [Header("Come Back To Place")]
    public float time = 1f;
    public  Vector2 initialPosition;
    public float speed = 5f;

    private bool isClicking;


    private void Awake()
    {
        thisTrashSprites = new Sprite[2];
        touchEmit = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();

        switch (thisTypeOfTrash)
        {
            case TypeOfTrash.vaso:
                thisTrashSprites[0] = everyTrashSprite[0];
                thisTrashSprites[1] = everyTrashSprite[1];
                touchEmit.clip = touchSound[0];
                break;
            case TypeOfTrash.lata:
                thisTrashSprites[0] = everyTrashSprite[2];
                thisTrashSprites[1] = everyTrashSprite[3];
                touchEmit.clip = touchSound[1];
                break;
            case TypeOfTrash.botella:
                thisTrashSprites[0] = everyTrashSprite[4];
                thisTrashSprites[1] = everyTrashSprite[5];
                touchEmit.clip = touchSound[0];
                break;
            case TypeOfTrash.botellaAbollada:
                thisTrashSprites[0] = everyTrashSprite[6];
                thisTrashSprites[1] = everyTrashSprite[7];
                touchEmit.clip = touchSound[0];
                break;
            case TypeOfTrash.lataAplastada:
                thisTrashSprites[0] = everyTrashSprite[8];
                thisTrashSprites[1] = everyTrashSprite[9];
                touchEmit.clip = touchSound[1];
                break;
            case TypeOfTrash.bolsa:
                thisTrashSprites[0] = everyTrashSprite[10];
                thisTrashSprites[1] = everyTrashSprite[11];
                touchEmit.clip = touchSound[2];
                break;
            case TypeOfTrash.bolsaAplastada:
                thisTrashSprites[0] = everyTrashSprite[12];
                thisTrashSprites[1] = everyTrashSprite[13];
                touchEmit.clip = touchSound[2];
                break;
        }
        sr.sprite = thisTrashSprites[0];
    }

    private void Start()
    {
        SumarBasura();
        
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
            sr.sprite = thisTrashSprites[1];
        }

    }

    public void SumarBasura()
    {
        GameManager.Instance.SumarBasura();
    }
    private void OnMouseDown()
    {
        if (!isClicking)
        {
            touchEmit.Play();
            isClicking = true;
            sr.sprite = thisTrashSprites[0];
           initialPosition = transform.position;
        }
        
    }
    private void OnMouseUp()
    {
        StartCoroutine(ComeBackToPlace());
        isClicking = false;

    }
    private void OnMouseExit()
    {
        if (!isClicking)
            sr.sprite = thisTrashSprites[0];
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isClicking && collision.gameObject.CompareTag("TrashBag")) 
        { 
            Destroy(this.gameObject);
            GameManager.Instance.RestarBasura();
        }
    }
    private IEnumerator ComeBackToPlace()
    {
        float timeElapsed = 0f;

        while (timeElapsed< time)
        {
            transform.position  = Vector2.Lerp(this.transform.position, initialPosition, speed*Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
