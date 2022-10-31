using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    public void Destruct()
    {
        Destroy(this.gameObject);
    }

    public void Boom()
    {
        gameObject.GetComponent<PointEffector2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }

    internal void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= ThresholdForce)
        {
            Boom();
        }
    }
}
