using UnityEngine;

public class SpawnGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // only allows rotation of the Y axis
        if (transform.eulerAngles.x != 0 || transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        Gizmos.matrix = this.transform.localToWorldMatrix;

        Gizmos.color = Color.red;
        Gizmos.DrawCube(Vector3.zero, new Vector3(0.6f, 2.0f, 0.4f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(Vector3.zero + new Vector3(0.0f, 0.0f, 0.55f), new Vector3(0.075f, 0.075f, 0.7f));
        Gizmos.DrawSphere(Vector3.zero + new Vector3(0.0f, 0.0f, 1.0f), 0.06f);

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + transform.forward * 1.0f;

        DrawArrowEnd(startPosition, endPosition);
    }

    private void DrawArrowEnd(Vector3 start, Vector3 end)
    {
        float arrowHeadLength = 0.2f;
        float arrowHeadWidth = 0.05f;
        float arrowHeadThickness = 0.05f;

        Vector3 direction = (end - start).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Calculates positions for the rectangular shapes of the arrowhead
        Vector3 right = rotation * Quaternion.Euler(0, 180 + 45, 0) * new Vector3(0, 0, arrowHeadLength);
        Vector3 left = rotation * Quaternion.Euler(0, 180 - 45, 0) * new Vector3(0, 0, arrowHeadLength);
        Vector3 up = rotation * Quaternion.Euler(180 + 45, 0, 0) * new Vector3(0, 0, arrowHeadLength);
        Vector3 down = rotation * Quaternion.Euler(180 - 45, 0, 0) * new Vector3(0, 0, arrowHeadLength);

        // Draws each side of the arrowhead
        DrawArrowRectangle(end, right, arrowHeadWidth, arrowHeadThickness);
        DrawArrowRectangle(end, left, arrowHeadWidth, arrowHeadThickness);
        DrawArrowRectangle(end, up, arrowHeadWidth, arrowHeadThickness);
        DrawArrowRectangle(end, down, arrowHeadWidth, arrowHeadThickness);
    }

    private void DrawArrowRectangle(Vector3 end, Vector3 direction, float width, float thickness)
    {
        Vector3 position = end + direction * 1.1f;
        Gizmos.matrix = Matrix4x4.TRS(position, Quaternion.LookRotation(direction), new Vector3(thickness, width, direction.magnitude));
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }






}
