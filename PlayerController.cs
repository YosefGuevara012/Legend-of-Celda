using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private bool walking = false;
    public Vector2 LastMovement = Vector2.zero;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical",
        WALK = "Walking", LAST_H = "LastH", LAST_V = "LastV";

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // s = v* t

        walking = false;

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            Vector3 translation = new Vector3(
                Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime, 0, 0);
            this.transform.Translate(translation);
            walking = true;
            LastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            Vector3 translation = new Vector3(0,
                Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
            walking = true;
            LastMovement = new Vector2(0,Input.GetAxisRaw(AXIS_V));
        }

    }

    private void LateUpdate()
    {
        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        _animator.SetBool(WALK, walking);
        _animator.SetFloat(LAST_H, LastMovement.x);
        _animator.SetFloat(LAST_V, LastMovement.y);
    }
}
