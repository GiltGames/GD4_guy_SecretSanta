using UnityEngine;

public class sDetectSave : MonoBehaviour
{

    [SerializeField] GameObject gChild;
    [SerializeField] sChild sChild;

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
        if (!sChild.fTooLate)
        {



            sChild.fSavedChild = true;
        }
    }

}
