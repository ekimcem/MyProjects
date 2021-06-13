using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableWall : MonoBehaviour
{
    public GameObject Brush;

    public PlayerController pc;
   
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Paint();
    }

   /* private void Paint()
    {
        if (Input.GetMouseButton(0))
        {

            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(Ray, out hit) && hit.transform.tag == "PaintableWall")
            {
                var go = Instantiate(Brush, hit.point - Vector3.forward * 0.01f, transform.rotation, transform);

            }

        }
    }*/
}
