using UnityEngine;

public class sAimUpDown : MonoBehaviour
{
    [SerializeField] float vUpperLook;
    [SerializeField] float vLowerLook;
    [SerializeField] sPlayerMove sPlayerMove;
    [SerializeField] float sAngleChangeMult;
    [SerializeField] float vUpDown;
    [SerializeField] GameObject gRightHand;
    [SerializeField] GameObject gRForearm;
    [SerializeField] float vAnglex;
    [SerializeField] float vAngley;
    [SerializeField] float vAnglez;
        
       // / Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.identity;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = gRightHand.transform.position; 
        

        if (sPlayerMove.fGameStart)
        {
            vUpDown = Input.GetAxis("MouseY") * sPlayerMove.vPlayerTurnSpeedMouse * Time.deltaTime *sAngleChangeMult;

            

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
