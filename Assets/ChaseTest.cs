using UnityEngine;


public class ChaseTest : MonoBehaviour {
    public GameObject Ball;
    public GameObject firePoint_A;
    public GameObject firePoint_B;
    public float speed_A;
    public float speed_B;

    public void FixedUpdate() {
        if (Input.GetKey(KeyCode.Mouse0)) {//发射子弹
            if (speed_A <= 0 || speed_B <= 0)//速度无效时直接无视
                return;

            var A = Instantiate(Ball, firePoint_A.transform);//生成子弹A
            var B = Instantiate(Ball, firePoint_B.transform);//生成子弹B
            A.GetComponent<Ball>().theOther = B;//设置另一半

            var mouse = (Vector2)Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);//鼠标位置
            var posA = (Vector2)firePoint_A.transform.position;//子弹A位置
            var direA = (mouse -posA).normalized;//子弹A方向
            var vectA = speed_A * direA;//子弹A的速度
            var posB = (Vector2)firePoint_B.transform.position;//子弹B位置
            var vectB = Forecast(posA, posB, vectA, speed_B);//子弹B方向【对子弹A进行预测】

            A.transform.position = posA;
            A.GetComponent<Rigidbody2D>().velocity = vectA;
            if (vectB.sqrMagnitude == 0) {//子弹B无效，直接销毁
                Destroy(B);
            }
            else {
                B.transform.position = posB;
                B.GetComponent<Rigidbody2D>().velocity = vectB;

                A.GetComponent<SpriteRenderer>().color = firePoint_A.GetComponent<SpriteRenderer>().color;
                B.GetComponent<SpriteRenderer>().color = firePoint_B.GetComponent<SpriteRenderer>().color;
            }
        }

    }

    private static Vector2 Forecast(Vector2 posA, Vector2 posB, Vector2 vector_A, float speed_B) {//子弹预测，返回子弹B的速度矢量(如果为0说明子弹追不上)
        double dX = posA.x - posB.x;
        double dY = posA.y - posB.y;
        double vX = vector_A.x;
        double vY = vector_A.y;

        //一元二次方程组At^2+Bt+C=0，t为时间。求解出时间t
        double A = vX * vX + vY * vY - speed_B * speed_B;
        double B = 2 * (vX * dX + vY * dY);
        double C = dX * dX + dY * dY;
        double D = B * B - 4 * A * C;
        if (D > 0) {//delta值小于0则无解
            D = System.Math.Sqrt(D);
            A = 2 * A;
            double t1 = (-B + D) / A;
            double t2 = (-B - D) / A;
            double t = 0;//符合条件的t值
            if (t1 > 0 && t2 > 0)
                t = System.Math.Min(t1, t2);
            else
                t = System.Math.Max(t1, t2);
            if (t > 0 && t < 10000)
                return new Vector2((float)(dX / t + vX), (float)(dY / t + vY));
        }
        return new Vector2(0, 0);
    }

}
