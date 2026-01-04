using Mono.Cecil;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class traceCamera : MonoBehaviour
{
    public Transform Target;
    float followSpeed = 5.0f;
    float offsetZ;
    void Start()
    {
        offsetZ = transform.position.z;
    }

    private void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 distance = Target.position - transform.position;
            Vector3 temppos  = transform.position;
            temppos.x = Mathf.Lerp(temppos.x, distance.x, followSpeed*Time.deltaTime);
            temppos.z = Mathf.Lerp(temppos.z, distance.z + offsetZ, followSpeed * Time.deltaTime);
            
            transform.position = temppos;
            
        }

    }



}
