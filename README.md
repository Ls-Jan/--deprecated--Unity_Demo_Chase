# 此项目已废弃

#### 废弃原因：
- 项目过于久远，不再考虑维护
- Unity败人缘，尚未了解游戏开发的请速速远离Unity，已深陷泥潭的也请考虑抽身之策

虽然本项目废弃，但其中涉及的“追逐算法”还是有点价值的(应该抽离出来作为dll

<br>
<br>
<br>

# Unity_Demo_Chase
原本是研究两物体的追逐算法的，然后为了看自己写的破算法对不对就用Unity运行一下。

结果感觉还有点好玩就稍微完善了一下，例如添加滑动条即时修改子弹速度、添加小箭头表示子弹发射方向。

Unity版本：2018.3.7f1


<img src="https://github.com/Ls-Jan/Unity_Demo_Chase/blob/main/RunningDisplay%5BMP4%2CGIF%5D/0.gif">



***
<img src="https://github.com/Ls-Jan/Unity_Demo_Chase/blob/main/RunningDisplay%5BMP4%2CGIF%5D/2.png">


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
    


