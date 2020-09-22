﻿using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;
        public HealthBar healthBar;
        public GameObject parent;
        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;


        //Variables
        public static float MaxHealth = 0.8f;
        public static float Health = 0.8f;
        public float EnemyHealth = 0.8f;
        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            
            healthBar.setMaxHealth(Health);
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
                
                
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector2 dir = collision.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
                // We then get the opposite (-Vector3) and normalize it
                dir = dir.normalized;
                Rigidbody2D rbb = collision.gameObject.GetComponent<Rigidbody2D>();
                PlayerController1.doActive = false;
                rbb.AddForce(dir * 600, ForceMode2D.Impulse);
                GameManager.TakeDamage(0.1f);
                
                PlayerController1.doActive = true;
                /*playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);*/
            }


        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("projectile"))
            {
                if (EnemyHealth - 0.2f <= 0)
                {
                    gameObject.SetActive(false);
                    EnemyHealth = 0f;
                    parent.GetComponent<AIPath>().enabled = false;
                    GameManager.AddEnergy(0.25f);
                }
                else
                {
                    EnemyHealth -= 0.2f;
                }
                Destroy(other.gameObject);
                
            }
            if (other.gameObject.CompareTag("melee"))
            {

                if (EnemyHealth - 0.1f <= 0)
                {
                    EnemyHealth = 0;
                    gameObject.SetActive(false);
                    parent.GetComponent<AIPath>().enabled = false;
                    GameManager.AddEnergy(0.25f);

                }
                else
                    EnemyHealth -= 0.1f;
                
            }
        }
        void Update()
        {
            Health = EnemyHealth;
            healthBar.setHealth(Health);
            if (path != null)
            {
                if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            }
            if (EnemyHealth <= 0)
                parent.GetComponent<AIPath>().enabled = false;
            
           
        }

    }
}