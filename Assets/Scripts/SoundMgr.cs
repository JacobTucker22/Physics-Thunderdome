using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    private float threasholdVolume = -80f;
    [Range(0f,1f)]
    public float masterVolume;
    [Range(0f, 1f)]
    public float musicVolume;
    [Range(0f, 1f)]
    public float collisionVolume;

    // Update is called once per frame
    void Update()
    {
        
    }
}
