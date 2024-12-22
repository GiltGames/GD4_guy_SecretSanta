using UnityEngine;

public class sEnemy : MonoBehaviour
{
    public float vHealth;
    public float vHealthMax;
    [SerializeField] float vSpeed;
    [SerializeField] float vDamage;
    [SerializeField] float vDamageVariance;
    [SerializeField] float vAttackSpeed;
    [SerializeField] float vMoveRange;
    [SerializeField] float vAttackRange;
    [SerializeField] float vAttackInterval;
    [SerializeField] Rigidbody rb;
    [SerializeField] float vTimeafterdeathvanish=5;
    [SerializeField] Animator aGoblin;
    [SerializeField] Animation bGoblin;
    [SerializeField] AnimationClip aIdle;
    [SerializeField] AnimationClip aDeath;
  
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aGoblin.GetComponent<Animator>();
        bGoblin.GetComponent<Animation>();

        bGoblin.Play("idle");
     
        

    }

    // Update is called once per frame
    void Update()
    {

        if (vHealth < 0)

        {

            Destroy(gameObject, vTimeafterdeathvanish);
            aGoblin.SetBool("anim_death_b", true);

            bGoblin.Play("death");

        }




    }
}
