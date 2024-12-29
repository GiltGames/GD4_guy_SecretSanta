using UnityEngine;

public class sSeekerSpellRun : MonoBehaviour
{
    [SerializeField] GameObject gChild;
    [SerializeField] float vSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created[s
    void Start()
    {
        gChild = FindAnyObjectByType<sChild>().gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vDir  = (gChild.transform.position - transform.position).normalized;
        transform.Translate(vDir*vSpeed*Time.deltaTime);
    }
}
