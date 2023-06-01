using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public enum SceneNames
    {
        outsideMiddle,
        outsideRight,
        outsideLeft,
        insideHouse,
        fromAfarScene,
        partyScene
    }

    public GameObject[] scenes;
    private Vector3[] cameraUbications;
    private void Start()
    {
        cameraUbications = new Vector3[scenes.Length];
        for (int i = 0; i < scenes.Length; i++)
        {
            cameraUbications[i] = new Vector3(scenes[i].transform.position.x, scenes[i].transform.position.y, -10);
        }
    }

    public Vector3 GetCameraNewPosition(int i)
    {
        return cameraUbications[(int)i];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
