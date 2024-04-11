using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    private Transform PlayerCamera;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    public void Shoot()
    {
        //een new Ray betekend dat we een starting punt kunnen vastleggen 
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        //als de gunray iets raakt binnen de bullet range
        //out houd informatie over wat de ray heeft gehit en de hit info stored the information
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            //checkt of het object dat geraakt is een bepaald component heeft dat entity heet en damage kan opnemen.
            if (hitInfo.collider.gameObject.TryGetComponent (out Entity enemy)) 
            {
                enemy.Health -= damage;
            }
        }
    }
}
