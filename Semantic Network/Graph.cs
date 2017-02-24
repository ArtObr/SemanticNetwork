using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Semantic_Network
{
    class SNGraph
    {
        //объявление полей графа
        public Node[] Nodes = null; //массив всех узлов графа
        public Edge[] Edges = null; // массив всех связей графа
        Bitmap bitmap, btmTest;
        public EditCursor EC;
        Point cursorPoint;
        public Point CursorPoint
        {
            set { cursorPoint = value; }
            get { return cursorPoint; }
        }
        int FreeIdNode, FreeIdEdge;
        //переменные для создания грани
        bool line; int xForLine;
        public bool Line
        {
            set { line = value; }
            get { return line; }
        }
        int startNode, endNode;
        public int StartNode
        {
            set { startNode = value; }
            get { return startNode; }
        }
        public int EndNode
        {
            set { endNode = value; }
            get { return endNode; }
        }
        public int XForLine
        {
            set { xForLine = value; }
            get { return xForLine; }
        }

        //конструктор графа
        public SNGraph(int W, int H)
        {
            Nodes = new Node[0];
            Edges = new Edge[0];
            btmTest = bitmap = new Bitmap(W, H);
            EC = EditCursor.usual;
            line = false;
            FreeIdNode = FreeIdEdge = 0;
        }
        ChangeSize(int W, int H)
        {
            bitmap = new Bitmap(W, H);
            bitmap
        }
        //методы для узлов
        /// <summary>
        /// добавляет узел
        /// </summary>
        public void AddNode(int x, int y, string name)
        {
            int N = Nodes.Length;
            Array.Resize<Node>(ref Nodes, N + 1);
            Nodes[N] = new Node();
            Nodes[N].ID = FreeIdNode++;
            Nodes[N].Name = name;
            Nodes[N].X = x;
            Nodes[N].Y = y;
            Nodes[N].ContourColor = Color.Black;
            Nodes[N].BackgroundColor = Color.LightGray;
            Nodes[N].StringColor = Color.Black;
            Nodes[N].LinksOnNodes = new int[0];
            Nodes[N].LinksOnThisNode = new int[0];
            Nodes[N].type = NodeType.rectangle;
            Nodes[N].Font = new Font("Times New Roman", 20);
            FalseDrawing();
        }

        /// <summary>
        /// отрисовка узлов
        /// </summary>
        void DrawNodes(Graphics g)
        {
            Pen contour = new Pen(new SolidBrush(Color.Black));
            SolidBrush background = new SolidBrush(Color.Black);
            SolidBrush str = new SolidBrush(Color.Black);
            for (int i = 0; i < Nodes.Length; i++)
            {
                contour = new Pen(new SolidBrush(Nodes[i].ContourColor));
                background.Color = Nodes[i].BackgroundColor;
                str.Color = Nodes[i].StringColor;
                Nodes[i].Size = g.MeasureString(Nodes[i].Name, Nodes[i].Font);
                switch (Nodes[i].type)
                {
                    case NodeType.rectangle:
                        g.FillRectangle(background, Nodes[i].X - Nodes[i].Size.Width / 2,
                            Nodes[i].Y - Nodes[i].Size.Height / 2, Nodes[i].Size.Width,
                            Nodes[i].Size.Height);
                        g.DrawRectangle(contour, Nodes[i].X - Nodes[i].Size.Width / 2,
                            Nodes[i].Y - Nodes[i].Size.Height / 2, Nodes[i].Size.Width,
                            Nodes[i].Size.Height);
                        break;
                    case NodeType.ellipse:
                        g.FillEllipse(background, Nodes[i].X - Nodes[i].Size.Width / 2,
                            Nodes[i].Y - Nodes[i].Size.Height / 2, Nodes[i].Size.Width,
                            Nodes[i].Size.Height);
                        g.DrawEllipse(contour, Nodes[i].X - Nodes[i].Size.Width / 2,
                            Nodes[i].Y - Nodes[i].Size.Height / 2, Nodes[i].Size.Width,
                            Nodes[i].Size.Height);
                        break;
                    case NodeType.hexagon:
                        Common_data.DrawHexagon(g, Nodes[i].X, Nodes[i].Y, (int)Nodes[i].Size.Width, (int)Nodes[i].Size.Height, contour, background);
                        break;
                    case NodeType.rhombus:
                        Common_data.DrawRhombus(g, Nodes[i].X, Nodes[i].Y, (int)Nodes[i].Size.Width, (int)Nodes[i].Size.Height, contour, background);
                        break;
                }
                g.DrawString(Nodes[i].Name, Nodes[i].Font, str,
                            Nodes[i].X - Nodes[i].Size.Width / 2,
                            Nodes[i].Y - Nodes[i].Size.Height / 2);
            }
        }

        /// <summary>
        /// находит узел по координатам
        /// </summary>
        public int FindNode(int x, int y)
        {
            foreach (Node node in Nodes)
            {
                switch (node.type)
                {
                    case NodeType.rectangle:
                        if (Math.Abs(x - node.X) < node.Size.Width / 2 &&
                            Math.Abs(y - node.Y) < node.Size.Height / 2)
                        {
                            return IndexReturner(Nodes, node.ID);
                        }
                        break;
                    case NodeType.rhombus:
                    case NodeType.hexagon:
                    case NodeType.ellipse:
                        if (Math.Pow(x - node.X, 2) / Math.Pow(node.Size.Width / 2, 2) +
                            Math.Pow(y - node.Y, 2) / Math.Pow(node.Size.Height / 2, 2) < 1)
                        {
                            return IndexReturner(Nodes, node.ID);
                        }
                        break;
                   // case NodeType.hexagon: goto case NodeType.ellipse;
                    //    double alf = (node.Size.Height / 2) / (node.Size.Width / 4);
                    //    if (
                    //        (alf * (x + node.X) < (y - node.Y)) &&
                    //        (alf * (x + node.X) < (y + node.Y))&&
                    //        (alf * (x - node.X) < (y - node.Y))&&
                    //        (alf * (x - node.X) < (y + node.Y))
                    //        )
                    //    {
                    //        return IndexReturner(Nodes, node.ID);
                    //    }
                    //    break;

                }
            }
            return -1;
        }

        /// <summary>
        /// задает узлу новые координаты
        /// </summary>
        public void SetCoordsNode(int N, int x, int y)
        {
            Nodes[N].X = x; Nodes[N].Y = y;
            int IndexOFLinkedNode,
                NewTo;
            for (int i = 0; i < Nodes[N].LinksOnNodes.Length; i++)
            {
                IndexOFLinkedNode = IndexReturner(Edges, Nodes[N].LinksOnNodes[i]);
                CalculateFirstPoint(IndexOFLinkedNode, 0, N);
                CalculateSecondPoint(IndexOFLinkedNode, 0, N);
            }
            for (int i = 0; i < Nodes[N].LinksOnThisNode.Length; i++)
            {
                NewTo = IndexReturner(Edges, Nodes[N].LinksOnThisNode[i]);
                //N = IndexReturner(Nodes, Edges[NewTo].From);
                CalculateThirdPoint(NewTo, 0, N);
                CalculateFourthPoint(NewTo, 0, N);
            }
        }

        /// <summary>
        /// удаляет узел
        /// </summary>
        /// <param name="N"></param>
        public void DeleteNode(int N)
        {
            int indexEdge;
            int indexTo;
            int index1;
            for (int i = 0; i < Nodes[N].LinksOnNodes.Length; i++)
            {
                indexEdge = IndexReturner(Edges, Nodes[N].LinksOnNodes[i]);
                indexTo = IndexReturner(Nodes, Edges[indexEdge].To);
                index1 = IndexReturner(Nodes[indexTo].LinksOnThisNode, Nodes[N].LinksOnNodes[i]);
                for (; index1 < Nodes[indexTo].LinksOnThisNode.Length - 1; index1++)
                {
                    Nodes[indexTo].LinksOnThisNode[index1] = Nodes[indexTo].LinksOnThisNode[index1 + 1];
                }
                Array.Resize(ref Nodes[indexTo].LinksOnThisNode, Nodes[indexTo].LinksOnThisNode.Length - 1);

                for (; indexEdge < Edges.Length - 1; indexEdge++)
                {
                    Edges[indexEdge] = Edges[indexEdge + 1];
                }
                Array.Resize(ref Edges, Edges.Length - 1);
            }
            //с другим массивом
            int indexFrom;
            for (int i = 0; i < Nodes[N].LinksOnThisNode.Length; i++)
            {
                indexEdge = IndexReturner(Edges, Nodes[N].LinksOnThisNode[i]);
                indexFrom = IndexReturner(Nodes, Edges[indexEdge].From);
                index1 = IndexReturner(Nodes[indexFrom].LinksOnNodes, Nodes[N].LinksOnThisNode[i]);

                for (; index1 < Nodes[indexFrom].LinksOnNodes.Length - 1; index1++)
                {
                    Nodes[indexFrom].LinksOnNodes[index1] = Nodes[indexFrom].LinksOnNodes[index1 + 1];
                }
                Array.Resize(ref Nodes[indexFrom].LinksOnNodes, Nodes[indexFrom].LinksOnNodes.Length - 1);
                for (; indexEdge < Edges.Length - 1; indexEdge++)
                {
                    Edges[indexEdge] = Edges[indexEdge + 1];
                }
                Array.Resize(ref Edges, Edges.Length - 1);
            }

            for (; N < Nodes.Length - 1; N++)
            {
                Nodes[N] = Nodes[N + 1];
            }
            Array.Resize(ref Nodes, Nodes.Length - 1);
        }



        //методы для связей
        /// <summary>
        /// добавляет связь
        /// </summary>
        public void AddEdge(int NodeFrom, int NodeTo, string name, int x1, int x2)
        {
            {
                int N = Nodes.Length;
                N = Edges.Length;
                Array.Resize<Edge>(ref Edges, N + 1);
                Edges[N] = new Edge();
                Edges[N].ID = FreeIdEdge++;
                Edges[N].Name = name;
                Edges[N].ContourColor = Color.Black;
                Edges[N].StringColor = Color.Black;
                Edges[N].From = Nodes[NodeFrom].ID;
                Edges[N].To = Nodes[NodeTo].ID;
                Edges[N].Font = new Font("Times New Roman", 20);
                Edges[N].XFrom = x1 - Nodes[NodeFrom].X;//точка по x откуда было начато соединение
                Edges[N].XTo = x2 - Nodes[NodeTo].X;//где было закончено
                CalculatePointsEdge(N);

                int N1 = Nodes[NodeFrom].LinksOnNodes.Length;
                Array.Resize<int>(ref Nodes[NodeFrom].LinksOnNodes, N1 + 1);
                Nodes[NodeFrom].LinksOnNodes[N1] = Edges[N].ID;

                N1 = Nodes[NodeTo].LinksOnThisNode.Length;
                Array.Resize<int>(ref Nodes[NodeTo].LinksOnThisNode, N1 + 1);
                Nodes[NodeTo].LinksOnThisNode[N1] = Edges[N].ID;
            }
        }

        /// <summary>
        /// рассчитывает точки отрисовки ребра
        /// </summary>
        void CalculatePointsEdge(int N)
        {
            int higher = 1;
            int NewFrom = IndexReturner(Nodes, Edges[N].From),
                NewTo = IndexReturner(Nodes, Edges[N].To);
            if (Nodes[NewFrom].Y > Nodes[NewTo].Y)
            {
                higher *= -1;
            }
            //первая точка
            Edges[N].Coordinates.A1 = new Point(Nodes[NewFrom].X + Edges[N].XFrom, Nodes[NewFrom].Y +
                (int)(Nodes[NewFrom].Size.Height / 2 * higher));
            higher *= -1;
            int avg = Nodes[NewTo].Y + (Nodes[NewFrom].Y - Nodes[NewTo].Y) / 2;
            //вторая точка
            Edges[N].Coordinates.A2 = new Point(Nodes[NewFrom].X + Edges[N].XFrom, avg);
            //третья точка
            Edges[N].Coordinates.A3 = new Point(Nodes[NewTo].X + Edges[N].XTo, avg);
            //четвертая точка
            Edges[N].Coordinates.A4 = new Point(Nodes[NewTo].X + Edges[N].XTo, Nodes[NewTo].Y +
                (int)(Nodes[NewTo].Size.Height / 2 * higher));
        }

        /// <summary>
        /// рассчет первой точки
        /// </summary>
        /// <param name="NewXFrom">введите 0, если это передвижение узла</param>
        public void CalculateFirstPoint(int IndexLinkedNode, int NewXFrom, int NewFrom)
        {
            int higher = 1;
            if (Nodes[NewFrom].Y > Edges[IndexLinkedNode].Coordinates.A2.Y)
            {
                higher *= -1;
            }
            if (NewXFrom != 0)
            {
                Edges[IndexLinkedNode].XFrom = NewXFrom - Nodes[NewFrom].X;
            }
            Edges[IndexLinkedNode].Coordinates.A1 = new Point(Nodes[NewFrom].X + Edges[IndexLinkedNode].XFrom, Nodes[NewFrom].Y +
                (int)(Nodes[NewFrom].Size.Height / 2 * higher));
            //case NodeType.ellipse:
            //    //сделать ту же фигню и с эллипсом, пусть радиусом 25
            //    Edges[IndexLinkedNode].Coordinates.A1 = new Point(Edges[IndexLinkedNode].XFrom, Nodes[NewFrom].Y +
            //        (int)(Math.Sqrt(625 -
            //        Math.Pow(Edges[IndexLinkedNode].XFrom - Nodes[NewFrom].X, 2)) * higher));
            //    break;
        }

        /// <summary>
        /// рассчет второй точки
        /// </summary>
        /// <param name="NewYMiddle">введите 0, если это передвижение узла</param>
        public void CalculateSecondPoint(int N, int NewYMiddle, int NewFrom)
        {
            if (NewYMiddle == 0)
                NewYMiddle = Edges[N].Coordinates.A2.Y;
            Edges[N].Coordinates.A2 = new Point(Nodes[NewFrom].X + Edges[N].XFrom, NewYMiddle);
        }

        /// <summary>
        /// рассчет третьей точки
        /// </summary>
        /// <param name="N"></param>
        /// <param name="NewYMiddle"></param>
        public void CalculateThirdPoint(int N, int NewYMiddle, int NewTo)
        {
            if (NewYMiddle == 0)
                NewYMiddle = Edges[N].Coordinates.A3.Y;
            Edges[N].Coordinates.A3 = new Point(Nodes[NewTo].X + Edges[N].XTo, NewYMiddle);
        }

        /// <summary>
        /// рассчет четвертой точки
        /// </summary>
        /// <param name="N"></param>
        /// <param name="NewXTo"></param>
        void CalculateFourthPoint(int N, int NewXTo, int NewTo)
        {
            int higher = 1;
            if (Edges[N].Coordinates.A3.Y > Nodes[NewTo].Y)
            {
                higher *= -1;
            }
            higher *= -1;
            if (NewXTo != 0)
            {
                Edges[N].XTo = NewXTo - Nodes[NewTo].X;
            }
            Edges[N].Coordinates.A4 = new Point(Nodes[NewTo].X + Edges[N].XTo, Nodes[NewTo].Y +
                (int)(Nodes[NewTo].Size.Height / 2 * higher));
        }

        /// <summary>
        /// отрисовка граней
        /// </summary>
        void DrawEdges(Graphics g)
        {
            Pen contour = new Pen(new SolidBrush(Color.Black));
            SolidBrush str = new SolidBrush(Color.Black);
            for (int i = 0; i < Edges.Length; i++)
            {

                contour = new Pen(new SolidBrush(Edges[i].ContourColor));
                contour.Width = Edges[i].Width = ((int)Nodes[IndexReturner(Nodes, Edges[i].To)].Size.Height +
                    (int)Nodes[IndexReturner(Nodes, Edges[i].From)].Size.Height) / 20;
                str.Color = Edges[i].StringColor;
                g.DrawLine(contour, Edges[i].Coordinates.A1, Edges[i].Coordinates.A2);
                g.DrawLine(contour, Edges[i].Coordinates.A2, Edges[i].Coordinates.A3);
                g.DrawLine(contour, Edges[i].Coordinates.A3, Edges[i].Coordinates.A4);
                //стрелочки
                int a = (int)Nodes[IndexReturner(Nodes, Edges[i].To)].Size.Height/3;
                g.DrawLine(contour, Edges[i].Coordinates.A4, new Point(Edges[i].Coordinates.A4.X - a, Edges[i].Coordinates.A4.Y - (int)(a * 1.5) * Math.Sign(Edges[i].Coordinates.A4.Y - Edges[i].Coordinates.A3.Y)));
                g.DrawLine(contour, Edges[i].Coordinates.A4, new Point(Edges[i].Coordinates.A4.X + a, Edges[i].Coordinates.A4.Y - (int)(a * 1.5) * Math.Sign(Edges[i].Coordinates.A4.Y - Edges[i].Coordinates.A3.Y)));
                SizeF size = g.MeasureString(Edges[i].Name, Edges[i].Font);
                g.DrawString(Edges[i].Name, Edges[i].Font, str, Edges[i].Coordinates.A3.X + (Edges[i].Coordinates.A2.X - Edges[i].Coordinates.A3.X) / 2 - size.Width / 2, Edges[i].Coordinates.A2.Y - size.Height);
            }
        }

        /// <summary>
        /// находит грань по координатам
        /// </summary>
        public int[] FindEdge(int x, int y)
        {
            int[] mas = new int[2];
            mas[0] = -1;
            int a = 5;
            for (int i = 0; i < Edges.Length; i++)
            {
                if (Edges[i].Width* 2 > 2) a = Edges[i].Width;
                if (Math.Abs(Edges[i].Coordinates.A1.X - x) < a &&
                    ((Edges[i].Coordinates.A1.Y > y && Edges[i].Coordinates.A2.Y < y)
                    || (Edges[i].Coordinates.A1.Y < y && Edges[i].Coordinates.A2.Y > y)))
                {
                    mas[0] = i; mas[1] = 0;
                    return mas;
                }

                if (Math.Abs(Edges[i].Coordinates.A2.Y - y) < a &&
                    ((Edges[i].Coordinates.A2.X > x && Edges[i].Coordinates.A3.X < x) ||
                    (Edges[i].Coordinates.A2.X < x && Edges[i].Coordinates.A3.X > x)))
                {
                    mas[0] = i; mas[1] = 1;
                    return mas;
                }

                if (Math.Abs(Edges[i].Coordinates.A3.X - x) < a &&
                    ((Edges[i].Coordinates.A3.Y > y && Edges[i].Coordinates.A4.Y < y) ||
                    (Edges[i].Coordinates.A3.Y < y && Edges[i].Coordinates.A4.Y > y)))
                {
                    mas[0] = i; mas[1] = 2;
                    return mas;
                }
            }
            return mas;
        }

        /// <summary>
        /// задает грани новые координаты
        /// </summary>
        /// <param name="mas"></param>
        public void SetCoordsEdge(int[] mas, int x, int y)
        {
            //mas[0] = IndexReturner(Edges, mas[0]);
            int NewFrom = IndexReturner(Nodes, Edges[mas[0]].From),
                NewTo = IndexReturner(Nodes, Edges[mas[0]].To);
            switch (mas[1])
            {
                case 0:
                    if (Math.Abs(x - Nodes[NewFrom].X) < Nodes[NewFrom].Size.Width / 2)
                    {
                        CalculateFirstPoint(mas[0], x, NewFrom);
                        CalculateSecondPoint(mas[0], 0, NewFrom);
                    }
                    break;
                case 1:
                    CalculateSecondPoint(mas[0], y, NewFrom);
                    CalculateThirdPoint(mas[0], y, NewTo);
                    CalculateFirstPoint(mas[0], 0, NewFrom);
                    CalculateFourthPoint(mas[0], 0, NewTo);
                    break;
                case 2:
                    if (Math.Abs(x - Nodes[NewTo].X) < Nodes[NewTo].Size.Width / 2)
                    {
                        CalculateFourthPoint(mas[0], x, NewTo);
                        CalculateThirdPoint(mas[0], 0, NewTo);
                    }
                    break;
            }
        }

        /// <summary>
        /// удаляет грань
        /// </summary>
        /// <param name="N"></param>
        public void DeleteEdge(int N)
        {
            //int ID = IndexReturner(Edges, ID);
            int indexFrom = IndexReturner(Nodes, Edges[N].From);
            int index1 = IndexReturner(Nodes[indexFrom].LinksOnNodes, Edges[N].ID);
            for (; index1 < Nodes[indexFrom].LinksOnNodes.Length - 1; index1++)
            {
                Nodes[indexFrom].LinksOnNodes[index1] = Nodes[indexFrom].LinksOnNodes[index1 + 1];
            }
            Array.Resize(ref Nodes[indexFrom].LinksOnNodes, Nodes[indexFrom].LinksOnNodes.Length - 1);


            int indexTo = IndexReturner(Nodes, Edges[N].To);
            index1 = IndexReturner(Nodes[indexTo].LinksOnThisNode, Edges[N].ID);
            for (; index1 < Nodes[indexTo].LinksOnThisNode.Length - 1; index1++)
            {
                Nodes[indexTo].LinksOnThisNode[index1] = Nodes[indexTo].LinksOnThisNode[index1 + 1];
            }
            Array.Resize(ref Nodes[indexTo].LinksOnThisNode, Nodes[indexTo].LinksOnThisNode.Length - 1);

            for (; N < Edges.Length - 1; N++)
            {
                Edges[N] = Edges[N + 1];
            }
            Array.Resize(ref Edges, Edges.Length - 1);
        }


        //общие методы
        /// <summary>
        /// зарисовывает bitmap
        /// </summary>
        public Image Drawing()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                DrawNodes(g);
                DrawEdges(g);
                //DrawCursor(g);
                if (line) DrawLine(g);
                DrawInterface(g);
            }
            return bitmap;
        }

        /// <summary>
        /// для определения размеров текста на поле
        /// </summary>
        private void FalseDrawing()
        {
            using (Graphics g = Graphics.FromImage(btmTest))
            {
                DrawNodes(g);
                g.Clear(Color.White);
            }
        }

        /// <summary>
        /// отриосвка линии при создании грани
        /// </summary>
        private void DrawLine(Graphics g)
        {

            //int NewStartNode = IndexReturner(Nodes, startNode);
            if (startNode != -1)
            {
                g.DrawLine(Pens.Black, xForLine, Nodes[startNode].Y, cursorPoint.X, cursorPoint.Y);
            }
        }

        /// <summary>
        /// отрисовка курсора
        /// </summary>
        public void DrawCursor(Graphics g)
        {
            switch (EC)
            {
                case EditCursor.usual: break;
                case EditCursor.addE:
                    g.DrawLine(Pens.Black, cursorPoint.X + 10, cursorPoint.Y + 15,
                        cursorPoint.X + 20, cursorPoint.Y + 15);
                    g.DrawLine(Pens.Black, cursorPoint.X + 15, cursorPoint.Y + 10,
                        cursorPoint.X + 15, cursorPoint.Y + 20);
                    break;
                case EditCursor.delete:
                    g.DrawLine(Pens.Black, cursorPoint.X + 10, cursorPoint.Y + 10,
                        cursorPoint.X + 20, cursorPoint.Y + 20);
                    g.DrawLine(Pens.Black, cursorPoint.X + 10, cursorPoint.Y + 20,
                        cursorPoint.X + 20, cursorPoint.Y + 10);
                    break;
            }
        }

        /// <summary>
        /// отрисовка интерфейса
        /// </summary>
        /// <param name="g"></param>
        public void DrawInterface(Graphics g)
        {
            string s = "";
            switch (EC)
            {
                case EditCursor.addN:
                    s = "создание объекта";
                    break;
                case EditCursor.addE:
                    s = "создание связи";
                    break;
                case EditCursor.delete:
                    s = "удаление";
                    break;
                case EditCursor.usual:
                    s = "передвижение";
                    break;
            }
            g.DrawString("Выбранно " + s, new Font("Times New Roman", 10),
                Brushes.Black, 5, 30);
        }

        /// <summary>
        /// находит указанный элемент массива, возвращая его индекс в массиве
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="N"></param>
        int IndexReturner(Edge[] mas, int ID)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].ID == ID)
                    return i;
            }
            return -1;
        }
        int IndexReturner(Node[] mas, int ID)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].ID == ID)
                    return i;
            }
            return -1;
        }
        int IndexReturner(int[] mas, int ID)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == ID)
                    return i;
            }
            return -1;
        }

        //методы для передачи свойств

    }
}
