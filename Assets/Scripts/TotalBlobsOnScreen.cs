using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TotalBlobsOnScreen : MonoBehaviour {

    Text text;
    public AlienInvasion.CreateRain _CreateRain;
    public float UpdateRate = 0.5f;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

        InvokeRepeating("UpdateText", 1.0f, UpdateRate);
    }

    void UpdateText()
    {
        int i = 0;
        Plane[] planes;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        foreach (var kb in _CreateRain.Blobs)
        {
            if (GeometryUtility.TestPlanesAABB(planes, kb.ren.bounds))
            {
                ++i;
            }
        }
        
        text.text = i.ToString();
    }
}
