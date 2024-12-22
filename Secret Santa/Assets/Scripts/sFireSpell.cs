using UnityEngine;

public class sFireSpell : MonoBehaviour
{
    [SerializeField] GameObject gFireSpell;
    [SerializeField] GameObject gFireSpelllocal;
    [SerializeField] sSpellControl sSpellControl;
    [SerializeField] sPlayerMove sPlayerMove;
    [SerializeField] float vSpeed;
    [SerializeField] float vManaUsed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && sPlayerMove.fGameStart && !sPlayerMove.fGameEnd)

        {
            if (sSpellControl.vMana > vManaUsed)

            {

                pFireSpellManifest();



            }



        }




    }

    void pFireSpellManifest()

    {

        gFireSpelllocal = Instantiate(gFireSpell,transform.position,Quaternion.identity);
        Rigidbody rb = gFireSpelllocal.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*vSpeed, ForceMode.Impulse);
        Destroy(gFireSpelllocal, 2  );
    }

}
