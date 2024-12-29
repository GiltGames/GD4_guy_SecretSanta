using UnityEngine;

public class sFireSpellRunning : MonoBehaviour
{
    [SerializeField] float vDamage;
    [SerializeField] float vDamageVariance;
    [SerializeField] string vEnemy;
    [SerializeField] string vWood;
    [SerializeField] string vFire;
    [SerializeField] float vFireDuration;
    [SerializeField] float vFireDurationEnemy;
   
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == vWood)
        {
            other.gameObject.GetComponent<sBurn>().fBurn = true;
            
            Destroy(gameObject);

        }


        if (other.transform.tag == vEnemy)
        {
           
            
            other.gameObject.GetComponent<sBurn>().fBurn = true;
           


            sEnemy sEnemy = other.gameObject.GetComponent<sEnemy>();

            

            sEnemy.vHealth = sEnemy.vHealth - vDamage;

            Destroy(gameObject);

        }





    }

}
