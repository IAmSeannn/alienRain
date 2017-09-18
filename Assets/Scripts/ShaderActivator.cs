using UnityEngine;
using System.Collections;

public class ShaderActivator : MonoBehaviour {

    Renderer rend;
    bool Squashing = false;
    public bool ShouldOutput = false;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_Displacement", 1.0f + Random.value);
        rend.material.SetFloat("_Speed", 0.2f + Random.value);
    }

    void Update()
    {
        //if (transform.position.y < 10.0f && !Squashing)
        //{
        //    rend.material.SetFloat("_ShouldSquash", 1.0f);
        //}

        //if (Squashing && transform.position.y < 0.0f)
        //{
        //    rend.material.SetFloat("_ShouldSquash", 0.0f);
        //}

        //if(transform.position.y < 6.0f)
        //{
        //    if(transform.position.y < 0.1f)
        //    {
        //        rend.material.SetFloat("_SquashValue", 40.0f);
        //    }
        //    else
        //    {
        //        rend.material.SetFloat("_SquashValue", (transform.position.y+4.0f) * 10.0f);
        //    }
            

           
        //}

        if (ShouldOutput)
            Debug.Log("pos is :: " + transform.position);
    }
}
