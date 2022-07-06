using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

	public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;
	public State remainState;
	public State chaseState; //reference variable to chasing state

	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public TankShooting tankShooting;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;

	private bool aiActive;

	// For Color Changing

	public Material[] material;
	Renderer rend; //reference to renderer
	Transform tankRenderer; //reference variable to the TankRenderer game object in the Chaser and Patroller Tank


	void Awake () 
	{
		tankShooting = GetComponent<TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
	{
		wayPointList = wayPointsFromTankManager;
		aiActive = aiActivationFromTankManager;
		if (aiActive) 
		{
			navMeshAgent.enabled = true;
		} else 
		{
			navMeshAgent.enabled = false;
		}
	}

	public void TransitionToState(State nextState)
	{
		if (nextState == remainState) return;
		//if nextState is chasing state
		if (nextState == chaseState)
        {
			changeColorChase(); //change color to chase color
        }
        else
        {
			changeColorNormal(); //change color back to normal
		}
		currentState = nextState;
		OnExitState();
	}

	public bool CheckIfCountDownElapsed(float duration)
	{
		stateTimeElapsed += Time.deltaTime;
		return stateTimeElapsed >= duration;
	}

	void Update()
	{
		if (!aiActive) return;

		currentState.UpdateState(this);
	}

	void OnExitState()
	{
		stateTimeElapsed = 0;
	}

	void OnDrawGizmos()
	{
		if (currentState != null && eyes != null)
		{
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
		}
	}

	//function to change color when chasing
	void changeColorChase()
	{
		tankRenderer = this.transform.GetChild(0); //get the "TankRenderer" game object in the tank prefab
		foreach (Transform child in tankRenderer)
		{ // for each child of the tankRenderer
			rend = child.GetComponent<Renderer>(); //get renderer of each child
			rend.enabled = true; //set the enabled to true
			rend.sharedMaterial = material[1]; //set to the second/alt material set in the Inspector for the Chase Color
		}
	}

	//function to change color back to normal
	void changeColorNormal()
	{
		tankRenderer = this.transform.GetChild(0); //get the "TankRenderer" game object in the tank prefab
		foreach (Transform child in tankRenderer)
		{ // for each child of the tankRenderer
			rend = child.GetComponent<Renderer>(); //get renderer of each child
			rend.enabled = true; //set the enabled to true
			rend.sharedMaterial = material[0]; //set to the first material set in the Inspector (normal color)
		}
	}
}