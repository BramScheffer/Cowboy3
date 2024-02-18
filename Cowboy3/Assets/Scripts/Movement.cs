using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float hor;
    public float vert;
    public float speed;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        dir = new Vector3(hor, 0f, vert);
        transform.Translate(dir * Time.deltaTime * speed);
    }
}
