
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveCameraPositionTo(Vector3 v3)
    {
        this.transform.position = v3;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
