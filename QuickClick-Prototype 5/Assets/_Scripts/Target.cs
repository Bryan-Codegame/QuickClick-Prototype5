using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float maxForce = 17.0f, minForce = 15.0f;
    public float torque = 12.0f;
    public float xRange = 4;
    public float yStartSpawn = -5;

    [Range(-20, 20)]
    public int pointValue;

    private GameManager gameManager;
    public ParticleSystem particleExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        gameManager = FindObjectOfType<GameManager>();

        _rigidbody.AddForce(RandomForceDirection(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Generate a random vector
    /// <summary/>
    /// <returns>Upward random force <returns/>
    private Vector3 RandomForceDirection()
    {
        return Vector3.up*Random.Range(minForce, maxForce);
    }

    /// <summary>
    /// Generate a random torque
    /// <summary/>
    /// <returns> Random value between torque  <returns/>
    private float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    /// <summary>
    /// Generate a random vector
    /// <summary/>
    /// <retuns>Vector with random x position and y position to spawn <returns/>

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yStartSpawn);
    }

    private void OnMouseExit() 
    {
        Destroy(gameObject);
        Instantiate(particleExplosion, transform.position, particleExplosion.transform.rotation);
        gameManager.UpdateScore(pointValue);

        if (gameObject.CompareTag("Death"))
        {
            gameManager.GameOver();
        }    
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("KillerZone"))
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(-5);
            }
        }
    }
}
