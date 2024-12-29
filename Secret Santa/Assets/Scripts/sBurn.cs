using UnityEngine;

public class sBurn : MonoBehaviour
{

    public bool fBurn;
    string vFire = "Fire";
    [SerializeField] float vBurnDuration;
    [SerializeField] float vTimer;
    [SerializeField] GameObject gFire;
    [SerializeField] bool fBurning;
    [SerializeField] Vector3 vInitialSize;
    [SerializeField] float vEndSize;
    [SerializeField] Vector3 vSize;
    [SerializeField] float vBrightness;



        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gFire.SetActive(false);
        fBurning = false;
        vInitialSize = gFire.transform.localScale;
        


    }

    // Update is called once per frame
    void Update()
    {

        gFire.SetActive(fBurning);

        if (fBurn)
        {
           gFire.transform.localScale = vInitialSize;
            fBurn = false;
            vTimer = vBurnDuration;
           
            fBurning=true;

        }

        if (vTimer > 0)
        {

            vTimer = vTimer - Time.deltaTime;
            vSize = vInitialSize * (vEndSize + (1- vEndSize) * (vTimer/vBurnDuration));
            gFire.transform.localScale = vSize;



        }

        else
        {
            
            fBurning = false ;

        }


    }
}
