using UnityEngine;

public class sSeekerHomerun : MonoBehaviour
{
     [SerializeField] GameObject gHome;
        [SerializeField] float vSpeed;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gHome = GameObject.FindGameObjectWithTag("Home");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vDir = (gHome.transform.position - transform.position).normalized;
        transform.Translate(vDir * vSpeed * Time.deltaTime);
    }
}
