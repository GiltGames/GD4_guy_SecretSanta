using UnityEngine;

public class sFireSpell : MonoBehaviour
{
    [SerializeField] GameObject gFireSpell;
    [SerializeField] GameObject gFireSpelllocal;
    [SerializeField] sSpellControl sSpellControl;
    [SerializeField] sPlayerMove sPlayerMove;
    [SerializeField] float vSpeed;
    [SerializeField] float vManaUsed;
    [SerializeField] float vManatohold;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aManaOut;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sSpellControl.vMana > vManaUsed)
        {

            if (Input.GetButtonDown("Fire1") && sPlayerMove.fGameStart && !sPlayerMove.fGameEnd)
            {

                pFireSpellManifest();


            }



            if (Input.GetButton("Fire1") && sPlayerMove.fGameStart && !sPlayerMove.fGameEnd)
            {

                pFireSpellHold();


            }



            if (Input.GetButtonUp("Fire1") && sPlayerMove.fGameStart && !sPlayerMove.fGameEnd)

            {
                

                    pFireSpellRelease();


                           



            }

           
            }

        else
        {

            if (gFireSpelllocal != null)
            {
                Destroy(gFireSpelllocal);
                aAudioSource.clip = aManaOut;
                aAudioSource.Play();

            }


        }





    }

    void pFireSpellManifest()

    {

        if (gFireSpelllocal != null)
        {
            Destroy(gFireSpelllocal);
        }
        
        gFireSpelllocal = Instantiate(gFireSpell, transform.position, Quaternion.identity);
       
    }

    void pFireSpellHold()
    {
        sSpellControl.vMana = sSpellControl.vMana - vManatohold * Time.deltaTime;


        if (gFireSpelllocal != null)
        {
            gFireSpelllocal.transform.position = transform.position;
        }
    }

    void pFireSpellRelease()
    {
        if (gFireSpelllocal != null)
        {
            Rigidbody rb = gFireSpelllocal.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * vSpeed, ForceMode.Impulse);


            Destroy(gFireSpelllocal, 2);


            sSpellControl.vMana = sSpellControl.vMana - vManaUsed;
        }
    }

}
