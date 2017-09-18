using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlienInvasion
{
    public class CreateRain : MonoBehaviour
    {
        public GameObject alien;
        public int NumOfBlobs = 10;
        public float KillHeight;
        public float xMax, xMin, zMax, zMin;
        public float RainSpeed;

		public List<BlobControl> Blobs = new List<BlobControl>();
        public Plane[] Planes;

        // Use this for initialization
        void Start()
        {
            // Hide the template object
            this.alien.SetActive(false);
            Planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            StartCoroutine("CreateInitialBlobs");
        }

        public void CreateBlob()
        {
            //generate random position
			float x = Random.Range(Camera.main.transform.position.x + xMin, Camera.main.transform.position.x +xMax);
			float z = Random.Range(Camera.main.transform.position.z +zMin, Camera.main.transform.position.z +zMax);
			float y = Random.Range(KillHeight, transform.position.y);

            GameObject o = (GameObject)Instantiate(alien, new Vector3(x, y, z), Quaternion.identity);
            o.transform.parent = this.transform;
            o.SetActive(true);
            var kb = o.GetComponent<BlobControl>();
            Blobs.Add(kb);
            kb.Setup(this, KillHeight, RainSpeed);
            o.transform.rotation = Random.rotation;
        }

        IEnumerator CreateInitialBlobs()
        {
            //divide by 100
            int chunk = NumOfBlobs / 50;
            if (chunk == 0)
                chunk = 1;
            int rounds = NumOfBlobs / chunk;

            for (int j = 0; j < rounds; j++)
            {
                for (int i = 0; i < chunk; i++)
                {
                    CreateBlob();
                }
                yield return new WaitForEndOfFrame();
            }
                             
        }

		void Update()
		{
			foreach (var b in Blobs) 
			{
				UpdateTransformsOutOfBounds(b.transform);
			}
		}

		void UpdateTransformsOutOfBounds(Transform t)
		{
			//get camera position
			Vector3 camPos = Camera.main.transform.position;

			//check all bounds
			Vector3 newPos = t.position;

			if(t.position.x > xMax + camPos.x)
			{
				newPos.x = xMin + camPos.x;
			}
			if(t.position.x < xMin + camPos.x)
			{
				newPos.x = xMax + camPos.x;
			}

			if(t.position.z > zMax + camPos.z)
			{
				newPos.z = zMin + camPos.z;
			}
			if(t.position.z < zMin + camPos.z)
			{
				newPos.z = zMax + camPos.z;
			}
			t.position = newPos;
		}

        public void ResetBlob(BlobControl bc)
        {
            //generate random position
            float x = Random.Range(Camera.main.transform.position.x + xMin, Camera.main.transform.position.x + xMax);
            float z = Random.Range(Camera.main.transform.position.z + zMin, Camera.main.transform.position.z + zMax);

            bc.transform.position = new Vector3(x, transform.position.y, z);

            //foreach(var r in bc.Rends)
            //{
            //    r.material.SetFloat("_SquashValue", 100.0f);
            //}
        }
    }
}
