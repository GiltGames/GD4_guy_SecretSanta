using UnityEngine;

public class sChild : MonoBehaviour
{
    [SerializeField] float vChildTimer;
    [SerializeField] float vChildLifeTime;
   public Vector3 vChildStartPosition;
    [SerializeField] GameObject gSkeleton;
    [SerializeField] GameObject gLiving;
   public  bool fTooLate;
    public bool fSavedChild;
    [SerializeField] GameObject gPlayer;
    [SerializeField] GameObject gFire;
    [SerializeField] GameObject gCage;
   
    [SerializeField] float vSizechange;
    public bool fAccompanied;
    [SerializeField] SHealth sHealth;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aThanks;
    [SerializeField] AudioSource aAudioPlayer;
    [SerializeField] AudioClip aTooLate;
    [SerializeField] sPlayerMove sPlayerMove;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vChildTimer = vChildLifeTime;
        vChildStartPosition = transform.position;
        sHealth = gPlayer.GetComponent<SHealth>();
        aAudioSource = GetComponent<AudioSource>();
        sPlayerMove = gPlayer.GetComponent<sPlayerMove>();

        
    }

    // Update is called once per frame
    void Update()
    {

        if (!fSavedChild && !fTooLate && sPlayerMove.fGameStart)


            {
            vChildTimer -= Time.deltaTime;
        }


        if(vChildTimer <= 0)

        {
            gLiving.SetActive(false);
            gSkeleton.SetActive(true);
            fTooLate = true;
          
        }


      /*  if (sHealth.vHealth <0)
        {
            transform.position = vChildStartPosition;
            fSavedChild = false;
            gFire.SetActive(false);
            gCage.SetActive(true);
            fAccompanied = false;

        }
      */

        if (fAccompanied)

        { 
            transform.position = gPlayer.transform.position + gPlayer.transform.forward*2 + Vector3.up*.4f;
        
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player" )
        {

            if (!fTooLate)
            {

                gCage.SetActive(false);
                if (!fAccompanied)
                { 
                    aAudioSource.clip = aThanks;
                    aAudioSource.Play();
                }
                fAccompanied = true;
            }

            else
            {

                aAudioPlayer.clip = aTooLate;
                aAudioPlayer.Play();


            }

        }




    }

}
