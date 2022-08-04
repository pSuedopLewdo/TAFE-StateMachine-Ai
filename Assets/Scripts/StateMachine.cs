using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Aware,
        Chase,
        Flee,
        Sleep,
    }

    [SerializeField] private State _state;
    private AiAgent _aiAgent;

    // Start is called before the first frame update
    private void Start()
    {
        _aiAgent = GetComponent<AiAgent>();

        NextState();
    }

    private void NextState()
    {
        switch(_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chase:
                StartCoroutine(ChaseState());
                break;
            default:
                break;
        }
    }

    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        while (_state == State.Patrol)
        {
            _aiAgent.Patrol();
            yield return null;
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == State.Chase)
        {
            _aiAgent.ChasePlayer();
            yield return null;
        }
        Debug.Log("Chase: Exit");
    }


    private void Update()
    {
        
    }
}
