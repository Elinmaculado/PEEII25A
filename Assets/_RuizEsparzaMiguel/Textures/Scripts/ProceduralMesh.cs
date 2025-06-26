using UnityEngine;

public class ProceduralMesh : MonoBehaviour
{
    [SerializeField] private Material material;
    private MeshFilter _meshFilter;
    private Mesh _mesh;

    private MeshRenderer _meshRenderer;
    void Start()
    {
        // Crear componentes
        _meshFilter = gameObject.AddComponent<MeshFilter>();
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Crear mesh
        _mesh = new Mesh();
        _mesh.name = "procedural Mesh";

        // configurar mesh data
        _mesh.vertices = new Vector3[]{

            // Cara trasera
            new Vector3(0, 0, 0), //Vertice 0
            new Vector3(0, 1, 0), //Vertice 1
            new Vector3(1, 1, 0), //Vertice 2
            new Vector3(1, 0, 0), //Vertice 3

            // Cara frontal
            new Vector3(1, 0, 1), //Vertice 4
            new Vector3(1, 1, 1), //Vertice 5
            new Vector3(0, 1, 1), //Vertice 6
            new Vector3(0, 0, 1),  //Vertice 7

            // Cara izquierda
            new Vector3(1, 0, 0), //Vertice 8
            new Vector3(1, 1, 0), //Vertice 9
            new Vector3(1, 1, 1), //Vertice 10
            new Vector3(1, 0, 1),  //Vertice 11

            // Cara derecha
            new Vector3(0, 0, 1), //Vertice 12
            new Vector3(0, 1, 1), //Vertice 13
            new Vector3(0, 1, 0), //Vertice 14
            new Vector3(0, 0, 0),  //Vertice 15

            // Cara arriba
            new Vector3(0, 1, 0), //Vertice 16
            new Vector3(0, 1, 1), //Vertice 17
            new Vector3(1, 1, 1), //Vertice 18
            new Vector3(1, 1, 0),  //Vertice 19

            // Cara abajo
            new Vector3(0, 0, 1), //Vertice 20
            new Vector3(0, 0, 0), //Vertice 21
            new Vector3(1, 0, 0), //Vertice 22
            new Vector3(1, 0, 1)  //Vertice 23
        };

        _mesh.triangles = new int[] {

            //Cara trasera
            0, 1, 2,
            0, 2, 3,

            //Cara frontal
            4, 5, 6,
            4, 6, 7,

            //Cara izquierda
            8, 9, 10,
            8, 10, 11,

            //Cara derecha
            12, 13, 14,
            12, 14, 15,

            // Cara arriba
            16, 17, 18,
            16, 18, 19,

            // Cara abajo
            20, 21, 22,
            20, 22, 23
        };

        _mesh.uv = new Vector2[] {

            // Cara trasera
            new Vector2(0, 0), //Vertice 0
            new Vector2(0, 1), //Vertice 1
            new Vector2(1, 1), //Vertice 2
            new Vector2(1, 0), //Vertice 3

            // Cara frontal
            new Vector2(0, 0), //Vertice 4
            new Vector2(0, 1), //Vertice 5
            new Vector2(1, 1), //Vertice 6
            new Vector2(1, 0), //Vertice 7

            // Cara izquierda
            new Vector2(0, 0), //Vertice 8
            new Vector2(0, 1), //Vertice 9
            new Vector2(1, 1), //Vertice 10
            new Vector2(1, 0), //Vertice 11

            // Cara derecha
            new Vector2(0, 0), //Vertice 12
            new Vector2(0, 1), //Vertice 13
            new Vector2(0, 1), //Vertice 14
            new Vector2(0, 0), //Vertice 15

            // Cara arriba
            new Vector2(0, 0), //Vertice 16
            new Vector2(0, 1), //Vertice 17
            new Vector2(1, 1), //Vertice 18
            new Vector2(1, 0), //Vertice 19

            // Cara abajo
            new Vector2(0, 0), //Vertice 20
            new Vector2(0, 1), //Vertice 21
            new Vector2(1, 1), //Vertice 22
            new Vector2(1, 0), //Vertice 23
         };

        _mesh.normals = new Vector3[] { 
            // Cara trasera
            Vector3.back, 
            Vector3.back, 
            Vector3.back, 
            Vector3.back,

            // Cara frontal
            Vector3.forward, 
            Vector3.forward, 
            Vector3.forward, 
            Vector3.forward,

            // Cara izquierda
            Vector3.right, 
            Vector3.right, 
            Vector3.right, 
            Vector3.right,

            // Cara derecha
            Vector3.left, 
            Vector3.left, 
            Vector3.left, 
            Vector3.left,

            // Cara arriba
            Vector3.up, 
            Vector3.up, 
            Vector3.up, 
            Vector3.up,

            // Cara abajo
            Vector3.down, 
            Vector3.down, 
            Vector3.down, 
            Vector3.down
        };

        _mesh.colors = new[]
        {
            // cara tracera 
            Color.black,
            Color.green,
            Color.yellow,
            Color.red,

            //cara delantera
            Color.magenta,
            Color.gray,
            Color.cyan,
            Color.blue,

            // cara derecha
            Color.red,
            Color.yellow,
            Color.grey,
            Color.magenta,

            // cara izquierda
            Color.blue,
            Color.cyan,
            Color.green,
            Color.black,

            // carra arriba
            Color.green,
            Color.cyan,
            Color.grey,
            Color.yellow,

            // cara abajo
            Color.blue,
            Color.black,
            Color.red,
            Color.magenta
        };

        // Asignar referencias
        _meshFilter.mesh = _mesh;
        _meshRenderer.material = material;
    }

    private void Update()
    {
        //transform.Translate(Vector3.right);
    }
}
