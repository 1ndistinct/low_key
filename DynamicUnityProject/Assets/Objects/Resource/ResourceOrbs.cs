using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceOrbs : MonoBehaviour
{
    private Transform player;
    private Transform particleEmitter;
    public ParticleSystem.Particle[] particles;
    float ForceToAdd;
    float max = 40f, speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        particleEmitter = gameObject.GetComponent<Transform>();
        player = GameObject.Find("Mr.AlienMain").GetComponent<Transform>();
        //particles = new ParticleSystem.Particle[particleEmitter.particleCount];
    }

    // Update is called once per frame
    void Update()
    {

            if (speed <= max)
            {
                speed+=0.02f;
            }
        
        particleEmitter.position = Vector3.MoveTowards( particleEmitter.position, player.transform.position, Time.deltaTime * speed);
        /*particles = new ParticleSystem.Particle[particleEmitter.particleCount];
        particleEmitter.GetParticles(particles);
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].position = Vector3.MoveTowards(player.transform.position,particles[i].position , Time.deltaTime * 1);
        }

        particleEmitter.SetParticles(particles, particles.Length);
        // Reassign back to emitter*/

    }


}
