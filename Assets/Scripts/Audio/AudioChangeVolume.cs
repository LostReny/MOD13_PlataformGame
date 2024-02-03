using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer audioGroup;
    public string F_Parameter = "My parameter";

    public void ChangeValueVol(float f)
    {
        audioGroup.SetFloat(F_Parameter, f);
    }
}
