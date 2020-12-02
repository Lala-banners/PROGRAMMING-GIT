using UnityEngine;

public class Bounce : MonoBehaviour
{
    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If player collides with platform and y velocity is 0 then make player bounce upwards
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 500f); //propel player upwards
            PlayerKiller.instance.Move();
        }
    }
}
