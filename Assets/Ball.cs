using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject theOther;//另一半
    public int liftTime;//寿命
    public void OnTriggerEnter2D(Collider2D collision) {//触发器触发函数
        if (theOther == collision.gameObject) {//遇到另一半，一起销毁
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void FixedUpdate() {
        if (--liftTime < 0)//寿终正寝
            Destroy(this.gameObject);
    }

}
