using UnityEngine;
using System.Collections;

public class FiringScriptEnemy : MonoBehaviour 
	{
		//--------------------------------
		// 1 - Designer variables
		//--------------------------------

		/// Projectile prefab for shooting
		public Transform shotPrefabLeft;
		public Transform shotPrefabRight;
		public Transform firingPoint;
		private Transform shotTransform;


		/// Cooldown in seconds between two shots
		public float shootingRate = 1f;

		//--------------------------------
		// 2 - Cooldown
		//--------------------------------

		private float shootCooldown;

		void Start()
		{
			shootCooldown = 0f;
		}

	void Update()
		{
			if (shootCooldown > 0)
			{
				shootCooldown -= Time.deltaTime;
			}

		if (CanAttack) {
			var playerScript = GameObject.FindWithTag ("Enemy").GetComponent<EnemyMovenemt>();
			shootCooldown = shootingRate;

			if (playerScript.facingRight) {
				// Create a new shot
				shotTransform = Instantiate (shotPrefabRight) as Transform;
			} else if (!playerScript.facingRight) {shotTransform = Instantiate (shotPrefabLeft) as Transform;
			}

			shotTransform.position = firingPoint.transform.position;  //transform.position;

			// The is enemy property

		}

		}

		
		public void Attack(bool isEnemy)
	{
		
	}




				
		public bool CanAttack
		{
			get
			{
				return shootCooldown <= 0f;
			}
		}
	}
