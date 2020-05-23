using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//enum
public class DoorHandler : MonoBehaviour
{
    public enum controller { left, right }
    public controller hand;
    private Vector3 velocity;
    private IEnumerator coroutine;
    private AudioSource AS;
    public AudioClip shot;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "door")
        {

            AS.PlayOneShot(shot);
            SplitMesh(other.gameObject);
            DoorType.Door Door = other.GetComponent<DoorType>().door;
            coroutine = DoorAction(Door, 2f);
            StartCoroutine(coroutine);
            Destroy(other.gameObject);

        }
    }



    private IEnumerator DoorAction(DoorType.Door doorEnum,float time)
    {
        yield return new WaitForSeconds(time);

        switch (doorEnum)
        {
            case (DoorType.Door.normal):
                break;
            case (DoorType.Door.exit):
                Application.Quit();
                break;
            case (DoorType.Door.menu):
                SceneManager.LoadScene(0);
                break;
            case (DoorType.Door.next):
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            default:
                break;
        }
    }

    // Get a cutting plane from the rotation/position of the saber
    private Plane GetPlane(GameObject go)
    {
        // 1.
        Vector3 pt1 = transform.rotation * new Vector3(0, 0, 0);
        Vector3 pt2 = transform.rotation * new Vector3(0, 1, 0);
        Vector3 pt3 = transform.rotation * new Vector3(0, 0, 1);

        // 2.
        Plane rv = new Plane();
        rv.Set3Points(pt1, pt2, pt3);
        return rv;
    }

    // Clone a Mesh "half"
    private Mesh CloneMesh(Plane p, Mesh oMesh, bool halve)
    {
        // 1.
        Mesh cMesh = new Mesh();
        cMesh.name = "slicedMesh";
        Vector3[] vertices = oMesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            bool side = p.GetSide(vertices[i]);

            if (side == halve)
            {
                vertices[i] = p.ClosestPointOnPlane(vertices[i]);
            }
        }

        // 2.
        cMesh.vertices = vertices;
        cMesh.triangles = oMesh.triangles;
        cMesh.normals = oMesh.normals;
        cMesh.uv = oMesh.uv;
        return cMesh;
    }

    // Configure the GameObject
    private GameObject MakeHalf(GameObject go, bool isLeft)
    {
        // 1.
        float sign = isLeft ? -1 : 1;
        GameObject half = Instantiate(go);
        MeshFilter filter = half.GetComponent<MeshFilter>();

        // 2.
        Plane cuttingPlane = GetPlane(go);
        filter.mesh = CloneMesh(cuttingPlane, filter.mesh, isLeft);

        // 3.
        half.transform.position = go.transform.position + transform.rotation * new Vector3(sign * 0.05f, 0, 0);
        half.GetComponent<Rigidbody>().isKinematic = false;
        half.GetComponent<Rigidbody>().useGravity = true;

        // 4.
        half.GetComponent<Collider>().isTrigger = false;
        Destroy(half, 1);
        return half;
    }

    // Make two GameObjects with "halves" of the original
    private void SplitMesh(GameObject go)
    {
        GameObject leftHalf = MakeHalf(go, true);
        GameObject rightHalf = MakeHalf(go, false);
        // 2.
        // GetComponent<AudioSource>().Play();
    }
}