using TMPro;
using UnityEngine;

public class sAimUpDown : MonoBehaviour
{
    [SerializeField] float vUpperLook;
    [SerializeField] float vLowerLook;
    [SerializeField] sPlayerMove sPlayerMove;
    [SerializeField] GameObject gPlayer;
    [SerializeField] float sAngleChangeMult;
    [SerializeField] float vUpDown;
    [SerializeField] GameObject gRightHand;
    [SerializeField] GameObject gRForearm;
    [SerializeField] float vAnglex;
    [SerializeField] float vAngley;
    [SerializeField] float vAnglez;
    public bool fAnyKeyEver;
    [SerializeField] TextMeshProUGUI tIns;
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioClip aIntroClip;
        
       // / Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.identity;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fAnyKeyEver = false;
        aAudioSource = gPlayer.GetComponent<AudioSource>();


        aAudioSource.clip = aIntroClip;
        aAudioSource.Play();


    }

    // Update is called once per frame
    void Update()
    {


        if (Input.anyKeyDown && !sPlayerMove.fGameStart)
        { 
            sPlayerMove.fGameStart = true;
            fAnyKeyEver =(true);
            tIns.text = "";
            aAudioSource.clip = aIntroClip;
            aAudioSource.Play();


            vAnglex = transform.eulerAngles.x;
            vAngley = transform.eulerAngles.y;
            vAnglez = transform.eulerAngles.z;

            transform.rotation = Quaternion.Euler(0,vAngley,vAnglez);

        }







        if (sPlayerMove.fGameStart)
        {

            if (fAnyKeyEver)
            {
                vUpDown = -1* Input.GetAxis("MouseY") * sPlayerMove.vPlayerTurnSpeedMouse * Time.deltaTime * sAngleChangeMult;
            }
            

            vAnglex = transform.eulerAngles.x;
            vAngley = transform.eulerAngles.y;
            vAnglez = transform.eulerAngles.z;





            if ((vAnglex > vUpperLook  && vUpDown < 0 ) || (vAnglex < vLowerLook && vUpDown>0  ) || (vAnglex <180 && vUpDown <0) ||(vAnglex> 180 && vUpDown >0))
              {

               transform.Rotate(new Vector3(vUpDown,0,0));
                gRForearm.transform.Rotate(new Vector3(vUpDown, 0, 0));

                }

      

        }

    }
}
