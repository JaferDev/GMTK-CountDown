using UnityEngine;
public class Grapple : MonoBehaviour
{
    private LineRenderer lineR;
    private DistanceJoint2D distanceJ;
    [SerializeField] LayerMask grappleLayer;
    private bool isGrappling;
    private Vector3 point;
    private PlayerMovement playerMove;

    private void Start()
    {
        lineR = GetComponent<LineRenderer>();
        distanceJ = GetComponent<DistanceJoint2D>();
        playerMove = GetComponent<PlayerMovement>();

        distanceJ.enabled = false;
        lineR.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartGrapple();
        if (Input.GetMouseButtonUp(0)) StopGrapple();
        if (isGrappling) UpdateGrapple();
    }

    private void StartGrapple()
    {
        playerMove.canMove = false;
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(point);
        if (Physics2D.OverlapCircle(point, 1f, grappleLayer))
        {
            FindAnyObjectByType<AudioManager>().PlayOnce("Grapple");
            isGrappling = true;

            distanceJ.enabled = true;
            distanceJ.connectedAnchor = point;
        }
    }

    private void StopGrapple()
    {
        FindAnyObjectByType<AudioManager>().PlayOnce("Grapple");
        playerMove.canMove = true;
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
