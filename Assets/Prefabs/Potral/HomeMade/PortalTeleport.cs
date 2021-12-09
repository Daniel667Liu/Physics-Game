using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform reciever;

    public bool playerIsOverlapping = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsOverlapping)
        {
            

/*            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log("dotProduct: "+ dotProduct);
            Debug.Log(dotProduct);
            if (dotProduct<0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                Debug.Log("rotationDiff:"+rotationDiff);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }*/
            player.position = reciever.position;
            playerIsOverlapping = false;
        }
    }
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag=="Player")
        {
            playerIsOverlapping = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
