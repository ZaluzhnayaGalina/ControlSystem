using System.Windows.Forms;

namespace ControlSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вопросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстовыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графическийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сВариантамиОтветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.безВариантовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формулаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьПользователяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПользователейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.createTopic = new System.Windows.Forms.TabPage();
            this.topiсCountTextBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cancelTopicButton = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.topicTimeTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.addTopicButton = new System.Windows.Forms.Button();
            this.topicNameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.createTextQue = new System.Windows.Forms.TabPage();
            this.cancelTextQuestionButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.firstAnswerTextQueRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.delAnswBut = new System.Windows.Forms.Button();
            this.firstPointsTextQueTextBox1 = new System.Windows.Forms.TextBox();
            this.addAnswBut = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addTextQuestionButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textQuestionTextBox = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.testing = new System.Windows.Forms.TabPage();
            this.EndButton = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.courseTestingComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.topicTestingComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.createGrafWithoutVarQue = new System.Windows.Forms.TabPage();
            this.unvisiblePointsButton = new System.Windows.Forms.Button();
            this.addPoint = new System.Windows.Forms.Button();
            this.deletePoint = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.axisYmaxBox = new System.Windows.Forms.TextBox();
            this.axisYminBox = new System.Windows.Forms.TextBox();
            this.axisXmaxBox = new System.Windows.Forms.TextBox();
            this.axisXminBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxGraphTypeWithoutWar = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cancelGraphWithoutWarButton = new System.Windows.Forms.Button();
            this.addGraphWithoutWarButton = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.labelCoordinates = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.createGrafWithVarQue = new System.Windows.Forms.TabPage();
            this.unvisiblePointsButtonWar = new System.Windows.Forms.Button();
            this.addPointWar = new System.Windows.Forms.Button();
            this.deletePointWar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.axisYmaxBoxWar = new System.Windows.Forms.TextBox();
            this.axisYminBoxWar = new System.Windows.Forms.TextBox();
            this.axisXmaxBoxWar = new System.Windows.Forms.TextBox();
            this.axisXminBoxWar = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.addVarGraph = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cancelGraphWithWarButton = new System.Windows.Forms.Button();
            this.addGraphWithWarButton = new System.Windows.Forms.Button();
            this.resetWar = new System.Windows.Forms.Button();
            this.labelCoordinatesWar = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.createCourse = new System.Windows.Forms.TabPage();
            this.cancelCourseButton = new System.Windows.Forms.Button();
            this.addCourseButton = new System.Windows.Forms.Button();
            this.courseNameTextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.showTopics = new System.Windows.Forms.TabPage();
            this.closeCoursesAndTopicsButton = new System.Windows.Forms.Button();
            this.coursesAndTopicsTreeView = new System.Windows.Forms.TreeView();
            this.results = new System.Windows.Forms.TabPage();
            this.closeResultsButton = new System.Windows.Forms.Button();
            this.resultsTreeView = new System.Windows.Forms.TreeView();
            this.createFormula = new System.Windows.Forms.TabPage();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBoxFormula = new System.Windows.Forms.PictureBox();
            this.buttonInputFormula = new System.Windows.Forms.Button();
            this.buttonCancelFormula = new System.Windows.Forms.Button();
            this.buttonAddFormula = new System.Windows.Forms.Button();
            this.coursesFormulaComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.richTextBoxFormula = new System.Windows.Forms.RichTextBox();
            this.topicsFormulaComboBox = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.createTopic.SuspendLayout();
            this.createTextQue.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.testing.SuspendLayout();
            this.createGrafWithoutVarQue.SuspendLayout();
            this.createGrafWithVarQue.SuspendLayout();
            this.createCourse.SuspendLayout();
            this.showTopics.SuspendLayout();
            this.results.SuspendLayout();
            this.createFormula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormula)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.тестированиеToolStripMenuItem,
            this.пользователиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.курсToolStripMenuItem,
            this.темаToolStripMenuItem,
            this.вопросыToolStripMenuItem});
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // курсToolStripMenuItem
            // 
            this.курсToolStripMenuItem.Name = "курсToolStripMenuItem";
            this.курсToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.курсToolStripMenuItem.Text = "Курс";
            this.курсToolStripMenuItem.Click += new System.EventHandler(this.курсToolStripMenuItem_Click);
            // 
            // темаToolStripMenuItem
            // 
            this.темаToolStripMenuItem.Name = "темаToolStripMenuItem";
            this.темаToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.темаToolStripMenuItem.Text = "Тема";
            this.темаToolStripMenuItem.Click += new System.EventHandler(this.темаToolStripMenuItem_Click);
            // 
            // вопросыToolStripMenuItem
            // 
            this.вопросыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текстовыйToolStripMenuItem,
            this.графическийToolStripMenuItem,
            this.формулаToolStripMenuItem});
            this.вопросыToolStripMenuItem.Name = "вопросыToolStripMenuItem";
            this.вопросыToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.вопросыToolStripMenuItem.Text = "Вопросы";
            // 
            // текстовыйToolStripMenuItem
            // 
            this.текстовыйToolStripMenuItem.Name = "текстовыйToolStripMenuItem";
            this.текстовыйToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.текстовыйToolStripMenuItem.Text = "Текстовый";
            this.текстовыйToolStripMenuItem.Click += new System.EventHandler(this.текстовыйToolStripMenuItem_Click);
            // 
            // графическийToolStripMenuItem
            // 
            this.графическийToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сВариантамиОтветаToolStripMenuItem,
            this.безВариантовToolStripMenuItem});
            this.графическийToolStripMenuItem.Name = "графическийToolStripMenuItem";
            this.графическийToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.графическийToolStripMenuItem.Text = "Графический";
            // 
            // сВариантамиОтветаToolStripMenuItem
            // 
            this.сВариантамиОтветаToolStripMenuItem.Name = "сВариантамиОтветаToolStripMenuItem";
            this.сВариантамиОтветаToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.сВариантамиОтветаToolStripMenuItem.Text = "С вариантами ответа";
            this.сВариантамиОтветаToolStripMenuItem.Click += new System.EventHandler(this.сВариантамиОтветаToolStripMenuItem_Click);
            // 
            // безВариантовToolStripMenuItem
            // 
            this.безВариантовToolStripMenuItem.Name = "безВариантовToolStripMenuItem";
            this.безВариантовToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.безВариантовToolStripMenuItem.Text = "Без вариантов";
            this.безВариантовToolStripMenuItem.Click += new System.EventHandler(this.безВариантовToolStripMenuItem_Click);
            // 
            // формулаToolStripMenuItem
            // 
            this.формулаToolStripMenuItem.Name = "формулаToolStripMenuItem";
            this.формулаToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.формулаToolStripMenuItem.Text = "Формула";
            this.формулаToolStripMenuItem.Click += new System.EventHandler(this.формулаToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.темыToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // темыToolStripMenuItem
            // 
            this.темыToolStripMenuItem.Name = "темыToolStripMenuItem";
            this.темыToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.темыToolStripMenuItem.Text = "Курсы и Темы";
            this.темыToolStripMenuItem.Click += new System.EventHandler(this.темыToolStripMenuItem_Click);
            // 
            // тестированиеToolStripMenuItem
            // 
            this.тестированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьToolStripMenuItem,
            this.результатыToolStripMenuItem});
            this.тестированиеToolStripMenuItem.Name = "тестированиеToolStripMenuItem";
            this.тестированиеToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.тестированиеToolStripMenuItem.Text = "Тестирование";
            // 
            // начатьToolStripMenuItem
            // 
            this.начатьToolStripMenuItem.Name = "начатьToolStripMenuItem";
            this.начатьToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.начатьToolStripMenuItem.Text = "Начать";
            this.начатьToolStripMenuItem.Click += new System.EventHandler(this.начатьToolStripMenuItem_Click);
            // 
            // результатыToolStripMenuItem
            // 
            this.результатыToolStripMenuItem.Name = "результатыToolStripMenuItem";
            this.результатыToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.результатыToolStripMenuItem.Text = "Результаты";
            this.результатыToolStripMenuItem.Click += new System.EventHandler(this.результатыToolStripMenuItem_Click);
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменитьПользователяToolStripMenuItem1,
            this.добавитьПользователяToolStripMenuItem,
            this.списокПользователейToolStripMenuItem});
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            // 
            // сменитьПользователяToolStripMenuItem1
            // 
            this.сменитьПользователяToolStripMenuItem1.Name = "сменитьПользователяToolStripMenuItem1";
            this.сменитьПользователяToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
            this.сменитьПользователяToolStripMenuItem1.Text = "Сменить пользователя";
            this.сменитьПользователяToolStripMenuItem1.Click += new System.EventHandler(this.сменитьПользователяToolStripMenuItem_Click);
            // 
            // добавитьПользователяToolStripMenuItem
            // 
            this.добавитьПользователяToolStripMenuItem.Name = "добавитьПользователяToolStripMenuItem";
            this.добавитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.добавитьПользователяToolStripMenuItem.Text = "Добавить пользователя";
            this.добавитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.пользовательToolStripMenuItem_Click);
            // 
            // списокПользователейToolStripMenuItem
            // 
            this.списокПользователейToolStripMenuItem.Name = "списокПользователейToolStripMenuItem";
            this.списокПользователейToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.списокПользователейToolStripMenuItem.Text = "Список пользователей";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.createTopic);
            this.tabControl1.Controls.Add(this.createTextQue);
            this.tabControl1.Controls.Add(this.testing);
            this.tabControl1.Controls.Add(this.createGrafWithoutVarQue);
            this.tabControl1.Controls.Add(this.createGrafWithVarQue);
            this.tabControl1.Controls.Add(this.createCourse);
            this.tabControl1.Controls.Add(this.showTopics);
            this.tabControl1.Controls.Add(this.results);
            this.tabControl1.Controls.Add(this.createFormula);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 709);
            this.tabControl1.TabIndex = 1;
            // 
            // createTopic
            // 
            this.createTopic.AllowDrop = true;
            this.createTopic.Controls.Add(this.topiсCountTextBox);
            this.createTopic.Controls.Add(this.label28);
            this.createTopic.Controls.Add(this.cancelTopicButton);
            this.createTopic.Controls.Add(this.comboBox3);
            this.createTopic.Controls.Add(this.label11);
            this.createTopic.Controls.Add(this.topicTimeTextBox);
            this.createTopic.Controls.Add(this.label10);
            this.createTopic.Controls.Add(this.addTopicButton);
            this.createTopic.Controls.Add(this.topicNameTextBox);
            this.createTopic.Controls.Add(this.label9);
            this.createTopic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.createTopic.Location = new System.Drawing.Point(4, 22);
            this.createTopic.Name = "createTopic";
            this.createTopic.Padding = new System.Windows.Forms.Padding(3);
            this.createTopic.Size = new System.Drawing.Size(976, 683);
            this.createTopic.TabIndex = 0;
            this.createTopic.Text = "Создать тему";
            this.createTopic.UseVisualStyleBackColor = true;
            // 
            // topiсCountTextBox
            // 
            this.topiсCountTextBox.Location = new System.Drawing.Point(385, 139);
            this.topiсCountTextBox.Name = "topiсCountTextBox";
            this.topiсCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.topiсCountTextBox.TabIndex = 19;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(259, 142);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(120, 13);
            this.label28.TabIndex = 18;
            this.label28.Text = "Количество вопросов:";
            // 
            // cancelTopicButton
            // 
            this.cancelTopicButton.Location = new System.Drawing.Point(232, 180);
            this.cancelTopicButton.Name = "cancelTopicButton";
            this.cancelTopicButton.Size = new System.Drawing.Size(75, 23);
            this.cancelTopicButton.TabIndex = 17;
            this.cancelTopicButton.Text = "Отмена";
            this.cancelTopicButton.UseVisualStyleBackColor = true;
            this.cancelTopicButton.Click += new System.EventHandler(this.cancelTopicButton_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox3.Location = new System.Drawing.Point(65, 54);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(191, 21);
            this.comboBox3.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Курс:";
            // 
            // topicTimeTextBox
            // 
            this.topicTimeTextBox.Location = new System.Drawing.Point(151, 139);
            this.topicTimeTextBox.Name = "topicTimeTextBox";
            this.topicTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.topicTimeTextBox.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Время на тест:";
            // 
            // addTopicButton
            // 
            this.addTopicButton.Location = new System.Drawing.Point(151, 180);
            this.addTopicButton.Name = "addTopicButton";
            this.addTopicButton.Size = new System.Drawing.Size(75, 23);
            this.addTopicButton.TabIndex = 2;
            this.addTopicButton.Text = "Добавить";
            this.addTopicButton.UseVisualStyleBackColor = true;
            this.addTopicButton.Click += new System.EventHandler(this.addTopicButton_Click);
            // 
            // topicNameTextBox
            // 
            this.topicNameTextBox.Location = new System.Drawing.Point(62, 115);
            this.topicNameTextBox.Name = "topicNameTextBox";
            this.topicNameTextBox.Size = new System.Drawing.Size(545, 20);
            this.topicNameTextBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Название темы:";
            // 
            // createTextQue
            // 
            this.createTextQue.Controls.Add(this.cancelTextQuestionButton);
            this.createTextQue.Controls.Add(this.groupBox1);
            this.createTextQue.Controls.Add(this.comboBox2);
            this.createTextQue.Controls.Add(this.label8);
            this.createTextQue.Controls.Add(this.addTextQuestionButton);
            this.createTextQue.Controls.Add(this.label4);
            this.createTextQue.Controls.Add(this.textQuestionTextBox);
            this.createTextQue.Controls.Add(this.comboBox1);
            this.createTextQue.Controls.Add(this.label1);
            this.createTextQue.Location = new System.Drawing.Point(4, 22);
            this.createTextQue.Name = "createTextQue";
            this.createTextQue.Padding = new System.Windows.Forms.Padding(3);
            this.createTextQue.Size = new System.Drawing.Size(976, 700);
            this.createTextQue.TabIndex = 1;
            this.createTextQue.Text = "Создать вопрос";
            this.createTextQue.UseVisualStyleBackColor = true;
            // 
            // cancelTextQuestionButton
            // 
            this.cancelTextQuestionButton.Location = new System.Drawing.Point(766, 409);
            this.cancelTextQuestionButton.Name = "cancelTextQuestionButton";
            this.cancelTextQuestionButton.Size = new System.Drawing.Size(75, 146);
            this.cancelTextQuestionButton.TabIndex = 20;
            this.cancelTextQuestionButton.Text = "Отмена";
            this.cancelTextQuestionButton.UseVisualStyleBackColor = true;
            this.cancelTextQuestionButton.Click += new System.EventHandler(this.cancelTextQuestionButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.firstAnswerTextQueRichTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.delAnswBut);
            this.groupBox1.Controls.Add(this.firstPointsTextQueTextBox1);
            this.groupBox1.Controls.Add(this.addAnswBut);
            this.groupBox1.Location = new System.Drawing.Point(18, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 449);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ответы:";
            // 
            // firstAnswerTextQueRichTextBox
            // 
            this.firstAnswerTextQueRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.firstAnswerTextQueRichTextBox.MaxLength = 255;
            this.firstAnswerTextQueRichTextBox.Name = "firstAnswerTextQueRichTextBox";
            this.firstAnswerTextQueRichTextBox.Size = new System.Drawing.Size(646, 46);
            this.firstAnswerTextQueRichTextBox.TabIndex = 3;
            this.firstAnswerTextQueRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Баллы за ответ:";
            // 
            // delAnswBut
            // 
            this.delAnswBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delAnswBut.Location = new System.Drawing.Point(698, 19);
            this.delAnswBut.Name = "delAnswBut";
            this.delAnswBut.Size = new System.Drawing.Size(34, 46);
            this.delAnswBut.TabIndex = 17;
            this.delAnswBut.Text = "-";
            this.delAnswBut.UseVisualStyleBackColor = true;
            this.delAnswBut.Click += new System.EventHandler(this.delAnswBut_Click);
            // 
            // firstPointsTextQueTextBox1
            // 
            this.firstPointsTextQueTextBox1.Location = new System.Drawing.Point(101, 71);
            this.firstPointsTextQueTextBox1.Name = "firstPointsTextQueTextBox1";
            this.firstPointsTextQueTextBox1.Size = new System.Drawing.Size(100, 20);
            this.firstPointsTextQueTextBox1.TabIndex = 7;
            // 
            // addAnswBut
            // 
            this.addAnswBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addAnswBut.Location = new System.Drawing.Point(658, 19);
            this.addAnswBut.Name = "addAnswBut";
            this.addAnswBut.Size = new System.Drawing.Size(34, 46);
            this.addAnswBut.TabIndex = 16;
            this.addAnswBut.Text = "+";
            this.addAnswBut.UseVisualStyleBackColor = true;
            this.addAnswBut.Click += new System.EventHandler(this.addAnswBut_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox2.Location = new System.Drawing.Point(18, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 21);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Курс:";
            // 
            // addTextQuestionButton
            // 
            this.addTextQuestionButton.Location = new System.Drawing.Point(766, 257);
            this.addTextQuestionButton.Name = "addTextQuestionButton";
            this.addTextQuestionButton.Size = new System.Drawing.Size(75, 146);
            this.addTextQuestionButton.TabIndex = 12;
            this.addTextQuestionButton.Text = "Добавить";
            this.addTextQuestionButton.UseVisualStyleBackColor = true;
            this.addTextQuestionButton.Click += new System.EventHandler(this.addTextQuestionButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вопрос:";
            // 
            // textQuestionTextBox
            // 
            this.textQuestionTextBox.Location = new System.Drawing.Point(18, 89);
            this.textQuestionTextBox.Name = "textQuestionTextBox";
            this.textQuestionTextBox.Size = new System.Drawing.Size(580, 97);
            this.textQuestionTextBox.TabIndex = 8;
            this.textQuestionTextBox.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(246, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(661, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тема:";
            // 
            // testing
            // 
            this.testing.Controls.Add(this.EndButton);
            this.testing.Controls.Add(this.tabControl2);
            this.testing.Controls.Add(this.label22);
            this.testing.Controls.Add(this.label21);
            this.testing.Controls.Add(this.Start);
            this.testing.Controls.Add(this.courseTestingComboBox);
            this.testing.Controls.Add(this.label14);
            this.testing.Controls.Add(this.topicTestingComboBox);
            this.testing.Controls.Add(this.label20);
            this.testing.Location = new System.Drawing.Point(4, 22);
            this.testing.Name = "testing";
            this.testing.Padding = new System.Windows.Forms.Padding(3);
            this.testing.Size = new System.Drawing.Size(976, 700);
            this.testing.TabIndex = 2;
            this.testing.Text = "Тестирование";
            this.testing.UseVisualStyleBackColor = true;
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(834, 58);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(75, 23);
            this.EndButton.TabIndex = 29;
            this.EndButton.Text = "Закончить";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.button_end_click);
            // 
            // tabControl2
            // 
            this.tabControl2.Location = new System.Drawing.Point(12, 87);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(956, 602);
            this.tabControl2.TabIndex = 28;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(355, 67);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 13);
            this.label22.TabIndex = 27;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(241, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Оставшееся время:";
            this.label21.Visible = false;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(21, 58);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 25;
            this.Start.Text = "Начать!";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // courseTestingComboBox
            // 
            this.courseTestingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseTestingComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.courseTestingComboBox.Location = new System.Drawing.Point(21, 30);
            this.courseTestingComboBox.Name = "courseTestingComboBox";
            this.courseTestingComboBox.Size = new System.Drawing.Size(191, 21);
            this.courseTestingComboBox.TabIndex = 24;
            this.courseTestingComboBox.SelectedValueChanged += new System.EventHandler(this.comboBox11_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Курс:";
            // 
            // topicTestingComboBox
            // 
            this.topicTestingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topicTestingComboBox.Location = new System.Drawing.Point(249, 30);
            this.topicTestingComboBox.Name = "topicTestingComboBox";
            this.topicTestingComboBox.Size = new System.Drawing.Size(661, 21);
            this.topicTestingComboBox.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(246, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "Тема:";
            // 
            // createGrafWithoutVarQue
            // 
            this.createGrafWithoutVarQue.Controls.Add(this.unvisiblePointsButton);
            this.createGrafWithoutVarQue.Controls.Add(this.addPoint);
            this.createGrafWithoutVarQue.Controls.Add(this.deletePoint);
            this.createGrafWithoutVarQue.Controls.Add(this.label26);
            this.createGrafWithoutVarQue.Controls.Add(this.axisYmaxBox);
            this.createGrafWithoutVarQue.Controls.Add(this.axisYminBox);
            this.createGrafWithoutVarQue.Controls.Add(this.axisXmaxBox);
            this.createGrafWithoutVarQue.Controls.Add(this.axisXminBox);
            this.createGrafWithoutVarQue.Controls.Add(this.label25);
            this.createGrafWithoutVarQue.Controls.Add(this.label24);
            this.createGrafWithoutVarQue.Controls.Add(this.label23);
            this.createGrafWithoutVarQue.Controls.Add(this.textBox2);
            this.createGrafWithoutVarQue.Controls.Add(this.label13);
            this.createGrafWithoutVarQue.Controls.Add(this.comboBoxGraphTypeWithoutWar);
            this.createGrafWithoutVarQue.Controls.Add(this.label12);
            this.createGrafWithoutVarQue.Controls.Add(this.cancelGraphWithoutWarButton);
            this.createGrafWithoutVarQue.Controls.Add(this.addGraphWithoutWarButton);
            this.createGrafWithoutVarQue.Controls.Add(this.reset);
            this.createGrafWithoutVarQue.Controls.Add(this.labelCoordinates);
            this.createGrafWithoutVarQue.Controls.Add(this.comboBox4);
            this.createGrafWithoutVarQue.Controls.Add(this.label2);
            this.createGrafWithoutVarQue.Controls.Add(this.label5);
            this.createGrafWithoutVarQue.Controls.Add(this.richTextBox3);
            this.createGrafWithoutVarQue.Controls.Add(this.comboBox5);
            this.createGrafWithoutVarQue.Controls.Add(this.label6);
            this.createGrafWithoutVarQue.Location = new System.Drawing.Point(4, 22);
            this.createGrafWithoutVarQue.Name = "createGrafWithoutVarQue";
            this.createGrafWithoutVarQue.Padding = new System.Windows.Forms.Padding(3);
            this.createGrafWithoutVarQue.Size = new System.Drawing.Size(976, 700);
            this.createGrafWithoutVarQue.TabIndex = 3;
            this.createGrafWithoutVarQue.Text = "Создать вопрос";
            this.createGrafWithoutVarQue.UseVisualStyleBackColor = true;
            this.createGrafWithoutVarQue.Enter += new System.EventHandler(this.createGrafWithoutVarQue_Enter);
            // 
            // unvisiblePointsButton
            // 
            this.unvisiblePointsButton.Location = new System.Drawing.Point(724, 136);
            this.unvisiblePointsButton.Name = "unvisiblePointsButton";
            this.unvisiblePointsButton.Size = new System.Drawing.Size(175, 23);
            this.unvisiblePointsButton.TabIndex = 39;
            this.unvisiblePointsButton.Text = "Спрятать точки";
            this.unvisiblePointsButton.UseVisualStyleBackColor = true;
            this.unvisiblePointsButton.Click += new System.EventHandler(this.unvisiblePointsButton_Click);
            // 
            // addPoint
            // 
            this.addPoint.Location = new System.Drawing.Point(297, 134);
            this.addPoint.Name = "addPoint";
            this.addPoint.Size = new System.Drawing.Size(25, 23);
            this.addPoint.TabIndex = 38;
            this.addPoint.Text = "+";
            this.addPoint.UseVisualStyleBackColor = true;
            this.addPoint.Click += new System.EventHandler(this.addPointWithoutWar_Click);
            // 
            // deletePoint
            // 
            this.deletePoint.Location = new System.Drawing.Point(328, 134);
            this.deletePoint.Name = "deletePoint";
            this.deletePoint.Size = new System.Drawing.Size(25, 23);
            this.deletePoint.TabIndex = 37;
            this.deletePoint.Text = "-";
            this.deletePoint.UseVisualStyleBackColor = true;
            this.deletePoint.Click += new System.EventHandler(this.deletePointWithoutWar_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(251, 139);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 13);
            this.label26.TabIndex = 36;
            this.label26.Text = "Точки:";
            // 
            // axisYmaxBox
            // 
            this.axisYmaxBox.Location = new System.Drawing.Point(485, 110);
            this.axisYmaxBox.Name = "axisYmaxBox";
            this.axisYmaxBox.Size = new System.Drawing.Size(54, 20);
            this.axisYmaxBox.TabIndex = 35;
            // 
            // axisYminBox
            // 
            this.axisYminBox.Location = new System.Drawing.Point(425, 108);
            this.axisYminBox.Name = "axisYminBox";
            this.axisYminBox.Size = new System.Drawing.Size(54, 20);
            this.axisYminBox.TabIndex = 34;
            this.axisYminBox.TextChanged += new System.EventHandler(this.axisBoxes_TextChanged);
            // 
            // axisXmaxBox
            // 
            this.axisXmaxBox.Location = new System.Drawing.Point(485, 82);
            this.axisXmaxBox.Name = "axisXmaxBox";
            this.axisXmaxBox.Size = new System.Drawing.Size(54, 20);
            this.axisXmaxBox.TabIndex = 33;
            this.axisXmaxBox.TextChanged += new System.EventHandler(this.axisBoxes_TextChanged);
            // 
            // axisXminBox
            // 
            this.axisXminBox.Location = new System.Drawing.Point(425, 82);
            this.axisXminBox.Name = "axisXminBox";
            this.axisXminBox.Size = new System.Drawing.Size(54, 20);
            this.axisXminBox.TabIndex = 32;
            this.axisXminBox.TextChanged += new System.EventHandler(this.axisBoxes_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(405, 113);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 31;
            this.label25.Text = "Y";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(405, 85);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "X";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(405, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "Интервалы:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 134);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Максимальный балл:";
            // 
            // comboBoxGraphTypeWithoutWar
            // 
            this.comboBoxGraphTypeWithoutWar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraphTypeWithoutWar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxGraphTypeWithoutWar.Location = new System.Drawing.Point(527, 136);
            this.comboBoxGraphTypeWithoutWar.Name = "comboBoxGraphTypeWithoutWar";
            this.comboBoxGraphTypeWithoutWar.Size = new System.Drawing.Size(191, 21);
            this.comboBoxGraphTypeWithoutWar.TabIndex = 26;
            this.comboBoxGraphTypeWithoutWar.SelectedValueChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(446, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Тип графика:";
            // 
            // cancelGraphWithoutWarButton
            // 
            this.cancelGraphWithoutWarButton.Location = new System.Drawing.Point(798, 46);
            this.cancelGraphWithoutWarButton.Name = "cancelGraphWithoutWarButton";
            this.cancelGraphWithoutWarButton.Size = new System.Drawing.Size(101, 84);
            this.cancelGraphWithoutWarButton.TabIndex = 24;
            this.cancelGraphWithoutWarButton.Text = "Отмена";
            this.cancelGraphWithoutWarButton.UseVisualStyleBackColor = true;
            this.cancelGraphWithoutWarButton.Click += new System.EventHandler(this.cancelGraphWithoutWarButton_Click);
            // 
            // addGraphWithoutWarButton
            // 
            this.addGraphWithoutWarButton.Location = new System.Drawing.Point(687, 46);
            this.addGraphWithoutWarButton.Name = "addGraphWithoutWarButton";
            this.addGraphWithoutWarButton.Size = new System.Drawing.Size(101, 84);
            this.addGraphWithoutWarButton.TabIndex = 23;
            this.addGraphWithoutWarButton.Text = "Добавить";
            this.addGraphWithoutWarButton.UseVisualStyleBackColor = true;
            this.addGraphWithoutWarButton.Click += new System.EventHandler(this.addGraphWithoutWarButton_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(606, 107);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 22;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.resetWithoutWar_Click);
            // 
            // labelCoordinates
            // 
            this.labelCoordinates.AutoSize = true;
            this.labelCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoordinates.Location = new System.Drawing.Point(546, 55);
            this.labelCoordinates.Name = "labelCoordinates";
            this.labelCoordinates.Size = new System.Drawing.Size(14, 20);
            this.labelCoordinates.TabIndex = 21;
            this.labelCoordinates.Text = "|";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox4.Location = new System.Drawing.Point(23, 19);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(191, 21);
            this.comboBox4.TabIndex = 20;
            this.comboBox4.SelectedValueChanged += new System.EventHandler(this.comboBox4_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Курс:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Вопрос:";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(23, 59);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(375, 71);
            this.richTextBox3.TabIndex = 17;
            this.richTextBox3.Text = "";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Location = new System.Drawing.Point(238, 19);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(661, 21);
            this.comboBox5.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Тема:";
            // 
            // createGrafWithVarQue
            // 
            this.createGrafWithVarQue.Controls.Add(this.unvisiblePointsButtonWar);
            this.createGrafWithVarQue.Controls.Add(this.addPointWar);
            this.createGrafWithVarQue.Controls.Add(this.deletePointWar);
            this.createGrafWithVarQue.Controls.Add(this.label7);
            this.createGrafWithVarQue.Controls.Add(this.axisYmaxBoxWar);
            this.createGrafWithVarQue.Controls.Add(this.axisYminBoxWar);
            this.createGrafWithVarQue.Controls.Add(this.axisXmaxBoxWar);
            this.createGrafWithVarQue.Controls.Add(this.axisXminBoxWar);
            this.createGrafWithVarQue.Controls.Add(this.label29);
            this.createGrafWithVarQue.Controls.Add(this.label30);
            this.createGrafWithVarQue.Controls.Add(this.label31);
            this.createGrafWithVarQue.Controls.Add(this.addVarGraph);
            this.createGrafWithVarQue.Controls.Add(this.comboBox7);
            this.createGrafWithVarQue.Controls.Add(this.label15);
            this.createGrafWithVarQue.Controls.Add(this.cancelGraphWithWarButton);
            this.createGrafWithVarQue.Controls.Add(this.addGraphWithWarButton);
            this.createGrafWithVarQue.Controls.Add(this.resetWar);
            this.createGrafWithVarQue.Controls.Add(this.labelCoordinatesWar);
            this.createGrafWithVarQue.Controls.Add(this.comboBox8);
            this.createGrafWithVarQue.Controls.Add(this.label17);
            this.createGrafWithVarQue.Controls.Add(this.label18);
            this.createGrafWithVarQue.Controls.Add(this.richTextBox4);
            this.createGrafWithVarQue.Controls.Add(this.comboBox9);
            this.createGrafWithVarQue.Controls.Add(this.label19);
            this.createGrafWithVarQue.Location = new System.Drawing.Point(4, 22);
            this.createGrafWithVarQue.Name = "createGrafWithVarQue";
            this.createGrafWithVarQue.Padding = new System.Windows.Forms.Padding(3);
            this.createGrafWithVarQue.Size = new System.Drawing.Size(976, 700);
            this.createGrafWithVarQue.TabIndex = 4;
            this.createGrafWithVarQue.Text = "Создать вопрос";
            this.createGrafWithVarQue.UseVisualStyleBackColor = true;
            this.createGrafWithVarQue.Enter += new System.EventHandler(this.createGrafWithVarQue_Enter);
            // 
            // unvisiblePointsButtonWar
            // 
            this.unvisiblePointsButtonWar.Location = new System.Drawing.Point(730, 128);
            this.unvisiblePointsButtonWar.Name = "unvisiblePointsButtonWar";
            this.unvisiblePointsButtonWar.Size = new System.Drawing.Size(175, 23);
            this.unvisiblePointsButtonWar.TabIndex = 52;
            this.unvisiblePointsButtonWar.Text = "Спрятать точки";
            this.unvisiblePointsButtonWar.UseVisualStyleBackColor = true;
            // 
            // addPointWar
            // 
            this.addPointWar.Location = new System.Drawing.Point(599, 251);
            this.addPointWar.Name = "addPointWar";
            this.addPointWar.Size = new System.Drawing.Size(25, 23);
            this.addPointWar.TabIndex = 51;
            this.addPointWar.Text = "+";
            this.addPointWar.UseVisualStyleBackColor = true;
            this.addPointWar.Click += new System.EventHandler(this.addPointWar_Click);
            // 
            // deletePointWar
            // 
            this.deletePointWar.Location = new System.Drawing.Point(630, 251);
            this.deletePointWar.Name = "deletePointWar";
            this.deletePointWar.Size = new System.Drawing.Size(25, 23);
            this.deletePointWar.TabIndex = 50;
            this.deletePointWar.Text = "-";
            this.deletePointWar.UseVisualStyleBackColor = true;
            this.deletePointWar.Click += new System.EventHandler(this.deletePointWar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Точки:";
            // 
            // axisYmaxBoxWar
            // 
            this.axisYmaxBoxWar.Location = new System.Drawing.Point(613, 212);
            this.axisYmaxBoxWar.Name = "axisYmaxBoxWar";
            this.axisYmaxBoxWar.Size = new System.Drawing.Size(54, 20);
            this.axisYmaxBoxWar.TabIndex = 48;
            // 
            // axisYminBoxWar
            // 
            this.axisYminBoxWar.Location = new System.Drawing.Point(553, 212);
            this.axisYminBoxWar.Name = "axisYminBoxWar";
            this.axisYminBoxWar.Size = new System.Drawing.Size(54, 20);
            this.axisYminBoxWar.TabIndex = 47;
            // 
            // axisXmaxBoxWar
            // 
            this.axisXmaxBoxWar.Location = new System.Drawing.Point(613, 179);
            this.axisXmaxBoxWar.Name = "axisXmaxBoxWar";
            this.axisXmaxBoxWar.Size = new System.Drawing.Size(54, 20);
            this.axisXmaxBoxWar.TabIndex = 46;
            // 
            // axisXminBoxWar
            // 
            this.axisXminBoxWar.Location = new System.Drawing.Point(553, 179);
            this.axisXminBoxWar.Name = "axisXminBoxWar";
            this.axisXminBoxWar.Size = new System.Drawing.Size(54, 20);
            this.axisXminBoxWar.TabIndex = 45;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(533, 212);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 13);
            this.label29.TabIndex = 44;
            this.label29.Text = "Y";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(533, 182);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(14, 13);
            this.label30.TabIndex = 43;
            this.label30.Text = "X";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(530, 157);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 13);
            this.label31.TabIndex = 42;
            this.label31.Text = "Интервалы:";
            // 
            // addVarGraph
            // 
            this.addVarGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addVarGraph.Location = new System.Drawing.Point(466, 157);
            this.addVarGraph.Name = "addVarGraph";
            this.addVarGraph.Size = new System.Drawing.Size(58, 149);
            this.addVarGraph.TabIndex = 41;
            this.addVarGraph.Text = "+";
            this.addVarGraph.UseVisualStyleBackColor = true;
            this.addVarGraph.Click += new System.EventHandler(this.addVarGraph_Click);
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox7.Location = new System.Drawing.Point(520, 130);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(191, 21);
            this.comboBox7.TabIndex = 40;
            this.comboBox7.SelectedValueChanged += new System.EventHandler(this.comboBox7_SelectedValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(439, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Тип графика:";
            // 
            // cancelGraphWithWarButton
            // 
            this.cancelGraphWithWarButton.Location = new System.Drawing.Point(804, 46);
            this.cancelGraphWithWarButton.Name = "cancelGraphWithWarButton";
            this.cancelGraphWithWarButton.Size = new System.Drawing.Size(101, 78);
            this.cancelGraphWithWarButton.TabIndex = 38;
            this.cancelGraphWithWarButton.Text = "Отмена";
            this.cancelGraphWithWarButton.UseVisualStyleBackColor = true;
            this.cancelGraphWithWarButton.Click += new System.EventHandler(this.cancelGraphWithWarButton_Click);
            // 
            // addGraphWithWarButton
            // 
            this.addGraphWithWarButton.Location = new System.Drawing.Point(693, 46);
            this.addGraphWithWarButton.Name = "addGraphWithWarButton";
            this.addGraphWithWarButton.Size = new System.Drawing.Size(101, 78);
            this.addGraphWithWarButton.TabIndex = 37;
            this.addGraphWithWarButton.Text = "Добавить";
            this.addGraphWithWarButton.UseVisualStyleBackColor = true;
            this.addGraphWithWarButton.Click += new System.EventHandler(this.addGraphWithWarButton_Click);
            // 
            // resetWar
            // 
            this.resetWar.Location = new System.Drawing.Point(613, 101);
            this.resetWar.Name = "resetWar";
            this.resetWar.Size = new System.Drawing.Size(75, 23);
            this.resetWar.TabIndex = 36;
            this.resetWar.Text = "Сбросить";
            this.resetWar.UseVisualStyleBackColor = true;
            this.resetWar.Click += new System.EventHandler(this.resetWithWar_Click);
            // 
            // labelCoordinatesWar
            // 
            this.labelCoordinatesWar.AutoSize = true;
            this.labelCoordinatesWar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoordinatesWar.Location = new System.Drawing.Point(717, 190);
            this.labelCoordinatesWar.Name = "labelCoordinatesWar";
            this.labelCoordinatesWar.Size = new System.Drawing.Size(14, 20);
            this.labelCoordinatesWar.TabIndex = 35;
            this.labelCoordinatesWar.Text = "|";
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox8.Location = new System.Drawing.Point(28, 19);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(191, 21);
            this.comboBox8.TabIndex = 34;
            this.comboBox8.SelectedValueChanged += new System.EventHandler(this.comboBox8_SelectedValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Курс:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Вопрос:";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(28, 59);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(580, 65);
            this.richTextBox4.TabIndex = 31;
            this.richTextBox4.Text = "";
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.Location = new System.Drawing.Point(244, 19);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(661, 21);
            this.comboBox9.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(241, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Тема:";
            // 
            // createCourse
            // 
            this.createCourse.Controls.Add(this.cancelCourseButton);
            this.createCourse.Controls.Add(this.addCourseButton);
            this.createCourse.Controls.Add(this.courseNameTextBox);
            this.createCourse.Controls.Add(this.label27);
            this.createCourse.Location = new System.Drawing.Point(4, 22);
            this.createCourse.Name = "createCourse";
            this.createCourse.Padding = new System.Windows.Forms.Padding(3);
            this.createCourse.Size = new System.Drawing.Size(976, 700);
            this.createCourse.TabIndex = 5;
            this.createCourse.Text = "Создать курс";
            this.createCourse.UseVisualStyleBackColor = true;
            // 
            // cancelCourseButton
            // 
            this.cancelCourseButton.Location = new System.Drawing.Point(128, 95);
            this.cancelCourseButton.Name = "cancelCourseButton";
            this.cancelCourseButton.Size = new System.Drawing.Size(75, 23);
            this.cancelCourseButton.TabIndex = 6;
            this.cancelCourseButton.Text = "Отмена";
            this.cancelCourseButton.UseVisualStyleBackColor = true;
            this.cancelCourseButton.Click += new System.EventHandler(this.cancelCourseButton_Click);
            // 
            // addCourseButton
            // 
            this.addCourseButton.Location = new System.Drawing.Point(47, 95);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(75, 23);
            this.addCourseButton.TabIndex = 5;
            this.addCourseButton.Text = "Добавить";
            this.addCourseButton.UseVisualStyleBackColor = true;
            this.addCourseButton.Click += new System.EventHandler(this.addCourseButton_Click);
            // 
            // courseNameTextBox
            // 
            this.courseNameTextBox.Location = new System.Drawing.Point(47, 69);
            this.courseNameTextBox.Name = "courseNameTextBox";
            this.courseNameTextBox.Size = new System.Drawing.Size(545, 20);
            this.courseNameTextBox.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(44, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(92, 13);
            this.label27.TabIndex = 3;
            this.label27.Text = "Название курса:";
            // 
            // showTopics
            // 
            this.showTopics.Controls.Add(this.closeCoursesAndTopicsButton);
            this.showTopics.Controls.Add(this.coursesAndTopicsTreeView);
            this.showTopics.Location = new System.Drawing.Point(4, 22);
            this.showTopics.Name = "showTopics";
            this.showTopics.Padding = new System.Windows.Forms.Padding(3);
            this.showTopics.Size = new System.Drawing.Size(976, 700);
            this.showTopics.TabIndex = 6;
            this.showTopics.Text = "Курсы и Темы";
            this.showTopics.UseVisualStyleBackColor = true;
            // 
            // closeCoursesAndTopicsButton
            // 
            this.closeCoursesAndTopicsButton.Location = new System.Drawing.Point(634, 7);
            this.closeCoursesAndTopicsButton.Name = "closeCoursesAndTopicsButton";
            this.closeCoursesAndTopicsButton.Size = new System.Drawing.Size(75, 23);
            this.closeCoursesAndTopicsButton.TabIndex = 1;
            this.closeCoursesAndTopicsButton.Text = "Закрыть";
            this.closeCoursesAndTopicsButton.UseVisualStyleBackColor = true;
            this.closeCoursesAndTopicsButton.Click += new System.EventHandler(this.closeCoursesAndTopicsButton_Click);
            // 
            // coursesAndTopicsTreeView
            // 
            this.coursesAndTopicsTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.coursesAndTopicsTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coursesAndTopicsTreeView.Location = new System.Drawing.Point(3, 3);
            this.coursesAndTopicsTreeView.Name = "coursesAndTopicsTreeView";
            this.coursesAndTopicsTreeView.Size = new System.Drawing.Size(624, 694);
            this.coursesAndTopicsTreeView.TabIndex = 0;
            this.coursesAndTopicsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // results
            // 
            this.results.Controls.Add(this.closeResultsButton);
            this.results.Controls.Add(this.resultsTreeView);
            this.results.Location = new System.Drawing.Point(4, 22);
            this.results.Name = "results";
            this.results.Padding = new System.Windows.Forms.Padding(3);
            this.results.Size = new System.Drawing.Size(976, 700);
            this.results.TabIndex = 7;
            this.results.Text = "Результаты";
            this.results.UseVisualStyleBackColor = true;
            // 
            // closeResultsButton
            // 
            this.closeResultsButton.Location = new System.Drawing.Point(633, 6);
            this.closeResultsButton.Name = "closeResultsButton";
            this.closeResultsButton.Size = new System.Drawing.Size(75, 23);
            this.closeResultsButton.TabIndex = 2;
            this.closeResultsButton.Text = "Закрыть";
            this.closeResultsButton.UseVisualStyleBackColor = true;
            this.closeResultsButton.Click += new System.EventHandler(this.closeResultsButton_Click);
            // 
            // resultsTreeView
            // 
            this.resultsTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.resultsTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultsTreeView.Location = new System.Drawing.Point(3, 3);
            this.resultsTreeView.Name = "resultsTreeView";
            this.resultsTreeView.Size = new System.Drawing.Size(624, 694);
            this.resultsTreeView.TabIndex = 1;
            // 
            // createFormula
            // 
            this.createFormula.Controls.Add(this.label34);
            this.createFormula.Controls.Add(this.textBox1);
            this.createFormula.Controls.Add(this.pictureBoxFormula);
            this.createFormula.Controls.Add(this.buttonInputFormula);
            this.createFormula.Controls.Add(this.buttonCancelFormula);
            this.createFormula.Controls.Add(this.buttonAddFormula);
            this.createFormula.Controls.Add(this.coursesFormulaComboBox);
            this.createFormula.Controls.Add(this.label16);
            this.createFormula.Controls.Add(this.label32);
            this.createFormula.Controls.Add(this.richTextBoxFormula);
            this.createFormula.Controls.Add(this.topicsFormulaComboBox);
            this.createFormula.Controls.Add(this.label33);
            this.createFormula.Location = new System.Drawing.Point(4, 22);
            this.createFormula.Name = "createFormula";
            this.createFormula.Padding = new System.Windows.Forms.Padding(3);
            this.createFormula.Size = new System.Drawing.Size(976, 700);
            this.createFormula.TabIndex = 8;
            this.createFormula.Text = "Создать вопрос";
            this.createFormula.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 145);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(116, 13);
            this.label34.TabIndex = 48;
            this.label34.Text = "Максимальный балл:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(132, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 47;
            // 
            // pictureBoxFormula
            // 
            this.pictureBoxFormula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFormula.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxFormula.Location = new System.Drawing.Point(3, 481);
            this.pictureBoxFormula.Name = "pictureBoxFormula";
            this.pictureBoxFormula.Size = new System.Drawing.Size(970, 216);
            this.pictureBoxFormula.TabIndex = 46;
            this.pictureBoxFormula.TabStop = false;
            // 
            // buttonInputFormula
            // 
            this.buttonInputFormula.Location = new System.Drawing.Point(238, 140);
            this.buttonInputFormula.Name = "buttonInputFormula";
            this.buttonInputFormula.Size = new System.Drawing.Size(143, 23);
            this.buttonInputFormula.TabIndex = 45;
            this.buttonInputFormula.Text = "Ввести формулу";
            this.buttonInputFormula.UseVisualStyleBackColor = true;
            this.buttonInputFormula.Click += new System.EventHandler(this.buttonInputFormula_Click_1);
            // 
            // buttonCancelFormula
            // 
            this.buttonCancelFormula.Location = new System.Drawing.Point(719, 67);
            this.buttonCancelFormula.Name = "buttonCancelFormula";
            this.buttonCancelFormula.Size = new System.Drawing.Size(100, 65);
            this.buttonCancelFormula.TabIndex = 42;
            this.buttonCancelFormula.Text = "Отмена";
            this.buttonCancelFormula.UseVisualStyleBackColor = true;
            // 
            // buttonAddFormula
            // 
            this.buttonAddFormula.Location = new System.Drawing.Point(613, 67);
            this.buttonAddFormula.Name = "buttonAddFormula";
            this.buttonAddFormula.Size = new System.Drawing.Size(100, 65);
            this.buttonAddFormula.TabIndex = 41;
            this.buttonAddFormula.Text = "Добавить";
            this.buttonAddFormula.UseVisualStyleBackColor = true;
            // 
            // coursesFormulaComboBox
            // 
            this.coursesFormulaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coursesFormulaComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.coursesFormulaComboBox.Location = new System.Drawing.Point(13, 27);
            this.coursesFormulaComboBox.Name = "coursesFormulaComboBox";
            this.coursesFormulaComboBox.Size = new System.Drawing.Size(191, 21);
            this.coursesFormulaComboBox.TabIndex = 40;
            this.coursesFormulaComboBox.SelectedIndexChanged += new System.EventHandler(this.coursesFormulaComboBox_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Курс:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(10, 51);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 13);
            this.label32.TabIndex = 38;
            this.label32.Text = "Вопрос:";
            // 
            // richTextBoxFormula
            // 
            this.richTextBoxFormula.Location = new System.Drawing.Point(13, 67);
            this.richTextBoxFormula.Name = "richTextBoxFormula";
            this.richTextBoxFormula.Size = new System.Drawing.Size(580, 65);
            this.richTextBoxFormula.TabIndex = 37;
            this.richTextBoxFormula.Text = "";
            // 
            // topicsFormulaComboBox
            // 
            this.topicsFormulaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topicsFormulaComboBox.Location = new System.Drawing.Point(229, 27);
            this.topicsFormulaComboBox.Name = "topicsFormulaComboBox";
            this.topicsFormulaComboBox.Size = new System.Drawing.Size(661, 21);
            this.topicsFormulaComboBox.TabIndex = 36;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(226, 11);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(37, 13);
            this.label33.TabIndex = 35;
            this.label33.Text = "Тема:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 733);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 726);
            this.Name = "Form1";
            this.Text = "Экзаменационный раздел";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.createTopic.ResumeLayout(false);
            this.createTopic.PerformLayout();
            this.createTextQue.ResumeLayout(false);
            this.createTextQue.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.testing.ResumeLayout(false);
            this.testing.PerformLayout();
            this.createGrafWithoutVarQue.ResumeLayout(false);
            this.createGrafWithoutVarQue.PerformLayout();
            this.createGrafWithVarQue.ResumeLayout(false);
            this.createGrafWithVarQue.PerformLayout();
            this.createCourse.ResumeLayout(false);
            this.createCourse.PerformLayout();
            this.showTopics.ResumeLayout(false);
            this.results.ResumeLayout(false);
            this.createFormula.ResumeLayout(false);
            this.createFormula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вопросыToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage createTopic;
        private System.Windows.Forms.TabPage createTextQue;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестированиеToolStripMenuItem;
        private System.Windows.Forms.TabPage testing;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem текстовыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графическийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сВариантамиОтветаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem безВариантовToolStripMenuItem;
        private System.Windows.Forms.TextBox firstPointsTextQueTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox textQuestionTextBox;
        private System.Windows.Forms.RichTextBox firstAnswerTextQueRichTextBox;
        private System.Windows.Forms.Button addTextQuestionButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addTopicButton;
        private System.Windows.Forms.TextBox topicNameTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox topicTimeTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button delAnswBut;
        private System.Windows.Forms.Button addAnswBut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage createGrafWithoutVarQue;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCoordinates;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button addGraphWithoutWarButton;
        private System.Windows.Forms.Button cancelTextQuestionButton;
        private System.Windows.Forms.Button cancelGraphWithoutWarButton;
        private System.Windows.Forms.ComboBox comboBoxGraphTypeWithoutWar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage createGrafWithVarQue;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button cancelGraphWithWarButton;
        private System.Windows.Forms.Button addGraphWithWarButton;
        private System.Windows.Forms.Button resetWar;
        private System.Windows.Forms.Label labelCoordinatesWar;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button addVarGraph;
        private System.Windows.Forms.ToolStripMenuItem начатьToolStripMenuItem;
        private System.Windows.Forms.ComboBox courseTestingComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox topicTestingComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.TextBox axisYmaxBox;
        private System.Windows.Forms.TextBox axisYminBox;
        private System.Windows.Forms.TextBox axisXmaxBox;
        private System.Windows.Forms.TextBox axisXminBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button addPoint;
        private System.Windows.Forms.Button deletePoint;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripMenuItem курсToolStripMenuItem;
        private System.Windows.Forms.TabPage createCourse;
        private System.Windows.Forms.Button addCourseButton;
        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button cancelTopicButton;
        private System.Windows.Forms.Button cancelCourseButton;
        private System.Windows.Forms.TextBox topiсCountTextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ToolStripMenuItem темыToolStripMenuItem;
        private System.Windows.Forms.TabPage showTopics;
        private System.Windows.Forms.TreeView coursesAndTopicsTreeView;
        private System.Windows.Forms.Button closeCoursesAndTopicsButton;
        private System.Windows.Forms.Button unvisiblePointsButton;
        private System.Windows.Forms.Button unvisiblePointsButtonWar;
        private System.Windows.Forms.Button addPointWar;
        private System.Windows.Forms.Button deletePointWar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox axisYmaxBoxWar;
        private System.Windows.Forms.TextBox axisYminBoxWar;
        private System.Windows.Forms.TextBox axisXmaxBoxWar;
        private System.Windows.Forms.TextBox axisXminBoxWar;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private ToolStripMenuItem пользователиToolStripMenuItem;
        private ToolStripMenuItem сменитьПользователяToolStripMenuItem1;
        private ToolStripMenuItem добавитьПользователяToolStripMenuItem;
        private ToolStripMenuItem списокПользователейToolStripMenuItem;
        private ToolStripMenuItem результатыToolStripMenuItem;
        private TabPage results;
        private TreeView resultsTreeView;
        private Button closeResultsButton;
        private TabPage createFormula;
        private ToolStripMenuItem формулаToolStripMenuItem;
        private ComboBox coursesFormulaComboBox;
        private Label label16;
        private Label label32;
        private RichTextBox richTextBoxFormula;
        private ComboBox topicsFormulaComboBox;
        private Label label33;
        private Button buttonCancelFormula;
        private Button buttonAddFormula;
        private Button buttonInputFormula;
        private PictureBox pictureBoxFormula;
        private Label label34;
        private TextBox textBox1;

        //мое

    }
}

