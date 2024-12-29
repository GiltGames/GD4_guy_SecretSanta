using UnityEngine;

public class sWindSpell : MonoBehaviour
{
    [SerializeField] GameObject gWindSpell;
    [SerializeField] float vManaCost;
    [SerializeField] sSpellControl sSpellControl;
    [SerializeField] GameObject gPlayer;
    [SerializeField] float vHeightofSpell;

    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aManaOut;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire3"))

        {

            if (vManaCost < sSpellControl.vMana)
            {
                sSpellControl.vMana = sSpellControl.vMana - vManaCost;



                Instantiate(gWindSpell, gPlayer.transform.position + new Vector3(0,vHeightofSpell,0),Quaternion.Euler(90, 0,0));
            }

            else
            {

                aAudioSource.clip = aManaOut;
                aAudioSource.Play();
            }

        }


    }
}
