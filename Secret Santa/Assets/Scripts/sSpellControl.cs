using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class sSpellControl : MonoBehaviour
{
    public float vMana;
    public float vMaxMana;
    [SerializeField] float vManaRecovery;
    [SerializeField] Image tMana;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(vMana < vMaxMana)
        {
            vMana = vMana+ vManaRecovery * Time.deltaTime;

        }

        tMana.color = new Color(0,0,(vMana  / vMaxMana), 1);

    }
}
