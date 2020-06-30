namespace NonStandartRequests
{
    partial class fNonStandartRequests
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
            this.tcQuery = new System.Windows.Forms.TabControl();
            this.tpFields = new System.Windows.Forms.TabPage();
            this.lbSelectedFieldsFields = new System.Windows.Forms.ListBox();
            this.lbAllFields = new System.Windows.Forms.ListBox();
            this.btAllLeftFieldFields = new System.Windows.Forms.Button();
            this.btAllRightFieldFields = new System.Windows.Forms.Button();
            this.btLeftFieldFields = new System.Windows.Forms.Button();
            this.btRightFieldFields = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpCondition = new System.Windows.Forms.TabPage();
            this.checkBoxGetOutSpace = new System.Windows.Forms.CheckBox();
            this.btChangeCond = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLigament = new System.Windows.Forms.ComboBox();
            this.cbExpression = new System.Windows.Forms.ComboBox();
            this.cbCriterion = new System.Windows.Forms.ComboBox();
            this.cbFieldName = new System.Windows.Forms.ComboBox();
            this.btDeleteCondition = new System.Windows.Forms.Button();
            this.btAddCondition = new System.Windows.Forms.Button();
            this.lvConditions = new System.Windows.Forms.ListView();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.btDown = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.lbOrder = new System.Windows.Forms.ListBox();
            this.lbSelectedFieldsOrder = new System.Windows.Forms.ListBox();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.rbDecreasing = new System.Windows.Forms.RadioButton();
            this.rbIncreasing = new System.Windows.Forms.RadioButton();
            this.btAllLeftFieldOrder = new System.Windows.Forms.Button();
            this.btAllRightFieldOrder = new System.Windows.Forms.Button();
            this.btLeftFieldOrder = new System.Windows.Forms.Button();
            this.btRightFieldOrder = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tpRestult = new System.Windows.Forms.TabPage();
            this.lvResult = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btFieldNameChange = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btExecute = new System.Windows.Forms.Button();
            this.btShowSQL = new System.Windows.Forms.Button();
            this.checkBoxUseBracked = new System.Windows.Forms.CheckBox();
            this.tcQuery.SuspendLayout();
            this.tpFields.SuspendLayout();
            this.tpCondition.SuspendLayout();
            this.tpOrder.SuspendLayout();
            this.gbOrder.SuspendLayout();
            this.tpRestult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcQuery
            // 
            this.tcQuery.Controls.Add(this.tpFields);
            this.tcQuery.Controls.Add(this.tpCondition);
            this.tcQuery.Controls.Add(this.tpOrder);
            this.tcQuery.Controls.Add(this.tpRestult);
            this.tcQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcQuery.Location = new System.Drawing.Point(0, 0);
            this.tcQuery.Margin = new System.Windows.Forms.Padding(4);
            this.tcQuery.Name = "tcQuery";
            this.tcQuery.SelectedIndex = 0;
            this.tcQuery.Size = new System.Drawing.Size(949, 316);
            this.tcQuery.TabIndex = 0;
            // 
            // tpFields
            // 
            this.tpFields.Controls.Add(this.lbSelectedFieldsFields);
            this.tpFields.Controls.Add(this.lbAllFields);
            this.tpFields.Controls.Add(this.btAllLeftFieldFields);
            this.tpFields.Controls.Add(this.btAllRightFieldFields);
            this.tpFields.Controls.Add(this.btLeftFieldFields);
            this.tpFields.Controls.Add(this.btRightFieldFields);
            this.tpFields.Controls.Add(this.label2);
            this.tpFields.Controls.Add(this.label1);
            this.tpFields.Location = new System.Drawing.Point(4, 25);
            this.tpFields.Margin = new System.Windows.Forms.Padding(4);
            this.tpFields.Name = "tpFields";
            this.tpFields.Padding = new System.Windows.Forms.Padding(4);
            this.tpFields.Size = new System.Drawing.Size(941, 287);
            this.tpFields.TabIndex = 0;
            this.tpFields.Text = "Поля";
            this.tpFields.UseVisualStyleBackColor = true;
            // 
            // lbSelectedFieldsFields
            // 
            this.lbSelectedFieldsFields.FormattingEnabled = true;
            this.lbSelectedFieldsFields.ItemHeight = 16;
            this.lbSelectedFieldsFields.Location = new System.Drawing.Point(521, 41);
            this.lbSelectedFieldsFields.Margin = new System.Windows.Forms.Padding(4);
            this.lbSelectedFieldsFields.Name = "lbSelectedFieldsFields";
            this.lbSelectedFieldsFields.Size = new System.Drawing.Size(406, 228);
            this.lbSelectedFieldsFields.TabIndex = 9;
            this.lbSelectedFieldsFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSelectedFieldsFields_MouseDoubleClick);
            this.lbSelectedFieldsFields.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_MouseDown);
            this.lbSelectedFieldsFields.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_MouseMove);
            this.lbSelectedFieldsFields.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lb_MouseUp);
            // 
            // lbAllFields
            // 
            this.lbAllFields.FormattingEnabled = true;
            this.lbAllFields.ItemHeight = 16;
            this.lbAllFields.Location = new System.Drawing.Point(16, 41);
            this.lbAllFields.Margin = new System.Windows.Forms.Padding(4);
            this.lbAllFields.Name = "lbAllFields";
            this.lbAllFields.Size = new System.Drawing.Size(388, 228);
            this.lbAllFields.TabIndex = 8;
            this.lbAllFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAllFields_MouseDoubleClick);
            // 
            // btAllLeftFieldFields
            // 
            this.btAllLeftFieldFields.Location = new System.Drawing.Point(413, 194);
            this.btAllLeftFieldFields.Margin = new System.Windows.Forms.Padding(4);
            this.btAllLeftFieldFields.Name = "btAllLeftFieldFields";
            this.btAllLeftFieldFields.Size = new System.Drawing.Size(100, 28);
            this.btAllLeftFieldFields.TabIndex = 7;
            this.btAllLeftFieldFields.Text = "<<";
            this.btAllLeftFieldFields.UseVisualStyleBackColor = true;
            this.btAllLeftFieldFields.Click += new System.EventHandler(this.btAllLeftFieldFields_Click);
            // 
            // btAllRightFieldFields
            // 
            this.btAllRightFieldFields.Location = new System.Drawing.Point(413, 158);
            this.btAllRightFieldFields.Margin = new System.Windows.Forms.Padding(4);
            this.btAllRightFieldFields.Name = "btAllRightFieldFields";
            this.btAllRightFieldFields.Size = new System.Drawing.Size(100, 28);
            this.btAllRightFieldFields.TabIndex = 6;
            this.btAllRightFieldFields.Text = ">>";
            this.btAllRightFieldFields.UseVisualStyleBackColor = true;
            this.btAllRightFieldFields.Click += new System.EventHandler(this.btAllRightFieldFields_Click);
            // 
            // btLeftFieldFields
            // 
            this.btLeftFieldFields.Location = new System.Drawing.Point(413, 122);
            this.btLeftFieldFields.Margin = new System.Windows.Forms.Padding(4);
            this.btLeftFieldFields.Name = "btLeftFieldFields";
            this.btLeftFieldFields.Size = new System.Drawing.Size(100, 28);
            this.btLeftFieldFields.TabIndex = 5;
            this.btLeftFieldFields.Text = "<";
            this.btLeftFieldFields.UseVisualStyleBackColor = true;
            this.btLeftFieldFields.Click += new System.EventHandler(this.btLeftFieldFields_Click);
            // 
            // btRightFieldFields
            // 
            this.btRightFieldFields.Location = new System.Drawing.Point(413, 86);
            this.btRightFieldFields.Margin = new System.Windows.Forms.Padding(4);
            this.btRightFieldFields.Name = "btRightFieldFields";
            this.btRightFieldFields.Size = new System.Drawing.Size(100, 28);
            this.btRightFieldFields.TabIndex = 4;
            this.btRightFieldFields.Text = ">";
            this.btRightFieldFields.UseVisualStyleBackColor = true;
            this.btRightFieldFields.Click += new System.EventHandler(this.btRightFieldFields_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выбранные поля";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Все поля";
            // 
            // tpCondition
            // 
            this.tpCondition.Controls.Add(this.checkBoxUseBracked);
            this.tpCondition.Controls.Add(this.checkBoxGetOutSpace);
            this.tpCondition.Controls.Add(this.btChangeCond);
            this.tpCondition.Controls.Add(this.label10);
            this.tpCondition.Controls.Add(this.label9);
            this.tpCondition.Controls.Add(this.label8);
            this.tpCondition.Controls.Add(this.label7);
            this.tpCondition.Controls.Add(this.cbLigament);
            this.tpCondition.Controls.Add(this.cbExpression);
            this.tpCondition.Controls.Add(this.cbCriterion);
            this.tpCondition.Controls.Add(this.cbFieldName);
            this.tpCondition.Controls.Add(this.btDeleteCondition);
            this.tpCondition.Controls.Add(this.btAddCondition);
            this.tpCondition.Controls.Add(this.lvConditions);
            this.tpCondition.Location = new System.Drawing.Point(4, 25);
            this.tpCondition.Margin = new System.Windows.Forms.Padding(4);
            this.tpCondition.Name = "tpCondition";
            this.tpCondition.Padding = new System.Windows.Forms.Padding(4);
            this.tpCondition.Size = new System.Drawing.Size(941, 287);
            this.tpCondition.TabIndex = 1;
            this.tpCondition.Text = "Условия";
            this.tpCondition.UseVisualStyleBackColor = true;
            // 
            // checkBoxGetOutSpace
            // 
            this.checkBoxGetOutSpace.AutoSize = true;
            this.checkBoxGetOutSpace.Enabled = false;
            this.checkBoxGetOutSpace.Location = new System.Drawing.Point(382, 256);
            this.checkBoxGetOutSpace.Name = "checkBoxGetOutSpace";
            this.checkBoxGetOutSpace.Size = new System.Drawing.Size(226, 20);
            this.checkBoxGetOutSpace.TabIndex = 16;
            this.checkBoxGetOutSpace.Text = "Убирать незначащие пробелы";
            this.checkBoxGetOutSpace.UseVisualStyleBackColor = true;
            // 
            // btChangeCond
            // 
            this.btChangeCond.Enabled = false;
            this.btChangeCond.Location = new System.Drawing.Point(615, 251);
            this.btChangeCond.Margin = new System.Windows.Forms.Padding(4);
            this.btChangeCond.Name = "btChangeCond";
            this.btChangeCond.Size = new System.Drawing.Size(100, 28);
            this.btChangeCond.TabIndex = 15;
            this.btChangeCond.Text = "Изменить";
            this.btChangeCond.UseVisualStyleBackColor = true;
            this.btChangeCond.Click += new System.EventHandler(this.btChangeCond_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(827, 196);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Связка";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 196);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Выражение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 196);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Критерий";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Имя поля";
            // 
            // cbLigament
            // 
            this.cbLigament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLigament.FormattingEnabled = true;
            this.cbLigament.Location = new System.Drawing.Point(830, 215);
            this.cbLigament.Margin = new System.Windows.Forms.Padding(4);
            this.cbLigament.Name = "cbLigament";
            this.cbLigament.Size = new System.Drawing.Size(98, 24);
            this.cbLigament.TabIndex = 10;
            // 
            // cbExpression
            // 
            this.cbExpression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExpression.FormattingEnabled = true;
            this.cbExpression.Location = new System.Drawing.Point(475, 215);
            this.cbExpression.Margin = new System.Windows.Forms.Padding(4);
            this.cbExpression.Name = "cbExpression";
            this.cbExpression.Size = new System.Drawing.Size(346, 24);
            this.cbExpression.TabIndex = 9;
            this.cbExpression.DropDownStyleChanged += new System.EventHandler(this.cbExpression_DropDownStyleChanged);
            // 
            // cbCriterion
            // 
            this.cbCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterion.FormattingEnabled = true;
            this.cbCriterion.Location = new System.Drawing.Point(335, 215);
            this.cbCriterion.Margin = new System.Windows.Forms.Padding(4);
            this.cbCriterion.Name = "cbCriterion";
            this.cbCriterion.Size = new System.Drawing.Size(132, 24);
            this.cbCriterion.TabIndex = 8;
            this.cbCriterion.SelectedIndexChanged += new System.EventHandler(this.cbCriterion_SelectedIndexChanged);
            // 
            // cbFieldName
            // 
            this.cbFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFieldName.FormattingEnabled = true;
            this.cbFieldName.Location = new System.Drawing.Point(11, 215);
            this.cbFieldName.Margin = new System.Windows.Forms.Padding(4);
            this.cbFieldName.Name = "cbFieldName";
            this.cbFieldName.Size = new System.Drawing.Size(316, 24);
            this.cbFieldName.TabIndex = 7;
            this.cbFieldName.SelectedIndexChanged += new System.EventHandler(this.cbFieldName_SelectedIndexChanged);
            // 
            // btDeleteCondition
            // 
            this.btDeleteCondition.Enabled = false;
            this.btDeleteCondition.Location = new System.Drawing.Point(830, 251);
            this.btDeleteCondition.Margin = new System.Windows.Forms.Padding(4);
            this.btDeleteCondition.Name = "btDeleteCondition";
            this.btDeleteCondition.Size = new System.Drawing.Size(100, 28);
            this.btDeleteCondition.TabIndex = 6;
            this.btDeleteCondition.Text = "Удалить";
            this.btDeleteCondition.UseVisualStyleBackColor = true;
            this.btDeleteCondition.Click += new System.EventHandler(this.btDeleteCondition_Click);
            // 
            // btAddCondition
            // 
            this.btAddCondition.Location = new System.Drawing.Point(722, 251);
            this.btAddCondition.Margin = new System.Windows.Forms.Padding(4);
            this.btAddCondition.Name = "btAddCondition";
            this.btAddCondition.Size = new System.Drawing.Size(100, 28);
            this.btAddCondition.TabIndex = 5;
            this.btAddCondition.Text = "Добавить";
            this.btAddCondition.UseVisualStyleBackColor = true;
            this.btAddCondition.Click += new System.EventHandler(this.btAddCondition_Click);
            // 
            // lvConditions
            // 
            this.lvConditions.FullRowSelect = true;
            this.lvConditions.HideSelection = false;
            this.lvConditions.Location = new System.Drawing.Point(8, 7);
            this.lvConditions.Margin = new System.Windows.Forms.Padding(4);
            this.lvConditions.Name = "lvConditions";
            this.lvConditions.Size = new System.Drawing.Size(919, 184);
            this.lvConditions.TabIndex = 0;
            this.lvConditions.UseCompatibleStateImageBehavior = false;
            this.lvConditions.View = System.Windows.Forms.View.Details;
            this.lvConditions.SelectedIndexChanged += new System.EventHandler(this.lvConditions_SelectedIndexChanged);
            // 
            // tpOrder
            // 
            this.tpOrder.Controls.Add(this.btDown);
            this.tpOrder.Controls.Add(this.btUp);
            this.tpOrder.Controls.Add(this.lbOrder);
            this.tpOrder.Controls.Add(this.lbSelectedFieldsOrder);
            this.tpOrder.Controls.Add(this.gbOrder);
            this.tpOrder.Controls.Add(this.btAllLeftFieldOrder);
            this.tpOrder.Controls.Add(this.btAllRightFieldOrder);
            this.tpOrder.Controls.Add(this.btLeftFieldOrder);
            this.tpOrder.Controls.Add(this.btRightFieldOrder);
            this.tpOrder.Controls.Add(this.label11);
            this.tpOrder.Controls.Add(this.label12);
            this.tpOrder.Location = new System.Drawing.Point(4, 25);
            this.tpOrder.Margin = new System.Windows.Forms.Padding(4);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(941, 287);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Порядок";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // btDown
            // 
            this.btDown.Enabled = false;
            this.btDown.Location = new System.Drawing.Point(795, 74);
            this.btDown.Margin = new System.Windows.Forms.Padding(4);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(43, 28);
            this.btDown.TabIndex = 20;
            this.btDown.Text = "↓";
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btUp
            // 
            this.btUp.Enabled = false;
            this.btUp.Location = new System.Drawing.Point(795, 38);
            this.btUp.Margin = new System.Windows.Forms.Padding(4);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(43, 28);
            this.btUp.TabIndex = 19;
            this.btUp.Text = "↑";
            this.btUp.UseVisualStyleBackColor = true;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // lbOrder
            // 
            this.lbOrder.FormattingEnabled = true;
            this.lbOrder.ItemHeight = 16;
            this.lbOrder.Location = new System.Drawing.Point(445, 28);
            this.lbOrder.Margin = new System.Windows.Forms.Padding(4);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(340, 244);
            this.lbOrder.TabIndex = 18;
            this.lbOrder.SelectedIndexChanged += new System.EventHandler(this.lbOrder_SelectedIndexChanged);
            this.lbOrder.DoubleClick += new System.EventHandler(this.lbOrder_DoubleClick);
            this.lbOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_MouseDown);
            this.lbOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_MouseMove);
            this.lbOrder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lb_MouseUp);
            // 
            // lbSelectedFieldsOrder
            // 
            this.lbSelectedFieldsOrder.FormattingEnabled = true;
            this.lbSelectedFieldsOrder.ItemHeight = 16;
            this.lbSelectedFieldsOrder.Location = new System.Drawing.Point(11, 28);
            this.lbSelectedFieldsOrder.Margin = new System.Windows.Forms.Padding(4);
            this.lbSelectedFieldsOrder.Name = "lbSelectedFieldsOrder";
            this.lbSelectedFieldsOrder.Size = new System.Drawing.Size(380, 244);
            this.lbSelectedFieldsOrder.TabIndex = 17;
            this.lbSelectedFieldsOrder.DoubleClick += new System.EventHandler(this.lbSelectedFieldsOrder_DoubleClick);
            // 
            // gbOrder
            // 
            this.gbOrder.Controls.Add(this.rbDecreasing);
            this.gbOrder.Controls.Add(this.rbIncreasing);
            this.gbOrder.Location = new System.Drawing.Point(795, 174);
            this.gbOrder.Margin = new System.Windows.Forms.Padding(4);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Padding = new System.Windows.Forms.Padding(4);
            this.gbOrder.Size = new System.Drawing.Size(140, 106);
            this.gbOrder.TabIndex = 16;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "Порядок";
            // 
            // rbDecreasing
            // 
            this.rbDecreasing.AutoSize = true;
            this.rbDecreasing.Enabled = false;
            this.rbDecreasing.Location = new System.Drawing.Point(8, 59);
            this.rbDecreasing.Margin = new System.Windows.Forms.Padding(4);
            this.rbDecreasing.Name = "rbDecreasing";
            this.rbDecreasing.Size = new System.Drawing.Size(103, 20);
            this.rbDecreasing.TabIndex = 1;
            this.rbDecreasing.Text = "Убывающий";
            this.rbDecreasing.UseVisualStyleBackColor = true;
            this.rbDecreasing.CheckedChanged += new System.EventHandler(this.rbDecreasing_CheckedChanged);
            // 
            // rbIncreasing
            // 
            this.rbIncreasing.AutoSize = true;
            this.rbIncreasing.Checked = true;
            this.rbIncreasing.Enabled = false;
            this.rbIncreasing.Location = new System.Drawing.Point(8, 27);
            this.rbIncreasing.Margin = new System.Windows.Forms.Padding(4);
            this.rbIncreasing.Name = "rbIncreasing";
            this.rbIncreasing.Size = new System.Drawing.Size(124, 20);
            this.rbIncreasing.TabIndex = 0;
            this.rbIncreasing.TabStop = true;
            this.rbIncreasing.Text = "Возрастающий";
            this.rbIncreasing.UseVisualStyleBackColor = true;
            this.rbIncreasing.CheckedChanged += new System.EventHandler(this.rbIncreasing_CheckedChanged);
            // 
            // btAllLeftFieldOrder
            // 
            this.btAllLeftFieldOrder.Location = new System.Drawing.Point(400, 194);
            this.btAllLeftFieldOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btAllLeftFieldOrder.Name = "btAllLeftFieldOrder";
            this.btAllLeftFieldOrder.Size = new System.Drawing.Size(37, 28);
            this.btAllLeftFieldOrder.TabIndex = 15;
            this.btAllLeftFieldOrder.Text = "<<";
            this.btAllLeftFieldOrder.UseVisualStyleBackColor = true;
            this.btAllLeftFieldOrder.Click += new System.EventHandler(this.btAllLeftFieldOrder_Click);
            // 
            // btAllRightFieldOrder
            // 
            this.btAllRightFieldOrder.Location = new System.Drawing.Point(400, 158);
            this.btAllRightFieldOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btAllRightFieldOrder.Name = "btAllRightFieldOrder";
            this.btAllRightFieldOrder.Size = new System.Drawing.Size(37, 28);
            this.btAllRightFieldOrder.TabIndex = 14;
            this.btAllRightFieldOrder.Text = ">>";
            this.btAllRightFieldOrder.UseVisualStyleBackColor = true;
            this.btAllRightFieldOrder.Click += new System.EventHandler(this.btAllRightFieldOrder_Click);
            // 
            // btLeftFieldOrder
            // 
            this.btLeftFieldOrder.Location = new System.Drawing.Point(400, 123);
            this.btLeftFieldOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btLeftFieldOrder.Name = "btLeftFieldOrder";
            this.btLeftFieldOrder.Size = new System.Drawing.Size(37, 28);
            this.btLeftFieldOrder.TabIndex = 13;
            this.btLeftFieldOrder.Text = "<";
            this.btLeftFieldOrder.UseVisualStyleBackColor = true;
            this.btLeftFieldOrder.Click += new System.EventHandler(this.btLeftFieldOrder_Click);
            // 
            // btRightFieldOrder
            // 
            this.btRightFieldOrder.Location = new System.Drawing.Point(400, 87);
            this.btRightFieldOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btRightFieldOrder.Name = "btRightFieldOrder";
            this.btRightFieldOrder.Size = new System.Drawing.Size(37, 28);
            this.btRightFieldOrder.TabIndex = 12;
            this.btRightFieldOrder.Text = ">";
            this.btRightFieldOrder.UseVisualStyleBackColor = true;
            this.btRightFieldOrder.Click += new System.EventHandler(this.btRightFieldOrder_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(544, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Порядок сортировки";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "Выбранные поля";
            // 
            // tpRestult
            // 
            this.tpRestult.Controls.Add(this.lvResult);
            this.tpRestult.Location = new System.Drawing.Point(4, 25);
            this.tpRestult.Margin = new System.Windows.Forms.Padding(4);
            this.tpRestult.Name = "tpRestult";
            this.tpRestult.Size = new System.Drawing.Size(941, 287);
            this.tpRestult.TabIndex = 3;
            this.tpRestult.Text = "Результат";
            this.tpRestult.UseVisualStyleBackColor = true;
            // 
            // lvResult
            // 
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.GridLines = true;
            this.lvResult.HideSelection = false;
            this.lvResult.Location = new System.Drawing.Point(0, 0);
            this.lvResult.Margin = new System.Windows.Forms.Padding(4);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(941, 287);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            this.lvResult.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvResult_ColumnClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btFieldNameChange);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btExecute);
            this.panel1.Controls.Add(this.btShowSQL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 320);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 42);
            this.panel1.TabIndex = 1;
            // 
            // btFieldNameChange
            // 
            this.btFieldNameChange.Location = new System.Drawing.Point(5, 10);
            this.btFieldNameChange.Margin = new System.Windows.Forms.Padding(4);
            this.btFieldNameChange.Name = "btFieldNameChange";
            this.btFieldNameChange.Size = new System.Drawing.Size(235, 28);
            this.btFieldNameChange.TabIndex = 3;
            this.btFieldNameChange.Text = "Редактировать названия полей";
            this.btFieldNameChange.UseVisualStyleBackColor = true;
            this.btFieldNameChange.Click += new System.EventHandler(this.btFieldNameChange_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(844, 10);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btExecute
            // 
            this.btExecute.Location = new System.Drawing.Point(685, 10);
            this.btExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btExecute.Name = "btExecute";
            this.btExecute.Size = new System.Drawing.Size(151, 28);
            this.btExecute.TabIndex = 1;
            this.btExecute.Text = "Выполнить запрос";
            this.btExecute.UseVisualStyleBackColor = true;
            this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
            // 
            // btShowSQL
            // 
            this.btShowSQL.Location = new System.Drawing.Point(551, 10);
            this.btShowSQL.Margin = new System.Windows.Forms.Padding(4);
            this.btShowSQL.Name = "btShowSQL";
            this.btShowSQL.Size = new System.Drawing.Size(126, 28);
            this.btShowSQL.TabIndex = 0;
            this.btShowSQL.Text = "Показать SQL";
            this.btShowSQL.UseVisualStyleBackColor = true;
            this.btShowSQL.Click += new System.EventHandler(this.btShowSQL_Click);
            // 
            // checkBox1
            // 
            this.checkBoxUseBracked.AutoSize = true;
            this.checkBoxUseBracked.Location = new System.Drawing.Point(11, 256);
            this.checkBoxUseBracked.Name = "checkBox1";
            this.checkBoxUseBracked.Size = new System.Drawing.Size(138, 20);
            this.checkBoxUseBracked.TabIndex = 17;
            this.checkBoxUseBracked.Text = "Показать скобки";
            this.checkBoxUseBracked.UseVisualStyleBackColor = true;
            this.checkBoxUseBracked.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // fNonStandartRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcQuery);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fNonStandartRequests";
            this.Text = "Новый запрос";
            this.Load += new System.EventHandler(this.fNonStandartRequests_Load);
            this.tcQuery.ResumeLayout(false);
            this.tpFields.ResumeLayout(false);
            this.tpFields.PerformLayout();
            this.tpCondition.ResumeLayout(false);
            this.tpCondition.PerformLayout();
            this.tpOrder.ResumeLayout(false);
            this.tpOrder.PerformLayout();
            this.gbOrder.ResumeLayout(false);
            this.gbOrder.PerformLayout();
            this.tpRestult.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcQuery;
        private System.Windows.Forms.TabPage tpFields;
        private System.Windows.Forms.TabPage tpCondition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btExecute;
        private System.Windows.Forms.Button btShowSQL;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.TabPage tpRestult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAllLeftFieldFields;
        private System.Windows.Forms.Button btAllRightFieldFields;
        private System.Windows.Forms.Button btLeftFieldFields;
        private System.Windows.Forms.Button btRightFieldFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLigament;
        private System.Windows.Forms.ComboBox cbExpression;
        private System.Windows.Forms.ComboBox cbCriterion;
        private System.Windows.Forms.ComboBox cbFieldName;
        private System.Windows.Forms.Button btDeleteCondition;
        private System.Windows.Forms.Button btAddCondition;
        private System.Windows.Forms.ListView lvConditions;
        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.RadioButton rbDecreasing;
        private System.Windows.Forms.RadioButton rbIncreasing;
        private System.Windows.Forms.Button btAllLeftFieldOrder;
        private System.Windows.Forms.Button btAllRightFieldOrder;
        private System.Windows.Forms.Button btLeftFieldOrder;
        private System.Windows.Forms.Button btRightFieldOrder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbAllFields;
        private System.Windows.Forms.ListBox lbSelectedFieldsFields;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.ListBox lbOrder;
        private System.Windows.Forms.ListBox lbSelectedFieldsOrder;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btChangeCond;
        private System.Windows.Forms.Button btFieldNameChange;
        private System.Windows.Forms.CheckBox checkBoxGetOutSpace;
        private System.Windows.Forms.CheckBox checkBoxUseBracked;
    }
}

