using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource[] soundFXWalk;


    void PlayerFootsteps()
    {
        soundFXWalk[0].Play();
    }
}
