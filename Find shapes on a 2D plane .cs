using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_rectangles_and_cirgles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}

public class Shape
{
    public int ID;

    public int Type; // 0 = circle 1 = rectangle
    public int radius;
    public int centerX;
    public int centerY;

    public int topX, topY;
    public int bottomX, bottomY;

    public int TouchonX;
    public int TouchonY;

}



public class Scrips
{



    public Dictionary<int, List<int>> FindIntersections(List<Shape> shapes)
    {
        Dictionary<int, List<int>> resultValue; //declare 
        resultValue = new Dictionary<int, List<int>>(); //create dictionary



        foreach (Shape item in shapes)
        {
            List<int> intersectingShapes; // declare
            intersectingShapes = new List<int>(); // create list
            foreach (Shape item2 in shapes) // goes over the all list again
            {
                if (item.ID != item2.ID)
                {
                    if (intersecting(item, item2))
                    {

                        intersectingShapes.Add(item2.ID);
                    }
                }
            }
            resultValue.Add(item.ID, intersectingShapes);
        }
        return resultValue;
    }

    public bool intersecting(Shape sh1, Shape sh2) // are these 2 shapes intersecting ?
    {
        if (AreTouchingOnX(sh1, sh2))
        {
            if (AreTouchingOnY(sh1, sh2))
            {
                return true;
            }
        }

        return false;

    }

    bool AreTouchingOnX(Shape sh1, Shape sh2)
    {

        int sh1leftX;
        int sh2LeftX;
        int sh1RightX;
        int sh2RightX;

        if (sh1.bottomX < sh1.topX) // find most left X
        {
            sh1leftX = sh1.bottomX;
        }
        else
        {
            sh1leftX = sh1.topX;
        }


        if (sh2.bottomX < sh2.topX) // find most left X
        {
            sh2LeftX = sh2.bottomX;
        }
        else
        {
            sh2LeftX = sh2.topX;
        }


        if (sh1.bottomX < sh1.topX) // find most right X
        {
            sh1RightX = sh1.topX;
        }
        else
        {
            sh1RightX = sh1.bottomX;
        }


        if (sh2.bottomX < sh2.topX) // find most Right X
        {
            sh2RightX = sh2.topX;
        }
        else
        {
            sh2RightX = sh2.bottomX;
        }


        if (sh1.bottomX + sh1.topX < sh2.bottomX + sh2.topX) // If Sh1 is the most left
        {
            if (sh1RightX > sh2LeftX)
            {
                return true;
            }

        }
        else // sh2 is the most left
        {
            if (sh2RightX > sh1leftX)
            {
                return true;
            }

        }

        return false;
    }


    bool AreTouchingOnY(Shape sh1, Shape sh2)

    {
        int sh1LowerY;
        int sh2LowerY;
        int sh1HigherY;
        int sh2HigherY;

        if (sh1.bottomY < sh1.topY) // find lowest Y shape 1
        {
            sh1LowerY = sh1.bottomY;
        }
        else
        {
            sh1LowerY = sh1.topY;
        }


        if (sh2.bottomY < sh2.topY) // find lowest Y shape 2
        {
            sh2LowerY = sh2.bottomY;
        }
        else
        {
            sh2LowerY = sh2.topY;
        }


        if (sh1.bottomY < sh1.topY) // find highest Y shape 1
        {
            sh1HigherY = sh1.topY;
        }
        else
        {
            sh1HigherY = sh1.bottomY;
        }


        if (sh2.bottomY < sh2.topY) // find highest Y shape 2
        {
            sh2HigherY = sh2.topY;
        }
        else
        {
            sh2HigherY = sh2.bottomY;
        }


        if (sh1.bottomY + sh1.topY < sh2.bottomY + sh2.topY) // If Sh2 is the lowest
        {
            if (sh1HigherY > sh2LowerY)
            {
                return true;
            }

        }
        else // sh2 is the lowest
        {
            if (sh2HigherY > sh1LowerY)
            {
                return true;
            }

        }

        return false;
    }

}
