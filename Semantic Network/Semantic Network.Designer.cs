namespace Semantic_Network
{
    partial class SM
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuMove = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PropColorDialog = new System.Windows.Forms.ColorDialog();
            this.PropPanel = new System.Windows.Forms.Panel();
            this.PropMainLabel = new System.Windows.Forms.Label();
            this.PropBackgroundColorButton = new System.Windows.Forms.Button();
            this.PropBackgroundColorLabel = new System.Windows.Forms.Label();
            this.PropTypeLabel = new System.Windows.Forms.Label();
            this.PropTypeBox = new System.Windows.Forms.ComboBox();
            this.PropFontColorLabel = new System.Windows.Forms.Label();
            this.PropFontLabel = new System.Windows.Forms.Label();
            this.PropFontColorButton = new System.Windows.Forms.Button();
            this.PropContourColorButton = new System.Windows.Forms.Button();
            this.PropFontButton = new System.Windows.Forms.Button();
            this.PropContourColorLabel = new System.Windows.Forms.Label();
            this.PropNameBox = new System.Windows.Forms.TextBox();
            this.PropNameLabel = new System.Windows.Forms.Label();
            this.PropIDLabel = new System.Windows.Forms.Label();
            this.PropFontDialog = new System.Windows.Forms.FontDialog();
            this.листингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainMenu.SuspendLayout();
            this.PropPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMove,
            this.MenuAdd,
            this.MenuDelete,
            this.очиститьВсеToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1284, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Menu";
            // 
            // MenuMove
            // 
            this.MenuMove.Name = "MenuMove";
            this.MenuMove.Size = new System.Drawing.Size(88, 20);
            this.MenuMove.Text = "Передвигать";
            this.MenuMove.Click += new System.EventHandler(this.MenuMove_Click);
            // 
            // MenuAdd
            // 
            this.MenuAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddNode,
            this.MenuAddEdge,
            this.листингToolStripMenuItem});
            this.MenuAdd.Name = "MenuAdd";
            this.MenuAdd.Size = new System.Drawing.Size(71, 20);
            this.MenuAdd.Text = "Добавить";
            this.MenuAdd.Click += new System.EventHandler(this.MenuAdd_Click);
            // 
            // MenuAddNode
            // 
            this.MenuAddNode.Name = "MenuAddNode";
            this.MenuAddNode.Size = new System.Drawing.Size(152, 22);
            this.MenuAddNode.Text = "Сущность";
            this.MenuAddNode.Click += new System.EventHandler(this.MenuAddNode_Click);
            // 
            // MenuAddEdge
            // 
            this.MenuAddEdge.Name = "MenuAddEdge";
            this.MenuAddEdge.Size = new System.Drawing.Size(152, 22);
            this.MenuAddEdge.Text = "Связь";
            this.MenuAddEdge.Click += new System.EventHandler(this.MenuAddEdge_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(63, 20);
            this.MenuDelete.Text = "Удалить";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // очиститьВсеToolStripMenuItem
            // 
            this.очиститьВсеToolStripMenuItem.Name = "очиститьВсеToolStripMenuItem";
            this.очиститьВсеToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.очиститьВсеToolStripMenuItem.Text = "Очистить все";
            this.очиститьВсеToolStripMenuItem.Click += new System.EventHandler(this.ClearAll);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 54);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 1;
            this.NameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameBox_KeyDown);
            // 
            // PropPanel
            // 
            this.PropPanel.Controls.Add(this.PropMainLabel);
            this.PropPanel.Controls.Add(this.PropBackgroundColorButton);
            this.PropPanel.Controls.Add(this.PropBackgroundColorLabel);
            this.PropPanel.Controls.Add(this.PropTypeLabel);
            this.PropPanel.Controls.Add(this.PropTypeBox);
            this.PropPanel.Controls.Add(this.PropFontColorLabel);
            this.PropPanel.Controls.Add(this.PropFontLabel);
            this.PropPanel.Controls.Add(this.PropFontColorButton);
            this.PropPanel.Controls.Add(this.PropContourColorButton);
            this.PropPanel.Controls.Add(this.PropFontButton);
            this.PropPanel.Controls.Add(this.PropContourColorLabel);
            this.PropPanel.Controls.Add(this.PropNameBox);
            this.PropPanel.Controls.Add(this.PropNameLabel);
            this.PropPanel.Controls.Add(this.PropIDLabel);
            this.PropPanel.Location = new System.Drawing.Point(1143, 27);
            this.PropPanel.Name = "PropPanel";
            this.PropPanel.Size = new System.Drawing.Size(129, 314);
            this.PropPanel.TabIndex = 2;
            // 
            // PropMainLabel
            // 
            this.PropMainLabel.AutoSize = true;
            this.PropMainLabel.Location = new System.Drawing.Point(3, 7);
            this.PropMainLabel.Name = "PropMainLabel";
            this.PropMainLabel.Size = new System.Drawing.Size(92, 13);
            this.PropMainLabel.TabIndex = 13;
            this.PropMainLabel.Text = "Параметры узла";
            // 
            // PropBackgroundColorButton
            // 
            this.PropBackgroundColorButton.Location = new System.Drawing.Point(3, 243);
            this.PropBackgroundColorButton.Name = "PropBackgroundColorButton";
            this.PropBackgroundColorButton.Size = new System.Drawing.Size(123, 23);
            this.PropBackgroundColorButton.TabIndex = 12;
            this.PropBackgroundColorButton.UseVisualStyleBackColor = true;
            this.PropBackgroundColorButton.Click += new System.EventHandler(this.PropBackgroundColorButton_Click);
            // 
            // PropBackgroundColorLabel
            // 
            this.PropBackgroundColorLabel.AutoSize = true;
            this.PropBackgroundColorLabel.Location = new System.Drawing.Point(3, 227);
            this.PropBackgroundColorLabel.Name = "PropBackgroundColorLabel";
            this.PropBackgroundColorLabel.Size = new System.Drawing.Size(77, 13);
            this.PropBackgroundColorLabel.TabIndex = 11;
            this.PropBackgroundColorLabel.Text = "Цвет заливки";
            // 
            // PropTypeLabel
            // 
            this.PropTypeLabel.AutoSize = true;
            this.PropTypeLabel.Location = new System.Drawing.Point(3, 269);
            this.PropTypeLabel.Name = "PropTypeLabel";
            this.PropTypeLabel.Size = new System.Drawing.Size(26, 13);
            this.PropTypeLabel.TabIndex = 9;
            this.PropTypeLabel.Text = "Тип";
            // 
            // PropTypeBox
            // 
            this.PropTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PropTypeBox.FormattingEnabled = true;
            this.PropTypeBox.Items.AddRange(new object[] {
            "Прямоугольник",
            "Эллипс",
            "Ромб",
            "Шестиугольник"});
            this.PropTypeBox.Location = new System.Drawing.Point(3, 285);
            this.PropTypeBox.Name = "PropTypeBox";
            this.PropTypeBox.Size = new System.Drawing.Size(123, 21);
            this.PropTypeBox.TabIndex = 8;
            this.PropTypeBox.SelectionChangeCommitted += new System.EventHandler(this.PropTypeBox_SelectionChangeCommitted);
            // 
            // PropFontColorLabel
            // 
            this.PropFontColorLabel.AutoSize = true;
            this.PropFontColorLabel.Location = new System.Drawing.Point(3, 140);
            this.PropFontColorLabel.Name = "PropFontColorLabel";
            this.PropFontColorLabel.Size = new System.Drawing.Size(74, 13);
            this.PropFontColorLabel.TabIndex = 10;
            this.PropFontColorLabel.Text = "Цвет шрифта";
            // 
            // PropFontLabel
            // 
            this.PropFontLabel.AutoSize = true;
            this.PropFontLabel.Location = new System.Drawing.Point(3, 96);
            this.PropFontLabel.Name = "PropFontLabel";
            this.PropFontLabel.Size = new System.Drawing.Size(41, 13);
            this.PropFontLabel.TabIndex = 7;
            this.PropFontLabel.Text = "Шрифт";
            // 
            // PropFontColorButton
            // 
            this.PropFontColorButton.Location = new System.Drawing.Point(3, 156);
            this.PropFontColorButton.Name = "PropFontColorButton";
            this.PropFontColorButton.Size = new System.Drawing.Size(123, 23);
            this.PropFontColorButton.TabIndex = 6;
            this.PropFontColorButton.UseVisualStyleBackColor = true;
            this.PropFontColorButton.Click += new System.EventHandler(this.PropFontColorButton_Click);
            // 
            // PropContourColorButton
            // 
            this.PropContourColorButton.Location = new System.Drawing.Point(3, 198);
            this.PropContourColorButton.Name = "PropContourColorButton";
            this.PropContourColorButton.Size = new System.Drawing.Size(123, 23);
            this.PropContourColorButton.TabIndex = 5;
            this.PropContourColorButton.UseVisualStyleBackColor = true;
            this.PropContourColorButton.Click += new System.EventHandler(this.PropContourColorButton_Click);
            // 
            // PropFontButton
            // 
            this.PropFontButton.Location = new System.Drawing.Point(3, 114);
            this.PropFontButton.Name = "PropFontButton";
            this.PropFontButton.Size = new System.Drawing.Size(123, 23);
            this.PropFontButton.TabIndex = 4;
            this.PropFontButton.UseVisualStyleBackColor = true;
            this.PropFontButton.Click += new System.EventHandler(this.PropFontButton_Click);
            // 
            // PropContourColorLabel
            // 
            this.PropContourColorLabel.AutoSize = true;
            this.PropContourColorLabel.Location = new System.Drawing.Point(3, 182);
            this.PropContourColorLabel.Name = "PropContourColorLabel";
            this.PropContourColorLabel.Size = new System.Drawing.Size(77, 13);
            this.PropContourColorLabel.TabIndex = 3;
            this.PropContourColorLabel.Text = "Цвет обводки";
            // 
            // PropNameBox
            // 
            this.PropNameBox.Location = new System.Drawing.Point(3, 72);
            this.PropNameBox.Name = "PropNameBox";
            this.PropNameBox.Size = new System.Drawing.Size(123, 20);
            this.PropNameBox.TabIndex = 2;
            this.PropNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PropNameBox_KeyDown);
            // 
            // PropNameLabel
            // 
            this.PropNameLabel.AutoSize = true;
            this.PropNameLabel.Location = new System.Drawing.Point(3, 56);
            this.PropNameLabel.Name = "PropNameLabel";
            this.PropNameLabel.Size = new System.Drawing.Size(29, 13);
            this.PropNameLabel.TabIndex = 1;
            this.PropNameLabel.Text = "Имя";
            // 
            // PropIDLabel
            // 
            this.PropIDLabel.AutoSize = true;
            this.PropIDLabel.Location = new System.Drawing.Point(3, 34);
            this.PropIDLabel.Name = "PropIDLabel";
            this.PropIDLabel.Size = new System.Drawing.Size(18, 13);
            this.PropIDLabel.TabIndex = 0;
            this.PropIDLabel.Text = "ID";
            // 
            // листингToolStripMenuItem
            // 
            this.листингToolStripMenuItem.Name = "листингToolStripMenuItem";
            this.листингToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.листингToolStripMenuItem.Text = "Листинг";
            this.листингToolStripMenuItem.Click += new System.EventHandler(this.листингToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            this.contextMenuStrip1.Resize += new System.EventHandler(this.contextMenuStrip1_Resize);
            // 
            // SM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.PropPanel);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "SM";
            this.Text = "Semantic Network";
            this.Load += new System.EventHandler(this.SM_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SM_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SM_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SM_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SM_MouseUp);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.PropPanel.ResumeLayout(false);
            this.PropPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem очиститьВсеToolStripMenuItem;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.ToolStripMenuItem MenuMove;
        private System.Windows.Forms.ToolStripMenuItem MenuAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNode;
        private System.Windows.Forms.ToolStripMenuItem MenuAddEdge;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.ColorDialog PropColorDialog;
        private System.Windows.Forms.Panel PropPanel;
        private System.Windows.Forms.Label PropIDLabel;
        private System.Windows.Forms.TextBox PropNameBox;
        private System.Windows.Forms.Label PropNameLabel;
        private System.Windows.Forms.Button PropFontColorButton;
        private System.Windows.Forms.Button PropContourColorButton;
        private System.Windows.Forms.Button PropFontButton;
        private System.Windows.Forms.Label PropContourColorLabel;
        private System.Windows.Forms.Label PropFontLabel;
        private System.Windows.Forms.FontDialog PropFontDialog;
        private System.Windows.Forms.Label PropTypeLabel;
        private System.Windows.Forms.ComboBox PropTypeBox;
        private System.Windows.Forms.Label PropFontColorLabel;
        private System.Windows.Forms.Button PropBackgroundColorButton;
        private System.Windows.Forms.Label PropBackgroundColorLabel;
        private System.Windows.Forms.Label PropMainLabel;
        private System.Windows.Forms.ToolStripMenuItem листингToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

