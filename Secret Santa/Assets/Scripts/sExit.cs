using TMPro;
using UnityEngine;

public class sExit : MonoBehaviour
{

    [SerializeField] sChild sChild;
    [SerializeField] TextMeshProUGUI tGameOver;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aSuccess;
    [SerializeField] AudioClip aAway;
    
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
        
        if (other.gameObject.tag == "Player")


        {

            if (sChild.fAccompanied)

            {

                //Win

                tGameOver.text = "Congratulations! You saved the Child!";
                aAudioSource.clip = aSuccess;
                aAudioSource.Play();


            }


            else
            {

                //survived
                tGameOver.text = "You survived but you didn't save the Child";

                aAudioSource.clip = aAway;
                aAudioSource.Play();

            }



        }


    }


}
