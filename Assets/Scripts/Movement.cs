using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform tr;
    public CharacterController chr;
    float pspeed = 5f;
    public AudioSource aud;
    public Light flash;
    public AudioSource flashaud;
    public Text txt;
    public int notecount = 0;
    public Text stamina;
    float last;
    float stam = 100f;
    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        //escape game
        if (Input.GetKey(KeyCode.Escape))
        {
            txt.text = "Exiting...";
            Application.Quit(0);
        }

        //sprinting
        if (Input.GetKey(KeyCode.LeftShift) && stam > 0)
        {
            pspeed = 10f;
            aud.pitch = 1.5f;
            stam -= 15*Time.deltaTime;
        }
        else
        {
            if (stam < 100)
            {
                stam +=10*Time.deltaTime;
            }
            pspeed = 5f;
            aud.pitch = 1f;
        }
        stamina.text = "Stamina: " + Mathf.Round(stam);
        //flashlight
        if (Input.GetKey(KeyCode.Mouse0) && flash.intensity == 0 && last > .5f)
        {
            last = 0;
            flashaud.time = .5f;
            flashaud.Play();
            flash.intensity = 1;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && last > .5f)
        {
            last = 0;
            flashaud.time = .5f;
            flashaud.Play();
            flash.intensity = 0;
        }
        last+=Time.deltaTime;

        //movement
        move = Input.GetAxis("Horizontal")*tr.right + Input.GetAxis("Vertical")*tr.forward;
        sounds(move);
        chr.Move(move*Time.deltaTime*pspeed);
        chr.Move(new Vector3(0f,-9.8f*Time.deltaTime,0f));
    }

    void sounds(Vector3 move)
    {
        float sum = move.x + move.y;
        if (sum!=0f)
        {
            aud.volume = 1;
        }
        else
        {
            aud.volume = 0;
        }
    }
}
