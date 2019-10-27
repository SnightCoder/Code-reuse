using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public List<ParticleCollisionEvent> collisionEvent;
    public Gradient particleColorGradient;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvent=new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other) {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher,other,collisionEvent);
        for(int i=0;i<collisionEvent.Count;i++){
          EmitAtLocation(collisionEvent[i]);
        }
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent){
        splatterParticles.transform.position=particleCollisionEvent.intersection;
        splatterParticles.transform.rotation=Quaternion.LookRotation(particleCollisionEvent.normal);

            //ParticleSystem.MainModule   psMain=splatterParticles.main;
           // psMain.startColor=particleColorGradient.Evaluate(Random.Range(0,1));
           splatterParticles.startColor=particleColorGradient.Evaluate(Random.Range(0,1));

        splatterParticles.Emit(1);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))    {
            ParticleSystem.MainModule   psMain=particleLauncher.main;
            psMain.startColor=particleColorGradient.Evaluate(Random.Range(0,1));
        particleLauncher.Emit(1);
        }
    }
}
