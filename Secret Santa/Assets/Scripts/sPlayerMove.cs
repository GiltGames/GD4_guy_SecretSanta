using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem.WebGL;

public class sPlayerMove : MonoBehaviour
{
    public float vPlayerMoveSpeed;
    public float vPlayerTurnSpeed;
    public float vPlayerTurnSpeedMouse;
    public bool fGameStart;
    public bool fGameEnd;
    [SerializeField] float vFor;
    [SerializeField] float vSide;
    [SerializeField] sIceWallSpell sIceWallSpell;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

      
        transform.rotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {

        

        if (fGameStart && !fGameEnd)
        {


            if (!sIceWallSpell.fIceWall)
            {

                pMoveForward();
            }
            
            pTurn();

           

        }



    }

    void pMoveForward()
    {
        vFor = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * vPlayerMoveSpeed * vFor *Time.deltaTime);


    }

    void pTurn()
    {

        vSide = Input.GetAxis("Horizontal")* vPlayerTurnSpeed;
        vSide = vSide + Input.GetAxis("MouseX") * vPlayerTurnSpeedMouse;
        transform.Rotate(new Vector3(0, vSide *Time.deltaTime , 0));



    }


}
