using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public GameObject pilot;
    public GameObject pilotBounds;
    
/*
    public bool inWindZone = false;
    public GameObject windZone;
*/

    public static float speed = 20f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    bool isRotated = true;

    Rigidbody rb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKey(KeyCode.Space))
        {
            controller.Move(Vector3.up * speed * Time.deltaTime);
            pilotBounds.transform.position = pilot.transform.position;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(Vector3.down * speed * Time.deltaTime);
            pilotBounds.transform.position = pilot.transform.position;
        }


        if (direction.magnitude >= 0.1f)
            {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            pilotBounds.transform.position = pilot.transform.position;

            isRotated = false;

        }
        else
        {
            if (!isRotated)
            {
 //               pilot.transform.Rotate(-90f, 0f, 0f, Space.World);
                isRotated = true;
            }
           
        }

      

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    

    // Functions below would be used when dealing with a rigid body pilot

    /*
        private void FixedUpdate()
        {
            if (inWindZone)
            {
                rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
            }
        }


        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "windArea")
            {
                windZone = coll.gameObject;
                inWindZone = true;
            }
        }

        void OnTriggerExit(Collider coll)
        {
            if (coll.gameObject.tag == "windArea")
            {
                inWindZone = false;
            }
        }
    */


}
