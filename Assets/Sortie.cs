using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sortie : MonoBehaviour
{
    public AudioSource vent;
    public AudioSource ventext;
    public AudioSource horreur;
    public Character chara;
    public AudioReverbFilter rev;

    void OnTriggerEnter()
    {
        vent.mute = false;
        ventext.mute = false;
        horreur.mute = true;
        chara.bruitPas = true;
        rev.reverbPreset = AudioReverbPreset.Generic;
        Debug.Log("Sortie");
    }
}
