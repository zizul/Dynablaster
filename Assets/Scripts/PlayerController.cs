using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bombPrefab;
    private Vector3 moveDirection;
    private Rigidbody rbody;
    private Vector3 previousPosition;
    private Vector3 lastDirection;

    public float velocidad = 5f;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        previousPosition = transform.position;

        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, this.velocidad);
            //this.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector3.forward;
            lastDirection = direction;
            transform.position += direction * Time.deltaTime * velocidad;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rbody.velocity = new Vector3(this.velocidad, rbody.velocity.y, rbody.velocity.z);
            //this.transform.rotation = Quaternion.Euler(0, 90, 0);
            direction = Vector3.right;
            lastDirection = direction;
            transform.position += direction * Time.deltaTime * velocidad;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, -this.velocidad);
            //this.transform.rotation = Quaternion.Euler(0, 180, 0);
            direction = Vector3.back;
            lastDirection = direction;
            transform.position += direction * Time.deltaTime * velocidad;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rbody.velocity = new Vector3(-this.velocidad, rbody.velocity.y, rbody.velocity.z);
            //this.transform.rotation = Quaternion.Euler(0, 270, 0);
            direction = Vector3.left;
            lastDirection = direction;
            transform.position += direction * Time.deltaTime * velocidad;
        }
        Debug.DrawLine(previousPosition, transform.position + direction, Color.white);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantBomb();
        }
    }

    private void PlantBomb()
    {
        GameObject o = Instantiate(
            bombPrefab);
        Vector3 pos = this.transform.position;
        pos -= (lastDirection * 0.8f);
        o.transform.position = new Vector3(
            Mathf.RoundToInt(pos.x),
            Mathf.RoundToInt(pos.y),
            Mathf.RoundToInt(pos.z)
            //),bombPrefab.transform.rotation * Quaternion.Euler(new Vector3(20, 20, 20)));
            );
        o.transform.localScale = bombPrefab.transform.localScale;

        if (Physics.CheckSphere(o.transform.position, 0.5f))
        {
            Debug.Log("collision!");
        }
        //Physics.IgnoreCollision(o.GetComponent<Collider>(), GetComponent<Collider>());
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            FindObjectOfType<MainController>().SetPlayerLastPosition(transform.position);
           // Destroy(this.gameObject);
        }
        //if (other.CompareTag("Bomb"))
        //{
        //    GetComponent<Collider>().isTrigger = false;
        //}
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.collider.CompareTag("Bomb"))
    //    {
    //        GetComponent<Collider>().isTrigger = false;
    //    }
    //    if (other.collider.CompareTag("Explosion"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
