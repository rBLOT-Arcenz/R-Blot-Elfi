using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator animator;
    public AudioSource ventPorte;
    public Transform porte;
    public AudioSource grince1;
    public AudioSource grince2;
    public AudioSource claque;

    public AudioClip grince;
    public AudioClip claquement;

    public AudioReverbFilter rev;

    // Start is called before the first frame update
    void Start()
    {
        //Assignation de son propre animator en tant que variable pour pouvoir y accéder plus simplement
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(porte.rotation.eulerAngles.y - 180);
        ventPorte.volume = ((porte.rotation.eulerAngles.y - 180) / -92.215f) / 6.6f;
    }
    
    //déclence l'animation d'ouverture des portes
    //Y intégrer le jeu d'un son ? Le lancement d'une corroutine ?
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("In", true);
        if (!rev.enabled)
        {
            rev.enabled = true;
        }
        else
        {
            rev.enabled = false;
        }
        grince1.PlayOneShot(grince);
        grince2.PlayOneShot(grince);
    }

    //déclence l'animation de fermeture des portes
    //Y intégrer le jeu d'un son ? Le lancement d'une corroutine ?
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("In", false);
        claque.PlayOneShot(claquement);
    }

    //Créer une fonction publique à appeler lors d'un animation event ?

}
