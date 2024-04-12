using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //serialize field is dat je het niet kan aanpassen tijdens de game
    [SerializeField] private float StartingHealth;
    private ScoreManager scoreManager;
    public int scoreValue;
    //health word gebruikt in dit script
    private float health;
    //Health word gebruikt om in andere scripts te referencen voor andere scripts
    public float Health
    {
        // get krijgt de info
        get
        {
            //geeft aan welke waarde moet worden teruggegeven wanneer de eigenschap wordt aangesproken aan het script
            return health;
        }
        //set veranderd de info
        set
        {
            //moet het gebruiken om de nieuwe waarde toe te wijzen aan de eigenschap binnen de set accessor
            health = value;
            Debug.Log(health);

            if (health <= 0f) 
            {
                Destroy(gameObject);
            }

        }
    }
    
    
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        Health = StartingHealth;
    }


    public void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.IncrementScore(scoreValue);
        }
    }
}
