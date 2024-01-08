using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float speed;

    [SerializeField] private Transform camera_pos;
    [SerializeField] private GameObject focalPoint;

    private bool hasPowerup;

    private float power = 50f;

    

    //private float forwardInput;


    private float vertical;



    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hasPowerup = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        
        

        rb.AddForce(focalPoint.transform.forward * speed * vertical);

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdown());

        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && hasPowerup)
        {
            
            Rigidbody foeRb = collision.gameObject.GetComponent<Rigidbody>();
            
            Vector3 direction = (collision.transform.position - transform.position).normalized;


            foeRb.AddForce(direction * speed * power, ForceMode.Impulse);
            
            
            

        }
        
    }


    private IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(6);

        hasPowerup = false;
    }



}
