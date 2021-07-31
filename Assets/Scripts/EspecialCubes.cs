using UnityEngine;
using UnityEngine.SceneManagement;

public class EspecialCubes : MonoBehaviour
{
    public string typeOfCube;
    protected string theType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            switch (typeOfCube)
            {
                case "inimigo":
                    SceneManager.LoadScene("Dead");

                    break;

                case "apenasAmarelo":
                    if (collision.collider.CompareTag("Player2"))
                        SceneManager.LoadScene("Dead");
                    else
                        Destroy(this.gameObject);

                    break;

                case "apenasRoxo":
                    if (collision.collider.CompareTag("Player1"))
                        SceneManager.LoadScene("Dead");
                    else
                        Destroy(this.gameObject);

                    break;

                case "impulso":

                    break;

                default:
                    Debug.Log("Tipo invalido");

                    break;
            }
        }
    }
}