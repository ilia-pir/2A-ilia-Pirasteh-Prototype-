using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShot("event:/SFX/Footstep_Grass");
    }
}
