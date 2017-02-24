using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semantic_Network
{
    public partial class SM : Form
    {
        SNGraph[] graphes;
        SNGraph graph;
        Graphics g;
        EditChooser edit;
        bool isDown;

        //переменные для движения
        int NumNodeMove;
        int[] NumEdgeMove;

        //для создания узла
        int XNode, YNode;

        //для создания ребра
        int XFrom, XTo;

        //переменные для удаления
        int[] NumEdgeDelete;
        int NumNodeDelete;

        //переменные для окна настройки
        int NumEdgeProp;
        int NumNodeProp;

        public SM()
        {
            InitializeComponent();
            isDown = false;
        }

        private void SM_Load(object sender, EventArgs e)
        {
            graph = new SNGraph(ClientRectangle.Width, ClientRectangle.Height);
            g = CreateGraphics();
            edit = EditChooser.move;
            AbleNameBox(false, 0, 0);
            PropPanel.Enabled = PropPanel.Visible = false;
            graph.AddNode(200, 200, "Король");
            graph.AddNode(400, 400, "Вассал");
            graph.AddNode(600, 200, "Корова");
            graph.AddNode(700, 300, "Крестьянин");
            graph.AddEdge(1, 0, "Подчиняется", 395, 205);
            graph.AddEdge(1, 2, "Владеет", 405, 595);
            graph.AddEdge(1, 3, "Владеет", 420, 695);
        }

        private void Draw()
        {
            g.DrawImage(graph.Drawing(), 0, 0);
        }

        private void SM_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        //Меню-----------------------------------------------------------
        private void ClearAll(object sender, EventArgs e)
        {
            graph = new SNGraph(ClientRectangle.Width, ClientRectangle.Height);
            Draw();
        }

        private void MenuMove_Click(object sender, EventArgs e)
        {
            edit = EditChooser.move;
            graph.EC = EditCursor.usual;
        }

        private void MenuAddNode_Click(object sender, EventArgs e)
        {
            edit = EditChooser.addNode;
            graph.EC = EditCursor.addN;
        }

        private void MenuAddEdge_Click(object sender, EventArgs e)
        {
            edit = EditChooser.addEdge;
            graph.EC = EditCursor.addE;
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            edit = EditChooser.delete;
            graph.EC = EditCursor.delete;
        }
        //---------------------------------------------------------------

        /// <summary>
        /// активирование/выключение текстбокса
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void AbleNameBox(bool enable, int x, int y)
        {
            if (enable)
            {
                NameBox.Enabled = NameBox.Visible = true;
                NameBox.Left = x; NameBox.Top = y;
                NameBox.Focus();
            }
            else
                NameBox.Enabled = NameBox.Visible = false;
        }

        //Окно настройки-------------------------------------------------
        private void SM_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                if (edit == EditChooser.propEdge || edit == EditChooser.propNode)
                {
                    edit = EditChooser.move;
                    MainMenu.Enabled = true;
                    PropPanel.Visible = PropPanel.Enabled = false;
                }
                isDown = true;
                switch (edit)
                {
                    case EditChooser.addEdge:
                        MainMenu.Enabled = false;
                        int NumNode = graph.FindNode(e.X, e.Y);
                        if (NumNode != -1)
                        {
                            graph.XForLine = XFrom = e.X;
                            graph.StartNode = NumNode;
                            graph.Line = true;
                        }
                        break;
                    case EditChooser.move:
                        NumNodeMove = graph.FindNode(e.X, e.Y);
                        if (NumNodeMove == -1)
                        {
                            NumEdgeMove = graph.FindEdge(e.X, e.Y);
                        }
                        break;
                }
            }
            Draw();
        }

        private void SM_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                NumNodeProp = graph.FindNode(e.X, e.Y);
                if (NumNodeProp == -1)
                {
                    NumEdgeProp = graph.FindEdge(e.X, e.Y)[0];
                    if (NumEdgeProp != -1)
                        PropertyForEdge();
                }
                else
                {
                    PropertyForNode();
                }
            }
            else
            {
                isDown = false;
                graph.Line = false;
                switch (edit)
                {
                    case EditChooser.addEdge:

                        int NumNode = graph.FindNode(e.X, e.Y);
                        if (NumNode != -1)
                        {
                            XTo = e.X;
                            graph.EndNode = NumNode;
                            AbleNameBox(true, e.X - 30, e.Y - 10);
                            edit = EditChooser.creationEdge;
                        }
                        else
                        {
                            MainMenu.Enabled = true;
                            XFrom = 0;
                            graph.StartNode = 0;

                        }
                        break;
                    case EditChooser.addNode:
                        MainMenu.Enabled = false;
                        XNode = e.X; YNode = e.Y;
                        AbleNameBox(true, e.X - 30, e.Y - 10);
                        edit = EditChooser.creationNode;
                        break;
                    case EditChooser.delete:
                        NumNodeDelete = graph.FindNode(e.X, e.Y);
                        if (NumNodeDelete != -1)
                            graph.DeleteNode(NumNodeDelete);
                        else
                        {
                            NumEdgeDelete = graph.FindEdge(e.X, e.Y);
                            if (NumEdgeDelete[0] != -1)
                            {
                                graph.DeleteEdge(NumEdgeDelete[0]);
                            }
                        }
                        break;
                }
                
            }
            Draw();
        }

        private void SM_MouseMove(object sender, MouseEventArgs e)
        {
            
            switch (edit)
            {
                case EditChooser.addEdge:
                    
                    break;
                case EditChooser.move:
                    if (isDown && NumNodeMove > -1)
                    {
                        graph.SetCoordsNode(NumNodeMove, e.X, e.Y);
                    }
                    else
                    {
                        if (isDown && NumEdgeMove[0] > -1)
                        {
                            graph.SetCoordsEdge(NumEdgeMove, e.X, e.Y);
                        }
                    }
                    break;
                case EditChooser.delete:
                    break;
            }
            graph.CursorPoint = new Point(e.X, e.Y);
            Draw();
        }

        private void NameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (edit)
                {
                    case EditChooser.creationNode:
                        if (NameBox.Text.Replace(" ", "") == "")
                        {
                            MainMenu.Enabled = true;
                            XNode = YNode = 0;
                            AbleNameBox(false, 0, 0);
                            edit = EditChooser.addNode;
                            NameBox.Text = "";
                        }
                        else
                        {
                            graph.AddNode(XNode, YNode, NameBox.Text);
                            MainMenu.Enabled = true;
                            XNode = YNode = 0;
                            AbleNameBox(false, 0, 0);
                            edit = EditChooser.addNode;
                            NameBox.Text = "";
                        }
                        break;
                    case EditChooser.creationEdge:
                        if (NameBox.Text.Replace(" ", "") == "")
                        {
                            MainMenu.Enabled = true;
                            XFrom = 0; XTo = 0;
                            graph.StartNode = 0; graph.EndNode = 0;
                            AbleNameBox(false, 0, 0);
                            edit = EditChooser.addEdge;
                            NameBox.Text = "";
                        }
                        else
                        {
                            graph.AddEdge(graph.StartNode, graph.EndNode, NameBox.Text, XFrom, XTo);
                            MainMenu.Enabled = true;
                            XFrom = 0; XTo = 0;
                            graph.StartNode = 0; graph.EndNode = 0;
                            AbleNameBox(false, 0, 0);
                            edit = EditChooser.addEdge;
                            NameBox.Text = "";
                        }
                        break;
                }
            }
        }

        private void PropNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (edit)
                {
                    case EditChooser.propEdge:
                        if (PropNameBox.Text.Replace(" ", "") != "")
                            graph.Edges[NumEdgeProp].Name = PropNameBox.Text;
                        else
                            PropNameBox.Text = graph.Edges[NumEdgeProp].Name;
                        break;
                    case EditChooser.propNode:
                        if (PropNameBox.Text.Replace(" ", "") != "")
                            graph.Nodes[NumNodeProp].Name = PropNameBox.Text;
                        else
                            PropNameBox.Text = graph.Nodes[NumNodeProp].Name;
                        break;
                }
                Draw();
            }
        }

        private void PropFontButton_Click(object sender, EventArgs e)
        {
            switch (edit)
            {
                case EditChooser.propEdge:
                    PropFontDialog.ShowDialog();
                    graph.Edges[NumEdgeProp].Font = PropFontDialog.Font;
                    PropFontButton.Text = graph.Edges[NumEdgeProp].Font.Name + "," +
                graph.Edges[NumEdgeProp].Font.Size.ToString();
                    break;
                case EditChooser.propNode:
                    PropFontDialog.ShowDialog();
                    graph.Nodes[NumNodeProp].Font = PropFontDialog.Font;
                    PropFontButton.Text = graph.Nodes[NumNodeProp].Font.Name + "," +
                graph.Nodes[NumNodeProp].Font.Size.ToString();
                    break;
            }
            Draw();
        }

        private void PropFontColorButton_Click(object sender, EventArgs e)
        {
            switch (edit)
            {
                case EditChooser.propEdge:
                    PropColorDialog.ShowDialog();
                    graph.Edges[NumEdgeProp].StringColor = PropColorDialog.Color;
                    PropFontColorButton.BackColor = PropColorDialog.Color;
                    break;
                case EditChooser.propNode:
                    PropColorDialog.ShowDialog();
                    graph.Nodes[NumNodeProp].StringColor = PropColorDialog.Color;
                    PropFontColorButton.BackColor = PropColorDialog.Color;
                    break;
            }
            Draw();
        }

        private void PropContourColorButton_Click(object sender, EventArgs e)
        {
            switch (edit)
            {
                case EditChooser.propEdge:
                    PropColorDialog.ShowDialog();
                    graph.Edges[NumEdgeProp].ContourColor = PropColorDialog.Color;
                    PropContourColorButton.BackColor = PropColorDialog.Color;
                    break;
                case EditChooser.propNode:
                    PropColorDialog.ShowDialog();
                    graph.Nodes[NumNodeProp].ContourColor = PropColorDialog.Color;
                    PropContourColorButton.BackColor = PropColorDialog.Color;
                    break;
            }
            Draw();
        }

        private void PropBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (edit == EditChooser.propNode)
            {
                    PropColorDialog.ShowDialog();
                    graph.Nodes[NumNodeProp].BackgroundColor = PropColorDialog.Color;
                    PropBackgroundColorButton.BackColor = PropColorDialog.Color;
            }
            Draw();
        }

        private void PropTypeBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (edit == EditChooser.propNode)
            {
                if (PropTypeBox.SelectedItem == PropTypeBox.Items[0])
                {
                    graph.Nodes[NumNodeProp].type = NodeType.rectangle;
                }
                if (PropTypeBox.SelectedItem == PropTypeBox.Items[1])
                {
                    graph.Nodes[NumNodeProp].type = NodeType.ellipse;
                }
                if (PropTypeBox.SelectedItem == PropTypeBox.Items[2])
                {
                    graph.Nodes[NumNodeProp].type = NodeType.rhombus;
                }
                if (PropTypeBox.SelectedItem == PropTypeBox.Items[3])
                {
                    graph.Nodes[NumNodeProp].type = NodeType.hexagon;
                }

            }
            Draw();
        }

        private void MenuAdd_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void листингToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Resize(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// отображение свойств узла
        /// </summary>
        void PropertyForNode()
        {
            edit = EditChooser.propNode;
            MainMenu.Enabled = false;
            PropPanel.Enabled = PropPanel.Visible = true;

            PropMainLabel.Text = "Параметры объекта";
            PropIDLabel.Text = "ID_" + graph.Nodes[NumNodeProp].ID;
            PropNameBox.Text = graph.Nodes[NumNodeProp].Name;
            PropFontButton.Text = graph.Nodes[NumNodeProp].Font.Name + "," +
                graph.Nodes[NumNodeProp].Font.Size.ToString();
            PropFontColorButton.BackColor = graph.Nodes[NumNodeProp].StringColor;
            PropContourColorButton.BackColor = graph.Nodes[NumNodeProp].ContourColor;

            PropTypeLabel.Enabled = PropTypeLabel.Visible = true;
            PropTypeBox.Enabled = PropTypeBox.Visible = true;
            switch (graph.Nodes[NumNodeProp].type)
            {
                case NodeType.rectangle: PropTypeBox.SelectedItem = PropTypeBox.Items[0]; break;
                case NodeType.ellipse: PropTypeBox.SelectedItem = PropTypeBox.Items[1]; break;
            }
            PropBackgroundColorLabel.Enabled = PropBackgroundColorLabel.Visible = true;
            PropBackgroundColorButton.Enabled = PropBackgroundColorButton.Visible = true;
            PropBackgroundColorButton.BackColor = graph.Nodes[NumNodeProp].BackgroundColor;

           
        }

        /// <summary>
        /// отображение свойств грани
        /// </summary>
        void PropertyForEdge()
        {
            edit = EditChooser.propEdge;
            MainMenu.Enabled = false;
            PropPanel.Enabled = PropPanel.Visible = true;

            PropMainLabel.Text = "Параметры связи";
            PropIDLabel.Text = "ID_" + graph.Edges[NumEdgeProp].ID;
            PropNameBox.Text = graph.Edges[NumEdgeProp].Name;
            PropFontButton.Text = graph.Edges[NumEdgeProp].Font.Name + "," +
                graph.Edges[NumEdgeProp].Font.Size.ToString();
            PropFontColorButton.BackColor = graph.Edges[NumEdgeProp].StringColor;
            PropContourColorButton.BackColor = graph.Edges[NumEdgeProp].ContourColor;

            PropTypeLabel.Enabled = PropTypeLabel.Visible = false;
            PropTypeBox.Enabled = PropTypeBox.Visible = false;
            PropBackgroundColorLabel.Enabled = PropBackgroundColorLabel.Visible = false;
            PropBackgroundColorButton.Enabled = PropBackgroundColorButton.Visible = false;
        }
        //----------------------------------------------------------------
    }
}
