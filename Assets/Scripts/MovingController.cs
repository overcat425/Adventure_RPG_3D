using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    public static void LookDirection(Transform transform, Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir.x * Vector3.right + dir.z * Vector3.forward);
    }

    public static void LookTarget(Transform transform, Transform targetTransform, float speed)
    {
        Vector3 dir = new Vector3(transform.position.x - targetTransform.transform.position.x, 0, transform.position.z - targetTransform.transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-dir), speed * Time.fixedDeltaTime);
    }

    public static void RigidMovePos(Transform transform, Vector3 dir, float speed)
    {
        transform.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(dir.x, 0, dir.z).normalized * speed * Time.fixedDeltaTime);
    }

    public static void LimitMoveRange(Transform transform, Vector3 minRange, Vector3 maxRange)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minRange.x, maxRange.x), transform.position.y, Mathf.Clamp(transform.position.z, minRange.z, maxRange.z));
    }
}
