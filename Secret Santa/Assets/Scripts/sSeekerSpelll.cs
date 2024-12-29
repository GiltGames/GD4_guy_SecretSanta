using UnityEngine;
using UnityEngine.AI;

public class sSeekerSpelll : MonoBehaviour
{
    [SerializeField] sPlayerMove sPlayerMove;
    [SerializeField] sSpellControl sSpellControl;
    [SerializeField] GameObject gSeekerSpell;
    [SerializeField] GameObject gSeekerSpell2;
    [SerializeField] GameObject gSeekerSpelllocal;
    [SerializeField] GameObject gSeekerSpelllocal2;
    [SerializeField] float vManaCost;
    [SerializeField] float vDuration;
    [SerializeField] NavMeshAgent aNavMeshAgent;
    [SerializeField] GameObject gChild;
    [SerializeField] float vCreationHeight;
    [SerializeField] Vector3 vStartPos;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aManaOut;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        vStartPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && sPlayerMove.fGameStart && !sPlayerMove.fGameEnd)
        {

            if (sSpellControl.vMana > vManaCost)
            {
                pSeekerSpellManifest();
            }

            else
            {
                aAudioSource.clip = aManaOut;
                aAudioSource.Play();



            }


        }

       


    }



    void pSeekerSpellManifest()

    {

        Vector3 vCreatePostionTmp = new Vector3(transform.position.x, vCreationHeight  , transform.position.z);

      /*  NavMeshHit hit;
        if(NavMesh.SamplePosition(vCreatePostionTmp, out hit, 7w.0f,NavMesh.AllAreas))
        {
            vCreatePostionTmp = hit.position;
  gSeekerSpelllocal = Instantiate(gSeekerSpell, vCreatePostionTmp, Quaternion.identity);
        aNavMeshAgent = gSeekerSpelllocal.GetComponent<NavMeshAgent>();
        aNavMeshAgent.enabled = true;
        
        sSpellControl.vMana = sSpellControl.vMana - vManaCost;


        }

        */

       
        gSeekerSpelllocal = Instantiate(gSeekerSpell, vCreatePostionTmp, Quaternion.identity);
        Destroy(gSeekerSpelllocal, 3f);

        sSpellControl.vMana = sSpellControl.vMana - vManaCost;

        gSeekerSpelllocal2 = Instantiate(gSeekerSpell2, vCreatePostionTmp, Quaternion.identity);
        Destroy(gSeekerSpelllocal2, 3f);


      

    }



}
