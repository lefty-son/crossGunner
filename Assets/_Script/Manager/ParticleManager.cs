using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
    public static ParticleManager instance;


    private readonly int PARTICLE_LENGTH = 20;
    [SerializeField]
    private int index;
    public ParticleSystem particle;
    private List<ParticleSystem> poolParticle;

    private void Awake()
    {
        if (instance == null) instance = this;

        poolParticle = new List<ParticleSystem>();
        index = 0;
        MakePool();
    }

    private void MakePool(){
        for (int i = 0; i < PARTICLE_LENGTH; i++){
            poolParticle.Add(Instantiate(particle));
        }
        MoveToVoid();
    }

    private void MoveToVoid(){
        for (int i = 0; i < PARTICLE_LENGTH; i++){
            poolParticle[i].transform.position = Vector3.zero;
            poolParticle[i].gameObject.SetActive(false);
        }
    }

    private ParticleSystem PopParticleFromPool(){
        var i = index % PARTICLE_LENGTH;
        if (poolParticle[i].gameObject.activeInHierarchy)
        {
            index++;
            PopParticleFromPool();
        }
        return poolParticle[index % PARTICLE_LENGTH];
    }

    public void PutParticleOnEnemy(Transform _transform){
        var ps = PopParticleFromPool();
        ps.transform.position = _transform.position;
        ps.gameObject.SetActive(true);
        ps.randomSeed = (uint)Random.Range(0, 999999);
        ps.Simulate(0, true, true);
        ps.Emit(15);
    }
}
