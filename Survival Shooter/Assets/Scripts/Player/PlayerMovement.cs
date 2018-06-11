using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.
    public Camera TPCamera;

    [SerializeField]
    [HideInInspector]
    private RotationSettings rotationSettings = null;

    Vector3 moveVector;                 // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveVector = PlayerInput.GetMovementInput(TPCamera);
        Vector3 movement = moveVector * speed * Time.deltaTime;

        Move(movement);
        Animating();
    }

    void Move (Vector3 movement)
    {
        transform.position += movement;
    }

    void Animating()
    {
        bool walking = moveVector.x != 0 || moveVector.z != 0;
        anim.SetBool("IsWalking", walking);
    }
}
