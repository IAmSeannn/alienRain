using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TotalBlobs : MonoBehaviour {

    Text text;
    public AlienInvasion.CreateRain _CreateRain;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        text.text = _CreateRain.NumOfBlobs.ToString();
	}
}
