using UnityEngine;

public class PlayersMov : MonoBehaviour
{
    public bool thisSelection;
    private bool playerSelection = true;
    public float speed, directionX = 0, directionY = 0;
    public bool canMov = true;

    private void Start()
    {
        canMov = true;
    }

    private void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * directionX, speed * directionY);

        if (canMov == true && playerSelection == thisSelection)
        {
            if (Input.GetAxis("Horizontal") > 0) directionX = 1; 
            else if (Input.GetAxis("Horizontal") < 0) directionX = -1;
            else directionX = 0;

            if (Input.GetAxis("Vertical") > 0) directionY = 1; 
            else if (Input.GetAxis("Vertical") < 0) directionY = -1;
            else directionY = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.P)) { playerSelection = !playerSelection; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canMov = true;
        directionX = 0;
        directionY = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canMov = false;
    }
}