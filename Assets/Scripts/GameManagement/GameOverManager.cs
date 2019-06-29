using UnityEngine;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        PlayerController playerController;       // Reference to the player's health.


        Animator anim;                          // Reference to the animator component.


        void Awake ()
        {

            playerController = playerController = FindObjectOfType<PlayerController>();
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            // If the player has run out of health...
            if(playerController.isDead)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger ("GameOver");
            }
        }
    }
}