using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

	public	GameObject		alertSign;
	public	float			seekingDuration = 5f;
	public	float			speed = 3.5f;
	public	float			rotationSpeed = 5f;
	public	float			stopDistance = 1.5f;
	public 	float			waitDuration = 1f;
	public	float			stuntDuration = 2f;
	public	float			shootInterval = 1f;
	public 	Transform		path;
	public 	Transform 		target;
	public 	Weapon 			weapon;

	private	int				waypointIndex = 0;
	private	bool			isMoving;
	private bool			inRange;
	private bool			canSee;
	private	bool			isAlerted;
	private	bool			isStunned = false;
	private bool			hasLost = true;
	private float			timer;
	private float			waitTimer;
	private float			stunnedTimer;
	private float			sightRange;

	private NavMeshAgent 	agent;
	private Animator		animator;
	private EnemyManager	enemyManager;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();
		enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
		sightRange = GetComponent<SphereCollider>().radius;

		agent.speed = speed;
		agent.angularSpeed = rotationSpeed;
		agent.stoppingDistance = (stopDistance);
		timer = seekingDuration;
		weapon.equip(
			transform.GetChild(transform.childCount - 1).GetComponent<SpriteRenderer>(),
			transform.GetChild(transform.childCount - 1).GetComponent<Weapon>()
		);
	}
	
	void FixedUpdate () {

		if (Input.GetKeyDown(KeyCode.T)){
			alert();
		}

		if (Input.GetKeyDown(KeyCode.Y)){
			stunt();
		}

		if (target){
			canSee = checkVisibility(target);
			hasLost = (inRange && canSee) ? false : true;
			timer = (hasLost) ? (timer + Time.deltaTime) : 0f;

			
			//Ennemi avance tant qu'il est à une certaine distance de la target
			if (timer < seekingDuration || isAlerted){
				if (!isStunned){
					agent.isStopped = false;
					alertSign.SetActive(true);
					if (isAlerted && !hasLost){
						isAlerted = false;
					}

					if (Vector3.Distance(transform.position, target.position)> stopDistance){
						agent.SetDestination(target.position);
					}
					transform.GetChild(transform.childCount - 1).GetComponent<Weapon>().EnemyShoot();
				} else {
					agent.isStopped = true;
				
					stunnedTimer += Time.deltaTime;

					if (stunnedTimer >= stuntDuration){
						isStunned = false;
						stunnedTimer = 0f;
					}
				}
			} else {
				alertSign.SetActive(false);
				
				//Parcourt un chemin si il existe
				if (path && path.childCount > 0){
					Transform waypoint = path.GetChild(waypointIndex).transform;

					//Ennemi avance tant qu'il est à une certaine distance de son prochain waypoint
					if (Vector3.Distance(transform.position, waypoint.position) > stopDistance){
						agent.SetDestination(waypoint.position);
					} else {
						//L'agent est stoppé tant que son temps d'attente n'est pas dépassé
						agent.isStopped = true;
						waitTimer += Time.deltaTime;
						
						//Set d'un nouveau waypoint et réinitialisation du temps d'attente
						if (waitTimer >= waitDuration){
							waitTimer = 0f;
							waypointIndex++;
							agent.isStopped = false;
							if (waypointIndex >= path.childCount){
								waypointIndex = 0;
							}
						}
					}
				}
			}
		}

		//Check si le personnage est en mouvement basé sur sa vitesse
		isMoving = (agent.velocity.magnitude >= 0.1f) ? true : false;

		if (isMoving){
			transform.rotation = rotateToward();
		}

		//Setting walking animation
		animator.SetBool("isMoving" , isMoving);
	}

	//Check si l'ennemi peut voir la cible
	bool checkVisibility(Transform obj) {
		RaycastHit hit;
		
		//Lance un rayon vers destination, retourne true si pas d'obstacle rencontré
		if (Physics.Raycast(transform.position, (obj.position - transform.position), out hit, sightRange)){
			if (hit.transform == obj){
				return true;
			}
		}
		return false;
	}

	//Rotation du sprite
	Quaternion rotateToward(){
		Vector3 direction = new Vector3(agent.velocity.x, 0, agent.velocity.z);
		Quaternion rotation = Quaternion.LookRotation(direction);

		return Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
	}


	public void setTarget(Transform t){
		target = t;
	}

	public void dead() {
        SoundManager.manager.EnemyDieSound();
		enemyManager.updateEnemyCount();
		Destroy(transform.parent.gameObject);
	}

	public void stunt(){
		if (!isStunned){
			isStunned = true;
		}
	}

	public void alert(){
		if (!isAlerted){
			isAlerted = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player" && col.transform == target){
			inRange = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player" && col.transform == target){
			inRange = false;
		}
	}

}
