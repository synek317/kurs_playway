using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private bool movingForward;
    private bool movingBackward;
    private bool movingLeft;
    private bool movingRight;

    public float sensitivity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        this.characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3();

        UpdateMoveDirection(KeyCode.W, ref this.movingForward, ref move.z, 1.0f);
        UpdateMoveDirection(KeyCode.S, ref this.movingBackward, ref move.z, -1.0f);
        UpdateMoveDirection(KeyCode.A, ref this.movingLeft, ref move.x, -1.0f);
        UpdateMoveDirection(KeyCode.D, ref this.movingRight, ref move.x, 1.0f);

        //this.transform.eulerAngles += new Vector3(10.0f, 20.0f, 30.0f) * Time.deltaTime;
        this.characterController.Move(move);
    }

    private void UpdateMoveDirection(KeyCode key, ref bool direction, ref float delta, float orientation)
    {
        if (Input.GetKeyDown(key))
        {
            direction = true;
        }
        else if (Input.GetKeyUp(key))
        {
            direction = false;
        }

        if (direction)
        {
            delta += this.sensitivity * orientation;
        }
    }
}
