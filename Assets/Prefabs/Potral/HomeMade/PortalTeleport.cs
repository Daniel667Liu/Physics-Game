using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform reciever;

    public GameObject[] Solar1DisappearPlanets;
    public GameObject[] Solar2DisappearPlanets;

    public bool playerIsOverlapping = false;
    public GameObject BlackHole;
    void Start()
    {
        BlackHole = GameObject.FindGameObjectWithTag("BH");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsOverlapping)
        {
            if(this.name== "Round1Teleporter")
            {
                for (int i = 0; i < Solar2DisappearPlanets.Length; i++)
                {
                    Solar2DisappearPlanets[i].SetActive(true);
                }
                for (int j=0;j< Solar1DisappearPlanets.Length;j++)
                {
                    Solar1DisappearPlanets[j].SetActive(false);
                }
            }
            if (this.name == "PortalTeleporterWell")
            {
                for (int k = 0; k < Solar1DisappearPlanets.Length; k++)
                {
                    Solar1DisappearPlanets[k].SetActive(true);
                }
                for (int l = 0; l < Solar2DisappearPlanets.Length; l++)
                {
                    Solar2DisappearPlanets[l].SetActive(false);
                }

                //BlackHole.gameObject.GetComponent<BlackHole>().DESTROY = true;
            }
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
