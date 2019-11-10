using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ControlSystem
{
    public partial class Form1 : Form
    {
        public Form1(string[] str)
        {
            InitializeComponent();
        }

        Font font1 = new Font(FontFamily.GenericSerif, 14);

        private void Form1_Load(object sender, EventArgs e)
        {
            //подключаемся к БД
            //запуск модуля аутентификации
            autentification(false);

            //убираем все окна с рабочей области
            createTopic.Parent = null;
            createTextQue.Parent = null;
            createGrafWithoutVarQue.Parent = null;
            createGrafWithVarQue.Parent = null;
            testing.Parent = null;
            createCourse.Parent = null;
            showTopics.Parent = null;
            results.Parent = null;
            createFormula.Parent = null;
        }

        #region Authentication

        //переменная указывающая уровень доступа пользователя
        //1 - преподаватель
        //0 - студент
        private int access;
        //переменная, в которой храниться имя пользователя
        private string userName;

        Form autentForm = new Form();
        Label autentLabel = new Label();
        Label autentLabelName = new Label();
        TextBox autentBoxName = new TextBox();
        Label autentLabelPassword = new Label();
        TextBox autentBoxPassword = new TextBox();
        Button autentButton = new Button();
        Label autentLabelRole = new Label();
        ComboBox autentComboBoxRole = new ComboBox();

        //основной метод аутентификации, принимает на вход указатель того, что
        //происходит регистрация или аутентификация
        private async void autentification(bool registr)
        {
            //закрытие доступа к функциям КЧ АОС
            файлToolStripMenuItem.Enabled = false;
            тестированиеToolStripMenuItem.Enabled = false;
            добавитьПользователяToolStripMenuItem.Enabled = false;
            пользователиToolStripMenuItem.Enabled = false;
            //заполнение окна аутентификации
            autentForm.TopMost = true;
            autentForm.ControlBox = false;
            autentForm.Size = new Size(300, 180);
            autentLabel.Text = "Введите имя пользователя и пароль:";
            autentLabel.AutoSize = true;
            autentLabel.Location = new Point(10, 10);
            autentForm.Controls.Add(autentLabel);
            autentLabelName.Location = new Point(10, 33);
            autentLabelName.Text = "Имя:";
            autentLabelName.AutoSize = true;
            autentForm.Controls.Add(autentLabelName);
            autentBoxName.Location = new Point(60, 30);
            autentBoxName.Size = new Size(200, 10);
            autentForm.Controls.Add(autentBoxName);
            autentLabelPassword.Location = new Point(10, 63);
            autentLabelPassword.Text = "Пароль:";
            autentLabelPassword.AutoSize = true;
            autentForm.Controls.Add(autentLabelPassword);
            autentBoxPassword.Location = new Point(60, 60);
            autentBoxPassword.Size = new Size(200, 10);
            autentBoxPassword.UseSystemPasswordChar = true;
            autentForm.Controls.Add(autentBoxPassword);
            autentLabelRole.Location = new Point(10, 93);
            autentLabelRole.Text = "Роль пользователя:";
            autentLabelRole.AutoSize = true;
            autentForm.Controls.Add(autentLabelRole);
            autentComboBoxRole.Location = new Point(130, 90);
            autentComboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            autentComboBoxRole.Items.Add("Студент");
            autentComboBoxRole.Items.Add("Преподаватель");
            autentForm.Controls.Add(autentComboBoxRole);
            autentButton.Location = new Point(100, 120);
            autentButton.Text = "OK";
            autentForm.Controls.Add(autentButton);

            autentForm.Show();

            //workBase.createDatabase();

            //проверка на то, сколько существует пользователей
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53363/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("api/user");
            //DataTable dt = workBase.sql("SELECT u.id_user FROM t_user u");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Пользователей еще не существует. При первом входе будет зарегистрирован администратор.",
                    "Внимание!", MessageBoxButtons.OK);
                //если пользователей не существует, происходит регистрация первого администратора
                autentButton.Click += autentButton_Click_registration;
                autentComboBoxRole.Items.Remove("Студент");
                autentComboBoxRole.SelectedIndex = 0;
                файлToolStripMenuItem.Enabled = true;
                тестированиеToolStripMenuItem.Enabled = true;
                пользователиToolStripMenuItem.Enabled = true;
                добавитьПользователяToolStripMenuItem.Enabled = true;
                результатыToolStripMenuItem.Enabled = true;
                списокПользователейToolStripMenuItem.Enabled = true;
                access = 1;
            }
            else
            {
                if (registr)
                {
                    //регистрация
                    autentButton.Click += autentButton_Click_registration;
                    autentLabelRole.Visible = true;
                    autentComboBoxRole.Visible = true;
                }
                else
                {
                    //аутентификация
                    autentButton.Click += autentButton_Click_autentification;
                    autentLabelRole.Visible = false;
                    autentComboBoxRole.Visible = false;
                }
            }
        }

        //обработчик события нажатия на кнопку "Ок" при регистрации
        void autentButton_Click_registration(object sender, EventArgs e)
        {
            if (autentBoxName.Text == "")
            {
                MessageBox.Show("Введите имя пользователя!", "Внимание!", MessageBoxButtons.OK);
                return;
            }
            if (autentBoxPassword.Text == "")
            {
                MessageBox.Show("Введите пароль!", "Внимание!", MessageBoxButtons.OK);
                return;
            }
            if (autentComboBoxRole.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль пользователя!", "Внимание!", MessageBoxButtons.OK);
                return;
            }
            //проверка, существует ли уже пользователь с таким именем
            DataTable dt = workBase.sql("SELECT u.name FROM t_user u");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == autentBoxName.Text)
                {
                    MessageBox.Show("Пользователь с таким именем уже существует!", "Внимание!", MessageBoxButtons.OK);
                    return;
                }
            }
            //Шифрование пароля:
            //класс, вычисляющий хэш SHA256 для входных данных
            SHA256 shaM = new SHA256Managed();
            //создание хэша пароля
            string hash = BitConverter.ToString(shaM.ComputeHash(Encoding.UTF8.GetBytes(autentBoxPassword.Text)));
            //создание хэша от (хэш пароля + имя пользователя)
            string hashSalt = BitConverter.ToString(shaM.ComputeHash(Encoding.UTF8.GetBytes(hash + autentBoxName.Text)));

            string role = "";
            if (autentComboBoxRole.SelectedItem == "Преподаватель")
            {
                role = "1";
            }
            else if (autentComboBoxRole.SelectedItem == "Студент")
            {
                role = "0";
            }

            //добавление пользователя в БД
            workBase.sql("INSERT INTO t_user (name, password, role) VALUES ('" + autentBoxName.Text + "', '" + hashSalt + "', '" + role + "')");
            autentBoxName.Text = "";
            autentBoxPassword.Text = "";
            autentForm.Hide();
            autentComboBoxRole.Items.Clear();
            autentButton.Click -= autentButton_Click_registration;
        }

        //обработчик события нажатия на кнопку "Ок" при аутентификации
        void autentButton_Click_autentification(object sender, EventArgs e)
        {
            if (autentBoxName.Text == "")
            {
                MessageBox.Show("Введите имя пользователя!", "Внимание!", MessageBoxButtons.OK);
                return;
            }
            if (autentBoxPassword.Text == "")
            {
                MessageBox.Show("Введите пароль!", "Внимание!", MessageBoxButtons.OK);
                return;
            }

            DataTable dt = workBase.sql("SELECT u.name, u.password, u.role  FROM t_user u WHERE u.name = '" + autentBoxName.Text +"'");
            //Шифрование пароля:
            //класс, вычисляющий хэш SHA256 для входных данных
            SHA256 shaM = new SHA256Managed();
            //создание хэша пароля
            string hash = BitConverter.ToString(shaM.ComputeHash(Encoding.UTF8.GetBytes(autentBoxPassword.Text)));
            //создание хэша от (хэш пароля + имя пользователя)
            string hashSalt = BitConverter.ToString(shaM.ComputeHash(Encoding.UTF8.GetBytes(hash + autentBoxName.Text)));
            //проверка правильности пароля
            if (dt.Rows.Count == 0 || dt.Rows[0][1].ToString() != hashSalt)
            {
                MessageBox.Show("Пользователя с таким именем не существует, либо пароль неверен!", "Внимание!", MessageBoxButtons.OK);
                return;
            }
            if (dt.Rows[0][1].ToString() == hashSalt)
            {
                if (dt.Rows[0][2].ToString() == "0")
                {
                    //открытие доступа к функциям КЧ для студента 
                    файлToolStripMenuItem.Enabled = false;
                    тестированиеToolStripMenuItem.Enabled = true;
                    пользователиToolStripMenuItem.Enabled = true;
                    добавитьПользователяToolStripMenuItem.Enabled = false;
                    результатыToolStripMenuItem.Enabled = false;
                    списокПользователейToolStripMenuItem.Enabled = false;
                    access = 0;
                }
                else if (dt.Rows[0][2].ToString() == "1")
                {
                    //открытие доступа к функциям КЧ для преподавателя 
                    файлToolStripMenuItem.Enabled = true;
                    тестированиеToolStripMenuItem.Enabled = true;
                    пользователиToolStripMenuItem.Enabled = true;
                    добавитьПользователяToolStripMenuItem.Enabled = true;
                    результатыToolStripMenuItem.Enabled = true;
                    списокПользователейToolStripMenuItem.Enabled = true;
                    access = 1;
                }
            }
            userName = autentBoxName.Text;
            autentBoxName.Text = "";
            autentBoxPassword.Text = "";
            autentForm.Hide();
            autentComboBoxRole.Items.Clear();
            autentButton.Click -= autentButton_Click_autentification;
        }

        //обработчик события при нажатии на кнопку "Добавить пользователя"
        //контекстного меню
        private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //регистрация нового пользователя
            autentification(true);
            файлToolStripMenuItem.Enabled = true;
            тестированиеToolStripMenuItem.Enabled = true;
            пользователиToolStripMenuItem.Enabled = true;
            добавитьПользователяToolStripMenuItem.Enabled = true;
        }
        //обработчик события при нажатии на кнопку "Сменить пользователя"
        //контекстного меню
        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTopic.Parent = null;
            createTextQue.Parent = null;
            createGrafWithoutVarQue.Parent = null;
            createGrafWithVarQue.Parent = null;
            testing.Parent = null;
            createCourse.Parent = null;
            showTopics.Parent = null;
            results.Parent = null;

            //смена пользователя
            autentification(false);
        }

        #endregion

        #region create Course

        //действия при добавлении курса
        private void addCourseButton_Click(object sender, EventArgs e)
        {
            if (courseNameTextBox.Text == "")
            {//Если не введено имя курса
                MessageBox.Show("Для добавления курса необходимо заполнить все поля!", "Не все поля заполненны!",
                    MessageBoxButtons.OK);
            }
            else {
                //Достаем из БД названия всех курсов
                DataTable dt = workBase.sql("SELECT c.name FROM course c");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == courseNameTextBox.Text)
                    {
                        MessageBox.Show("Такой курс уже существует!", "Ошибка!",
                            MessageBoxButtons.OK);
                        return;
                    }
                }

                //Вставляем в таблицу название курса
                workBase.sql("INSERT INTO course (name) VALUES ('" + courseNameTextBox.Text + "')");
                createCourse.Parent = null;
                courseNameTextBox.Text = "";
            }
        }
        //действия при выборе в меню "файл"-"создать"-"курс"
        private void курсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createCourse.Parent = tabControl1;
            tabControl1.SelectTab(createCourse);
        }
        //отмена создания курса
        private void cancelCourseButton_Click(object sender, EventArgs e)
        {
            courseNameTextBox.Text = "";
            createCourse.Parent = null;
        }

        #endregion

        #region create Topic
        //действие при добавлении курса
        private void addTopicButton_Click(object sender, EventArgs e)
        {
            if (topicNameTextBox.Text == "" || topicTimeTextBox.Text == "" || topiсCountTextBox.Text == "")
            {//если какое то из полей не заполнено
                MessageBox.Show("Для добавления темы необходимо заполнить все поля!", "Не все поля заполненны!",
                    MessageBoxButtons.OK);
            }
            else
            {
                int res = 0;
                if (!Int32.TryParse(topicTimeTextBox.Text, out res))
                {
                    MessageBox.Show("В поле 'Время' недопустимые символы!", "Недопустимые символы!",
                        MessageBoxButtons.OK);
                }
                else
                {
                    //достаем из БД ID выбранного курса
                    int id_course = workBase.getId("course", "name", comboBox3.SelectedValue.ToString(), "");
                    //достаем из БД все темы для выбранного курса
                    DataTable dt = workBase.sql("SELECT t.name FROM topic t WHERE t.id_course = " + id_course);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == topicNameTextBox.Text)
                        {
                            MessageBox.Show("Такая тема уже существует для указанного курса!", "Ошибка!",
                                MessageBoxButtons.OK);
                            return;
                        }
                    }

                    //вставляем тему в БД
                    workBase.sql("INSERT INTO topic (name, time, id_course, count) VALUES ('" + topicNameTextBox.Text + "', " + res + ", " +
                        id_course + ", " + topiсCountTextBox.Text + ")");
                    createTopic.Parent = null;
                    topicNameTextBox.Text = "";
                    topicTimeTextBox.Text = "";
                    topiсCountTextBox.Text = "";
                }
            }
        }
        //действия при выборе меню "файл"-"создать"-"тема"
        private void темаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTopic.Parent = tabControl1;
            createTopic.Enter += createTopic_Enter;
            tabControl1.SelectTab(createTopic);
            comboBox3.DataSource = workBase.getCourses();
        }
        //действие при открытии окна создания темы
        private void createTopic_Enter(object sender, EventArgs e)
        {
            comboBox3.DataSource = workBase.getCourses();
        }
        //действия при отмене создания курса 
        private void cancelTopicButton_Click(object sender, EventArgs e)
        {
            topicNameTextBox.Text = "";
            topicTimeTextBox.Text = "";
            createTopic.Parent = null;
        }
        #endregion

        #region ShowTopicsAndCourses
        //действия при выборе меню "файл"-"открыть"-"курсы и темы"
        private void темыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTopics.Parent = tabControl1;

            showTopics.Enter += showTopics_Enter;
            regrowthCoursesAndTopicsTreeView();
            fillCoursesAndTopicsTreeView();
        }
        //действия при закрытии окна "курсы и темы"
        private void closeCoursesAndTopicsButton_Click(object sender, EventArgs e)
        {
            showTopics.Parent = null;
        }
        //изменение размеров дерева с курсами
        private void regrowthCoursesAndTopicsTreeView()
        {// ширина равна половине окна программы
            coursesAndTopicsTreeView.Width = Width / 2;
            closeCoursesAndTopicsButton.Location = new Point(coursesAndTopicsTreeView.Location.X + coursesAndTopicsTreeView.Width + 5, closeCoursesAndTopicsButton.Location.Y);
        }
        //заполнение дерева с курсами
        private void fillCoursesAndTopicsTreeView()
        {
            coursesAndTopicsTreeView.BeginUpdate();
            //предварительная очистка дерева
            coursesAndTopicsTreeView.Nodes.Clear();
            //достаем из БД курсы
            List<string> courses = workBase.getCourses();

            for (int i = 0; i < courses.Count; i++)
            {//добавляем контекстные меню, открывающиеся при нажатии правой кнопкой мыши по курсу
                System.Windows.Forms.ContextMenu contextMenuCourse;
                contextMenuCourse = new System.Windows.Forms.ContextMenu();
                //пункт "Изменить"
                System.Windows.Forms.MenuItem menuItemChangeCourse;
                menuItemChangeCourse = new System.Windows.Forms.MenuItem();
                //пункт "Удалить"
                System.Windows.Forms.MenuItem menuItemDeleteCourse;
                menuItemDeleteCourse = new System.Windows.Forms.MenuItem();
                //добавляем пункты в меню
                contextMenuCourse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItemChangeCourse, menuItemDeleteCourse });
                menuItemChangeCourse.Index = 0;
                menuItemChangeCourse.Text = "Изменить...";
                menuItemChangeCourse.Click += menuItemChangeTopic_Click;

                menuItemDeleteCourse.Index = 1;
                menuItemDeleteCourse.Text = "Удалить";
                menuItemDeleteCourse.Click += menuItemDeleteCourse_Click;

                coursesAndTopicsTreeView.Nodes.Add(courses[i]);
                coursesAndTopicsTreeView.Nodes[i].ContextMenu = contextMenuCourse;
                //получаем все темы для рассматриевомого курса
                List<string> topics = workBase.getTopics(courses[i]);

                for (int j = 0; j < topics.Count; j++)
                {//добавляем контекстные меню, открывающиеся при нажатии правой кнопкой мыши по теме
                    System.Windows.Forms.ContextMenu contextMenuTopic;
                    contextMenuTopic = new System.Windows.Forms.ContextMenu();
                    //пункт "время"
                    System.Windows.Forms.MenuItem menuItemTime;
                    menuItemTime = new System.Windows.Forms.MenuItem();
                    menuItemTime.Enabled = false;
                    //пункт "Количество вопросов"
                    System.Windows.Forms.MenuItem menuItemCount;
                    menuItemCount = new System.Windows.Forms.MenuItem();
                    menuItemCount.Enabled = false;
                    //пункт "изменить"
                    System.Windows.Forms.MenuItem menuItemChangeTopic;
                    menuItemChangeTopic = new System.Windows.Forms.MenuItem();
                    //пункт "удалить"
                    System.Windows.Forms.MenuItem menuItemDeleteTopic;
                    menuItemDeleteTopic = new System.Windows.Forms.MenuItem();

                    contextMenuTopic.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItemTime, menuItemCount, menuItemChangeTopic, menuItemDeleteTopic });
                    menuItemTime.Index = 0;
                    menuItemTime.Text = "Время на тест: ";
                    menuItemCount.Index = 1;
                    menuItemCount.Text = "Количество вопросов: ";
                    menuItemChangeTopic.Index = 2;
                    menuItemChangeTopic.Text = "Изменить...";
                    menuItemChangeTopic.Click += menuItemChangeTopic_Click;
                    menuItemDeleteTopic.Index = 3;
                    menuItemDeleteTopic.Text = "Удалить";
                    menuItemDeleteTopic.Click += menuItemDeleteTopic_Click;

                    coursesAndTopicsTreeView.Nodes[i].Nodes.Add(topics[j]);

                    DataTable timeAndCount =
                        workBase.sql("SELECT t.time, t.count FROM topic t WHERE t.name = '" + topics[j] + "'");

                    menuItemTime.Text = "Время на тест: " + timeAndCount.Rows[0][0].ToString();
                    menuItemCount.Text = "Количество вопросов: " + timeAndCount.Rows[0][1].ToString();

                    coursesAndTopicsTreeView.Nodes[i].Nodes[j].ContextMenu = contextMenuTopic;
                }
            }
            coursesAndTopicsTreeView.EndUpdate();
        }
        //действия при удалении темы
        void menuItemDeleteTopic_Click(object sender, EventArgs e)
        {
            //предупреждение при удалении
            DialogResult deleteResult = MessageBox.Show("Удаление темы повлечет за собой удаление всех вопросов, входящих в тему.",
                "Вы уверены, что хотите удалить тему?", MessageBoxButtons.OKCancel);

            if (deleteResult == DialogResult.OK)
            {//удаляем тему, если пользователь нажал "Ок"
                workBase.deleteTopic(coursesAndTopicsTreeView.SelectedNode.Text);
            }
            //перезаполняем дерево
            fillCoursesAndTopicsTreeView();
        }
        //действия при удалении курса
        void menuItemDeleteCourse_Click(object sender, EventArgs e)
        {
            //предупреждение при удалении темы
            DialogResult deleteResult = MessageBox.Show("Удаление курса повлечет за собой удаление всех тем, вопросов, входящих в темы.",
                "Вы уверены, что хотите удалить курс?", MessageBoxButtons.OKCancel);

            if (deleteResult == DialogResult.OK)
            {//удаляем тк=ему
                workBase.deleteCourse(coursesAndTopicsTreeView.SelectedNode.Text);
            }
            //перезаполняем дерево
            fillCoursesAndTopicsTreeView();
        }

        private Form InputBox;
        private TextBox newNameBox;
        private TextBox newTimeBox;
        private TextBox newCountBox;
        //действия при изменении темы
        private void menuItemChangeTopic_Click(object sender, EventArgs e)
        {//создаем окно изменения темы или курса
            InputBox = new Form();
            Label newNameLabel = new Label();
            newNameLabel.Text = "Новое имя:";
            newNameLabel.AutoSize = true;
            newNameLabel.Location = new Point(5, 10);
            InputBox.Controls.Add(newNameLabel);

            newNameBox = new TextBox();
            newNameBox.Width = 250;
            newNameBox.Location = new Point(newNameLabel.Location.X + 5, newNameLabel.Location.Y + 20);
            InputBox.Controls.Add(newNameBox);

            Button buttonOk = new Button();
            buttonOk.Text = "Сохранить";
            InputBox.Controls.Add(buttonOk);

            Button buttonCancel = new Button();
            buttonCancel.Text = "Отмена";
            InputBox.Controls.Add(buttonCancel);
            buttonCancel.Click += buttonCancel_Click;

            InputBox.ControlBox = false;

            if (coursesAndTopicsTreeView.SelectedNode.Level == 1)
            {//если изменяется тема, то добавляем поля для времени и количества вопросов
                Label newTimeLabel = new Label();
                newTimeLabel.Text = "Время:";
                newTimeLabel.AutoSize = true;
                newTimeLabel.Location = new Point(newNameBox.Location.X, newNameBox.Location.Y + 30);
                InputBox.Controls.Add(newTimeLabel);

                newTimeBox = new TextBox();
                newTimeBox.Location = new Point(newTimeLabel.Location.X + 5, newTimeLabel.Location.Y + 20);
                InputBox.Controls.Add(newTimeBox);

                Label newCountLabel = new Label();
                newCountLabel.Text = "Количество вопросов:";
                newCountLabel.AutoSize = true;
                newCountLabel.Location = new Point(newTimeBox.Location.X, newTimeBox.Location.Y + 30);
                InputBox.Controls.Add(newCountLabel);

                newCountBox = new TextBox();
                newCountBox.Location = new Point(newCountLabel.Location.X + 5, newCountLabel.Location.Y + 20);
                InputBox.Controls.Add(newCountBox);

                buttonOk.Location = new Point(newCountBox.Location.X + 40, newCountBox.Location.Y + 40);
                buttonCancel.Location = new Point(buttonOk.Location.X + 85, buttonOk.Location.Y);

                InputBox.Text = "Изменение темы";
                InputBox.Height = buttonCancel.Location.Y + 80;

                buttonOk.Click += buttonOkTopic_Click;

                DataTable timeAndCount = workBase.sql("SELECT t.time, t.count FROM topic t WHERE t.name = '" + coursesAndTopicsTreeView.SelectedNode.Text + "'");

                newNameBox.Text = coursesAndTopicsTreeView.SelectedNode.Text;
                newTimeBox.Text = timeAndCount.Rows[0][0].ToString();
                newCountBox.Text = timeAndCount.Rows[0][1].ToString();
            }
            else if (coursesAndTopicsTreeView.SelectedNode.Level == 0)
            {
                buttonOk.Location = new Point(newNameBox.Location.X + 40, newNameBox.Location.Y + 40);
                buttonCancel.Location = new Point(buttonOk.Location.X + 85, buttonOk.Location.Y);

                InputBox.Text = "Изменение курса";
                InputBox.Height = buttonCancel.Location.Y + 80;

                buttonOk.Click += buttonOkCourse_Click;

                newNameBox.Text = coursesAndTopicsTreeView.SelectedNode.Text;
            }
            InputBox.Show();

            Enabled = false;
        }
        //отмена изменения
        void buttonCancel_Click(object sender, EventArgs e)
        {
            Enabled = true;
            InputBox.Close();
        }
        //внести изменения в тему
        void buttonOkTopic_Click(object sender, EventArgs e)
        {
            //создаем запрос для внесения изменения в тему
            string sqlString = "UPDATE topic t SET ";

            if (newNameBox.Text != "")
            {
                sqlString += "t.name = '" + newNameBox.Text + "' ";
            }
            if (newTimeBox.Text != "")
            {
                if (newNameBox.Text != "")
                {
                    sqlString += ", ";
                }
                sqlString += "t.time = " + newTimeBox.Text;
            }
            if (newCountBox.Text != "")
            {
                if (newNameBox.Text != "" || newTimeBox.Text != "")
                {
                    sqlString += ", ";
                }
                sqlString += "t.count = " + newCountBox.Text;
            }

            sqlString += " WHERE t.name = '" + coursesAndTopicsTreeView.SelectedNode.Text + "'";
            //выполняем запрос
            workBase.sql(sqlString);
            //перезаполняем дерево
            fillCoursesAndTopicsTreeView();
            Enabled = true;
            InputBox.Close();
        }
        //внести именения в курс
        void buttonOkCourse_Click(object sender, EventArgs e)
        {//создаем запрос для внесения изменений в курс и выполняем его
            if (newNameBox.Text != "")
            {
                workBase.sql("UPDATE `course` SET `name` = '" + newNameBox.Text + "' WHERE `name` = '" + coursesAndTopicsTreeView.SelectedNode.Text + "'");
            }
            //перезаполняем дерево
            fillCoursesAndTopicsTreeView();
            Enabled = true;
            InputBox.Close();
        }
        //действия при открытии окна "темы и курсы"
        private void showTopics_Enter(object sender, EventArgs e)
        {
            fillCoursesAndTopicsTreeView();
        }
        //действие при щелчке мышью на дерево с курсами
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            coursesAndTopicsTreeView.SelectedNode = e.Node;
        }

        #endregion

        #region CreateTextQue
        //действи при выборе контекстно меню "Текстовый"
        private void текстовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //очищаем поля для ввода
            textQuestionTextBox.Text = "";
            firstAnswerTextQueRichTextBox.Text = "";
            firstPointsTextQueTextBox1.Text = "";
            //открываем окно создания
            createTextQue.Parent = tabControl1;
            createTextQue.Enter += createTextQue_Enter;

            richBoxes.Add(firstAnswerTextQueRichTextBox);
            boxes.Add(firstPointsTextQueTextBox1);

            tabControl1.SelectTab(createTextQue);

            delAnswBut.Enabled = false;

            lables.Add(label3);
        }
        //действие при открытии окна создания
        private void createTextQue_Enter(object sender, EventArgs e)
        {
            comboBox2.DataSource = workBase.getCourses();
        }
        //действие при нажатии на кнопку "Добавить"
        private void addTextQuestionButton_Click(object sender, EventArgs e)
        {//проверки, введен ли текст вопроса все ответы и баллы, и ответов больше 1 
            if (textQuestionTextBox.Text == "")
            {
                MessageBox.Show("Введите текст вопроса!", "Не все поля заполненны!",
                    MessageBoxButtons.OK);
                return;
            }
            if (richBoxes.Count < 2)
            {
                MessageBox.Show("Должно быть хотя бы два ответа!", "Неверное заполнение!",
                    MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].Text == "")
                {
                    MessageBox.Show("Введите баллы для каждого ответа", "Неверное заполнение!",
                        MessageBoxButtons.OK);
                    return;
                }
            }
            //достаем из БД ID выбранной темы
            int id_topic = workBase.getId("topic", "name", comboBox1.SelectedValue.ToString(),
                "id_course = " + workBase.getId("course", "name", comboBox2.SelectedValue.ToString(), ""));

            //добавляем вопрос в БД
            workBase.sql("INSERT INTO question (text, type, count, id_topic) VALUES ('" + textQuestionTextBox.Text + "', 't', "
                         + richBoxes.Count + ", " + id_topic + ")");
            //достаем из БД ID нового вопроса
            int id_que = workBase.getId("question", "text", textQuestionTextBox.Text, "id_topic = " + id_topic);

            for (int i = 0; i < richBoxes.Count; i++)
            {//добавляем все ответы в БД
                workBase.sql("INSERT INTO answer (text, id_que, point) VALUES ('" + richBoxes[i].Text + "', " + id_que +
                             ", " + boxes[i].Text + ")");
            }

            for (int i = richBoxes.Count - 1; i > 0; i--)
            {
                groupBox1.Controls.Remove(richBoxes[i]);
                groupBox1.Controls.Remove(boxes[i]);
                groupBox1.Controls.Remove(lables[i]);
            }
            boxes.Clear();
            richBoxes.Clear();

            createTextQue.Parent = null;
        }
        //действие при выборе курса
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = workBase.getTopics(comboBox2.SelectedItem.ToString());
        }

        List<RichTextBox> richBoxes = new List<RichTextBox>();
        List<TextBox> boxes = new List<TextBox>();
        List<Label> lables = new List<Label>();
        //действие при нажатии на кнопку "добавить ответ"
        private void addAnswBut_Click(object sender, EventArgs e)
        {
            delAnswBut.Enabled = true;
            //создаем поля для нового ответа
            RichTextBox newAnsw = new RichTextBox();
            newAnsw.Height = 46;
            newAnsw.Width = 646;
            newAnsw.Location = new Point(31, richBoxes[richBoxes.Count - 1].Location.Y + 85);

            groupBox1.Controls.Add(newAnsw);
            richBoxes.Add(newAnsw);

            TextBox newPoint = new TextBox();
            newPoint.Height = 20;
            newPoint.Width = 100;
            newPoint.Location = new Point(126, boxes[boxes.Count - 1].Location.Y + 85);

            groupBox1.Controls.Add(newPoint);
            boxes.Add(newPoint);

            Label newLabel = new Label();
            newLabel.AutoSize = true;
            newLabel.Location = new Point(80, lables[lables.Count - 1].Location.Y + 85);
            newLabel.Text = "Баллы: ";
            groupBox1.Controls.Add(newLabel);
            lables.Add(newLabel);

            if (richBoxes.Count == 5)
            {
                addAnswBut.Enabled = false;
            }
        }
        //действие при нажатии на кнопку "удалить ответ"
        private void delAnswBut_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Remove(richBoxes[richBoxes.Count - 1]);
            richBoxes.Remove(richBoxes[richBoxes.Count - 1]);

            groupBox1.Controls.Remove(boxes[boxes.Count - 1]);
            boxes.Remove(boxes[boxes.Count - 1]);

            groupBox1.Controls.Remove(lables[lables.Count - 1]);
            lables.Remove(lables[lables.Count - 1]);

            if (richBoxes.Count == 1)
            {
                delAnswBut.Enabled = false;
            }

            addAnswBut.Enabled = true;
        }
        //действие при нажатии на кнопку "Отмена"
        private void cancelTextQuestionButton_Click(object sender, EventArgs e)
        {
            for (int i = richBoxes.Count - 1; i > 0; i--)
            {
                groupBox1.Controls.Remove(richBoxes[i]);
                groupBox1.Controls.Remove(boxes[i]);
                groupBox1.Controls.Remove(lables[i]);
            }
            boxes.Clear();
            richBoxes.Clear();

            createTextQue.Parent = null;
        }

        #endregion

        #region CreateGraph (WITH VARIANTS)

        private Chart chart2;
        //глобальные координаты точек, используются для взаимодействия между методами и обработчиками событий
        double[] XpointsPaintVar = { -4, -2, 0, 2, 4 };
        double[] YpointsPaintVar = { 0, 0, 0, 0, 0 };
        //действие при входе на страницу создания вопроса
        private void createGrafWithVarQue_Enter(object sender, EventArgs e)
        {
            comboBox8.DataSource = workBase.getCourses();
        }
        //действия при выборе в меню "С вариантами"
        private void сВариантамиОтветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createGrafWithVarQue.Parent = tabControl1;
            comboBox8.DataSource = workBase.getCourses();

            tabControl1.SelectTab(createGrafWithVarQue);
            //добавляем типы графика
            comboBox7.Items.Add("Линейный");
            comboBox7.Items.Add("Ступенчатый");
            comboBox7.Items.Add("Криволинейный");
            //добавляем графическое поле для построения графика
            chart2 = new Chart();

            chart2.Location = new Point(20, 150);
            chart2.Width = 450;
            chart2.Height = 300;

            chart2.ChartAreas.Add("Ch");
            //добавляем оси координат, максимумы и минимумы - из соответствующих полей ввода
            chart2.ChartAreas["Ch"].AxisX.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisX.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisX.Interval = 2;
            //минимум и максимум по оси асцисс
            axisXminBoxWar.Text = (-10).ToString();
            axisXmaxBoxWar.Text = 10.ToString();

            chart2.ChartAreas["Ch"].AxisY.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisY.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisY.Interval = 2;
            chart2.ChartAreas["Ch"].AxisY.Enabled = AxisEnabled.False;
            //минимум и максимум по оси ординат
            axisYminBoxWar.Text = (-10).ToString();
            axisYmaxBoxWar.Text = 10.ToString();
            //для того, чтобы подпись делений оси ординат были справа
            chart2.ChartAreas["Ch"].AxisY2.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisY2.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisY2.Interval = 2;
            chart2.ChartAreas["Ch"].AxisY2.Enabled = AxisEnabled.True;

            chart2.ChartAreas["Ch"].InnerPlotPosition = new ElementPosition(0, 0, 92, 92);
            //добавляем линию оси абсцисс
            chart2.Series.Add("x");
            chart2.Series["x"].XValueType = ChartValueType.Int32;
            chart2.Series["x"].YValueType = ChartValueType.Int32;
            chart2.Series["x"].ChartType = SeriesChartType.Spline;
            chart2.Series["x"].BorderWidth = 3;
            chart2.Series["x"].IsVisibleInLegend = true;
            chart2.Series["x"].LegendText = "Function";
            chart2.Series["x"].Color = Color.Black;

            int[] Xpoints1 = { -10, 10 };
            int[] Ypoints1 = { 0, 0 };

            chart2.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);
            //добавляем линию оси ординат
            chart2.Series.Add("y");
            chart2.Series["y"].XValueType = ChartValueType.Int32;
            chart2.Series["y"].YValueType = ChartValueType.Int32;
            chart2.Series["y"].ChartType = SeriesChartType.Spline;
            chart2.Series["y"].BorderWidth = 3;
            chart2.Series["y"].IsVisibleInLegend = true;
            chart2.Series["y"].LegendText = "Function";
            chart2.Series["y"].Color = Color.Black;

            int[] Xpoints2 = { 0, 0 };
            int[] Ypoints2 = { -10, 10 };

            chart2.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);
            //добавляем сам график
            chart2.Series.Add("new");
            chart2.Series["new"].XValueType = ChartValueType.Int32;
            chart2.Series["new"].YValueType = ChartValueType.Int32;
            chart2.Series["new"].ChartType = SeriesChartType.Spline;
            chart2.Series["new"].BorderWidth = 3;
            chart2.Series["new"].MarkerStyle = MarkerStyle.Diamond;

            chart2.Series["new"].IsVisibleInLegend = true;
            chart2.Series["new"].LegendText = "Function";
            chart2.Series["new"].Color = Color.Green;
            chart2.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
            //добавляем точки на графике
            chart2.Series.Add("paint");
            chart2.Series["paint"].XValueType = ChartValueType.Int32;
            chart2.Series["paint"].YValueType = ChartValueType.Int32;
            chart2.Series["paint"].ChartType = SeriesChartType.Bubble;
            chart2.Series["paint"].BorderWidth = 10;
            chart2.Series["paint"].MarkerStyle = MarkerStyle.Cross;

            chart2.Series["paint"].IsVisibleInLegend = true;
            chart2.Series["paint"].LegendText = "Function";
            chart2.Series["paint"].Color = Color.Brown;

            chart2.Series["paint"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);

            chart2.MouseMove += chart2_DragDrop;
            chart2.MouseDown += chart2_MouseDown;
            chart2.MouseUp += chart2_MouseUp;
            //добавляем события при изменении полей ввода интервалов осей
            axisXminBoxWar.TextChanged += axisBoxesWithWar_TextChanged;
            axisXmaxBoxWar.TextChanged += axisBoxesWithWar_TextChanged;
            axisYminBoxWar.TextChanged += axisBoxesWithWar_TextChanged;
            axisYmaxBoxWar.TextChanged += axisBoxesWithWar_TextChanged;

            createGrafWithVarQue.Controls.Add(chart2);

            newCoordinatesForPointsWithWar();

            xV_s = new List<double[]>();
            yV_s = new List<double[]>();
        }
        //действие при добавлении новой точки
        private void addPointWar_Click(object sender, EventArgs e)
        {
            //увеличиваем размерность масивов на 1
            XpointsPaintVar = new double[XpointsPaintVar.Count() + 1];
            YpointsPaintVar = new double[YpointsPaintVar.Count() + 1];
            //пересчитываем координаты точек
            newCoordinatesForPointsWithWar();
        }
        //действие при удалении точки
        private void deletePointWar_Click(object sender, EventArgs e)
        {//если точек больше чем 2
            if (XpointsPaintVar.Count() > 2)
            {//уменьшаем размерности масивов на 1
                XpointsPaintVar = new double[XpointsPaintVar.Count() - 1];
                YpointsPaintVar = new double[YpointsPaintVar.Count() - 1];
                //пересчитываем координаты
                newCoordinatesForPointsWithWar();
            }
        }

        double eXvar;
        double eYvar;

        private int indXvar;
        private int indYvar;
        //событие при перемещении курсора по полю построения графика
        private void chart2_DragDrop(object sender, MouseEventArgs e)
        {
            //расчитываем длину одного деления
            double Xsegment = 389 / (Convert.ToDouble(axisXmaxBoxWar.Text) - Convert.ToDouble(axisXminBoxWar.Text));
            double Ysegment = 259 / (Convert.ToDouble(axisYmaxBoxWar.Text) - Convert.ToDouble(axisYminBoxWar.Text));
            //расчет координат курсора относительно осей координат
            eXvar = (e.X - 13 + Xsegment * Convert.ToDouble(axisXminBoxWar.Text)) / Xsegment;
            eYvar = -(e.Y - 9 - Math.Abs(Ysegment * Convert.ToDouble(axisYmaxBoxWar.Text))) / Ysegment;
            //записываем их в поле "координаты"
            labelCoordinatesWar.Text = Math.Round(eXvar, 2) + "; " + Math.Round(eYvar, 2);
            //количество делений оси абсцисс
            double XsegmentCount = Convert.ToDouble(axisXmaxBoxWar.Text) - Convert.ToDouble(axisXminBoxWar.Text);
            //радиус вокруг точки, при попадании в который считаем, что курсор на точке
            double Xround = 0;
            if (XsegmentCount <= 24) Xround = 1;
            else if (XsegmentCount > 24 && XsegmentCount <= 110) Xround = 5;
            else if (XsegmentCount > 110) Xround = 10;
            //количество делений оси ординат
            double YsegmentCount = Convert.ToDouble(axisYmaxBoxWar.Text) - Convert.ToDouble(axisYminBoxWar.Text);
            double Yround = 0;
            if (YsegmentCount <= 49) Yround = 1;
            else if (YsegmentCount > 34 && YsegmentCount <= 171) Yround = 5;
            else if (YsegmentCount > 171) Yround = 10;

            if (mouseIsDownVar)
            {
                for (int i = 0; i < XpointsPaintVar.Count(); i++)
                {//если курсор на точке, 
                    if (eXvar > XpointsPaintVar[i] - Xround && eXvar < XpointsPaintVar[i] + Xround && eYvar > YpointsPaintVar[i] - Yround && eYvar < YpointsPaintVar[i] + Yround)
                    {//приравниваем точке координаты курсора
                        XpointsPaintVar[i] = eXvar;
                        YpointsPaintVar[i] = eYvar;
                        i = XpointsPaintVar.Count();
                    }
                }
            }
            chart2.Series["paint"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
            chart2.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
        }
        //событие изменения текстовых полей "интервалы"
        private void axisBoxesWithWar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int xMin, xMax, yMin, yMax;
                //если в поле не "-" и не пусто
                if (axisXminBoxWar.Text != "" && axisXminBoxWar.Text != "-" &&
                    axisXmaxBoxWar.Text != "" && axisXmaxBoxWar.Text != "-" &&
                    axisYminBoxWar.Text != "" && axisYminBoxWar.Text != "-" &&
                    axisYmaxBoxWar.Text != "" && axisYmaxBoxWar.Text != "-")
                {
                    try
                    {//конвертируем из строкового типа в числовой с плавающей запятой
                        xMin = Convert.ToInt32(axisXminBoxWar.Text);
                        xMax = Convert.ToInt32(axisXmaxBoxWar.Text);
                        yMin = Convert.ToInt32(axisYminBoxWar.Text);
                        yMax = Convert.ToInt32(axisYmaxBoxWar.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Недопустимое значение", "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }

                    if (xMin >= xMax || yMin >= yMax)
                    {
                        MessageBox.Show("Минимум интервала больше или равен максимуму!", "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }
                    //переназначаем минимумы и максимумы
                    chart2.ChartAreas["Ch"].AxisX.Minimum = xMin;
                    chart2.ChartAreas["Ch"].AxisX.Maximum = xMax;
                    chart2.ChartAreas["Ch"].AxisY2.Minimum = yMin;
                    chart2.ChartAreas["Ch"].AxisY2.Maximum = yMax;
                    chart2.ChartAreas["Ch"].AxisY.Minimum = yMin;
                    chart2.ChartAreas["Ch"].AxisY.Maximum = yMax;
                    //перестраиваем линии осей
                    int[] Xpoints1 = { xMin, xMax };
                    int[] Ypoints1 = { 0, 0 };

                    chart2.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

                    int[] Xpoints2 = { 0, 0 };
                    int[] Ypoints2 = { yMin, yMax };

                    chart2.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

                    newCoordinatesForPointsWithWar();
                }
            }
            catch
            {
                return;
            }
        }
        //метод пересчета координат точек
        private void newCoordinatesForPointsWithWar()
        {
            //координата Y, середина интервала
            double newY = (Convert.ToDouble(axisYmaxBoxWar.Text) + Convert.ToDouble(axisYminBoxWar.Text)) / 2;
            //расчет растояния между точками: (максимум - минимум)/(числоТочек+1)
            double Xdistance = (Convert.ToDouble(axisXmaxBoxWar.Text) -
                                Convert.ToDouble(axisXminBoxWar.Text)) / (XpointsPaintVar.Count() + 1);
            //координаты первой точки
            XpointsPaintVar[0] = Convert.ToDouble(axisXminBoxWar.Text) + Xdistance;
            YpointsPaintVar[0] = newY;
            for (int i = 1; i < XpointsPaintVar.Count(); i++)
            {
                XpointsPaintVar[i] = XpointsPaintVar[i - 1] + Xdistance;
                YpointsPaintVar[i] = newY;
            }
            //пересчет значений делений на осях
            newIntervalWar();

            chart2.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
            chart2.Series["paint"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
        }
        //пересчет значений делений на осях (интервалов)
        private void newIntervalWar()
        {
            //количество делений, при интервале 1
            double XsegmentCount = Convert.ToDouble(axisXmaxBoxWar.Text) - Convert.ToDouble(axisXminBoxWar.Text);
            //пересчет интервалов
            if (XsegmentCount <= 11)
            {
                chart2.ChartAreas["Ch"].AxisX.Interval = 1;
            }
            else if (XsegmentCount > 11 && XsegmentCount <= 24)
            {
                chart2.ChartAreas["Ch"].AxisX.Interval = 2;
            }
            else if (XsegmentCount > 24 && XsegmentCount <= 49)
            {
                chart2.ChartAreas["Ch"].AxisX.Interval = 5;
            }
            else if (XsegmentCount > 49 && XsegmentCount <= 110)
            {
                chart2.ChartAreas["Ch"].AxisX.Interval = 10;
            }
            else if (XsegmentCount > 110)
            {
                chart2.ChartAreas["Ch"].AxisX.Interval = 40;
            }

            double YsegmentCount = Convert.ToDouble(axisYmaxBoxWar.Text) - Convert.ToDouble(axisYminBoxWar.Text);

            if (YsegmentCount <= 11)
            {
                chart2.ChartAreas["Ch"].AxisY2.Interval = 1;
            }
            else if (YsegmentCount > 11 && YsegmentCount <= 34)
            {
                chart2.ChartAreas["Ch"].AxisY2.Interval = 2;
            }
            else if (YsegmentCount > 34 && YsegmentCount <= 49)
            {
                chart2.ChartAreas["Ch"].AxisY2.Interval = 5;
            }
            else if (YsegmentCount > 49 && YsegmentCount <= 171)
            {
                chart2.ChartAreas["Ch"].AxisY2.Interval = 10;
            }
            else if (YsegmentCount > 171)
            {
                chart2.ChartAreas["Ch"].AxisY2.Interval = 40;
            }
        }

        private bool mouseIsDownVar = false;
        //если левая кнопка мыши опущена
        private void chart2_MouseDown(object sender, EventArgs e)
        {
            mouseIsDownVar = true;
        }
        //если правая кнопка мыши поднята
        private void chart2_MouseUp(object sender, EventArgs e)
        {
            mouseIsDownVar = false;
        }
        //событие при закрытии окна создания вопроса
        private void cancelGraphWithWarButton_Click(object sender, EventArgs e)
        {
            labelCoordinatesWar.Text = "|";

            for (int i = 0; i < charts.Count; i++)
            {
                createGrafWithVarQue.Controls.Remove(charts[i]);
                createGrafWithVarQue.Controls.Remove(points[i]);
                createGrafWithVarQue.Controls.Remove(buttonsRemove[i]);
            }
            charts.Clear();
            points.Clear();
            buttonsRemove.Clear();

            createGrafWithVarQue.Parent = null;

            axisXminBoxWar.Text = "-10";
            axisXmaxBoxWar.Text = "10";
            axisYminBoxWar.Text = "-10";
            axisYmaxBoxWar.Text = "10";

            chart2.ChartAreas["Ch"].AxisX.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisX.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisY2.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisY2.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisY.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisY.Maximum = 10;

            XpointsPaintVar = new double[] { -4, -2, 0, 2, 4 };
            YpointsPaintVar = new double[] { 0, 0, 0, 0, 0 };

            createGrafWithVarQue.Controls.Remove(chart2);
        }
        //при нажатии на кнопку "Добавить"
        private void addGraphWithWarButton_Click(object sender, EventArgs e)
        {
            if (richTextBox4.Text == "")
            {
                MessageBox.Show("Введите текст вопроса!", "Не все поля заполненны!",
                    MessageBoxButtons.OK);
                return;
            }
            if (charts.Count < 2)
            {
                MessageBox.Show("Должно быть хотя бы два ответа!", "Неверное заполнение!",
                    MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i < charts.Count; i++)
            {
                if (points[i].Text == "")
                {
                    MessageBox.Show("Заполните баллы для всех ответов!", "Неверное заполнение!",
                        MessageBoxButtons.OK);
                    return;
                }
            }
            //достаем ID темы из БД
            int id_topic = workBase.getId("topic", "name", comboBox9.SelectedValue.ToString(),
                "id_course = " + workBase.getId("course", "name", comboBox8.SelectedValue.ToString(), ""));

            //добавляем вопрос в БД
            workBase.sql("INSERT INTO question (text, type, count, id_topic) VALUES ('" + richTextBox4.Text + "', 'gN', "
                         + charts.Count + ", " + id_topic + ")");
            //достаем из БД ID нового ворпоса
            int id_que = workBase.getId("question", "text", richTextBox4.Text, "id_topic = " + id_topic);
            for (int j = 0; j < charts.Count; j++)
            {//создаем запрос для добавления координат
                string sql = "INSERT INTO coordinates (axisX, axisY, type, points, id_que) VALUES ('";

                for (int i = 0; i < xV_s[j].Count(); i++)
                {
                    sql = sql + Math.Round(xV_s[j][i], 2);
                    if (i < xV_s[j].Count() - 1)
                    {
                        sql = sql + "|";
                    }
                }

                sql = sql + "', '";

                for (int i = 0; i < yV_s[j].Count(); i++)
                {
                    sql = sql + Math.Round(yV_s[j][i], 2);
                    if (i < yV_s[j].Count() - 1)
                    {
                        sql = sql + "|";
                    }
                }

                sql = sql + "', '" + charts[j].Series["new"].ChartType + "', " + points[j].Text + ", " + id_que + ")";

                workBase.sql(sql);
            }

            cancelGraphWithWarButton_Click(sender, e);
        }

        List<Chart> charts = new List<Chart>();
        List<TextBox> points = new List<TextBox>();
        List<Button> buttonsRemove = new List<Button>();

        List<double[]> xV_s;
        List<double[]> yV_s;
        //при нажатии на кнопку "добавление ответа"
        private void addVarGraph_Click(object sender, EventArgs e)
        {
            //новое графическое поле
            Chart newChart = new Chart();
            if (charts.Count == 0)
            {
                newChart.Location = new Point(20, 450);
            }
            else
            {
                newChart.Location = new Point(charts[charts.Count - 1].Location.X + 260, 450);
            }
            newChart.Width = 225;
            newChart.Height = 150;

            newChart.ChartAreas.Add("Ch");
            //расчет интервалов и промежутков на новом поле
            int xMin, xMax, yMin, yMax;

            if (axisXminBoxWar.Text != "" && axisXminBoxWar.Text != "-" &&
                axisXmaxBoxWar.Text != "" && axisXmaxBoxWar.Text != "-" &&
                axisYminBoxWar.Text != "" && axisYminBoxWar.Text != "-" &&
                axisYmaxBoxWar.Text != "" && axisYmaxBoxWar.Text != "-")
            {
                try
                {
                    xMin = Convert.ToInt32(axisXminBoxWar.Text);
                    xMax = Convert.ToInt32(axisXmaxBoxWar.Text);
                    yMin = Convert.ToInt32(axisYminBoxWar.Text);
                    yMax = Convert.ToInt32(axisYmaxBoxWar.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Недопустимое значение", "Ошибка!", MessageBoxButtons.OK);
                    return;
                }

                if (xMin >= xMax || yMin >= yMax)
                {
                    MessageBox.Show("Минимум интервала больше или равен максимуму!", "Ошибка!", MessageBoxButtons.OK);
                    return;
                }

                double XsegmentCount = Convert.ToDouble(axisXmaxBoxWar.Text) - Convert.ToDouble(axisXminBoxWar.Text);

                if (XsegmentCount <= 11)
                {
                    newChart.ChartAreas["Ch"].AxisX.Interval = 5;
                }
                else if (XsegmentCount > 11 && XsegmentCount <= 24)
                {
                    newChart.ChartAreas["Ch"].AxisX.Interval = 10;
                }
                else if (XsegmentCount > 24 && XsegmentCount <= 49)
                {
                    newChart.ChartAreas["Ch"].AxisX.Interval = 15;
                }
                else if (XsegmentCount > 49 && XsegmentCount <= 110)
                {
                    newChart.ChartAreas["Ch"].AxisX.Interval = 40;
                }
                else if (XsegmentCount > 110)
                {
                    newChart.ChartAreas["Ch"].AxisX.Interval = 100;
                }

                double YsegmentCount = Convert.ToDouble(axisYmaxBoxWar.Text) - Convert.ToDouble(axisYminBoxWar.Text);

                if (YsegmentCount <= 11)
                {
                    newChart.ChartAreas["Ch"].AxisY2.Interval = 5;
                }
                else if (YsegmentCount > 11 && YsegmentCount <= 34)
                {
                    newChart.ChartAreas["Ch"].AxisY2.Interval = 10;
                }
                else if (YsegmentCount > 34 && YsegmentCount <= 49)
                {
                    newChart.ChartAreas["Ch"].AxisY2.Interval = 15;
                }
                else if (YsegmentCount > 49 && YsegmentCount <= 171)
                {
                    newChart.ChartAreas["Ch"].AxisY2.Interval = 40;
                }
                else if (YsegmentCount > 171)
                {
                    newChart.ChartAreas["Ch"].AxisY2.Interval = 100;
                }
                //аналогичные действия, как для основного поля
                newChart.ChartAreas["Ch"].AxisX.Minimum = xMin;
                newChart.ChartAreas["Ch"].AxisX.Maximum = xMax;
                newChart.ChartAreas["Ch"].AxisX.Interval = XsegmentCount;

                newChart.ChartAreas["Ch"].AxisY.Minimum = yMin;
                newChart.ChartAreas["Ch"].AxisY.Maximum = yMax;
                newChart.ChartAreas["Ch"].AxisY.Interval = YsegmentCount;
                newChart.ChartAreas["Ch"].AxisY.Enabled = AxisEnabled.False;

                newChart.ChartAreas["Ch"].AxisY2.Minimum = yMin;
                newChart.ChartAreas["Ch"].AxisY2.Maximum = yMax;
                newChart.ChartAreas["Ch"].AxisY2.Interval = YsegmentCount;
                newChart.ChartAreas["Ch"].AxisY2.Enabled = AxisEnabled.True;

                newChart.ChartAreas["Ch"].InnerPlotPosition = new ElementPosition(1, 1, 80, 80);

                newChart.Series.Add("x");
                newChart.Series["x"].XValueType = ChartValueType.Int32;
                newChart.Series["x"].YValueType = ChartValueType.Int32;
                newChart.Series["x"].ChartType = SeriesChartType.Spline;
                newChart.Series["x"].BorderWidth = 2;
                newChart.Series["x"].IsVisibleInLegend = true;
                newChart.Series["x"].LegendText = "Function";
                newChart.Series["x"].Color = Color.Black;

                int[] Xpoints1 = {xMin, xMax};
                int[] Ypoints1 = {0, 0};

                newChart.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

                newChart.Series.Add("y");
                newChart.Series["y"].XValueType = ChartValueType.Int32;
                newChart.Series["y"].YValueType = ChartValueType.Int32;
                newChart.Series["y"].ChartType = SeriesChartType.Spline;
                newChart.Series["y"].BorderWidth = 2;
                newChart.Series["y"].IsVisibleInLegend = true;
                newChart.Series["y"].LegendText = "Function";
                newChart.Series["y"].Color = Color.Black;

                int[] Xpoints2 = {0, 0};
                int[] Ypoints2 = {yMin, yMax};

                newChart.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

                newChart.Series.Add("new");
                newChart.Series["new"].XValueType = ChartValueType.Int32;
                newChart.Series["new"].YValueType = ChartValueType.Int32;
                newChart.Series["new"].ChartType = chart2.Series["new"].ChartType;
                newChart.Series["new"].BorderWidth = 3;
                newChart.Series["new"].MarkerStyle = MarkerStyle.Diamond;

                newChart.Series["new"].IsVisibleInLegend = true;
                newChart.Series["new"].LegendText = "Function";
                newChart.Series["new"].Color = Color.Green;
                newChart.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);

                double[] new1x = new double[XpointsPaintVar.Count()];
                double[] new1y = new double[YpointsPaintVar.Count()];

                for (int i = 0; i < new1x.Count(); i++)
                {
                    new1x[i] = XpointsPaintVar[i];
                    new1y[i] = YpointsPaintVar[i];
                }

                xV_s.Add(new1x);
                yV_s.Add(new1y);
                //добавляем новое поле на экран и в общий список ответов
                createGrafWithVarQue.Controls.Add(newChart);
                charts.Add(newChart);

                if (charts.Count == 4)
                {
                    addVarGraph.Enabled = false;
                }
                //кнопка "Удалить ответ"
                Button newButton = new Button();

                newButton.Text = "-";
                newButton.Height = 65;
                newButton.Width = 25;
                newButton.Location = new Point(newChart.Location.X + 226, newChart.Location.Y + 10);

                newButton.Click += buttonRemove_Click;

                createGrafWithVarQue.Controls.Add(newButton);
                buttonsRemove.Add(newButton);
                //поле для ввода баллов
                TextBox newText = new TextBox();
                newText.BackColor = Color.LightGray;
                newText.Location = new Point(newChart.Location.X + 30, newChart.Location.Y + 150);

                createGrafWithVarQue.Controls.Add(newText);
                points.Add(newText);
            }
        }
        //при нажатии на кнопку "удаление ответа"
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int ind = 0;
            //вычисляем индекс удаляемого ответа в общем списке ответов
            for (int i = 0; i < buttonsRemove.Count; i++)
            {
                if (buttonsRemove[i] == sender)
                {
                    ind = i;
                }
            }
            //пересчет координат последующих полей ответа
            for (int i = ind + 1; i < buttonsRemove.Count; i++)
            {
                charts[i].Location = new Point(charts[i].Location.X - 260, 450);
                buttonsRemove[i].Location = new Point(charts[i].Location.X + 226, charts[i].Location.Y + 10);
                points[i].Location = new Point(charts[i].Location.X + 30, charts[i].Location.Y + 150);
            }
            //удаление соответствующих полей ответа
            createGrafWithVarQue.Controls.Remove(charts[ind]);
            createGrafWithVarQue.Controls.Remove(buttonsRemove[ind]);
            createGrafWithVarQue.Controls.Remove(points[ind]);
            //удаление соответствующих полей ответа
            charts.Remove(charts[ind]);
            buttonsRemove.Remove(buttonsRemove[ind]);
            points.Remove(points[ind]);
            xV_s.Remove(xV_s[ind]);
            yV_s.Remove(yV_s[ind]);

            addVarGraph.Enabled = true;
        }
        //при выборе типа графика
        private void comboBox7_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem.ToString() == "Линейный")
            {
                chart2.Series["new"].ChartType = SeriesChartType.FastLine;
                chart2.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
            }
            if (comboBox7.SelectedItem.ToString() == "Ступенчатый")
            {
                chart2.Series["new"].ChartType = SeriesChartType.StepLine;
                chart2.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
            }
            if (comboBox7.SelectedItem.ToString() == "Криволинейный")
            {
                chart2.Series["new"].ChartType = SeriesChartType.Spline;
                chart2.Series["new"].Points.DataBindXY(XpointsPaintVar, YpointsPaintVar);
            }

        }
        //сброс графика до начального состояния
        private void resetWithWar_Click(object sender, EventArgs e)
        {
            axisXminBoxWar.Text = "-10";
            axisXmaxBoxWar.Text = "10";
            axisYminBoxWar.Text = "-10";
            axisYmaxBoxWar.Text = "10";

            chart2.ChartAreas["Ch"].AxisX.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisX.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisY2.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisY2.Maximum = 10;
            chart2.ChartAreas["Ch"].AxisY.Minimum = -10;
            chart2.ChartAreas["Ch"].AxisY.Maximum = 10;

            XpointsPaintVar = new double[] { -4, -2, 0, 2, 4 };
            YpointsPaintVar = new double[] { 0, 0, 0, 0, 0 };

            newCoordinatesForPointsWithWar();
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox9.DataSource = workBase.getTopics(comboBox8.SelectedItem.ToString());
        }
        #endregion

        #region CreateGraph (WITHOUT VARIANTS)

        private Chart chart1;

        double[] XpointsPaint = { -4, -2, 0, 2, 4 };
        double[] YpointsPaint = { 0, 0, 0, 0, 0 };
        //все события и методы, указанные в данном разделе, аналогичны событиям и методам из прошлого раздела
        //при удалении точки
        private void deletePointWithoutWar_Click(object sender, EventArgs e)
        {
            if (XpointsPaint.Count() > 2)
            {
                XpointsPaint = new double[YpointsPaint.Count() - 1];
                YpointsPaint = new double[YpointsPaint.Count() - 1];
                newCoordinatesForPoints();            
            }
        }
        //при добавлении точки
        private void addPointWithoutWar_Click(object sender, EventArgs e)
        {
            XpointsPaint = new double[YpointsPaint.Count() + 1];
            YpointsPaint = new double[YpointsPaint.Count() + 1];

            newCoordinatesForPoints();
        }
        //при входе на страницу создания вопроса
        private void createGrafWithoutVarQue_Enter(object sender, EventArgs e)
        {
            comboBox4.DataSource = workBase.getCourses();
        }
        //при выборе в меню
        private void безВариантовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createGrafWithoutVarQue.Parent = tabControl1;
            comboBox4.DataSource = workBase.getCourses();
            tabControl1.SelectTab(createGrafWithoutVarQue);

            typesOfGraph();

            chart1 = new Chart();
            chart1.Size = new Size(800, 500);
            chart1.Location = new Point(20, 150);
            chart1.AutoSize = false;

            chart1.ChartAreas.Add("Ch");
            chart1.ChartAreas["Ch"].AxisX.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisX.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisX.Interval = 1;
            axisXminBox.Text = (-10).ToString();
            axisXmaxBox.Text = 10.ToString();

            chart1.ChartAreas["Ch"].AxisY.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisY.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisY.Interval = 1;
            chart1.ChartAreas["Ch"].AxisY.Enabled = AxisEnabled.False;
            axisYminBox.Text = (-10).ToString();
            axisYmaxBox.Text = 10.ToString();

            chart1.ChartAreas["Ch"].AxisY2.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisY2.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisY2.Interval = 1;
            chart1.ChartAreas["Ch"].AxisY2.Enabled = AxisEnabled.True;

            chart1.ChartAreas["Ch"].InnerPlotPosition = new ElementPosition(1,1,92,92);

            chart1.Series.Add("x");
            chart1.Series["x"].XValueType = ChartValueType.Int32;
            chart1.Series["x"].YValueType = ChartValueType.Int32;
            chart1.Series["x"].ChartType = SeriesChartType.Spline;
            chart1.Series["x"].BorderWidth = 3;
            chart1.Series["x"].IsVisibleInLegend = true;
            chart1.Series["x"].LegendText = "Function";
            chart1.Series["x"].Color = Color.Black;

            int[] Xpoints1 = { -10, 10 };
            int[] Ypoints1 = { 0, 0 };

            chart1.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

            chart1.Series.Add("y");
            chart1.Series["y"].XValueType = ChartValueType.Int32;
            chart1.Series["y"].YValueType = ChartValueType.Int32;
            chart1.Series["y"].ChartType = SeriesChartType.Spline;
            chart1.Series["y"].BorderWidth = 3;
            chart1.Series["y"].IsVisibleInLegend = true;
            chart1.Series["y"].LegendText = "Function";
            chart1.Series["y"].Color = Color.Black;

            int[] Xpoints2 = { 0, 0 };
            int[] Ypoints2 = { -10, 10 };

            chart1.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

            chart1.Series.Add("new");
            chart1.Series["new"].XValueType = ChartValueType.Int32;
            chart1.Series["new"].YValueType = ChartValueType.Int32;
            chart1.Series["new"].ChartType = SeriesChartType.Spline;
            chart1.Series["new"].BorderWidth = 3;
            chart1.Series["new"].MarkerStyle = MarkerStyle.Diamond;

            chart1.Series["new"].IsVisibleInLegend = true;
            chart1.Series["new"].LegendText = "Function";
            chart1.Series["new"].Color = Color.Green;
            chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);

            chart1.Series.Add("paint");
            chart1.Series["paint"].XValueType = ChartValueType.Int32;
            chart1.Series["paint"].YValueType = ChartValueType.Int32;
           
            chart1.Series["paint"].ChartType = SeriesChartType.Bubble;
            chart1.Series["paint"].BorderWidth = 10;
            chart1.Series["paint"].MarkerStyle = MarkerStyle.Cross;
            chart1.Series["paint"].IsVisibleInLegend = true;
            chart1.Series["paint"].LegendText = "Function";
            chart1.Series["paint"].Color = Color.Brown;

            chart1.Series["paint"].Points.DataBindXY(XpointsPaint, YpointsPaint);

            chart1.MouseMove += chart1_DragDrop;
            chart1.MouseDown += chart1_MouseDown;
            chart1.MouseUp += chart1_MouseUp;

            axisXminBox.TextChanged += axisBoxes_TextChanged;
            axisXmaxBox.TextChanged += axisBoxes_TextChanged;
            axisYminBox.TextChanged += axisBoxes_TextChanged;
            axisYmaxBox.TextChanged += axisBoxes_TextChanged;

            newCoordinatesForPoints();

            createGrafWithoutVarQue.Controls.Add(chart1);
        }

        double eX;
        double eY;

        private int indX;
        private int indY;
        //при перемещении курсора по полю построения графика
        private void chart1_DragDrop(object sender, MouseEventArgs e)
        {
            double Xsegment = 691 / (Convert.ToDouble(axisXmaxBox.Text) - Convert.ToDouble(axisXminBox.Text));
            double Ysegment = 431 / (Convert.ToDouble(axisYmaxBox.Text) - Convert.ToDouble(axisYminBox.Text));
            
            eX = (e.X - 31 + Xsegment * Convert.ToDouble(axisXminBox.Text))/ Xsegment;
            eY = -(e.Y - 20 - Math.Abs(Ysegment * Convert.ToDouble(axisYmaxBox.Text))) / Ysegment;

            labelCoordinates.Text = Math.Round(eX, 3) + "; " + Math.Round(eY, 3);

            double XsegmentCount = Convert.ToDouble(axisXmaxBox.Text) - Convert.ToDouble(axisXminBox.Text);
            double Xround = 0;

            if (XsegmentCount <= 24) Xround = 0.5;
            else if (XsegmentCount > 24 && XsegmentCount <= 110) Xround = 2;
            else if (XsegmentCount > 110) Xround = 5;

            double YsegmentCount = Convert.ToDouble(axisYmaxBox.Text) - Convert.ToDouble(axisYminBox.Text);
            double Yround = 0;

            if (YsegmentCount <= 49) Yround = 0.5;
            else if (YsegmentCount > 34 && YsegmentCount <= 171) Yround = 2;
            else if (YsegmentCount > 171) Yround = 5;

            if (mouseIsDown)
            {
                for (int i = 0; i < XpointsPaint.Count(); i++)
                {
                    if (eX > XpointsPaint[i] - Xround && eX < XpointsPaint[i] + Xround && eY > YpointsPaint[i] - Yround && eY < YpointsPaint[i] + Yround)
                    {
                        XpointsPaint[i] = eX;
                        YpointsPaint[i] = eY;
                        i = XpointsPaint.Count();
                    }
                }
            }
            chart1.Series["paint"].Points.DataBindXY(XpointsPaint, YpointsPaint);
            chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);
        }

        private bool mouseIsDown = false;
        //при нажатии левой кнопки мыши
        private void chart1_MouseDown(object sender, EventArgs e)
        {
            mouseIsDown = true;
        }
        //при отпускании левой кнопки мыши
        private void chart1_MouseUp(object sender, EventArgs e)
        {
            mouseIsDown = false;
        }
        //сброс до начального состояния
        private void resetWithoutWar_Click(object sender, EventArgs e)
        {
            axisXminBox.Text = "-10";
            axisXmaxBox.Text = "10";
            axisYminBox.Text = "-10";
            axisYmaxBox.Text = "10";

            chart1.ChartAreas["Ch"].AxisX.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisX.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisY2.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisY2.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisY.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisY.Maximum = 10;

            XpointsPaint = new double[] { -4, -2, 0, 2, 4 };
            YpointsPaint = new double[] { 0, 0, 0, 0, 0 };

            newCoordinatesForPoints();
        }
        //при выборе курса
        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox5.DataSource = workBase.getTopics(comboBox4.SelectedItem.ToString());
        }
        //при нажатии на кнопку "Добавить"
        private void addGraphWithoutWarButton_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "")
            {
                MessageBox.Show("Введите текст вопроса!", "Не все поля заполненны!",
                    MessageBoxButtons.OK);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите баллы!", "Неверное заполнение!",
                    MessageBoxButtons.OK);
                return;
            }

            int id_topic = workBase.getId("topic", "name", comboBox5.SelectedValue.ToString(),
                "id_course = " + workBase.getId("course", "name", comboBox4.SelectedValue.ToString(), ""));

            workBase.sql("INSERT INTO question (text, type, count, id_topic) VALUES ('" + richTextBox3.Text + "', 'g1', 1, " + id_topic + ")");

            int id_que = workBase.getId("question", "text", richTextBox3.Text, "id_topic = " + id_topic);

            string sql = "INSERT INTO coordinates (axisX, axisY, type, points, id_que) VALUES ('";

            for (int i = 0; i < XpointsPaint.Count(); i++)
            {
                sql = sql + Math.Round(XpointsPaint[i], 1);
                if (i < XpointsPaint.Count() - 1)
                {
                    sql = sql + "|";
                }
            }

            sql = sql + "', '";

            for (int i = 0; i < YpointsPaint.Count(); i++)
            {
                sql = sql + Math.Round(YpointsPaint[i], 1);
                if (i < YpointsPaint.Count() - 1)
                {
                    sql = sql + "|";
                }
            }

            sql = sql + "', '" + chart1.Series["new"].ChartType + "', " + textBox2.Text + ", " + id_que + ")";

            workBase.sql(sql);

            double a = -9;
            for (int i = 0; i < YpointsPaint.Count(); i++)
            {
                XpointsPaint[i] = a;
                a += 2;
                YpointsPaint[i] = 0;
            }

            chart1.Series["paint"].Points.DataBindXY(XpointsPaint, YpointsPaint);
            chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);

            createGrafWithoutVarQue.Controls.Remove(chart1);
            createGrafWithoutVarQue.Parent = null;

            comboBoxGraphTypeWithoutWar.Items.Clear();
        }
        //при нажатии на кнопку "Отмена"
        private void cancelGraphWithoutWarButton_Click(object sender, EventArgs e)
        {
            labelCoordinates.Text = "|";

            createGrafWithoutVarQue.Controls.Remove(chart1);
            createGrafWithoutVarQue.Parent = null;

            comboBoxGraphTypeWithoutWar.Items.Clear();

            axisXminBox.Text = "-10";
            axisXmaxBox.Text = "10";
            axisYminBox.Text = "-10";
            axisYmaxBox.Text = "10";

            chart1.ChartAreas["Ch"].AxisX.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisX.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisY2.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisY2.Maximum = 10;
            chart1.ChartAreas["Ch"].AxisY.Minimum = -10;
            chart1.ChartAreas["Ch"].AxisY.Maximum = 10;

            chart1 = null;

            XpointsPaint = new double[] { -4, -2, 0, 2, 4 };
            YpointsPaint = new double[] { 0, 0, 0, 0, 0 };
        }
        //при выборе типа графика
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGraphTypeWithoutWar.SelectedItem.ToString() == "Линейный")
            {
                chart1.Series["new"].ChartType = SeriesChartType.FastLine;
                chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);
            }
            if (comboBoxGraphTypeWithoutWar.SelectedItem.ToString() == "Ступенчатый")
            {
                chart1.Series["new"].ChartType = SeriesChartType.StepLine;
                chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);
            }
            if (comboBoxGraphTypeWithoutWar.SelectedItem.ToString() == "Криволинейный")
            {
                chart1.Series["new"].ChartType = SeriesChartType.Spline;
                chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);
            }
        }
        //добавление типов графика в выпадающий список
        public void typesOfGraph()
        {
            comboBoxGraphTypeWithoutWar.Items.Add("Линейный");
            comboBoxGraphTypeWithoutWar.Items.Add("Ступенчатый");
            comboBoxGraphTypeWithoutWar.Items.Add("Криволинейный");
        }
        //при изменении значений в полях "Интервалы"
        private void axisBoxes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int xMin, xMax, yMin, yMax;

                if (axisXminBox.Text != "" && axisXminBox.Text != "-" &&
                    axisXmaxBox.Text != "" && axisXmaxBox.Text != "-" &&
                    axisYminBox.Text != "" && axisYminBox.Text != "-" &&
                    axisYmaxBox.Text != "" && axisYmaxBox.Text != "-")
                {
                    try
                    {
                        xMin = Convert.ToInt32(axisXminBox.Text);
                        xMax = Convert.ToInt32(axisXmaxBox.Text);
                        yMin = Convert.ToInt32(axisYminBox.Text);
                        yMax = Convert.ToInt32(axisYmaxBox.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Недопустимое значение", "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }

                    if (xMin >= xMax || yMin >= yMax)
                    {
                        MessageBox.Show("Минимум интервала больше или равен максимуму!", "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }

                    chart1.ChartAreas["Ch"].AxisX.Minimum = xMin;
                    chart1.ChartAreas["Ch"].AxisX.Maximum = xMax;
                    chart1.ChartAreas["Ch"].AxisY2.Minimum = yMin;
                    chart1.ChartAreas["Ch"].AxisY2.Maximum = yMax;
                    chart1.ChartAreas["Ch"].AxisY.Minimum = yMin;
                    chart1.ChartAreas["Ch"].AxisY.Maximum = yMax;

                    int[] Xpoints1 = {xMin, xMax};
                    int[] Ypoints1 = {0, 0};

                    chart1.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

                    int[] Xpoints2 = {0, 0};
                    int[] Ypoints2 = {yMin, yMax};

                    chart1.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

                    newCoordinatesForPoints();
                }
            }
            catch
            {
                return;
            }
        }
        //перерасчет координат точек
        private void newCoordinatesForPoints()
        {
            double newY = (Convert.ToDouble(axisYmaxBox.Text) + Convert.ToDouble(axisYminBox.Text))/2;

            double Xdistance = (Convert.ToDouble(axisXmaxBox.Text) -
                                Convert.ToDouble(axisXminBox.Text))/(XpointsPaint.Count()+1);

            XpointsPaint[0] = Convert.ToDouble(axisXminBox.Text) + Xdistance;
            YpointsPaint[0] = newY;
            for (int i = 1; i < XpointsPaint.Count(); i++)
            {
                XpointsPaint[i] = XpointsPaint[i - 1] + Xdistance;
                YpointsPaint[i] = newY;
            }

            newInterval();

            chart1.Series["new"].Points.DataBindXY(XpointsPaint, YpointsPaint);
            chart1.Series["paint"].Points.DataBindXY(XpointsPaint, YpointsPaint);

        }
        //пересчет интервало между делениями на осях
        private void newInterval()
        {
            double XsegmentCount = Convert.ToDouble(axisXmaxBox.Text) - Convert.ToDouble(axisXminBox.Text);

            if (XsegmentCount <= 11)
            {
                chart1.ChartAreas["Ch"].AxisX.Interval = 0.5;
            }
            else if (XsegmentCount > 11 && XsegmentCount <= 24)
            {
                chart1.ChartAreas["Ch"].AxisX.Interval = 1;
            }
            else if (XsegmentCount > 24 && XsegmentCount <= 49)
            {
                chart1.ChartAreas["Ch"].AxisX.Interval = 2;
            }
            else if (XsegmentCount > 49 && XsegmentCount <= 110)
            {
                chart1.ChartAreas["Ch"].AxisX.Interval = 5;
            }
            else if (XsegmentCount > 110)
            {
                chart1.ChartAreas["Ch"].AxisX.Interval = 20;
            }

            double YsegmentCount = Convert.ToDouble(axisYmaxBox.Text) - Convert.ToDouble(axisYminBox.Text);

            if (YsegmentCount <= 11)
            {
                chart1.ChartAreas["Ch"].AxisY2.Interval = 0.5;
            }
            else if (YsegmentCount > 11 && YsegmentCount <= 34)
            {
                chart1.ChartAreas["Ch"].AxisY2.Interval = 1;
            }
            else if (YsegmentCount > 34 && YsegmentCount <= 49)
            {
                chart1.ChartAreas["Ch"].AxisY2.Interval = 2;
            }
            else if (YsegmentCount > 49 && YsegmentCount <= 171)
            {
                chart1.ChartAreas["Ch"].AxisY2.Interval = 5;
            }
            else if (YsegmentCount > 171)
            {
                chart1.ChartAreas["Ch"].AxisY2.Interval = 20;
            }
        }
        //при нажатии на кнопку "Скрыть точки"
        private void unvisiblePointsButton_Click(object sender, EventArgs e)
        {
            if (chart1.Series["paint"].ChartType == SeriesChartType.Bubble)
            {
                chart1.Series["paint"].ChartType = SeriesChartType.FastPoint;
                unvisiblePointsButton.Text = "Показать точки";
            }
            else
            {
                chart1.Series["paint"].ChartType = SeriesChartType.Bubble;
                unvisiblePointsButton.Text = "Спрятать точки";
            }
        }

        #endregion

        #region CreateFormula
        //при выборе в меню "Формула"
        private void формулаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createFormula.Parent = tabControl1;
            coursesFormulaComboBox.DataSource = workBase.getCourses();

            pictureBoxFormula.Height = Height - buttonInputFormula.Location.X - buttonInputFormula.Height;
        }
        //при выборе курса
        private void coursesFormulaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            topicsFormulaComboBox.DataSource = workBase.getTopics(coursesFormulaComboBox.SelectedItem.ToString());
        }
        //при нажатии на кнопку "Ввести формулу"
        private void buttonInputFormula_Click_1(object sender, EventArgs e)
        {
            //запускаем редактор формул
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "formulaEditor.exe";
            proc.Start();
            //ожидаем завершения его работы
            proc.WaitForExit();
            //рисуем формулу
            drawFormula();
            //удаляем файл 
            File.Delete("parametrs.param");
        }
        //отрисовка формулы
        private void drawFormula()
        {//считываем из файла весь текст
            string file = File.ReadAllText("parametrs.param");
            //разделяем его на строки
            string[] allPrametres = file.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //создаем новый экземпляр класса, который инкапсулирует поверхность рисования  
            Graphics formGraphics;
            formGraphics = pictureBoxFormula.CreateGraphics();
            //новые кисти
            Brush brush = new SolidBrush(Color.Black);
            Font fontSymbol = new Font("Lucida Console", 30);
            Font fontPower = new Font("Lucida Console", 10);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);

            string[] linesCoordinates = allPrametres[1].Split(new string[] {"lines: ", ";"}, StringSplitOptions.RemoveEmptyEntries);
            //добавляем линии для дробей
            for (int i = 0; i < linesCoordinates.Count(); i++)
            {
                string[] coordinates = linesCoordinates[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                float xCoordLine1 = Convert.ToSingle(coordinates[0]);
                float xCoordLine2 = Convert.ToSingle(coordinates[2]);

                float yCoordLine = Convert.ToSingle(coordinates[1]);
                //рисуем линии
                formGraphics.DrawLine(blackPen, xCoordLine1, yCoordLine, xCoordLine2, yCoordLine);
            }
            //добавляем сами символы
            for (int i = 2; i < allPrametres.Count(); i++)
            {
                string[] parametres = allPrametres[i].Split(new string[] { "|", ";" }, StringSplitOptions.RemoveEmptyEntries);

                string symbol = parametres[0][0].ToString();
                string index = "";
                string power = "";
                //если у символа есть интдекс
                if (parametres[0].Contains("{"))
                {
                    index = parametres[0].Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
                //если у символа есть степень
                if (parametres[0].Contains("^"))
                {
                    string[] str = parametres[0].Split(new string[] { "^", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                    power = str[str.Count() - 1];
                }

                float xCoordSymbol = Convert.ToSingle(parametres[1]);
                float yCoordSymbol = Convert.ToSingle(parametres[2]);
                //если символ - умножение, рисуем его немного ниже чем остальные
                if (symbol == "*")
                {
                    formGraphics.DrawString(symbol, fontSymbol, brush, xCoordSymbol, yCoordSymbol + 10);
                }
                else
                {
                    formGraphics.DrawString(symbol, fontSymbol, brush, xCoordSymbol, yCoordSymbol);
                }

                float heightSymbol = formGraphics.MeasureString(symbol, fontSymbol).Height;
                float widthSymbol = formGraphics.MeasureString(symbol, fontSymbol).Width;

                formGraphics.DrawString(power, fontPower, brush, xCoordSymbol + widthSymbol - 10, yCoordSymbol);
                formGraphics.DrawString(index, fontPower, brush, xCoordSymbol + widthSymbol - 10, yCoordSymbol + heightSymbol - 10);

            }

            formGraphics.Dispose();
        }

        #endregion

        #region Testin
        //при выборе в меню "Тестирование" - "Начать"
        private void начатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testing.Parent = tabControl1;
            tabControl1.SelectTab(testing);

            courseTestingComboBox.DataSource = workBase.getCourses();

            XpointsTesting = new double[] { -9, -7, -5, -3, -1, 1, 3, 5, 7, 9 };
            YpointsTesting = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        //При выборе курса 
        private void comboBox11_SelectedValueChanged(object sender, EventArgs e)
        {
            topicTestingComboBox.DataSource = workBase.getTopics(courseTestingComboBox.SelectedItem.ToString());
        }
        //нажатие на кнопку "Начать"
        private void button_Start_Click(object sender, EventArgs e)
        {
            //Добавляем кнопке "закончить" обработчик "заончить во время тестирования"
            EndButton.Click -= button_end_click;
            EndButton.Click += button_end_click_testing;
            //создаем последовательность вопросов(номера)
            int[] sequense = Questions.generateSeqOfQue(topicTestingComboBox.SelectedItem.ToString(), workBase);

            if (sequense == null)
            {
                MessageBox.Show("По выбранной теме вопросов меньше необходимого", "Ошибка!", MessageBoxButtons.OK);
                return;
            }
            //создаем вопросы
            questions = Questions.questionsCreate(topicTestingComboBox.SelectedItem.ToString(), sequense, workBase);

            courseTestingComboBox.Enabled = false;
            topicTestingComboBox.Enabled = false;
            Start.Enabled = false;

            label21.Visible = true;
            EndButton.Enabled = true;
            createTesting();

            //ЗАПУСК ТАЙМЕРА
            t = new Thread(labeTimer);
            starTime = DateTime.Now;

            DelTime = new DelegateForTime(time);
            t.Priority = ThreadPriority.Lowest;
            t.IsBackground = true;
            t.Start();

            //pages = new List<TabPage>(); 

            int a = 0;

        }
        //вопросы
        private Questions questions;
        //страницы вопросов
        List<TabPage> pages = new List<TabPage>();
        //кнопки для выбора ответов
        List<List<RadioButton>> radioButtons = new List<List<RadioButton>>();
        //поля для ввода графиков
        List<Chart> testingCharts = new List<Chart>();

        double[] XpointsTesting = { -9, -7, -5, -3, -1, 1, 3, 5, 7, 9 };
        double[] YpointsTesting = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        List<Label> coordinatesLabels = new List<Label>();
        List<TextBox> minXtextBoxes = new List<TextBox>();
        List<TextBox> maxXtextBoxes = new List<TextBox>();
        List<TextBox> minYtextBoxes = new List<TextBox>();
        List<TextBox> maxYtextBoxes = new List<TextBox>();
        List<ComboBox> typeGraphicComboBoxes = new List<ComboBox>();
        //создание тестирования
        private void createTesting()
        {
            for (int i = 0; i < questions.QuestionsList.Count; i++)
            {
                //создание страниц с вопросами 
                TabPage newPage = new TabPage("Вопрос " + (i + 1) + "---");

                newPage.Parent = tabControl2;

                Label newLabel = new Label();
                newLabel.Text = questions.QuestionsList[i].questionText;
                newLabel.Font = font1;
                newLabel.AutoSize = false;
                newLabel.Height = 100;
                newLabel.Width = 800;
                newLabel.Location = new Point(10, 10);
                newPage.Controls.Add(newLabel);
                //если вопрос текстовый
                if (questions.QuestionsList[i].type == type.text)
                {
                    //новый список кнопок выбора варианта
                    List<RadioButton> newList = new List<RadioButton>();
                    //идем по ответам
                    for (int j = 0; j < questions.QuestionsList[i].answers.Count; j++)
                    {
                        //новая кнопка выбора варианта
                        RadioButton newButton = new RadioButton();
                        newButton.Text = questions.QuestionsList[i].answers[j].aswerText;
                        newButton.AutoSize = false;
                        newButton.Height = 20;
                        newButton.Width = 500;
                        if (newList.Count == 0)
                        {
                            newButton.Location = new Point(10, newLabel.Height + 10);
                        }
                        else if (newList.Count > 0)
                        {
                            newButton.Location = new Point(10, newList[newList.Count - 1].Location.Y + 30);
                        }
                        //добавляем событие при нажатии на кнопку выбора
                        newButton.Click += radio_button_click;
                        //добавляем кнопку выбора в окно с вопросом
                        newList.Add(newButton);
                        newPage.Controls.Add(newButton);

                    }
                    radioButtons.Add(newList);
                }//если вопрос графический с вариантами
                else if (questions.QuestionsList[i].type == type.graphVar)
                {
                    //новый список кнопок выбора
                    List<RadioButton> newList = new List<RadioButton>();
                    //идем по ответам 
                    for (int j = 0; j < questions.QuestionsList[i].answers.Count; j++)
                    {
                        //новая кнопка выбора
                        RadioButton newButton = new RadioButton();
                        newButton.Text = questions.QuestionsList[i].answers[j].aswerText;
                        newButton.AutoSize = false;
                        newButton.Height = 20;
                        newButton.Width = 20;
                        //если в списке еще ни одной кнопки
                        if (newList.Count == 0)
                        {
                            newButton.Location = new Point(10, newLabel.Height + 60);
                        }//если в списке есть уже один ответ
                        else if (newList.Count == 1)
                        {
                            newButton.Location = new Point(newList[0].Location.X, newList[0].Location.Y + 200);
                        }//если 2 ответа
                        else if (newList.Count == 2)
                        {
                            newButton.Location = new Point(newList[0].Location.X + 400, newList[0].Location.Y);
                        }//если 3
                        else if (newList.Count == 3)
                        {
                            newButton.Location = new Point(newList[2].Location.X, newList[2].Location.Y + 200);
                        }
                        newButton.Click += radio_button_click;
                        newList.Add(newButton);
                        newPage.Controls.Add(newButton);
                        //разделяем строку с координатами на координаты для Х и Y
                        string[] str1 = questions.QuestionsList[i].answers[j].aswerText.Split(new char[] { '+' },
                            StringSplitOptions.RemoveEmptyEntries);
                        //разделяем строки с координатами на отдельные координаты
                        string[] str2 = str1[0].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] str3 = str1[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                        double[] axX = new double[str2.Count()];
                        for (int k = 0; k < str2.Count(); k++)
                        {
                            axX[k] = Convert.ToDouble(str2[k]);
                        }
                        double[] axY = new double[str3.Count()];
                        for (int k = 0; k < str3.Count(); k++)
                        {
                            axY[k] = Convert.ToDouble(str3[k]);
                        }

                        //добавляем новое графическое поле с ответом
                        Chart newChart = new Chart();
                        newChart.Location = new Point(newButton.Location.X + 20, newButton.Location.Y - 50);
                        newChart.Width = 225;
                        newChart.Height = 150;

                        newChart.ChartAreas.Add("Ch");

                        double Xmin = axX[0];
                        double Xmax = axX[0];
                        double Ymin = axY[0];
                        double Ymax = axY[0];

                        for (int k = 1; k < axX.Count(); k++)
                        {
                            if (axX[k] < Xmin)
                            {
                                Xmin = axX[k];
                            }
                            if (axX[k] > Xmax)
                            {
                                Xmax = axX[k];
                            }
                            if (axY[k] < Ymin)
                            {
                                Ymin = axY[k];
                            }
                            if (axY[k] > Ymax)
                            {
                                Ymax = axY[k];
                            }
                        }

                        Xmin = Math.Round(Xmin - 6, 0);
                        Xmax = Math.Round(Xmax + 5, 0);
                        Ymin = Math.Round(Ymin - 6, 0);
                        Ymax = Math.Round(Ymax + 5, 0);

                        newChart.ChartAreas["Ch"].AxisX.Minimum = Xmin;
                        newChart.ChartAreas["Ch"].AxisX.Maximum = Xmax;
                        newChart.ChartAreas["Ch"].AxisX.Interval = 4;

                        newChart.ChartAreas["Ch"].AxisY.Minimum = Ymin;
                        newChart.ChartAreas["Ch"].AxisY.Maximum = Ymax;
                        newChart.ChartAreas["Ch"].AxisY.Enabled = AxisEnabled.False;

                        newChart.ChartAreas["Ch"].AxisY2.Minimum = Ymin;
                        newChart.ChartAreas["Ch"].AxisY2.Maximum = Ymax;
                        newChart.ChartAreas["Ch"].AxisY2.Enabled = AxisEnabled.True;

                        double XsegmentCount = Math.Abs(Xmax - Xmin);

                        if (XsegmentCount <= 11)
                        {
                            newChart.ChartAreas["Ch"].AxisX.Interval = 2;
                        }
                        else if (XsegmentCount > 11 && XsegmentCount <= 24)
                        {
                            newChart.ChartAreas["Ch"].AxisX.Interval = 5;
                        }
                        else if (XsegmentCount > 24 && XsegmentCount <= 49)
                        {
                            newChart.ChartAreas["Ch"].AxisX.Interval = 10;
                        }
                        else if (XsegmentCount > 49)
                        {
                            newChart.ChartAreas["Ch"].AxisX.Interval = 40;
                        }

                        double YsegmentCount = Math.Abs(Ymax - Ymin);

                        if (YsegmentCount <= 11)
                        {
                            newChart.ChartAreas["Ch"].AxisY2.Interval = 2;
                        }
                        else if (YsegmentCount > 11 && YsegmentCount <= 34)
                        {
                            newChart.ChartAreas["Ch"].AxisY2.Interval = 5;
                        }
                        else if (YsegmentCount > 34 && YsegmentCount <= 49)
                        {
                            newChart.ChartAreas["Ch"].AxisY2.Interval = 10;
                        }
                        else if (YsegmentCount > 49)
                        {
                            newChart.ChartAreas["Ch"].AxisY2.Interval = 40;
                        }

                        newChart.Series.Add("x");
                        newChart.Series["x"].XValueType = ChartValueType.Int32;
                        newChart.Series["x"].YValueType = ChartValueType.Int32;
                        newChart.Series["x"].ChartType = SeriesChartType.Spline;
                        newChart.Series["x"].BorderWidth = 2;
                        newChart.Series["x"].IsVisibleInLegend = true;
                        newChart.Series["x"].LegendText = "Function";
                        newChart.Series["x"].Color = Color.Black;

                        int[] Xpoints1 = { Convert.ToInt32(Xmin), Convert.ToInt32(Xmax) };
                        int[] Ypoints1 = { 0, 0 };

                        newChart.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

                        newChart.Series.Add("y");
                        newChart.Series["y"].XValueType = ChartValueType.Int32;
                        newChart.Series["y"].YValueType = ChartValueType.Int32;
                        newChart.Series["y"].ChartType = SeriesChartType.Spline;
                        newChart.Series["y"].BorderWidth = 2;
                        newChart.Series["y"].IsVisibleInLegend = true;
                        newChart.Series["y"].LegendText = "Function";
                        newChart.Series["y"].Color = Color.Black;

                        int[] Xpoints2 = { 0, 0 };
                        int[] Ypoints2 = { Convert.ToInt32(Ymin), Convert.ToInt32(Ymax) };

                        newChart.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

                        newChart.Series.Add("new");
                        newChart.Series["new"].XValueType = ChartValueType.Int32;
                        newChart.Series["new"].YValueType = ChartValueType.Int32;
                        if (str1[2] == "Spline")
                        {
                            newChart.Series["new"].ChartType = SeriesChartType.Spline;
                        }
                        else if (str1[2] == "FastLine")
                        {
                            newChart.Series["new"].ChartType = SeriesChartType.FastLine;
                        }
                        else if (str1[2] == "StepLine")
                        {
                            newChart.Series["new"].ChartType = SeriesChartType.StepLine;
                        }

                        newChart.Series["new"].BorderWidth = 3;
                        newChart.Series["new"].MarkerStyle = MarkerStyle.Diamond;

                        newChart.Series["new"].IsVisibleInLegend = true;
                        newChart.Series["new"].LegendText = "Function";
                        newChart.Series["new"].Color = Color.Green;

                        newChart.Series["new"].Points.DataBindXY(axX, axY);

                        newPage.Controls.Add(newChart);
                    }
                    radioButtons.Add(newList);
                }//если графический без вариантов
                else if (questions.QuestionsList[i].type == type.graph)
                {

                    List<RadioButton> newList = new List<RadioButton>();

                    newLabel.Height = 50;

                    Label typeLab = new Label();
                    typeLab.Text = "Вид графика:";
                    typeLab.Location = new Point(10, 70);
                    newPage.Controls.Add(typeLab);

                    Label newLabelCoordinates = new Label();
                    newLabelCoordinates.Text = "|";
                    newLabelCoordinates.Location = new Point(750, 110);
                    newPage.Controls.Add(newLabelCoordinates);
                    coordinatesLabels.Add(newLabelCoordinates);

                    Label newX = new Label();
                    newX.Text = "X: ";
                    newX.Location = new Point(750, 140);
                    newX.AutoSize = true;
                    newPage.Controls.Add(newX);

                    TextBox newMinX = new TextBox();
                    newMinX.Text = "-10";
                    newMinX.Location = new Point(770, 140);
                    newMinX.Width = 50;
                    newMinX.TextChanged += axisBoxes_TextChanged_testing;
                    newPage.Controls.Add(newMinX);
                    minXtextBoxes.Add(newMinX);

                    TextBox newMaxX = new TextBox();
                    newMaxX.Text = "10";
                    newMaxX.Location = new Point(830, 140);
                    newMaxX.Width = 50;
                    newMaxX.TextChanged += axisBoxes_TextChanged_testing;
                    newPage.Controls.Add(newMaxX);
                    maxXtextBoxes.Add(newMaxX);

                    Label newY = new Label();
                    newY.Text = "Y: ";
                    newY.Location = new Point(750, 170);
                    newY.AutoSize = true;
                    newPage.Controls.Add(newY);

                    TextBox newMinY = new TextBox();
                    newMinY.Text = "-10";
                    newMinY.Location = new Point(770, 170);
                    newMinY.Width = 50;
                    newMinY.TextChanged += axisBoxes_TextChanged_testing;
                    newPage.Controls.Add(newMinY);
                    minYtextBoxes.Add(newMinY);

                    TextBox newMaxY = new TextBox();
                    newMaxY.Text = "10";
                    newMaxY.Location = new Point(830, 170);
                    newMaxY.Width = 50;
                    newMaxY.TextChanged += axisBoxes_TextChanged_testing;
                    newPage.Controls.Add(newMaxY);
                    maxYtextBoxes.Add(newMaxY);

                    ComboBox newBox = new ComboBox();
                    newBox.Items.Add("Линейный");
                    newBox.Items.Add("Ступенчатый");
                    newBox.Items.Add("Криволинейный");
                    newBox.Location = new Point(120, 70);
                    newBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    newBox.SelectedValueChanged += newBox_SelectedValueChanged;
                    newPage.Controls.Add(newBox);
                    typeGraphicComboBoxes.Add(newBox);

                    Button butPlu = new Button();
                    butPlu.Location = new Point(300, 70);
                    butPlu.Text = "+";
                    newPage.Controls.Add(butPlu);
                    butPlu.Click += buttonPlus_Click;

                    Button butMin = new Button();
                    butMin.Location = new Point(400, 70);
                    butMin.Text = "-";
                    newPage.Controls.Add(butMin);
                    butMin.Click += buttonMinus_Click;

                    Chart newChart = new Chart();

                    newChart.Location = new Point(10, 110);
                    newChart.Width = 700;
                    newChart.Height = 400;

                    newChart.ChartAreas.Add("Ch");

                    newChart.ChartAreas["Ch"].AxisX.Minimum = -10;
                    newChart.ChartAreas["Ch"].AxisX.Maximum = 10;
                    newChart.ChartAreas["Ch"].AxisX.Interval = 1;

                    newChart.ChartAreas["Ch"].AxisY.Minimum = -10;
                    newChart.ChartAreas["Ch"].AxisY.Maximum = 10;
                    newChart.ChartAreas["Ch"].AxisY.Interval = 1;
                    newChart.ChartAreas["Ch"].AxisY.Enabled = AxisEnabled.False;
                    //axisYminBox.Text = (-10).ToString();
                    //axisYmaxBox.Text = 10.ToString();

                    newChart.ChartAreas["Ch"].AxisY2.Minimum = -10;
                    newChart.ChartAreas["Ch"].AxisY2.Maximum = 10;
                    newChart.ChartAreas["Ch"].AxisY2.Interval = 1;
                    newChart.ChartAreas["Ch"].AxisY2.Enabled = AxisEnabled.True;

                    newChart.ChartAreas["Ch"].InnerPlotPosition = new ElementPosition(1, 1, 92, 92);

                    newChart.Series.Add("x");
                    newChart.Series["x"].XValueType = ChartValueType.Int32;
                    newChart.Series["x"].YValueType = ChartValueType.Int32;
                    newChart.Series["x"].ChartType = SeriesChartType.Spline;
                    newChart.Series["x"].BorderWidth = 3;
                    newChart.Series["x"].IsVisibleInLegend = true;
                    newChart.Series["x"].LegendText = "Function";
                    newChart.Series["x"].Color = Color.Black;

                    int[] Xpoints1 = { -10, 10 };
                    int[] Ypoints1 = { 0, 0 };

                    newChart.Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

                    newChart.Series.Add("y");
                    newChart.Series["y"].XValueType = ChartValueType.Int32;
                    newChart.Series["y"].YValueType = ChartValueType.Int32;
                    newChart.Series["y"].ChartType = SeriesChartType.Spline;
                    newChart.Series["y"].BorderWidth = 3;
                    newChart.Series["y"].IsVisibleInLegend = true;
                    newChart.Series["y"].LegendText = "Function";
                    newChart.Series["y"].Color = Color.Black;

                    int[] Xpoints2 = { 0, 0 };
                    int[] Ypoints2 = { -10, 10 };

                    newChart.Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

                    newChart.Series.Add("new");
                    newChart.Series["new"].XValueType = ChartValueType.Int32;
                    newChart.Series["new"].YValueType = ChartValueType.Int32;
                    newChart.Series["new"].ChartType = SeriesChartType.Spline;
                    newChart.Series["new"].BorderWidth = 3;
                    newChart.Series["new"].MarkerStyle = MarkerStyle.Diamond;

                    newChart.Series["new"].IsVisibleInLegend = true;
                    newChart.Series["new"].LegendText = "Function";
                    newChart.Series["new"].Color = Color.Green;
                    newChart.Series["new"].Points.DataBindXY(XpointsTesting, YpointsTesting);

                    newChart.Series.Add("paint");
                    newChart.Series["paint"].XValueType = ChartValueType.Int32;
                    newChart.Series["paint"].YValueType = ChartValueType.Int32;
                    newChart.Series["paint"].ChartType = SeriesChartType.Bubble;
                    newChart.Series["paint"].BorderWidth = 10;
                    newChart.Series["paint"].MarkerStyle = MarkerStyle.Cross;

                    newChart.Series["paint"].IsVisibleInLegend = true;
                    newChart.Series["paint"].LegendText = "Function";
                    newChart.Series["paint"].Color = Color.Brown;

                    newChart.Series["paint"].Points.DataBindXY(XpointsTesting, YpointsTesting);

                    newChart.MouseMove += testingChart_DragDrop;
                    newChart.MouseDown += testingChart_MouseDown;
                    newChart.MouseUp += testingChart_MouseUp;

                    testingCharts.Add(newChart);
                    newPage.Controls.Add(newChart);

                    radioButtons.Add(newList);

                }

                pages.Add(newPage);

                tabControl2.SelectedIndexChanged += newPage_click;

            }
        }
        //при выборе типа графика
        void newBox_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < testingCharts.Count; i++)
            {
                if (tabControl2.SelectedTab.Controls.Contains(testingCharts[i]))
                {
                    if (typeGraphicComboBoxes[i].SelectedItem.ToString() == "Линейный")
                    {
                        testingCharts[i].Series["new"].ChartType = SeriesChartType.FastLine;
                        testingCharts[i].Series["new"].Points.DataBindXY(XpointsTesting, YpointsTesting);
                    }
                    if (typeGraphicComboBoxes[i].SelectedItem.ToString() == "Ступенчатый")
                    {
                        testingCharts[i].Series["new"].ChartType = SeriesChartType.StepLine;
                        testingCharts[i].Series["new"].Points.DataBindXY(XpointsTesting, YpointsTesting);
                    }
                    if (typeGraphicComboBoxes[i].SelectedItem.ToString() == "Криволинейный")
                    {
                        testingCharts[i].Series["new"].ChartType = SeriesChartType.Spline;
                        testingCharts[i].Series["new"].Points.DataBindXY(XpointsTesting, YpointsTesting);
                    }
                }
            }
        }
        //при изменении текста в полях для ввода интервалов
        private void axisBoxes_TextChanged_testing(object sender, EventArgs e)
        {
            int index = -1;

            for (int i = 0; i < minXtextBoxes.Count; i++)
            {
                if (tabControl2.SelectedTab.Controls.Contains(minXtextBoxes[i]))
                {
                    index = i;
                }
            }
            try
            {
                int xMin, xMax, yMin, yMax;

                if (minXtextBoxes[index].Text != "" && minXtextBoxes[index].Text != "-" &&
                    maxXtextBoxes[index].Text != "" && maxXtextBoxes[index].Text != "-" &&
                    minYtextBoxes[index].Text != "" && minYtextBoxes[index].Text != "-" &&
                    maxYtextBoxes[index].Text != "" && maxYtextBoxes[index].Text != "-")
                {
                    try
                    {
                        xMin = Convert.ToInt32(minXtextBoxes[index].Text);
                        xMax = Convert.ToInt32(maxXtextBoxes[index].Text);
                        yMin = Convert.ToInt32(minYtextBoxes[index].Text);
                        yMax = Convert.ToInt32(maxYtextBoxes[index].Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Недопустимое значение", "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }

                    if (xMin >= xMax || yMin >= yMax)
                    {
                        MessageBox.Show("Минимум интервала больше или равен максимуму!", "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }

                    testingCharts[index].ChartAreas["Ch"].AxisX.Minimum = xMin;
                    testingCharts[index].ChartAreas["Ch"].AxisX.Maximum = xMax;
                    testingCharts[index].ChartAreas["Ch"].AxisY2.Minimum = yMin;
                    testingCharts[index].ChartAreas["Ch"].AxisY2.Maximum = yMax;
                    testingCharts[index].ChartAreas["Ch"].AxisY.Minimum = yMin;
                    testingCharts[index].ChartAreas["Ch"].AxisY.Maximum = yMax;

                    int[] Xpoints1 = { xMin, xMax };
                    int[] Ypoints1 = { 0, 0 };

                    testingCharts[index].Series["x"].Points.DataBindXY(Xpoints1, Ypoints1);

                    int[] Xpoints2 = { 0, 0 };
                    int[] Ypoints2 = { yMin, yMax };

                    testingCharts[index].Series["y"].Points.DataBindXY(Xpoints2, Ypoints2);

                    newCoordinatesForPoints_testing();
                }
            }
            catch
            {
                return;
            }
        }
        //пересчет координат
        private void newCoordinatesForPoints_testing()
        {
            int index = -1;

            for (int i = 0; i < minXtextBoxes.Count; i++)
            {
                if (tabControl2.SelectedTab.Controls.Contains(minXtextBoxes[i]))
                {
                    index = i;
                }
            }

            double newY = (Convert.ToDouble(maxYtextBoxes[index].Text) + Convert.ToDouble(minYtextBoxes[index].Text)) / 2;

            double Xdistance = (Convert.ToDouble(maxXtextBoxes[index].Text) -
                                Convert.ToDouble(minXtextBoxes[index].Text)) / (XpointsTesting.Count() + 1);

            XpointsTesting[0] = Convert.ToDouble(minXtextBoxes[index].Text) + Xdistance;
            YpointsTesting[0] = newY;

            for (int i = 1; i < XpointsTesting.Count(); i++)
            {
                XpointsTesting[i] = XpointsTesting[i - 1] + Xdistance;
                YpointsTesting[i] = newY;
            }

            newInterval_testing();

            testingCharts[index].Series["new"].Points.DataBindXY(XpointsTesting, YpointsTesting);
            testingCharts[index].Series["paint"].Points.DataBindXY(XpointsTesting, YpointsTesting);

        }
        //пересчет интервалов на осях
        private void newInterval_testing()
        {
            int index = -1;

            for (int i = 0; i < minXtextBoxes.Count; i++)
            {
                if (tabControl2.SelectedTab.Controls.Contains(minXtextBoxes[i]))
                {
                    index = i;
                }
            }

            double XsegmentCount = Convert.ToDouble(maxXtextBoxes[index].Text) - Convert.ToDouble(minXtextBoxes[index].Text);

            if (XsegmentCount <= 11)
            {
                testingCharts[index].ChartAreas["Ch"].AxisX.Interval = 0.5;
            }
            else if (XsegmentCount > 11 && XsegmentCount <= 24)
            {
                testingCharts[index].ChartAreas["Ch"].AxisX.Interval = 1;
            }
            else if (XsegmentCount > 24 && XsegmentCount <= 49)
            {
                testingCharts[index].ChartAreas["Ch"].AxisX.Interval = 2;
            }
            else if (XsegmentCount > 49 && XsegmentCount <= 110)
            {
                testingCharts[index].ChartAreas["Ch"].AxisX.Interval = 5;
            }
            else if (XsegmentCount > 110)
            {
                testingCharts[index].ChartAreas["Ch"].AxisX.Interval = 20;
            }

            double YsegmentCount = Convert.ToDouble(maxYtextBoxes[index].Text) - Convert.ToDouble(minYtextBoxes[index].Text);

            if (YsegmentCount <= 11)
            {
                testingCharts[index].ChartAreas["Ch"].AxisY2.Interval = 0.5;
            }
            else if (YsegmentCount > 11 && YsegmentCount <= 34)
            {
                testingCharts[index].ChartAreas["Ch"].AxisY2.Interval = 1;
            }
            else if (YsegmentCount > 34 && YsegmentCount <= 49)
            {
                testingCharts[index].ChartAreas["Ch"].AxisY2.Interval = 2;
            }
            else if (YsegmentCount > 49 && YsegmentCount <= 171)
            {
                testingCharts[index].ChartAreas["Ch"].AxisY2.Interval = 5;
            }
            else if (YsegmentCount > 171)
            {
                testingCharts[index].ChartAreas["Ch"].AxisY2.Interval = 20;
            }
        }
        //при удалении точки
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (XpointsTesting.Count() > 2)
            {
                XpointsTesting = new double[XpointsTesting.Count() - 1];
                YpointsTesting = new double[YpointsTesting.Count() - 1];

                newCoordinatesForPoints_testing();
            }
        }
        //при добавлении точки
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            XpointsTesting = new double[XpointsTesting.Count() + 1];
            YpointsTesting = new double[YpointsTesting.Count() + 1];

            newCoordinatesForPoints_testing();
        }
        //при открытии окна с ответом
        private void newPage_click(object sender, EventArgs e)
        {
            if (tabControl2.TabPages.Count != 0)
            {
                for (int i = 0; i < testingCharts.Count; i++)
                {
                    if (tabControl2.SelectedTab.Contains(testingCharts[i]))
                    {
                        XpointsTesting = new double[testingCharts[i].Series["paint"].Points.Count];
                        YpointsTesting = new double[testingCharts[i].Series["paint"].Points.Count];

                        for (int j = 0; j < XpointsTesting.Count(); j++)
                        {
                            XpointsTesting[j] = testingCharts[i].Series["paint"].Points[j].XValue;
                            YpointsTesting[j] = testingCharts[i].Series["paint"].Points[j].YValues[0];
                        }
                    }
                }
            }
        }
        //при перемещении курсора по полю построения графика (аналогично созданию графического ворпоса)
        private void testingChart_DragDrop(object sender, MouseEventArgs e)
        {
            int index = -1;

            for (int i = 0; i < minXtextBoxes.Count; i++)
            {
                if (tabControl2.SelectedTab.Controls.Contains(minXtextBoxes[i]))
                {
                    index = i;
                }
            }

            double Xsegment = 604 / (Convert.ToDouble(maxXtextBoxes[index].Text) - Convert.ToDouble(minXtextBoxes[index].Text));
            double Ysegment = 345 / (Convert.ToDouble(maxYtextBoxes[index].Text) - Convert.ToDouble(minYtextBoxes[index].Text));

            eX = (e.X - 28 + Xsegment * Convert.ToDouble(minXtextBoxes[index].Text)) / Xsegment;
            eY = -(e.Y - 16 - Math.Abs(Ysegment * Convert.ToDouble(maxYtextBoxes[index].Text))) / Ysegment;

            for (int i = 0; i < coordinatesLabels.Count; i++)
            {
                if (tabControl2.SelectedTab.Contains(coordinatesLabels[i]))
                {
                    coordinatesLabels[i].Text = Math.Round(eX, 2) + ";" + Math.Round(eY,2);
                }
            }

            if (testingMouseIsDown)
            {
                for (int i = 0; i < testingCharts.Count; i++)
                {
                    if (tabControl2.SelectedTab.Contains(testingCharts[i]))
                    {
                        for (int j = 0; j < XpointsTesting.Count(); j++)
                        {
                            if (eX > XpointsTesting[j] - 0.5 && eX < XpointsTesting[j] + 0.5 && eY > YpointsTesting[j] - 0.5 && eY < YpointsTesting[j] + 0.5)
                            {
                                XpointsTesting[j] = eX;
                                YpointsTesting[j] = eY;
                                j = XpointsTesting.Count();
                            }
                        }
                        testingCharts[i].Series["paint"].Points.DataBindXY(XpointsTesting, YpointsTesting);
                        testingCharts[i].Series["new"].Points.DataBindXY(XpointsTesting, YpointsTesting);

                        if (tabControl2.SelectedTab.Text.Contains("---"))
                        {
                            tabControl2.SelectedTab.Text = tabControl2.SelectedTab.Text.Replace("---", "+");
                        }
                    }
                }
            }
        }

        private bool testingMouseIsDown = false;
        //при нажатии левой кнопки мыши
        private void testingChart_MouseDown(object sender, EventArgs e)
        {
            testingMouseIsDown = true;
        }
        //при отпускании левой кнопки мыши
        private void testingChart_MouseUp(object sender, EventArgs e)
        {
            testingMouseIsDown = false;
        }
        //подсчет результатов
        private void testResults()
        {
            double res = 0;
            double maxPoints = 0;

            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                if (questions.QuestionsList[i].type == type.text || questions.QuestionsList[i].type == type.graphVar)
                {
                    int max = 0;
                    for (int j = 0; j < radioButtons[i].Count; j++)
                    {
                        if (questions.QuestionsList[i].answers[j].point > max)
                        {
                            max = questions.QuestionsList[i].answers[j].point;
                        }
                        if (radioButtons[i][j].Checked)
                        {
                            res += questions.QuestionsList[i].answers[j].point;
                        }
                    }
                    maxPoints += max;
                }
                else if (questions.QuestionsList[i].type == type.graph)
                {
                    for (int k = 0; k < testingCharts.Count; k++)
                    {
                        if (tabControl2.TabPages[i].Contains(testingCharts[k]))
                        {
                            for (int j = 0; j < XpointsTesting.Count(); j++)
                            {
                                XpointsTesting[j] = Math.Round(testingCharts[k].Series["paint"].Points[j].XValue, 1);
                                YpointsTesting[j] = Math.Round(testingCharts[k].Series["paint"].Points[j].YValues[0], 1);
                            }
                        }
                    }

                    string[] str = questions.QuestionsList[i].answers[0].aswerText.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] strX = str[0].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] strY = str[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    double[] xTrueAnsw = new double[strX.Count()];
                    double[] yTrueAnsw = new double[strY.Count()];

                    for (int m = 0; m < xTrueAnsw.Count(); m++)
                    {
                        xTrueAnsw[m] = Convert.ToDouble(strX[m]);
                        yTrueAnsw[m] = Convert.ToDouble(strY[m]);
                    }

                    double max_err = 1;//максимальная ошибка
                    double err = max_err - GraphCheck.Check(xTrueAnsw, yTrueAnsw, XpointsTesting, YpointsTesting, xTrueAnsw.Count());
                    double res_points = 0;

                    if (err > 0)
                    {
                        double perc = (err / max_err) * 100;
                        res_points = questions.QuestionsList[i].answers[0].point;
                        res_points = res_points * perc / 100;
                    }
                    maxPoints += questions.QuestionsList[i].answers[0].point;
                    res += res_points;

                    int a = 0;
                }
            }

            if (access == 0)
            {
                saveResults(Math.Round((100 / maxPoints) * res, 0));
            }

            MessageBox.Show("Вы набрали  " + Math.Round((100 / maxPoints) * res, 0) + " из 100",
                        "Внимание!", MessageBoxButtons.OK);
        }
        //сохранение результатов
        private void saveResults(double points)
        {
            DataTable userDataTable = workBase.sql("SELECT u.id_user FROM t_user u WHERE u.name = '" + userName + "'");

            DataTable courseDataTable = workBase.sql("SELECT c.id_course FROM course c WHERE c.name = '" + courseTestingComboBox.SelectedItem + "'");

            int id_course = Convert.ToInt32(courseDataTable.Rows[0][0]);
            DataTable topicDataTable = workBase.sql("SELECT t.id_topic FROM topic t WHERE t.name = '" + topicTestingComboBox.SelectedItem + "' AND t.id_course = " + id_course);

            string time = DateTime.Now.ToShortTimeString();
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            workBase.sql("INSERT INTO result (id_course, id_topic, id_user, points, date, time) VALUES (" + courseDataTable.Rows[0][0] +", "+ topicDataTable.Rows[0][0] + ", " + userDataTable.Rows[0][0] + ", " + points + ", '"+date+ "', '"+ time+"')");
        }
        //при выборе варианта ответа
        private void radio_button_click(object sender, EventArgs e)
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (tabControl2.SelectedTab == pages[i])
                {
                    pages[i].Text = pages[i].Text.Replace("---", "+");
                }
            }
        }
        //кнопка "завершение теста" до начала тестирования
        private void button_end_click(object sender, EventArgs e)
        {
            testing.Parent = null;
        }
        //кнопка "завершение теста" во время тестирования
        private void button_end_click_testing(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                if (tabControl2.TabPages[i].Text.Contains("---") && t.IsAlive)
                {
                    DialogResult endMess1 = MessageBox.Show("Не на все вопросы даны ответы! Действительно закончить?",
                        "Внимание!", MessageBoxButtons.OKCancel);
                    if (endMess1 == DialogResult.Cancel)
                    {
                        return;
                    }
                    i = tabControl2.TabPages.Count;
                }
            }
            if (t.IsAlive)
            {
                t.Abort();
            }

            testResults();

            testing.Parent = null;
            courseTestingComboBox.Enabled = true;
            topicTestingComboBox.Enabled = true;
            Start.Enabled = true;

            label21.Text = "";
            label22.Text = "";

            tabControl2.TabPages.Clear();
            pages.Clear();
            radioButtons.Clear();
            testingCharts.Clear();

            EndButton.Click -= button_end_click_testing;
            EndButton.Click += button_end_click;

            int a = -9;
            for (int i = 0; i < XpointsTesting.Count(); i++)
            {
                XpointsTesting[i] = a;
                YpointsTesting[i] = 0;
                a += 2;
            }
        }

        #endregion

        #region TIMER

        public delegate void DelegateForTime(Label timer);

        private DelegateForTime DelTime;
        private Thread t;
        private DateTime starTime;
        private DateTime endTime;

        void labeTimer()
        {
            while (true)
            {
                Invoke(DelTime, label22);
            }
        }

        void time(Label labe)
        {
            string[] abc = (questions.time-(DateTime.Now - starTime)).ToString()
                .Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            string s = abc[0];
            labe.Text = s;
            if (s == "00:00:00")
            {
                t.Abort();
                MessageBox.Show("Время вышло!", "Внимание!", MessageBoxButtons.OK);
                button_end_click(EndButton, new EventArgs());
            }
        }
        #endregion

        #region ShowResults
        //изменение размеров дерева
        private void regrowthResultsTreeView()
        {//размер всегда равен половине ширины экрана
            resultsTreeView.Width = Width / 2;

            closeResultsButton.Location = new Point(resultsTreeView.Location.X + resultsTreeView.Width + 5, closeResultsButton.Location.Y);
        }
        //перезаполнение дерева
        private void fillResultsTreeView()
        {
            resultsTreeView.BeginUpdate();

            resultsTreeView.Nodes.Clear();

            List<List<string>> results = workBase.getResults();

            for (int i = 0; i < results.Count; i++)
            {
                resultsTreeView.Nodes.Add(results[i][0]);

                for (int j = 1; j < results[i].Count; j++)
                {
                    resultsTreeView.Nodes[i].Nodes.Add(results[i][j]);
                }
            }

            resultsTreeView.EndUpdate();
        }
        //при выборе в меню "Результаты"
        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            results.Parent = tabControl1;

            regrowthResultsTreeView();
            fillResultsTreeView();
        }
        //закрытие результатов
        private void closeResultsButton_Click(object sender, EventArgs e)
        {
            results.Parent = null;
        }
        #endregion

        // ДЕЙСТВИЕ ПРИ ЗАКРЫТИИ ПРИЛОЖЕНИЯ
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null) t.Abort();

            workBase.connectionClose();

            Environment.Exit(0);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            regrowthCoursesAndTopicsTreeView();
            regrowthResultsTreeView();

            pictureBoxFormula.Height = Height - buttonInputFormula.Location.X - buttonInputFormula.Height;

        }


    }
}
