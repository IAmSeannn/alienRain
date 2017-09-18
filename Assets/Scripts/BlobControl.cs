using UnityEngine;
using System.Collections;

public class BlobControl : MonoBehaviour {

    AlienInvasion.CreateRain _createRain;
    private float KillHeight;
    private float Speed;

    public Bounds ObjBounds;
    public Renderer[] Rends;
    public Renderer ren;

    public void Setup(AlienInvasion.CreateRain cr, float kh, float sp)
    {
        _createRain = cr;
        KillHeight = kh;
        Speed = sp;

        //remove 1 fifth
        float Flare = sp / 5;
        Speed = Speed - (Flare / 2);

        Speed = Speed + Random.Range(0, Flare);

        InvokeRepeating("CheckIfOOB", 0.0f, 0.1f);

        ren = GetComponent<Renderer>();
        if (ren == null)
            ren = GetComponentInChildren<Renderer>();

        ObjBounds = ren.bounds;

        Rends = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
		//move the blob downwards
        transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.World);

        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //if (pos.x < 0)
        //    _createRain.ResetBlob(this);
        //if (pos.x > 1)
        //    _createRain.ResetBlob(this);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void CheckIfOOB()
    {
        //check if blob should die
        if (transform.position.y <= KillHeight)
        {
            _createRain.ResetBlob(this);
        }
    }
}
