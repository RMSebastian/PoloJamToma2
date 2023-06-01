using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveArrowScript : MonoBehaviour
{

    public LevelManager.SceneNames SceneToMoveTo;
    private LevelManager levelManager;
    private SpriteRenderer sr;

    public Sprite notHoveredSprite;
    public Sprite hoveredSprite;

    private void Start()
    { 
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = notHoveredSprite;
        levelManager = GameManager.Instance.levelManager;
    }
    public void GoToScene()
    {
        GameManager.Instance.blackScreen.GetComponent<Animator>().SetTrigger("Moving");
        Invoke(nameof(MovingToNextScene), 2f);
    }
    public void MovingToNextScene()
    {
        GameManager.Instance.inventory.MoveInventoryPositionTo(levelManager.GetCameraNewPosition(SceneToMoveTo.GetHashCode()));
        GameManager.Instance.onlyCamera.MoveCameraPositionTo(levelManager.GetCameraNewPosition(SceneToMoveTo.GetHashCode()));
        GameManager.Instance.music.SetMusicScene((SceneToMoveTo.GetHashCode()));
    }
    #region OnTouchArrow


    private bool isClicking;

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
            sr.sprite = hoveredSprite;
            GoToScene();

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
    #endregion
}
