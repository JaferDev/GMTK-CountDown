using UnityEngine;
public class Grapple : MonoBehaviour
{
    private LineRenderer lineR;
    private DistanceJoint2D distanceJ;
    [SerializeField] LayerMask grappleLayer;
    private bool isGrappling;
    private Vector3 point;

    private void Start()
    {
        lineR = GetComponent<LineRenderer>();
        distanceJ = GetComponent<DistanceJoint2D>();
        distanceJ.enabled = false;
        lineR.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Grappling();
        if (Input.GetMouseButtonUp(0)) StopGrapple();
        if (isGrappling) UpdateGrapple();
    }

    private void Grappling()
    {
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Physics2D.OverlapCircle(point, 0.1f, grappleLayer))
        {
            isGrappling = true;

            distanceJ.enabled = true;
            distanceJ.connectedAnchor = point;
        }
    }

    private void StopGrapple()
    {
        lineR.enabled = false;
        distanceJ.enabled = false;
        isGrappling = false;
    }

    private void UpdateGrapple()
    {
        lineR.enabled = true;
        lineR.SetPosition(0, transform.position);
        lineR.SetPosition(1, point);
    }
}
