using UnityEngine;
using UnityEngine.AI;

public class sEnemy : MonoBehaviour
{
    public float vHealth;
    public float vHealthMax;
    [SerializeField] float vSpeed;
    [SerializeField] float vDamage;
    [SerializeField] float vDamageVariance;
    [SerializeField] float vAttackSpeed;
    [SerializeField] float vAttackInterval;
    [SerializeField] Rigidbody rb;
    [SerializeField] float vTimeafterdeathvanish=4;
    [SerializeField] Animator aGoblin;
    [SerializeField] Animation bGoblin;
    [SerializeField] AnimationClip aIdle;
    [SerializeField] AnimationClip aDeath;
    [SerializeField] AnimationClip aAttack;
    [SerializeField] AnimationClip aWalk;
    [SerializeField] GameObject vTarget;
    [SerializeField] Vector3 vTargetLoc;
    [SerializeField] NavMeshAgent aNavMeshAgent;
    [SerializeField] int vMode;
    [SerializeField] bool vModeChange;
    [SerializeField] Vector3 vTargetVector;
    [SerializeField] float vThresholdWalk;
    [SerializeField] float vThresholdAttack;
    [SerializeField] float vThresholdHit;
    [SerializeField] float vHitDuration;
    [SerializeField] float vHitTimer;
    [SerializeField] float vResumeAttackTimer; 
     [SerializeField] float   vResumeAttackInterval;
    [SerializeField] float vResumeRotSpeed;
    [SerializeField] float vRetreatMult = 3;
    [SerializeField] sIceWallSpell sIceWallSpell;
    [SerializeField] SHealth sHealth;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aWarcry;
    [SerializeField] AudioSource aAudioPlayer;
    [SerializeField] AudioClip aClaw;

    [SerializeField] AudioClip aGoblindieWords;
    [SerializeField] AudioClip aGoblinChiefdiesWords;
    [SerializeField] AudioClip aDie;
    [SerializeField] float vHealthChiefThreshold=20;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aGoblin.GetComponent<Animator>();
        bGoblin.GetComponent<Animation>();

        bGoblin.Play("idle");

        aNavMeshAgent = GetComponent<NavMeshAgent>();
        aNavMeshAgent.enabled = false;
        vTarget = FindFirstObjectByType<sPlayerMove>().gameObject;

        sIceWallSpell = FindFirstObjectByType<sIceWallSpell>().GetComponent<sIceWallSpell>();
        sHealth = FindFirstObjectByType<sPlayerMove>().GetComponent<SHealth>();

        aAudioPlayer = FindFirstObjectByType<sPlayerMove>().GetComponent<AudioSource>();

     
        

    }

    // Update is called once per frame
    void Update()
    {


        //check for death
        if (vHealth < 0)

        {

            Destroy(gameObject, vTimeafterdeathvanish);
            aGoblin.SetBool("anim_death_b", true);

            bGoblin.Play("death");

            aAudioSource.clip = aDie;

            if (vHealthMax < vHealthChiefThreshold)
            {
                aAudioPlayer.clip = aGoblindieWords;
            }
            else
            {
                aAudioPlayer.clip = aGoblinChiefdiesWords;

            }
            
            aAudioSource.Play();

            aAudioPlayer.Play();

        }


        pMove();


       



    }

    void pMove()
    {

        //Move Mode
        vTargetLoc = vTarget.transform.position;
        vTargetVector = vTargetLoc - transform.position;

        if (vTargetVector.magnitude < vThresholdWalk && vMode == 0)
        {
            vMode = 1;
            vModeChange = true;

        }

        //idle
        if (vMode == 0)


        {
            if (vModeChange)
            {
                bGoblin.Play("idle");
                vModeChange = false;
            }



        }
        // approach
        if (vMode == 1)

        {
            if (vModeChange)
            {
                bGoblin.Play("walk");
                vModeChange = false;
                aAudioSource.clip = null;


            }

            vTargetLoc = vTarget.transform.position;

            aNavMeshAgent.enabled = true;
            aNavMeshAgent.SetDestination(vTargetLoc);

            if (vTargetVector.magnitude < vThresholdAttack)
            {

                vMode = 2;
                vModeChange = true;

            }

        }


        // attack

        if (vMode == 2)
        {


            if (vModeChange)
            {
                bGoblin.Play("run");
                vModeChange = false;
                aAudioSource.clip = aWarcry;
                aAudioSource.Play();


            }

            rb.AddForce(vTargetVector.normalized * vAttackSpeed);
            Quaternion vtargetRotationTmp = Quaternion.LookRotation(vTargetVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, vtargetRotationTmp, vResumeRotSpeed * Time.deltaTime);

            if (vTargetVector.magnitude < vThresholdHit)
            {
                vModeChange = true;
                vMode = 3;

                if (sIceWallSpell.fIceWall)
                { 
                    vMode = 4; 
                    rb.linearVelocity = Vector3.zero;  
                }


            }


        }

        // retreat
        if (vMode == 3)
        {

            if (vModeChange)
            {
                bGoblin.Play("attack1");
                vModeChange = false;
                vHitTimer = vHitDuration;
                sHealth.vHealth = sHealth.vHealth - (vDamage - Random.Range(0,vDamageVariance)) ;
                aAudioSource.clip = aClaw;
                aAudioSource.Play();

            }
            Quaternion vtargetRotationTmp = Quaternion.LookRotation(vTargetVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, vtargetRotationTmp, vResumeRotSpeed * Time.deltaTime);

            vHitTimer = vHitTimer - Time.deltaTime;

            if(vHitTimer < 0)

            {

                vMode = 4;
                vModeChange |= true;

                vTargetLoc = vTarget.transform.position + vTarget.transform.forward * -1*  vThresholdAttack * vRetreatMult ;
                aNavMeshAgent.SetDestination(vTargetLoc);
                
            }


        }

        // retreat
        if(vMode == 4)

        {
            if(vModeChange)
            {
                bGoblin.Play("walk");
                vModeChange = false;
                vResumeAttackTimer = vResumeAttackInterval;
                aAudioSource.clip = null;
               
            }

            vResumeAttackTimer = vResumeAttackTimer - Time.deltaTime;

            if (vResumeAttackTimer < 0)
            {

                vTarget = FindFirstObjectByType<sPlayerMove>().gameObject;
                vTargetLoc = vTarget.transform.position;
                vModeChange = true;
                vMode = 2;
                aNavMeshAgent.SetDestination(vTargetLoc);
               


            }


        }


    }

}
