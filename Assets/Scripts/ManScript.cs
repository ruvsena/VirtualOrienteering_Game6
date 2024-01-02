using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform plrpos;
    public GameObject man;
    public AudioSource aud;
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(plrpos.position,plrpos.forward);
        float sum = Mathf.Abs((plrpos.position - man.GetComponent<Transform>().position).magnitude);
        string collided = "";
        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            collided = hit.collider.gameObject.name;
        }
        if (collided == "Mesh1" && sum < 15)
        {
            aud.Play();
            this.enabled = false;
            Destroy(man);
            print("Dead");
        }
    }
}
