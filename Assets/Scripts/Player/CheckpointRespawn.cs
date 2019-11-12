using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Player
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(Rigidbody))]
    public class CheckpointRespawn : MonoBehaviour
    {
        private Transform lastCheckpoint;
        private Rigidbody rb;
        private PlayerController pc;

        // Start is called before the first frame update
        void Start()
        {
            lastCheckpoint = transform;
            rb = GetComponent <Rigidbody>();
            pc = GetComponent<PlayerController>();            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RespawnPlayer()
        {
            Vector3 savedVelocity = rb.velocity;
            rb.isKinematic = true;
            transform.position = lastCheckpoint.transform.position;
            transform.rotation = lastCheckpoint.transform.rotation;
            rb.isKinematic = false;
            savedVelocity.Scale(transform.rotation.eulerAngles.normalized);
            rb.velocity = savedVelocity;

            pc.anim.TriggerState(AnimationManager.states.Lose);
            pc.playerVoice.TriggerVoiceEffect(PlayerVoiceManager.Emotion.Sad);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                lastCheckpoint = other.gameObject.transform.parent.transform;
             
            }
            else if (other.CompareTag("Respawn"))
            {
                RespawnPlayer();
            }
            else if (other.CompareTag("FinishLine"))
            {
                pc.EndRacing();
            }

        }
    }
}

