using UnityEngine;

public class sIceWallSpell : MonoBehaviour
{
    [SerializeField] GameObject gIceWall;
    [SerializeField] GameObject gPlayer;
        
        [SerializeField] sSpellControl sSpellControl;
        [SerializeField] sPlayerMove sPlayerMove;
        
        [SerializeField] float vManaUsed;
    public bool fIceWall;

    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aManaOut;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gIceWall.SetActive(false);
        fIceWall = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        gIceWall.transform.position = gPlayer.transform.position;

        if (Input.GetButtonDown("Fire2") && sPlayerMove.fGameStart && !sPlayerMove.fGameEnd && sSpellControl.vMana > vManaUsed/2)

        {
                    pIceSpellManifest();
            

        }




        if (fIceWall)

        {

            

            sSpellControl.vMana = sSpellControl.vMana - vManaUsed * Time.deltaTime;

            if (sSpellControl.vMana < 0 || Input.GetButtonUp("Fire2"))
            {
                pIceSpellStop();
                aAudioSource.clip = aManaOut;
                aAudioSource.Play();

            }

        }



    }

    void pIceSpellManifest()

    {
        gIceWall.SetActive(true);
        fIceWall = true;



     }

    void pIceSpellStop()
    {

        gIceWall.SetActive(false);
        fIceWall = false;

    }


}
