using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

    private LineRenderer lr;
    private SpriteRenderer sr;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                Vector3 temp = hit.point;
                Vector3 temp2 = Vector3.Lerp(lr.GetPosition(1), temp, 0.2f);

                lr.SetPosition(1, temp2);
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }
}
