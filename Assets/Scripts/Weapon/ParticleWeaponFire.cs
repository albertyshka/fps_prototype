using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeaponFire : WeaponFire
{
	[SerializeField] private BuffProvider _buffProvider;
	[SerializeField] private ParticleSystem _particleSystem;
	[SerializeField] private string _enemyTag;

	public override void Fire()
	{
        _particleSystem.Play();
    }

	/*private void OnTrigger()
	{
		if (other.tag == _enemyTag)
		{
			var statsHolder = other.transform.root.GetComponent<NpcStatController>() as INpcStatsHolder;
			_buffProvider.ApplyBuff(statsHolder);
		}

		Destroy(this.gameObject);
	}*/

	void OnParticleTrigger()
    {
        Debug.LogError($"ParticleWeaponFire");

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        // get
        int numEnter = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 0, 0, 255);
            enter[i] = p;
        }
        for (int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            p.startColor = new Color32(0, 255, 0, 255);
            exit[i] = p;
        }

        // set
        _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}
