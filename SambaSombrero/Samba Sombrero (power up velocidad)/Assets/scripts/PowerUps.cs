using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite[] powerUpsStatic;
    public GameObject[] powerUpsAnimated;
    bool inGround;
    SpriteRenderer sr;
    private Movimiento2 m2;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        m2 = FindObjectOfType<Movimiento2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        int aleatory = Random.Range(0, 2);
        if (aleatory == 0)
        {
            sr.sprite = powerUpsStatic[Random.Range(0, powerUpsStatic.Length)];
            gameObject.name = sr.sprite.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Abajo")
        {
            inGround = true;
            Destroy(gameObject, 5);
        }
        if (other.gameObject.tag == "Jugador")
        {
            if (gameObject.name.Equals("CintaVelocidad"))
            {
                m2.Speed();
            }
            if (gameObject.name.Equals("Escopeta"))
            {
                m2.Speed();
            }
            Destroy(gameObject);
        }
    }
}
