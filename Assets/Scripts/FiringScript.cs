using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class FiringScript : MonoBehaviour
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
	}

	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------

	/// Create a new projectile if possible
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			var playerScript = GameObject.FindWithTag ("Player").GetComponent<PlatformerCharacter2D>();

				if (playerScript.m_FacingRight) {
				// Create a new shot
				shotTransform = Instantiate (shotPrefabRight) as Transform;
				} else if (!playerScript.m_FacingRight) {shotTransform = Instantiate (shotPrefabLeft) as Transform;
			}
				

			// Assign position
			shotTransform.position = firingPoint.transform.position;  //transform.position;

		}
	}

	/// Is the weapon ready to create a new projectile?
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
