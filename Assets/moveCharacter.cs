using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController Cc;
    public Transform cameraTransform;
    public float Gravity;
    public float WalkSpeed;
    public float JumpSpeed;

    private float yspeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        cameraTransform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));


        if (Cc.isGrounded)
        {
            yspeed = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yspeed = JumpSpeed;
            }
        }
        else
        {
            if (yspeed > 0)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    yspeed *= 0.1f;
                }
            }

            yspeed += Gravity * Time.deltaTime;
        }

        Vector3 move = Vector3.zero;
        // Apply walk vector
        move += Input.GetAxis("Vertical") * transform.forward * WalkSpeed;
        move += Input.GetAxis("Horizontal") * transform.right * WalkSpeed;
        // Apply gravity
        move += new Vector3(0, yspeed, 0);

        Cc.Move(move * Time.deltaTime);

        HandleRaycasting();
    }

    private void HandleRaycasting()

    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawLine(cameraTransform.position + new Vector3(0, -0.1f, 0), hit.point, Color.red, 1f);

                colorChange hitButton = hit.collider.gameObject.GetComponent<colorChange>();
                if (hitButton != null)
                {
                    hitButton.Press();
                }
            }
        }
    }

}
