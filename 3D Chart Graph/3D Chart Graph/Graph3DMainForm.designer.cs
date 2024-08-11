namespace Plot3D
{
    partial class Graph3DMainForm
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
            this.trackRho = new System.Windows.Forms.TrackBar();
            this.trackTheta = new System.Windows.Forms.TrackBar();
            this.trackPhi = new System.Windows.Forms.TrackBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.comboColors = new System.Windows.Forms.ComboBox();
            this.comboDataSrc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboRaster = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textboxForNewNameOfLegend = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.equationBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.deletetabbutton = new System.Windows.Forms.Button();
            this.addtabbutton = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.loadfromfilebutton = new System.Windows.Forms.Button();
            this.savetofilebutton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SaveSetButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.loadsettingsbutton = new System.Windows.Forms.Button();
            this.saveloadbutton = new System.Windows.Forms.Button();
            this.buttonforchangetitle = new System.Windows.Forms.Button();
            this.texttitle = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.boxtoformatlegend = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkVisibleLegend = new System.Windows.Forms.CheckBox();
            this.coloraxisbox = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.graph3D = new Plot3D.Graph3D();
            ((System.ComponentModel.ISupportInitialize)(this.trackRho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTheta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPhi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackRho
            // 
            this.trackRho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackRho.Location = new System.Drawing.Point(57, 306);
            this.trackRho.Name = "trackRho";
            this.trackRho.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackRho.Size = new System.Drawing.Size(45, 290);
            this.trackRho.TabIndex = 10;
            this.trackRho.TickFrequency = 20;
            this.trackRho.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackTheta
            // 
            this.trackTheta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackTheta.Location = new System.Drawing.Point(104, 306);
            this.trackTheta.Name = "trackTheta";
            this.trackTheta.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackTheta.Size = new System.Drawing.Size(45, 289);
            this.trackTheta.TabIndex = 11;
            this.trackTheta.TickFrequency = 20;
            this.trackTheta.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackPhi
            // 
            this.trackPhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackPhi.Location = new System.Drawing.Point(9, 306);
            this.trackPhi.Name = "trackPhi";
            this.trackPhi.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackPhi.Size = new System.Drawing.Size(45, 289);
            this.trackPhi.TabIndex = 12;
            this.trackPhi.TickFrequency = 20;
            this.trackPhi.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(6, 129);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(25, 13);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "Info";
            // 
            // comboColors
            // 
            this.comboColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColors.FormattingEnabled = true;
            this.comboColors.Location = new System.Drawing.Point(5, 63);
            this.comboColors.MaxDropDownItems = 30;
            this.comboColors.Name = "comboColors";
            this.comboColors.Size = new System.Drawing.Size(121, 21);
            this.comboColors.TabIndex = 2;
            this.comboColors.SelectedIndexChanged += new System.EventHandler(this.comboColors_SelectedIndexChanged);
            // 
            // comboDataSrc
            // 
            this.comboDataSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataSrc.FormattingEnabled = true;
            this.comboDataSrc.Items.AddRange(new object[] {
            "Callback",
            "Scatterplot",
            "Scatterlines",
            "Surface"});
            this.comboDataSrc.Location = new System.Drawing.Point(5, 23);
            this.comboDataSrc.MaxDropDownItems = 30;
            this.comboDataSrc.Name = "comboDataSrc";
            this.comboDataSrc.Size = new System.Drawing.Size(121, 21);
            this.comboDataSrc.TabIndex = 1;
            this.comboDataSrc.SelectedIndexChanged += new System.EventHandler(this.comboDataSrc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(214, 598);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Left mouse button : Elevate,  Right mouse: Rotate,  Left mouse + SHIFT: Move,  Le" +
    "ft mouse + CTRL or wheel: Zoom";
            // 
            // comboRaster
            // 
            this.comboRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRaster.FormattingEnabled = true;
            this.comboRaster.Location = new System.Drawing.Point(5, 102);
            this.comboRaster.MaxDropDownItems = 30;
            this.comboRaster.Name = "comboRaster";
            this.comboRaster.Size = new System.Drawing.Size(121, 21);
            this.comboRaster.TabIndex = 3;
            this.comboRaster.SelectedIndexChanged += new System.EventHandler(this.comboRaster_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Data Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Color Scheme:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Coordinate System:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 601);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Rho";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Theta";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 598);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Phi";
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(132, 147);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(121, 23);
            this.btnScreenshot.TabIndex = 5;
            this.btnScreenshot.Text = "Save Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(5, 147);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(123, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Position";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // textboxForNewNameOfLegend
            // 
            this.textboxForNewNameOfLegend.Location = new System.Drawing.Point(132, 190);
            this.textboxForNewNameOfLegend.Name = "textboxForNewNameOfLegend";
            this.textboxForNewNameOfLegend.Size = new System.Drawing.Size(121, 20);
            this.textboxForNewNameOfLegend.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 643);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.equationBox);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.deletetabbutton);
            this.tabPage1.Controls.Add(this.addtabbutton);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 617);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SetCreate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // equationBox
            // 
            this.equationBox.Location = new System.Drawing.Point(6, 526);
            this.equationBox.Multiline = true;
            this.equationBox.Name = "equationBox";
            this.equationBox.Size = new System.Drawing.Size(604, 71);
            this.equationBox.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(192, 507);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(520, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "For the program to work correctly, your set or file must be arranged as follows -" +
    " Value X, Value Y, Value F(x,y).";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 478);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "\"-\" delete Set";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "\"+\" add Set";
            // 
            // deletetabbutton
            // 
            this.deletetabbutton.Location = new System.Drawing.Point(99, 448);
            this.deletetabbutton.Name = "deletetabbutton";
            this.deletetabbutton.Size = new System.Drawing.Size(87, 72);
            this.deletetabbutton.TabIndex = 12;
            this.deletetabbutton.Text = "-";
            this.deletetabbutton.UseVisualStyleBackColor = true;
            this.deletetabbutton.Click += new System.EventHandler(this.deletetabbutton_Click);
            // 
            // addtabbutton
            // 
            this.addtabbutton.Location = new System.Drawing.Point(6, 448);
            this.addtabbutton.Name = "addtabbutton";
            this.addtabbutton.Size = new System.Drawing.Size(87, 72);
            this.addtabbutton.TabIndex = 11;
            this.addtabbutton.Text = "+";
            this.addtabbutton.UseVisualStyleBackColor = true;
            this.addtabbutton.Click += new System.EventHandler(this.addtabbutton_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(777, 436);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.loadfromfilebutton);
            this.tabPage3.Controls.Add(this.savetofilebutton);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBox5);
            this.tabPage3.Controls.Add(this.textBox4);
            this.tabPage3.Controls.Add(this.SaveSetButton);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(769, 410);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "ForDebug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // loadfromfilebutton
            // 
            this.loadfromfilebutton.Location = new System.Drawing.Point(263, 210);
            this.loadfromfilebutton.Name = "loadfromfilebutton";
            this.loadfromfilebutton.Size = new System.Drawing.Size(251, 52);
            this.loadfromfilebutton.TabIndex = 17;
            this.loadfromfilebutton.Text = "LoadFromFile";
            this.loadfromfilebutton.UseVisualStyleBackColor = true;
            this.loadfromfilebutton.Click += new System.EventHandler(this.loadfromfilebutton_Click);
            // 
            // savetofilebutton
            // 
            this.savetofilebutton.Location = new System.Drawing.Point(6, 326);
            this.savetofilebutton.Name = "savetofilebutton";
            this.savetofilebutton.Size = new System.Drawing.Size(251, 52);
            this.savetofilebutton.TabIndex = 15;
            this.savetofilebutton.Text = "SaveSetToFile";
            this.savetofilebutton.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(112, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Step";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 161);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(112, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Ymax";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Ymin";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 135);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 109);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 10;
            // 
            // SaveSetButton
            // 
            this.SaveSetButton.Location = new System.Drawing.Point(6, 268);
            this.SaveSetButton.Name = "SaveSetButton";
            this.SaveSetButton.Size = new System.Drawing.Size(251, 52);
            this.SaveSetButton.TabIndex = 9;
            this.SaveSetButton.Text = "Save to build";
            this.SaveSetButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(147, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(584, 198);
            this.dataGridView1.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Step";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Display points";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(112, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Xmax";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(112, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Xmin";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.loadsettingsbutton);
            this.tabPage2.Controls.Add(this.saveloadbutton);
            this.tabPage2.Controls.Add(this.buttonforchangetitle);
            this.tabPage2.Controls.Add(this.texttitle);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.boxtoformatlegend);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.checkVisibleLegend);
            this.tabPage2.Controls.Add(this.coloraxisbox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textboxForNewNameOfLegend);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboColors);
            this.tabPage2.Controls.Add(this.comboDataSrc);
            this.tabPage2.Controls.Add(this.trackPhi);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.trackRho);
            this.tabPage2.Controls.Add(this.trackTheta);
            this.tabPage2.Controls.Add(this.comboRaster);
            this.tabPage2.Controls.Add(this.btnScreenshot);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lblInfo);
            this.tabPage2.Controls.Add(this.graph3D);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 617);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graph";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // loadsettingsbutton
            // 
            this.loadsettingsbutton.Location = new System.Drawing.Point(132, 63);
            this.loadsettingsbutton.Name = "loadsettingsbutton";
            this.loadsettingsbutton.Size = new System.Drawing.Size(122, 23);
            this.loadsettingsbutton.TabIndex = 40;
            this.loadsettingsbutton.Text = "LoadPreset";
            this.loadsettingsbutton.UseVisualStyleBackColor = true;
            this.loadsettingsbutton.Click += new System.EventHandler(this.loadsettingsbutton_Click);
            // 
            // saveloadbutton
            // 
            this.saveloadbutton.Location = new System.Drawing.Point(132, 23);
            this.saveloadbutton.Name = "saveloadbutton";
            this.saveloadbutton.Size = new System.Drawing.Size(122, 23);
            this.saveloadbutton.TabIndex = 25;
            this.saveloadbutton.Text = "SavePreset";
            this.saveloadbutton.UseVisualStyleBackColor = true;
            this.saveloadbutton.Click += new System.EventHandler(this.saveloadbutton_Click);
            // 
            // buttonforchangetitle
            // 
            this.buttonforchangetitle.Location = new System.Drawing.Point(5, 242);
            this.buttonforchangetitle.Name = "buttonforchangetitle";
            this.buttonforchangetitle.Size = new System.Drawing.Size(120, 23);
            this.buttonforchangetitle.TabIndex = 39;
            this.buttonforchangetitle.Text = "ChangeTitle";
            this.buttonforchangetitle.UseVisualStyleBackColor = true;
            this.buttonforchangetitle.Click += new System.EventHandler(this.buttonforchangetitle_Click);
            // 
            // texttitle
            // 
            this.texttitle.Location = new System.Drawing.Point(5, 271);
            this.texttitle.Name = "texttitle";
            this.texttitle.Size = new System.Drawing.Size(120, 20);
            this.texttitle.TabIndex = 38;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(256, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 13);
            this.label27.TabIndex = 37;
            this.label27.Text = "TITLE";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(578, 535);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 13);
            this.label26.TabIndex = 36;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(578, 507);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 13);
            this.label25.TabIndex = 35;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(578, 478);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 13);
            this.label24.TabIndex = 34;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(570, 454);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 13);
            this.label23.TabIndex = 33;
            this.label23.Text = "Division price:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(256, 535);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 13);
            this.label22.TabIndex = 32;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(256, 507);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 13);
            this.label21.TabIndex = 31;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(256, 478);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(256, 454);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Range of values along the axes:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(129, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "New Legend Name";
            // 
            // boxtoformatlegend
            // 
            this.boxtoformatlegend.AutoCompleteCustomSource.AddRange(new string[] {
            "LegendAxisX",
            "LegendAxisY",
            "LegendAxisZ",
            "ChooseLegend"});
            this.boxtoformatlegend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxtoformatlegend.FormattingEnabled = true;
            this.boxtoformatlegend.Items.AddRange(new object[] {
            "LegendAxisX",
            "LegendAxisY",
            "LegendAxisZ",
            "Choose Legend"});
            this.boxtoformatlegend.Location = new System.Drawing.Point(5, 189);
            this.boxtoformatlegend.Name = "boxtoformatlegend";
            this.boxtoformatlegend.Size = new System.Drawing.Size(121, 21);
            this.boxtoformatlegend.TabIndex = 27;
            this.boxtoformatlegend.SelectedIndexChanged += new System.EventHandler(this.boxtoformatlegend_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 173);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Legend";
            // 
            // checkVisibleLegend
            // 
            this.checkVisibleLegend.AutoSize = true;
            this.checkVisibleLegend.Location = new System.Drawing.Point(9, 216);
            this.checkVisibleLegend.Name = "checkVisibleLegend";
            this.checkVisibleLegend.Size = new System.Drawing.Size(95, 17);
            this.checkVisibleLegend.TabIndex = 25;
            this.checkVisibleLegend.Text = "Visible Legend";
            this.checkVisibleLegend.UseVisualStyleBackColor = true;
            this.checkVisibleLegend.CheckedChanged += new System.EventHandler(this.checkVisibleLegend_CheckedChanged);
            // 
            // coloraxisbox
            // 
            this.coloraxisbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coloraxisbox.FormattingEnabled = true;
            this.coloraxisbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.coloraxisbox.Items.AddRange(new object[] {
            "ColorAxisX",
            "ColorAxisY",
            "ColorAxisZ",
            "AxisColorChoose"});
            this.coloraxisbox.Location = new System.Drawing.Point(132, 102);
            this.coloraxisbox.Name = "coloraxisbox";
            this.coloraxisbox.Size = new System.Drawing.Size(121, 21);
            this.coloraxisbox.TabIndex = 24;
            this.coloraxisbox.SelectedIndexChanged += new System.EventHandler(this.coloraxisbox_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(616, 526);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(150, 13);
            this.label28.TabIndex = 26;
            this.label28.Text = "Enter function of two variables";
            // 
            // graph3D
            // 
            this.graph3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph3D.AxisX_Color = System.Drawing.Color.DarkBlue;
            this.graph3D.AxisX_Legend = null;
            this.graph3D.AxisY_Color = System.Drawing.Color.DarkGreen;
            this.graph3D.AxisY_Legend = null;
            this.graph3D.AxisZ_Color = System.Drawing.Color.DarkRed;
            this.graph3D.AxisZ_Legend = null;
            this.graph3D.BackColor = System.Drawing.Color.White;
            this.graph3D.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.graph3D.Cursor = System.Windows.Forms.Cursors.Default;
            this.graph3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graph3D.Location = new System.Drawing.Point(256, 46);
            this.graph3D.Name = "graph3D";
            this.graph3D.PolygonLineColor = System.Drawing.Color.Black;
            this.graph3D.Raster = Plot3D.Graph3D.eRaster.Off;
            this.graph3D.Size = new System.Drawing.Size(524, 405);
            this.graph3D.TabIndex = 6;
            this.graph3D.TopLegendColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.graph3D.Load += new System.EventHandler(this.graph3D_Load);
            // 
            // Graph3DMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 715);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Graph3DMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph3D";
            this.Load += new System.EventHandler(this.Graph3DMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackRho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTheta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPhi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackRho;
        private System.Windows.Forms.TrackBar trackTheta;
        private System.Windows.Forms.TrackBar trackPhi;
        private Plot3D.Graph3D graph3D;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox comboColors;
        private System.Windows.Forms.ComboBox comboDataSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnReset;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textboxForNewNameOfLegend;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button deletetabbutton;
        private System.Windows.Forms.Button addtabbutton;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button SaveSetButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox coloraxisbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button savetofilebutton;
        private System.Windows.Forms.Button loadfromfilebutton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkVisibleLegend;
        private System.Windows.Forms.ComboBox boxtoformatlegend;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox texttitle;
        private System.Windows.Forms.Button buttonforchangetitle;
        private System.Windows.Forms.Button saveloadbutton;
        private System.Windows.Forms.Button loadsettingsbutton;
        private System.Windows.Forms.TextBox equationBox;
        private System.Windows.Forms.Label label28;
    }
}

