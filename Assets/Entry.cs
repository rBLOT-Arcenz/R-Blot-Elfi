using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public AudioSource vent;
    public AudioSource ventext;
    public AudioSource horreur;
    public Character chara;
    public AudioReverbFilter rev;

    void OnTriggerEnter()
    {
        vent.mute = true;
        ventext.mute = true;
        horreur.mute = false;
        chara.bruitPas = false;
        rev.reverbPreset = AudioReverbPreset.Stoneroom;
        Debug.Log("Entry");
    }
}
