using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AiAgent))]
public class StateMachine : MonoBehaviour
{
    private enum State
    {
        Patrol,
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
        _aiAgent.Search();
        while(_state == State.Patrol)
        {
            _aiAgent.Patrol();
            if (_aiAgent.IsPlayerInRange())
            {
                _state = State.Chase;
            }
            yield return null;
        }
        NextState();
    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == State.Chase)
        {
            _aiAgent.ChasePlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            yield return null;
        }
        Debug.Log("Chase: Exit");
        NextState();
    }

    private void Update()
    {
        
    }
}
