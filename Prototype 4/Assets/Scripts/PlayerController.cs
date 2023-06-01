using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerUp;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
        }
        StartCoroutine(PowerupCountdownRoutine());
    }

    IEnumerator PowerupCountdownRoutine() 
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    public float powerUpstr = 15.0f;
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayFromPlayer = (collision.gameObject.transform.position-transform.position);
            Debug.Log("Collided with" + collision.gameObject.name + "with powerUp set to" + hasPowerUp);
            enemyRigidbody.AddForce(AwayFromPlayer * powerUpstr, ForceMode.Impulse);
        }
    }
}
