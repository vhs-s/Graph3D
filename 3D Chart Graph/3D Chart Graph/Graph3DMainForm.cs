
/*****************************************************************************

This class has been written by Elmь (elmue@gmx.de)

Check if you have the latest version on:
https://www.codeproject.com/Articles/5293980/Graph3D-A-Windows-Forms-Render-Control-in-Csharp

*****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using delRendererFunction = Plot3D.Graph3D.delRendererFunction;
using cPoint3D            = Plot3D.Graph3D.cPoint3D;
using eRaster             = Plot3D.Graph3D.eRaster;
using cScatter            = Plot3D.Graph3D.cScatter;
using eNormalize          = Plot3D.Graph3D.eNormalize;
using eSchema             = Plot3D.ColorSchema.eSchema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Serialization;
using _3D_Chart_Graph.Properties;
using log4net.Repository.Hierarchy;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.Text.RegularExpressions;
using _3D_Chart_Graph;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Plot3D
{

    public partial class Graph3DMainForm : Form
    {
        _3D_Chart_Graph.Logger logger = new _3D_Chart_Graph.Logger("Program.log"); // Имя файла лога
        static double[,] dataArray2;

        static string[] axislegend;

        static List<double> dataListX;
        static List<double> dataListY;
        static List<double> dataListXY;

        static List<double> listxtruly;
        static List<double> listytruly;

        static double[] XYStep;

        static double[] mySteps;

        static int controliter;
        static ColorDialog colorDialogAxis = new ColorDialog();


        public Graph3DMainForm()
        {
            InitializeComponent();
            logger.CreateLogFile();
            logger.WriteLog("Application is running");

            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            dataListX = new List<double>();
            dataListY = new List<double>();
            dataListXY = new List<double>();

            listxtruly = new List<double>();
            listytruly = new List<double>();


            XYStep = new double[5];

            mySteps = new double[3];

            axislegend = new string[3];

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "X";
            dataGridView1.Columns[2].Name = "Y";
            dataGridView1.Columns[3].Name = "F(x,y)";
        }
        [Serializable]
        public class AppSettings
        {
       
            public int trackvalueRho { get; set; }
            public int trackvalueTheta { get; set; }
            public int trackvaluePhi { get; set; }
            public int indexofboxRaster {  get; set; }
            public int indexcolorgraph { get; set; }
            public string titleofmygraph { get; set; }
            public string legendWithaxisX { get; set; }
            public string legendWithaxisY {  get; set; }
            public string legendWithaxisZ { get; set; }

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            // This is optional. If you don't want to use Trackbars leave this away.
            graph3D.AssignTrackBars(trackRho, trackTheta, trackPhi);

            comboRaster.Sorted = false;
            foreach (eRaster e_Raster in Enum.GetValues(typeof(eRaster)))
            {
                comboRaster.Items.Add(e_Raster);
            }
            comboRaster.SelectedIndex = (int)eRaster.Labels;

            comboColors.Sorted = false;
            foreach (eSchema e_Schema in Enum.GetValues(typeof(eSchema)))
            {
                comboColors.Items.Add(e_Schema);
            }
            comboColors.SelectedIndex = (int)eSchema.Rainbow1;

            comboDataSrc.SelectedIndex = 0; // set "Callback"
        }

        private void comboDataSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDataSrc.SelectedIndex)
            {
                case 0: SetCallback(); break;
                case 1: SetScatterPlot(false); break;
                case 2: SetScatterPlot(true); break;
                case 3: SetSurface(); break;
            }

            lblInfo.Text = "Points: " + graph3D.TotalPoints;
        }

        private void comboColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color[] c_Colors = ColorSchema.GetSchema((eSchema)comboColors.SelectedIndex);
            graph3D.SetColorScheme(c_Colors, 3);
            
        }

        private void comboRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.Raster = (eRaster)comboRaster.SelectedIndex;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            graph3D.SetCoefficients(1350, 70, 230);
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            SaveFileDialog i_Dlg = new SaveFileDialog();
            i_Dlg.Title = "Save as PNG image";
            i_Dlg.Filter = "PNG Image|*.png";
            i_Dlg.DefaultExt = ".png";

            if (DialogResult.Cancel == i_Dlg.ShowDialog(this))
                return;

            Bitmap i_Bitmap = graph3D.GetScreenshot();
            try
            {
                i_Bitmap.Save(i_Dlg.FileName, ImageFormat.Png);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================================================

        /// <summary>
        /// This demonstrates how to use a callback function which calculates Z values from X and Y
        /// </summary>
        private void SetCallback()
        {
            delRendererFunction f_Callback = delegate (double X, double Y)
            {
                double r = 0.15 * Math.Sqrt(X * X + Y * Y);
                if (r < 1e-10) return 120;
                else return 120 * Math.Sin(r) / r;
            };

            // IMPORTANT: Normalize maintainig the relation between X,Y,Z values otherwise the function will be distorted.
            graph3D.SetFunction(f_Callback, new PointF(-120, -80), new PointF(120, 80), 5, eNormalize.MaintainXYZ);
        }






        /// <summary>
        /// This demonstrates how to set X, Y, Z scatterplot points in form of a spiral.
        /// b_Lines = true --> connect the points with lines.
        /// </summary>
        private void SetScatterPlot(bool b_Lines)
        {
            try
            {
                List<cScatter> i_List = new List<cScatter>();
                if (dataArray2 == null) { dataarraycreate(); }


                for (int i = 0; i < listxtruly.Count; i++)
                {
                    for (int j = 0; j < listytruly.Count; j++)
                    {
                        double X = listxtruly[i];
                        double Y = listytruly[j];
                        double Z = dataArray2[i, j];


                        i_List.Add(new cScatter(X, Y, Z, null));
                    }

                }
                // Depending on your use case you can also specify MaintainXY or MaintainXYZ here
                if (b_Lines)
                { graph3D.SetScatterLines(i_List.ToArray(), eNormalize.Separate, 3); logger.WriteLog("Scatterlines tool used"); }

                else
                { graph3D.SetScatterPoints(i_List.ToArray(), eNormalize.Separate); logger.WriteLog("ScatterPlot tool used"); }

                if ((graph3D.AxisX_Legend == null) && (graph3D.AxisY_Legend == null) && (graph3D.AxisZ_Legend == null))
                {
                    graph3D.AxisX_Legend = "Axis X";
                    graph3D.AxisY_Legend = "Axis Y";
                    graph3D.AxisZ_Legend = "Axiz Z";
                }
                axislegend[0] = graph3D.AxisX_Legend;
                axislegend[1] = graph3D.AxisY_Legend;
                axislegend[2] = graph3D.AxisZ_Legend;
                checkVisibleLegend.Checked = true;
                label20.Text = $"X є [{dataListX.Min()};{dataListX.Max()}]";
                label21.Text = $"Y є [{dataListY.Min()};{dataListY.Max()}]";
                label22.Text = $"Z є [{dataListXY.Min()};{dataListXY.Max()}]";
                label24.Text = $"For X = {mySteps[0]}";
                label25.Text = $"For Y = {mySteps[1]}";
            }
            catch(Exception) { MessageBox.Show("Please check your data set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>
        /// This demonstrates how to set X, Y, Z scatterplot points in form of a heart
        /// </summary>
        private void SetSurface()
        {
            try
            {
                if (dataArray2 == null) { dataarraycreate(); }
                controliter = 1;
                double[,] s32_Values = dataArray2;

                cPoint3D[,] i_Points3D = new cPoint3D[listxtruly.Count, listytruly.Count];
                for (int X = 0; X < listxtruly.Count; X++)
                {
                    for (int Y = 0; Y < listytruly.Count; Y++)
                    {

                        i_Points3D[X, Y] = new cPoint3D(listxtruly[X], listytruly[Y], s32_Values[X, Y]);
                    }


                }

                graph3D.SetSurfacePoints(i_Points3D, eNormalize.Separate);

                // Setting one of the strings = null results in hiding this legend
                if ((graph3D.AxisX_Legend == null) && (graph3D.AxisY_Legend == null) && (graph3D.AxisZ_Legend == null))
                {
                    graph3D.AxisX_Legend = "Axis X";
                    graph3D.AxisY_Legend = "Axis Y";
                    graph3D.AxisZ_Legend = "Axiz Z";
                }
                axislegend[0] = graph3D.AxisX_Legend;
                axislegend[1] = graph3D.AxisY_Legend;
                axislegend[2] = graph3D.AxisZ_Legend;
                checkVisibleLegend.Checked = true;
                label20.Text = $"X є [{dataListX.Min()};{dataListX.Max()}]";
                label21.Text = $"Y є [{dataListY.Min()};{dataListY.Max()}]";
                label22.Text = $"Z є [{dataListXY.Min()};{dataListXY.Max()}]";
                label24.Text = $"For X = {mySteps[0]}";
                label25.Text = $"For Y = {mySteps[1]}";

                // IMPORTANT: Normalize X,Y,Z separately because there is an extreme mismatch 
                // between X values (< 300) and Z values (> 30000)
                //  graph3D.SetSurfacePoints(i_Points3D, eNormalize.Separate);
                logger.WriteLog("Surface tool used");
            }
            catch (Exception) { MessageBox.Show("Please check your data set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
            
        

        private void graph3D_Load(object sender, EventArgs e)
        {

        }

        private void CreateNewTab()
        {
            logger.WriteLog($"Tab Set {tabControl2.TabCount + 1} created");
            // Создаем новую вкладку
            TabPage newTabPage = new TabPage("Set" + (tabControl2.TabCount + 1));

            


            // Создаем новые экземпляры элементов управления
            System.Windows.Forms.TextBox newTextBox1 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TextBox newTextBox2 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TextBox newTextBox3 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TextBox newTextBox4 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TextBox newTextBox5 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TextBox newTextBox6 = new System.Windows.Forms.TextBox();



            System.Windows.Forms.Button newButton = new System.Windows.Forms.Button();
            System.Windows.Forms.Button newButtonSave = new System.Windows.Forms.Button();
            System.Windows.Forms.Button savetofilesetbutton = new System.Windows.Forms.Button();
            System.Windows.Forms.Button loadfrombilebut = new System.Windows.Forms.Button();


            DataGridView newdataGridView = new DataGridView();


            System.Windows.Forms.Label newLabel1 = new System.Windows.Forms.Label(); // Создаем новые подписи
            System.Windows.Forms.Label newLabel2 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newLabel3 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newLabel4 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newLabel5 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newLabel6 = new System.Windows.Forms.Label();




            System.Windows.Forms.Button newButton2 = new System.Windows.Forms.Button(); // Создаем новые кнопки

            // Настройка позиции элементов управления
            newTextBox1.Location = textBox1.Location;
            newTextBox2.Location = textBox2.Location;
            newTextBox3.Location = textBox3.Location;
            newTextBox4.Location = textBox4.Location;
            newTextBox5.Location = textBox5.Location;
            newTextBox6.Location = textBox6.Location;



            newButton.Location = button1.Location;
            newButtonSave.Location = SaveSetButton.Location;
            savetofilesetbutton.Location = savetofilebutton.Location;
            loadfrombilebut.Location = loadfromfilebutton.Location;

            newdataGridView.Location = dataGridView1.Location;

          //  checkquantXY.Location = checkforXYequals.Location;

            newLabel1.Location = label13.Location; // Устанавливаем позиции подписей
            newLabel2.Location = label12.Location;
            newLabel3.Location = label11.Location;
            newLabel4.Location = label10.Location;
            newLabel5.Location = label14.Location;
            newLabel6.Location = label15.Location;


            // Настройка размеров элементов управления
            newTextBox1.Size = textBox1.Size;
            newTextBox2.Size = textBox2.Size;
            newTextBox3.Size = textBox3.Size;
            newTextBox4.Size = textBox4.Size;
            newTextBox5.Size = textBox5.Size;
            newTextBox6.Size = textBox6.Size;



            newButton.Size = button1.Size;
            newButtonSave.Size = SaveSetButton.Size;
            savetofilesetbutton.Size = savetofilebutton.Size;
            loadfrombilebut.Size = loadfromfilebutton.Size;

            newdataGridView.Size = dataGridView1.Size;

          //  checkquantXY.Size = checkforXYequals.Size;

            newLabel1.Size = label13.Size; // Устанавливаем размеры подписей
            newLabel2.Size = label12.Size;
            newLabel3.Size = label11.Size;
            newLabel4.Size = label10.Size;
            newLabel5.Size = label14.Size;
            newLabel6.Size = label15.Size;


          //  checkquantXY.Text = checkforXYequals.Text;
            // Устанавливаем текст для подписей
            newLabel1.Text = label13.Text;
            newLabel2.Text = label12.Text;
            newLabel3.Text = label11.Text;
            newLabel4.Text = label10.Text;
            newLabel5.Text = label14.Text;
            newLabel6.Text = label15.Text;

            // Устанавливаем текст для кнопок
            newButton.Text = button1.Text;
            newButtonSave.Text = SaveSetButton.Text;
            savetofilesetbutton.Text = savetofilebutton.Text;
            loadfrombilebut.Text = loadfromfilebutton.Text;

            /*newTextBox1.Text = "-10";
            newTextBox2.Text = "10";
            newTextBox3.Text = "0,5";
            newTextBox4.Text = "-1";
            newTextBox5.Text = "1";
            newTextBox6.Text = "0,1";
            */






            // Добавляем столбцы в новый DataGridView
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                DataGridViewColumn newColumn = new DataGridViewColumn(column.CellTemplate);
                newColumn.HeaderText = column.HeaderText;
                newColumn.Name = column.Name;
                newColumn.DataPropertyName = column.DataPropertyName;
                newColumn.Visible = column.Visible;
                newdataGridView.Columns.Add(newColumn);
            }



            // Добавляем обработчик события для кнопки
            newButton.Click += (sender, e) =>
            {
                newdataGridView.Rows.Clear();
                try
                {
                    Random random = new Random();
                    double left = double.Parse(newTextBox1.Text);
                    double right = double.Parse(newTextBox2.Text); 
                    double step = double.Parse(newTextBox3.Text); 
                    double leftfory = double.Parse(newTextBox4.Text); 
                    double rightfory = double.Parse(newTextBox5.Text);
                    double stepfory = double.Parse(newTextBox6.Text);
                    string eq = equationBox.Text;
                    int q = 0;

                    listxtruly.Clear();
                    listytruly.Clear();

                    _3D_Chart_Graph.Xgenerate xs = new _3D_Chart_Graph.Xgenerate(left, right, step);
                    _3D_Chart_Graph.Xgenerate ygen = new _3D_Chart_Graph.Xgenerate(leftfory, rightfory, stepfory);
                    _3D_Chart_Graph.MyFunctions fun = new _3D_Chart_Graph.MyFunctions();

                    double[] xmass = xs.Xgen(left, right, step);
                    double[] ymass = ygen.Xgen(leftfory, rightfory, stepfory);

                    


                    for (int i = 0; i < xmass.Length; i++)
                    {
                        listxtruly.Add(xmass[i]);
                    }
                    for (int i = 0; i < ymass.Length; i++)
                    {
                        listytruly.Add(ymass[i]);
                    }

                    if (xmass.Length > ymass.Length)
                    {
                        for (int i = 0; i < xmass.Length; i++)
                        {
                            for (int j = 0; j < ymass.Length; j++)
                            {
                                double value = fun.f1(xmass[i], ymass[j], eq);
                                dataListXY.Add(value);
                                DataGridViewRow newRow = new DataGridViewRow();
                                newRow.CreateCells(newdataGridView);
                                q++;
                                newRow.Cells[0].Value = q;
                                // Устанавливаем значения в соответствующие ячейки строки

                                newRow.Cells[1].Value = xmass[i]; // Предполагается, что x находится в первом столбце
                                newRow.Cells[2].Value = ymass[j]; // Предполагается, что y находится во втором столбце
                                newRow.Cells[3].Value = value; // Предполагается, что результат формулы должен быть в третьем столбце

                                // Добавляем строку в DataGridView
                                newdataGridView.Rows.Add(newRow);

                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ymass.Length; i++)
                        {
                            for (int j = 0; j < xmass.Length; j++)
                            {
                                double value = fun.f1(xmass[j], ymass[i], eq);
                                dataListXY.Add(value);
                                DataGridViewRow newRow = new DataGridViewRow();
                                newRow.CreateCells(newdataGridView);
                                q++;
                                newRow.Cells[0].Value = q;
                                // Устанавливаем значения в соответствующие ячейки строки

                                newRow.Cells[1].Value = xmass[j]; // Предполагается, что x находится в первом столбце
                                newRow.Cells[2].Value = ymass[i]; // Предполагается, что y находится во втором столбце
                                newRow.Cells[3].Value = value; // Предполагается, что результат формулы должен быть в третьем столбце

                                // Добавляем строку в DataGridView
                                newdataGridView.Rows.Add(newRow);

                            }
                        }
                    }
             

                    mySteps[0] = xs.StepFinder(step, xmass[0], xmass[1]);
                    mySteps[1] = ygen.StepFinder(stepfory, ymass[0], ymass[1]);
                }
                catch(FormatException) { MessageBox.Show("Perhaps one of your values contains a comma or symbol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (OverflowException) { MessageBox.Show("You have gone beyond what is permitted", "Overflow", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (Xgenerate.BorderExeption) { MessageBox.Show($"The left border must be smaller than the right", "BorderError", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (Xgenerate.ZeroStepExeption) { MessageBox.Show($"Choose a step other than zero!", "ZeroStepError", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (NCalc.EvaluationException) { MessageBox.Show($"Сheck if all operator arguments are specified", "Not enough operator parameters", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (MyFunctions.OneParameter) { MessageBox.Show($"Please enter a function of two variables. Example: x + y", "Function with one parameter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (System.ArgumentException) { MessageBox.Show($"The function only accepts parameters named x and y, excluding for example Log(x, y, radix). (lower case for parametrs)", "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (MyFunctions.NaNorInfinity) { MessageBox.Show($"The calculations resulted in an invalid value. Сheck the log file for more information!", "NaN or Infinity", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (Exception ex) { MessageBox.Show($"{ex}", "Other Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
              

            };
            newButtonSave.Click += (sender, e) =>
            {
                
                dataListX.Clear();
                dataListY.Clear();
                dataListXY.Clear();

              

                foreach (DataGridViewRow row in newdataGridView.Rows)
                {

                    // Получаем данные из ячейки
                    if (row.Cells[1].Value != null && double.TryParse(row.Cells[1].Value.ToString(), out double doubleValueX))
                    {
                        dataListX.Add(doubleValueX);
                    }
                    if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double doubleValueY))
                    {
                        dataListY.Add(doubleValueY);
                    }
                    if (row.Cells[3].Value != null && double.TryParse(row.Cells[3].Value.ToString(), out double doubleValueXY))
                    {
                        dataListXY.Add(doubleValueXY);
                    }
                    
                }


                dataarraycreate();

            };

            savetofilesetbutton.Click += (sender, e) =>
            {
                SaveToFile(newdataGridView);
            };
            loadfrombilebut.Click += (sender, e) =>
            {
                LoadFromFile(newdataGridView);
            };

           
            // Добавляем элементы управления на новую вкладку
            newTabPage.Controls.Add(newTextBox1);
            newTabPage.Controls.Add(newTextBox2);
            newTabPage.Controls.Add(newTextBox3);
            newTabPage.Controls.Add(newTextBox4);
            newTabPage.Controls.Add(newTextBox5);
            newTabPage.Controls.Add(newTextBox6);


            newTabPage.Controls.Add(newButton);
            newTabPage.Controls.Add(newButtonSave);
            newTabPage.Controls.Add(savetofilesetbutton);
            newTabPage.Controls.Add(loadfrombilebut);

            newTabPage.Controls.Add(newLabel1); // Добавляем подписи на новую вкладку
            newTabPage.Controls.Add(newLabel2);
            newTabPage.Controls.Add(newLabel3);
            newTabPage.Controls.Add(newLabel4);
            newTabPage.Controls.Add(newLabel5);
            newTabPage.Controls.Add(newLabel6);



            newTabPage.Controls.Add(newdataGridView);

            // Добавляем новую вкладку на TabControl
            tabControl2.TabPages.Add(newTabPage);
        }

        private void dataarraycreate()
        {
            try
            {
                dataArray2 = new double[listxtruly.Count, listytruly.Count];

                if (listxtruly.Count >= listytruly.Count)
                {
                    for (int i = 0; i < listxtruly.Count; i++)
                    {
                        for (int j = 0; j < listytruly.Count; j++)
                        {
                            int index = i * listytruly.Count + j;
                            double z = dataListXY[index];
                            dataArray2[i, j] = z;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < listytruly.Count; i++)
                    {
                        for (int j = 0; j < listxtruly.Count; j++)
                        {
                            int index = i * listxtruly.Count + j;
                            double z = dataListXY[index];
                            dataArray2[j, i] = z;
                        }
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException) { MessageBox.Show("You may have tried to save a set with errors. Please recreate the set", "SaveSetError", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void addtabbutton_Click(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void deletetabbutton_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab != null)
            {
                logger.WriteLog($"Tab {tabControl2.SelectedTab} removed");
                tabControl2.TabPages.Remove(tabControl2.SelectedTab);
            }
        }

        private void Graph3DMainForm_Load(object sender, EventArgs e)
        {
            tabControl2.TabPages.Remove(tabControl2.SelectedTab);
            coloraxisbox.SelectedIndex = 3;
            boxtoformatlegend.SelectedIndex = 3;
            checkVisibleLegend.Checked = true;
            equationBox.Font = new Font(equationBox.Font.FontFamily, 14);
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.WriteLog("Form is closed");
        }

        private void coloraxisbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (coloraxisbox.SelectedIndex)
            {
                case 0:
                    if (colorDialogAxis.ShowDialog() == DialogResult.OK)
                        graph3D.AxisX_Color = colorDialogAxis.Color;
                        logger.WriteLog("X axis painted");
                    break;
                case 1:
                    if (colorDialogAxis.ShowDialog() == DialogResult.OK)
                        graph3D.AxisY_Color = colorDialogAxis.Color;
                        logger.WriteLog("Y axis painted");
                    break;
                case 2:
                    if (colorDialogAxis.ShowDialog() == DialogResult.OK)
                        graph3D.AxisZ_Color = colorDialogAxis.Color;
                        logger.WriteLog("Z axis painted");
                    break;
                default: break;
            }
        }

     
        private void SaveToFile(DataGridView newdatagrid)
        {
            // Определяем путь к папке "Документы"
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Создаем имя файла на основе "Set" и номера
            string fileName = $"Set{GetFileNumber()}.set";
            string fileNameXY = $"XYFunSet{GetFileNumber()}.txt";

            // Полный путь к файлу
            string filePath = Path.Combine(documentsPath, fileName);
            string filePathXY = Path.Combine(documentsPath, fileNameXY);

            // Объединяем списки в строку с вертикальной чертой в качестве разделителя
            string dataX = string.Join("|", listxtruly);
            string dataY = string.Join("|", listytruly);
            string dataXY = string.Join("|", dataListXY);

            File.WriteAllText(filePathXY, dataX + "\n" + dataY + "\n" + dataXY);

            try
            {
                // Открываем поток для записи в файл
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Проходим по каждой строке в DataGridView
                    foreach (DataGridViewRow row in newdatagrid.Rows)
                    {
                        // Получаем значения из столбцов X, Y и F
                        string xValue = row.Cells["X"].Value?.ToString();
                        string yValue = row.Cells["Y"].Value?.ToString();
                        string fValue = row.Cells["F(x,y)"].Value?.ToString();

                        // Записываем значения в файл, разделяя их запятыми
                        if (xValue != null || yValue != null || fValue != null)
                        {
                            sw.WriteLine($"{xValue};{yValue};{fValue}");
                        }
                    }
                }

                MessageBox.Show("Data successfully saved to file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}");
            }
            logger.WriteLog($"The file named {fileName} is saved");
        }

        // Метод для получения номера файла
        private int GetFileNumber()
        {
            // Предположим, что номер начинается с 1
            int number = 1;

            // Определяем путь к папке "Документы"
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Пока файл существует, увеличиваем номер
            while (File.Exists(Path.Combine(documentsPath, $"Set{number}.set")))
            {
                number++;
            }

            return number;
        }
        static int GetFileNumberForLoad(string filename)
        {
            // Используем регулярное выражение для поиска всех последовательностей цифр в названии файла
            Match match = Regex.Match(filename, @"\d+");

            if (match.Success)
            {
                // Если найдено, преобразуем строку с цифрами в число и возвращаем его
                return int.Parse(match.Value);
            }
            else
            {
                // Если цифры не найдены, можно вернуть значение по умолчанию или выбросить исключение
                throw new ArgumentException("В названии файла не найдено числа");
            }
        }

        private void LoadFromFile(DataGridView dataGridView)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.set)|*.set|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл для загрузки данных";
            int linenumber = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        dataGridView.Rows.Clear(); // Очищаем DataGridView перед загрузкой новых данных

                        string line;
                        int F = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] values = line.Split(';');
                            string values2 = line;

                            if (values.Length >= 3)
                            {
                                // Создаем новую строку в DataGridView
                                if (values[0] != "" || values[1] != "" || values[2] != "")
                                {
                                    DataGridViewRow newRow = new DataGridViewRow();
                                    newRow.CreateCells(dataGridView);

                                    // Устанавливаем значения в конкретные столбцы новой строки
                                    newRow.Cells[0].Value = linenumber;
                                    newRow.Cells[1].Value = values[0];
                                    newRow.Cells[2].Value = values[1];
                                    newRow.Cells[3].Value = values[2];
                                    linenumber++;
                                    // Добавляем строку в DataGridView
                                    dataGridView.Rows.Add(newRow);
                                }
                                else
                                {
                                    F++;
                                    continue;
                                }
                            }
                        }
                        // Получаем путь к папке "Документы"
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string filePath = Path.Combine(documentsPath, $"XYFunSet{GetFileNumberForLoad(openFileDialog.FileName)}.txt");

                        if (File.Exists(filePath))
                        {
                            // Читаем строки из файла
                            string[] lines = File.ReadAllLines(filePath);

                            // Разделяем строки на элементы и преобразуем в списки
                            listxtruly = new List<double>(Array.ConvertAll(lines[0].Split('|'), double.Parse));
                            listytruly = new List<double>(Array.ConvertAll(lines[1].Split('|'), double.Parse));
                            dataListXY = new List<double>(Array.ConvertAll(lines[2].Split('|'), double.Parse));

                           
                        }
                        if (F > 0)
                        {
                            MessageBox.Show("Warning!","The file contained lines with incomplete data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    logger.WriteLog($"The file on path {openFileDialog.FileName} is loaded");
                    MessageBox.Show("The data was successfully loaded from the file.");
                }
                catch (System.ArgumentOutOfRangeException) { MessageBox.Show("You may have tried to load a set with errors. Please recreate the set", "SaveSetError", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void checkVisibleLegend_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkVisibleLegend.Checked) { logger.WriteLog("Legend Visible changed"); graph3D.AxisX_Legend = null; graph3D.AxisY_Legend = null; graph3D.AxisZ_Legend = null; }
            else { graph3D.AxisX_Legend = axislegend[0]; graph3D.AxisY_Legend = axislegend[1]; graph3D.AxisZ_Legend = axislegend[2]; }
        }

        private void boxtoformatlegend_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(boxtoformatlegend.SelectedIndex)
            {
                case 0:
                    graph3D.AxisX_Legend = textboxForNewNameOfLegend.Text; axislegend[0] = textboxForNewNameOfLegend.Text; logger.WriteLog("X axis renamed"); break;
                case 1:
                    graph3D.AxisY_Legend = textboxForNewNameOfLegend.Text; axislegend[1] = textboxForNewNameOfLegend.Text; logger.WriteLog("Y axis renamed"); break;
                case 2:
                    graph3D.AxisZ_Legend = textboxForNewNameOfLegend.Text; axislegend[2] = textboxForNewNameOfLegend.Text; logger.WriteLog("Z axis renamed"); break;
                default: break;
            }
        }

        private void buttonforchangetitle_Click(object sender, EventArgs e)
        {
            label27.Text = texttitle.Text;
            logger.WriteLog("Title renamed");
        }

        private void SaveSettings()
        {
            AppSettings settings = new AppSettings();
            settings.trackvalueRho = trackRho.Value;
            settings.trackvalueTheta = trackTheta.Value;
            settings.trackvaluePhi = trackPhi.Value;
            settings.indexofboxRaster = comboRaster.SelectedIndex;
            settings.indexcolorgraph = comboColors.SelectedIndex;
            settings.titleofmygraph = texttitle.Text;
            settings.legendWithaxisX = axislegend[0];
            settings.legendWithaxisY = axislegend[1];
            settings.legendWithaxisZ = axislegend[2];


            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsPath, "settings.xml");
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, settings);
            }
            logger.WriteLog("Preset saved");
        }

        private AppSettings LoadSettings()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsPath, "settings.xml");
            logger.WriteLog("Preset loaded");
            if (File.Exists(filePath))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    using (TextReader reader = new StreamReader(filePath))
                    {
                        return (AppSettings)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Read File Error: " + ex.Message);
                    return new AppSettings(); // Вернуть пустые настройки в случае ошибки
                }
            }
            else
            {
                MessageBox.Show("File does not exist.");
                return new AppSettings(); // Если файл не существует, вернуть пустые настройки
            }
        }

        private void saveloadbutton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void loadsettingsbutton_Click(object sender, EventArgs e)
        {
            AppSettings settings = LoadSettings();
           
            comboRaster.SelectedIndex = settings.indexofboxRaster;
            comboColors.SelectedIndex = settings.indexcolorgraph;
            graph3D.SetCoefficients(settings.trackvalueRho, settings.trackvalueTheta, settings.trackvaluePhi);
            label27.Text = settings.titleofmygraph;
            graph3D.AxisX_Legend = settings.legendWithaxisX;
            graph3D.AxisY_Legend = settings.legendWithaxisY;
            graph3D.AxisZ_Legend = settings.legendWithaxisZ;
        }

        private void loadfromfilebutton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}
   
    
