using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform movingPoint;
    public LayerMask whatStopsMovement;

    public int movementDisabler;
    public bool movementEnabled = true;
    public float moveSpeed = 5f;



    void Start()
    {
        movingPoint.parent = null;
    }

    void Update()
    {
        if (movementDisabler > 0) movementDisabler--;

        transform.position = Vector3.MoveTowards(transform.position, movingPoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movingPoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (Physics2D.OverlapCircle(movingPoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement) == false && movementEnabled && movementDisabler == 0)
                {
                    movingPoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    movementDisabler = 80;
                }

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (Physics2D.OverlapCircle(movingPoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement) == false && movementEnabled && movementDisabler == 0)
                {
                    movingPoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    movementDisabler = 80;
                }

            }
        }
    }
}
