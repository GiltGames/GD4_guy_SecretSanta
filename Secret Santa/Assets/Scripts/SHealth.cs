using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SHealth : MonoBehaviour
{
    public float vHealth;
    public float vhealthMax;
    [SerializeField] float vHealthRecovery;
    [SerializeField] Image tHealth;
    [SerializeField] Vector3 vStartPos;
    [SerializeField] GameObject gTeleportEffect;
    [SerializeField] sChild sChild;
    [SerializeField] GameObject gChild;
    [SerializeField] GameObject gCage;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aTeleport;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vStartPos = transform.position;
        aAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vHealth <0)
        {

            StartCoroutine(pGameOver());

        }

        if (vHealth < vhealthMax)
        {
            vHealth = vHealth + vHealthRecovery;


        }

        tHealth.color = new Color(((vhealthMax - vHealth) / vhealthMax), (vHealth / vhealthMax), 0, 1);


    }

    public IEnumerator pGameOver()

    {
        GameObject vTeleTmp = Instantiate(gTeleportEffect, transform.position, Quaternion.identity, gameObject.transform);

        aAudioSource.clip = aTeleport;
        aAudioSource.Play();

        gChild.transform.position = sChild.vChildStartPosition;
        sChild.fAccompanied = false;
        gCage.SetActive(true);
        sChild.fSavedChild = false;
        yield return new WaitForSeconds(0.5f);
        
        transform.position = vStartPos;
       
        Destroy(vTeleTmp,1f);

       

        
        
        vHealth = vhealthMax;

        yield break;

    }

}
