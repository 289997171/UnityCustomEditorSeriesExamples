using UnityEngine;

/// <summary>
/// 看不见的触发器，在编辑环境下可见
/// </summary>
public class InvisibleTrigger : MonoBehaviour
{
    public Color color = Color.white;

    private BoxCollider2D boxCollider = null;
    private BoxCollider2D BoxCollider
    {
        get
        {
            if (boxCollider == null)
            {
                boxCollider = GetComponent<BoxCollider2D>();
            }
            return boxCollider;
        }

    }

    private CircleCollider2D sphereCollider = null;
    private CircleCollider2D SphereCollider
    {
        get
        {
            if (sphereCollider == null)
            {
                sphereCollider = GetComponent<CircleCollider2D>();
            }
            return sphereCollider;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name + " entered " + gameObject.name);
    }

    /// <summary>
    /// OnDrawGizmos 绘制图标
    /// </summary>
    void OnDrawGizmos()
    {
        Color oldColor = Gizmos.color;

        Gizmos.color = color;


        //        Gizmo.DrawXXX(postion, < defining characteristics >)
        //            1.Cube          正方体
        //            2.Icon          图标
        //            3.Line          直线
        //            4.Ray           射线
        //            5.Sphere        圆形
        //            6.WireSphere

        // 在未选中的情况下，只绘制边框图标
        if (BoxCollider != null)
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(BoxCollider.size.x, BoxCollider.size.y, 1.0f));
        }
        if (SphereCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, SphereCollider.radius);
        }

        Gizmos.color = oldColor;
    }


    /// <summary>
    /// 选中后绘制图标
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Color oldColor = Gizmos.color;

        Gizmos.color = color;

        // 在选中模式下绘制实体图标
        if (BoxCollider != null)
        {
            Gizmos.DrawCube(transform.position, new Vector3(BoxCollider.size.x, BoxCollider.size.y, 1.0f));
        }
        if (SphereCollider != null)
        {
            Gizmos.DrawSphere(transform.position, SphereCollider.radius);
        }

        Gizmos.color = oldColor;
    }
}
