using UnityEngine;

public static class Extensions
{
    public static LayerMask layerMask = LayerMask.GetMask("Default");

    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic) {
            return false;
        }
        float radius = 0.25f;
        float distanse = 0.375f;
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distanse, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

//  смотрим с какой стороны у нас блок, если сверху то true иначе false
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirectional)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirectional) > 0.7f; 
        //normalized нужен чтобы вектор сделать от 0 до 1 
    }
}