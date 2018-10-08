using UnityEngine;

public class TriggeredScript : MonoBehaviour {

    private GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") {
            playerMovement.AddScore(1);
        }
    }
}
