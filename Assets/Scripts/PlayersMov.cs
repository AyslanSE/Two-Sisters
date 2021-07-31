using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersMov : MonoBehaviour
{
    public bool thisSelection;
    public float speed, directionX = 0, directionY = 0;
    public string Newscene;

    private bool canMov = true, playerSelection = true;

    private void Start()
    {
        canMov = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) playerSelection = !playerSelection;

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * directionX, speed * directionY);

        if (canMov == true && playerSelection == thisSelection)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                directionX = 0;
                directionY = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                directionX = 0;
                directionY = -1;

            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                directionX = 1;
                directionY = 0;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                directionX = -1;
                directionY = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player1"))
            SceneManager.LoadScene(Newscene);
        else if (collision.collider.CompareTag("impulseBlock"))
        {
            directionX *= -1;
            directionY *= -1;
            canMov = false;
        }

        canMov = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canMov = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("especialBlocks"))
            canMov = true;
        else
            canMov = false;
    }
}