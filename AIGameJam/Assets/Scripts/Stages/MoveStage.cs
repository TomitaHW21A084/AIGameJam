using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    [SerializeField, Tooltip("移動速度")]
    private float moveSpeed;

    [SerializeField, Tooltip("進行方向")]
    private bool isLeftGo;

    private StageDataBase stageDB;
    private Vector3 movePosision;
    
    // Start is called before the first frame update
    void Start()
    {
        stageDB = DataBaseManager.instance.GetStageData();
        SetMoveSpeed(stageDB.moveStageSpd);
        if (isLeftGo) moveSpeed = -moveSpeed;
        movePosision = new Vector3(moveSpeed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartGame.shouldStartingGame) return;
        transform.position += movePosision * Time.deltaTime * ManageCarrySystem.instance.CalcVelocityDiameter();
    }

    private void SetMoveSpeed(float _spd)
    {
        moveSpeed = _spd;
    }

    public void SetTravelingDirection(bool _isLeftGo)
    {
        isLeftGo = _isLeftGo;
    }
}
