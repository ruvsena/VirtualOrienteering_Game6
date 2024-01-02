using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickUpNotes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform tr;
    public Transform cam;
    public MeshRenderer mr;
    public MeshRenderer mr2;
    public AudioSource aud;
    public Text txt;
    public Text press;
    public Text notecount;
    public RectTransform panel;
    public Text wintxt;
    public Canvas btn;
    public Canvas canvass;
    public GameObject obj;
    public GameObject flash;
    int parsednotecount = 0;
    // Update is called once per frame
    void Update()
    {
        float sum = Mathf.Abs((tr.position - transform.position).magnitude);
        Ray ray = new Ray(cam.position,cam.forward);
        string collided = "";

        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            collided = hit.collider.gameObject.name;
        }
        if (sum < 4f && Input.GetKey(KeyCode.E) && collided == "rust_key")
        {
            press.enabled = false;
            aud.Play();
            mr.enabled = false;
            mr2.enabled = false;
            this.enabled = false;
            parsednotecount = int.Parse(notecount.text);
            parsednotecount += 1;
            notecount.text = parsednotecount.ToString();
            txt.text = "Scores: "+notecount.text+"/8";
            if (parsednotecount == 8)
            {
                panel.localScale = new Vector3(1,1,1);
                wintxt.enabled = true;
                btn.enabled = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                canvass.enabled = false;
                obj.GetComponent<ReturntoMen>().enabled = true;
                obj.GetComponent<AudioSource>().enabled = false;
                flash.GetComponent<AudioSource>().enabled = false;
            }
        }
        else if (sum < 5f && collided == "rust_key")
        {
            press.enabled = true;
        }
        else if (collided != "rust_key")
        {
            press.enabled = false;
        }
    }
}
