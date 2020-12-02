using UnityEngine;

public class BigBounce : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If player collides with platform and y velocity is 0 then make player bounce upwards
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 900f); //propel player upwards for BIG BOUNCE
            //Make doodler space jump sprite appear when big bounce happens

        }
    }
}
