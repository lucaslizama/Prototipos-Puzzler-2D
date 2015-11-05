using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour
{
    public float _velocidadMovimiento = 5f;
    public float _fuerzaSalto = 300f;
    public LayerMask _esPiso;

    private Rigidbody2D _rigigbody;
    private BoxCollider2D _boxCollider;
    private bool _estoySobrePiso;

    void Awake()
    {
        this._rigigbody = GetComponent<Rigidbody2D>();
        this._boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Moverse();
        Saltar();
    }

    void FixedUpdate()
    {
        RevisarPiso();
    }

    private void Moverse()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this._rigigbody.velocity = new Vector2(this._velocidadMovimiento, this._rigigbody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            this._rigigbody.velocity = new Vector2(-this._velocidadMovimiento, this._rigigbody.velocity.y);
        }
        else
        {
            this._rigigbody.velocity = new Vector2(0f, this._rigigbody.velocity.y);
        }
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this._estoySobrePiso)
        {
            _rigigbody.AddForce(new Vector2(0f, this._fuerzaSalto));
        }
    }

    private void RevisarPiso()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 0.52f,this._esPiso.value);

        if(hit.collider != null)
        {
            this._estoySobrePiso = hit.collider.tag.Equals("piso");
        }
        else
        {
            this._estoySobrePiso = false;
        }
    }
}
