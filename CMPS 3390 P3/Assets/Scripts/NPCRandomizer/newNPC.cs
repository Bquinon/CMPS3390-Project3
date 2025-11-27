using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class newNPC : MonoBehaviour
{
    public bool leave;
    public bool accepted;

    void moveRight()
    {
        transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime;
    }
    void Start()
    {
        leave = false;
        accepted = false;
    }

    void Update()
    {
        // reset NPC
        if (transform.position.x <= -15f || transform.position.x >= 15f)
        {
            transform.position = new Vector3(-10f, 1.5f, -4f);
            leave = false;
            accepted = false;
            // randomize new NPC ()
        }

        // move NPC to the right when NPC is entering
        if (transform.position.x < -3.25 && leave == false) { moveRight(); }    

        // waiting for player response
        if (transform.position.x >= -3.25 && transform.position.x <= -2.75)
        {
            // insert code for player logic
            //
            // structure_pass = ? monitor.structure == id.structure == NPC.structure
            // face_pass = ? monitor.face == id.face == NPC.face
            // hair_pass = ? monitor.hair == id.hair == NPC.hair
            // accessory_pass = ? monitor.accessory == id.accessory == NPC.accessory
            // expiration_pass = ? monitor.expiration == id.expiration == calendar.expiration
            // logo_pass = ? id.logo == environment.logo
            //
            // (structure_pass == face_pass == hair_pass == accessory_pass == expiration_pass == logo_pass) ? True -> accpeted = True
            //     else leave = True

            // do nothing if player hasn't responded
            if (leave == false == accepted) { return; }

            // NPC leaves
            if (leave == true) { transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime; }

            // NPC is accepted
            if (accepted == true) { moveRight();  }

        }
        
    }
}
