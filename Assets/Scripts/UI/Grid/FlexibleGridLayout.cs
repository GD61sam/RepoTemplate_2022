//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public enum EnumFitType
    {
        Uniform,
        Width,
        Height,
        FixedRow,
        FixedColumn
    }

    //SERIALIZED VAULES-----------------------------------
    [Header("Rows and Collums")]
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;

    //[Header("Cell Sizes")]
    private Vector2 _cellSize;

    [Header("Spacing")]
    [SerializeField] private Vector2 _spacing;

    [Header("Grid Type")]
    [SerializeField] private EnumFitType _fitType;



    //PRIVATE VALUES--------------------------------------
    private bool fixX;
    private bool fixY;


    
    //PUBLC VALUES----------------------------------------
    //PROPERTIES------------------------------------------

    //UNITY METHODS---------------------------------------
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if(_fitType == EnumFitType.Uniform || _fitType == EnumFitType.Width || _fitType == EnumFitType.Height)
        {
            fixX = true;
            fixY = true;

            //determin number of rows and columns based on child amount
            float sqrRt = Mathf.Sqrt(transform.childCount);
            _rows = Mathf.CeilToInt(sqrRt);
            _columns = Mathf.CeilToInt(sqrRt);

        }

        if (_fitType == EnumFitType.Width || _fitType == EnumFitType.FixedColumn)
        {
            _rows = Mathf.CeilToInt(transform.childCount / (float)_columns);
        }

        if (_fitType == EnumFitType.Height || _fitType == EnumFitType.FixedRow)
        {
            _columns = Mathf.CeilToInt(transform.childCount / (float)_rows);
        }




        //get size of parent
        float parentWidth = rectTransform.rect.width;
        float ParentHeight = rectTransform.rect.height;

        //get desired size of children base off parent size and row /  column amount
        float cellWidth = parentWidth / (float)_columns - ((_spacing.x / (float)_columns) * (_columns - 1)) - (padding.left / (float)_columns) - (padding.right / (float)_columns);
        float cellHeight = ParentHeight / (float)_rows - ((_spacing.y / (float)_rows) * (_rows - 1)) - (padding.top / (float)_rows) - (padding.bottom / (float)_rows);

        _cellSize.x = fixX ? cellWidth : _cellSize.x;
        _cellSize.y = fixY ? cellHeight : _cellSize.y;

        int columnCount = 0;
        int rowCount = 0;

        //loop through childrenS
        for (int i = 0; i < rectChildren.Count; i++)
        {
            //get current row and column index of item
            rowCount = i / _columns;
            columnCount = i % _columns;

            var item = rectChildren[i];

            var xPos = (_cellSize.x * columnCount) + (_spacing.x * columnCount) + padding.left;
            var yPos = (_cellSize.y * rowCount) + (_spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, _cellSize.x);
            SetChildAlongAxis(item, 1, yPos, _cellSize.y);
        }

    }

    public override void CalculateLayoutInputVertical()
    {



    }

    public override void SetLayoutHorizontal()
    {

    }

    public override void SetLayoutVertical()
    {

    }

    //CUSTOM METHODS -------------------------------------

}
