using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision informationAboutWhatIHit)
    {
        if (informationAboutWhatIHit.gameObject.CompareTag("Player"))
        {
         pHealth.health -= damage;

        }
    }
}
