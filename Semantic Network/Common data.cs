using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Semantic_Network
{
    public struct Node
    {
        static int nextId = 0;
        //ID
        int id;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        //Name
        string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        //Position
        int x, y;
        public int X
        {
            set { if (value > 0) x = value; }
            get { return x; }
        }
        public int Y
        {
            set { if (value > 20) y = value; }
            get { return y; }
        }
        //Color
        Color contourColor;
        public Color ContourColor
        {
            set { contourColor = value; }
            get { return contourColor; }
        }
        Color backgroundColor;
        public Color BackgroundColor
        {
            set { backgroundColor = value; }
            get { return backgroundColor; }
        }
        Color stringColor;
        public Color StringColor
        {
            set { stringColor = value; }
            get { return stringColor; }
        }
        //Relates
        public int[] LinksOnNodes;
        public int[] LinksOnThisNode;
        //Type
        public NodeType type;
        //Size
        SizeF size;
        public SizeF Size
        {
            set { size = value; }
            get { return size; }
        }
        //Font
        Font font;
        public Font Font
        {
            set { font = value; }
            get { return font; }
        }
    }
    public struct Edge
    {
        //public static Action<Edge[], int> actEdge;
        //public static Action<Node[], int> actNode;
        //ID
        int id;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        //Name
        string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        //Position
        int xFrom;
        public int XFrom
        {
            set { xFrom = value; }
            get { return xFrom; }
        }
        //int yFrom;
        //public int YFrom
        //{
        //    set { yFrom = value; }
        //    get { return yFrom; }
        //}
        int xTo;
        public int XTo
        {
            set { xTo = value; }
            get { return xTo; }
        }
        //int yTo;
        //public int YTo
        //{
        //    set { yTo = value; }
        //    get { return yTo; }
        //}
        public Coords Coordinates;
        //Color
        Color contourColor;
        public Color ContourColor
        {
            set { contourColor = value; }
            get { return contourColor; }
        }
        Color stringColor;
        public Color StringColor
        {
            set { stringColor = value; }
            get { return stringColor; }
        }
        //Relates
        int from;
        public int From
        {
            set { from = value; }
            get { return from; }
        }
        int to;
        public int To
        {
            set { to = value; }
            get { return to; }
        }
        //Font
        Font font;
        public Font Font
        {
            set { font = value; }
            get { return font; }
        }
        //Width
        int width;
        public int Width
        {
            set { width = value; }
            get { return width; }
        }

    }
    public struct Coords
    {
        Point a1;
        public Point A1
        {
            set { a1 = value; }
            get { return a1; }
        }
        Point a2;
        public Point A2
        {
            set { a2 = value; }
            get { return a2; }
        }
        Point a3;
        public Point A3
        {
            set { a3 = value; }
            get { return a3; }
        }
        Point a4;
        public Point A4
        {
            set { a4 = value; }
            get { return a4; }
        }
        public Coords(Point a1, Point a2, Point a3, Point a4)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.a4 = a4;
        }
    }
    public enum NodeType
    {
        rectangle, ellipse, hexagon, rhombus
    }
    public enum EditChooser
    {
        move, addNode, addEdge, delete, creationNode, creationEdge, off, propNode, propEdge
    }
    public enum EditCursor
    {
        usual, addE, addN, delete
    }
    public static class Common_data
    {

        static public void DrawHexagon(Graphics g, int x, int y, int width, int height, Pen pen, Brush brush)
        {
            width += width / 3;
            Point point1 = new Point(x - width / 2, y),
         point2 = new Point(x - width / 4, y - height / 2),
        point3 = new Point(x + width / 4, y - height / 2),
        point4 = new Point(x + width / 2, y),
        point5 = new Point(x + width / 4, y + height / 2),
        point6 = new Point(x - width / 4, y + height / 2);
            Point[] HexagonPoints =
                 {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6
             };
            g.DrawPolygon(pen, HexagonPoints);
            g.FillPolygon(brush, HexagonPoints);
        }
        static public void DrawRhombus(Graphics g, int x, int y, int width, int height, Pen pen, Brush brush)
        {
            height += width / 2;
            width += width / 8;
            Point point1 = new Point(x - width / 2, y),
         point2 = new Point(x, y - height / 2),
        point3 = new Point(x + width / 2, y),
        point4 = new Point(x, y + height / 2);
            Point[] HexagonPoints =
                 {
                 point1,
                 point2,
                 point3,
                 point4
             };
            g.DrawPolygon(pen, HexagonPoints);
            g.FillPolygon(brush, HexagonPoints);
        }
    }
}
