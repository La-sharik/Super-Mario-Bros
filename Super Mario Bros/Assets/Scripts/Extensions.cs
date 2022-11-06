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
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction, distanse, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }
}