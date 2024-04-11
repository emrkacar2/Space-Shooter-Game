using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;
    Rigidbody physic;
    AudioSource audioPlayer;
    public float xMin, xMax, zMin, zMax;
    public GameObject shot;
    public GameObject shotSpawn;
     void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>(); 
    }
    
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play();
        }
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        physic.velocity = movement * speed;
        Vector3 position = new Vector3(
        Mathf.Clamp(physic.position.x, xMin, xMax),
            0,
            Mathf.Clamp(physic.position.z, zMin, zMax));
        physic.position = position;

        physic.rotation = Quaternion.Euler(0,0,physic.velocity.x*tilt);
           
    }

}
