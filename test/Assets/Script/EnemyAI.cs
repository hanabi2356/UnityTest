using UnityEngine;
using System.Collections;
public enum State
{
    Idle, Chase, Attack, Die
}

public class EnemyAI : MonoBehaviour
{
    public Transform Target;

    private EnemyStats stats;
    private State currentState = State.Idle;

    private Vector3 direction;
    private float distance;
    void Start()
    {
        stats = GetComponent<EnemyStats>();

        //처음 시작할 코루틴
        StartCoroutine(Idle());
    }

    void Update()
    {
        direction = Target.position - transform.position;
        distance = Vector3.Magnitude(direction);
        if( currentState == State.Die )
        {
            Debug.Log("Die");
        }
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Cahse());

    }

    IEnumerator Cahse()
    {
        currentState = State.Chase;
        transform.LookAt(Target.position);
        Vector3 temppos = transform.position;
        temppos.x = Mathf.Lerp(temppos.x, direction.x, stats.moveSpeed*Time.deltaTime);
        temppos.z = Mathf.Lerp(temppos.x, direction.x, stats.moveSpeed * Time.deltaTime);
        transform.position = temppos;
        if(stats.AttackRange >=distance)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        currentState= State.Attack;
        Debug.Log("Attack");
        if(distance>=stats.AttackRange)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Cahse());
        }


    }
    void EnemyDie()
    {
        currentState = State.Die;
    }
}
