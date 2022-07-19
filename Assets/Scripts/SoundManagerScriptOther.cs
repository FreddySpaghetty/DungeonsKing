using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScriptOther : MonoBehaviour
{
    public static AudioClip clicSound, mouseclicSound, collectingSound, swordSound, lvlupSound, attackupSound, defenseupSound;
    static AudioSource audioSrc;

    void Start()
    {
        clicSound = Resources.Load<AudioClip>("clic");
        mouseclicSound = Resources.Load<AudioClip>("mouseclic");
        collectingSound = Resources.Load<AudioClip>("collecting");
        swordSound = Resources.Load<AudioClip>("sword");
        lvlupSound = Resources.Load<AudioClip>("lvlup");
        attackupSound = Resources.Load<AudioClip>("attack");
        defenseupSound = Resources.Load<AudioClip>("defense");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "clic":
                audioSrc.PlayOneShot(clicSound);
                break;
            case "mouseclic":
                audioSrc.PlayOneShot(mouseclicSound);
                break;
            case "collecting":
                audioSrc.PlayOneShot(collectingSound);
                break;
            case "sword":
                audioSrc.PlayOneShot(swordSound);
                break;
            case "lvlup":
                audioSrc.PlayOneShot(lvlupSound);
                break;
            case "attack":
                audioSrc.PlayOneShot(attackupSound);
                break;
            case "defense":
                audioSrc.PlayOneShot(defenseupSound);
                break;
        }
    }
}
