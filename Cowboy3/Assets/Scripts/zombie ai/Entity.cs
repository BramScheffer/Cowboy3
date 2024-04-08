using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    private ScoreManager scoreManager;
    public int scoreValue;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
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

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.IncrementScore(scoreValue);
        }
    }
}
