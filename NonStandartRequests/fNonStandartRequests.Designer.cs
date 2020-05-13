﻿namespace NonStandartRequests
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
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btAllLeftFieldFields = new System.Windows.Forms.Button();
            this.btAllRightFieldFields = new System.Windows.Forms.Button();
            this.btLeftFieldFields = new System.Windows.Forms.Button();
            this.btRightFieldFields = new System.Windows.Forms.Button();
            this.lvSelectedFields1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvAllFields = new System.Windows.Forms.ListView();
            this.tpCondition = new System.Windows.Forms.TabPage();
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.ebDecreasing = new System.Windows.Forms.RadioButton();
            this.rbIncreasing = new System.Windows.Forms.RadioButton();
            this.btAllLeftFieldOrder = new System.Windows.Forms.Button();
            this.btAllRightFieldOrder = new System.Windows.Forms.Button();
            this.btLeftFieldOrder = new System.Windows.Forms.Button();
            this.btRightFieldOrder = new System.Windows.Forms.Button();
            this.lvOrder = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lvSelectedFields2 = new System.Windows.Forms.ListView();
            this.tpRestult = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btExecute = new System.Windows.Forms.Button();
            this.btShowSQL = new System.Windows.Forms.Button();
            this.tcQuery.SuspendLayout();
            this.tpFields.SuspendLayout();
            this.tpCondition.SuspendLayout();
            this.tpOrder.SuspendLayout();
            this.gbOrder.SuspendLayout();
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
            this.tcQuery.Name = "tcQuery";
            this.tcQuery.SelectedIndex = 0;
            this.tcQuery.Size = new System.Drawing.Size(555, 222);
            this.tcQuery.TabIndex = 0;
            // 
            // tpFields
            // 
            this.tpFields.Controls.Add(this.listBox2);
            this.tpFields.Controls.Add(this.listBox1);
            this.tpFields.Controls.Add(this.btAllLeftFieldFields);
            this.tpFields.Controls.Add(this.btAllRightFieldFields);
            this.tpFields.Controls.Add(this.btLeftFieldFields);
            this.tpFields.Controls.Add(this.btRightFieldFields);
            this.tpFields.Controls.Add(this.lvSelectedFields1);
            this.tpFields.Controls.Add(this.label2);
            this.tpFields.Controls.Add(this.label1);
            this.tpFields.Controls.Add(this.lvAllFields);
            this.tpFields.Location = new System.Drawing.Point(4, 22);
            this.tpFields.Name = "tpFields";
            this.tpFields.Padding = new System.Windows.Forms.Padding(3);
            this.tpFields.Size = new System.Drawing.Size(547, 196);
            this.tpFields.TabIndex = 0;
            this.tpFields.Text = "Поля";
            this.tpFields.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(375, 33);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(151, 147);
            this.listBox2.TabIndex = 9;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(122, 147);
            this.listBox1.TabIndex = 8;
            // 
            // btAllLeftFieldFields
            // 
            this.btAllLeftFieldFields.Location = new System.Drawing.Point(210, 134);
            this.btAllLeftFieldFields.Name = "btAllLeftFieldFields";
            this.btAllLeftFieldFields.Size = new System.Drawing.Size(75, 23);
            this.btAllLeftFieldFields.TabIndex = 7;
            this.btAllLeftFieldFields.Text = "<<";
            this.btAllLeftFieldFields.UseVisualStyleBackColor = true;
            this.btAllLeftFieldFields.Click += new System.EventHandler(this.btAllLeftFieldFields_Click);
            // 
            // btAllRightFieldFields
            // 
            this.btAllRightFieldFields.Location = new System.Drawing.Point(210, 105);
            this.btAllRightFieldFields.Name = "btAllRightFieldFields";
            this.btAllRightFieldFields.Size = new System.Drawing.Size(75, 23);
            this.btAllRightFieldFields.TabIndex = 6;
            this.btAllRightFieldFields.Text = ">>";
            this.btAllRightFieldFields.UseVisualStyleBackColor = true;
            this.btAllRightFieldFields.Click += new System.EventHandler(this.btAllRightFieldFields_Click);
            // 
            // btLeftFieldFields
            // 
            this.btLeftFieldFields.Location = new System.Drawing.Point(210, 76);
            this.btLeftFieldFields.Name = "btLeftFieldFields";
            this.btLeftFieldFields.Size = new System.Drawing.Size(75, 23);
            this.btLeftFieldFields.TabIndex = 5;
            this.btLeftFieldFields.Text = "<";
            this.btLeftFieldFields.UseVisualStyleBackColor = true;
            this.btLeftFieldFields.Click += new System.EventHandler(this.btLeftFieldFields_Click);
            // 
            // btRightFieldFields
            // 
            this.btRightFieldFields.Location = new System.Drawing.Point(210, 47);
            this.btRightFieldFields.Name = "btRightFieldFields";
            this.btRightFieldFields.Size = new System.Drawing.Size(75, 23);
            this.btRightFieldFields.TabIndex = 4;
            this.btRightFieldFields.Text = ">";
            this.btRightFieldFields.UseVisualStyleBackColor = true;
            this.btRightFieldFields.Click += new System.EventHandler(this.btRightFieldFields_Click);
            // 
            // lvSelectedFields1
            // 
            this.lvSelectedFields1.HideSelection = false;
            this.lvSelectedFields1.Location = new System.Drawing.Point(281, 7);
            this.lvSelectedFields1.Name = "lvSelectedFields1";
            this.lvSelectedFields1.Size = new System.Drawing.Size(58, 47);
            this.lvSelectedFields1.TabIndex = 3;
            this.lvSelectedFields1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выбранные поля";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Все поля";
            // 
            // lvAllFields
            // 
            this.lvAllFields.HideSelection = false;
            this.lvAllFields.Location = new System.Drawing.Point(140, 10);
            this.lvAllFields.Name = "lvAllFields";
            this.lvAllFields.Size = new System.Drawing.Size(64, 44);
            this.lvAllFields.TabIndex = 0;
            this.lvAllFields.UseCompatibleStateImageBehavior = false;
            this.lvAllFields.View = System.Windows.Forms.View.List;
            // 
            // tpCondition
            // 
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
            this.tpCondition.Controls.Add(this.label6);
            this.tpCondition.Controls.Add(this.label5);
            this.tpCondition.Controls.Add(this.label4);
            this.tpCondition.Controls.Add(this.label3);
            this.tpCondition.Controls.Add(this.listView1);
            this.tpCondition.Location = new System.Drawing.Point(4, 22);
            this.tpCondition.Name = "tpCondition";
            this.tpCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tpCondition.Size = new System.Drawing.Size(547, 196);
            this.tpCondition.TabIndex = 1;
            this.tpCondition.Text = "Условия";
            this.tpCondition.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(417, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Связка";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Выражение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Критерий";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Имя поля";
            // 
            // cbLigament
            // 
            this.cbLigament.FormattingEnabled = true;
            this.cbLigament.Location = new System.Drawing.Point(420, 139);
            this.cbLigament.Name = "cbLigament";
            this.cbLigament.Size = new System.Drawing.Size(121, 21);
            this.cbLigament.TabIndex = 10;
            // 
            // cbExpression
            // 
            this.cbExpression.FormattingEnabled = true;
            this.cbExpression.Location = new System.Drawing.Point(259, 139);
            this.cbExpression.Name = "cbExpression";
            this.cbExpression.Size = new System.Drawing.Size(121, 21);
            this.cbExpression.TabIndex = 9;
            // 
            // cbCriterion
            // 
            this.cbCriterion.FormattingEnabled = true;
            this.cbCriterion.Location = new System.Drawing.Point(165, 139);
            this.cbCriterion.Name = "cbCriterion";
            this.cbCriterion.Size = new System.Drawing.Size(56, 21);
            this.cbCriterion.TabIndex = 8;
            // 
            // cbFieldName
            // 
            this.cbFieldName.FormattingEnabled = true;
            this.cbFieldName.Location = new System.Drawing.Point(6, 139);
            this.cbFieldName.Name = "cbFieldName";
            this.cbFieldName.Size = new System.Drawing.Size(121, 21);
            this.cbFieldName.TabIndex = 7;
            // 
            // btDeleteCondition
            // 
            this.btDeleteCondition.Location = new System.Drawing.Point(466, 167);
            this.btDeleteCondition.Name = "btDeleteCondition";
            this.btDeleteCondition.Size = new System.Drawing.Size(75, 23);
            this.btDeleteCondition.TabIndex = 6;
            this.btDeleteCondition.Text = "Удалить";
            this.btDeleteCondition.UseVisualStyleBackColor = true;
            // 
            // btAddCondition
            // 
            this.btAddCondition.Location = new System.Drawing.Point(385, 167);
            this.btAddCondition.Name = "btAddCondition";
            this.btAddCondition.Size = new System.Drawing.Size(75, 23);
            this.btAddCondition.TabIndex = 5;
            this.btAddCondition.Text = "Добавить";
            this.btAddCondition.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(486, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Связка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Значение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Критерий";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя поля";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(535, 93);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tpOrder
            // 
            this.tpOrder.Controls.Add(this.gbOrder);
            this.tpOrder.Controls.Add(this.btAllLeftFieldOrder);
            this.tpOrder.Controls.Add(this.btAllRightFieldOrder);
            this.tpOrder.Controls.Add(this.btLeftFieldOrder);
            this.tpOrder.Controls.Add(this.btRightFieldOrder);
            this.tpOrder.Controls.Add(this.lvOrder);
            this.tpOrder.Controls.Add(this.label11);
            this.tpOrder.Controls.Add(this.label12);
            this.tpOrder.Controls.Add(this.lvSelectedFields2);
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(547, 196);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Порядок";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // gbOrder
            // 
            this.gbOrder.Controls.Add(this.ebDecreasing);
            this.gbOrder.Controls.Add(this.rbIncreasing);
            this.gbOrder.Location = new System.Drawing.Point(420, 57);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(119, 86);
            this.gbOrder.TabIndex = 16;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "Порядок";
            // 
            // ebDecreasing
            // 
            this.ebDecreasing.AutoSize = true;
            this.ebDecreasing.Location = new System.Drawing.Point(6, 48);
            this.ebDecreasing.Name = "ebDecreasing";
            this.ebDecreasing.Size = new System.Drawing.Size(88, 17);
            this.ebDecreasing.TabIndex = 1;
            this.ebDecreasing.Text = "Убывающий";
            this.ebDecreasing.UseVisualStyleBackColor = true;
            // 
            // rbIncreasing
            // 
            this.rbIncreasing.AutoSize = true;
            this.rbIncreasing.Checked = true;
            this.rbIncreasing.Location = new System.Drawing.Point(6, 22);
            this.rbIncreasing.Name = "rbIncreasing";
            this.rbIncreasing.Size = new System.Drawing.Size(102, 17);
            this.rbIncreasing.TabIndex = 0;
            this.rbIncreasing.TabStop = true;
            this.rbIncreasing.Text = "Возрастающий";
            this.rbIncreasing.UseVisualStyleBackColor = true;
            // 
            // btAllLeftFieldOrder
            // 
            this.btAllLeftFieldOrder.Location = new System.Drawing.Point(192, 134);
            this.btAllLeftFieldOrder.Name = "btAllLeftFieldOrder";
            this.btAllLeftFieldOrder.Size = new System.Drawing.Size(45, 23);
            this.btAllLeftFieldOrder.TabIndex = 15;
            this.btAllLeftFieldOrder.Text = "<<";
            this.btAllLeftFieldOrder.UseVisualStyleBackColor = true;
            // 
            // btAllRightFieldOrder
            // 
            this.btAllRightFieldOrder.Location = new System.Drawing.Point(192, 105);
            this.btAllRightFieldOrder.Name = "btAllRightFieldOrder";
            this.btAllRightFieldOrder.Size = new System.Drawing.Size(45, 23);
            this.btAllRightFieldOrder.TabIndex = 14;
            this.btAllRightFieldOrder.Text = ">>";
            this.btAllRightFieldOrder.UseVisualStyleBackColor = true;
            // 
            // btLeftFieldOrder
            // 
            this.btLeftFieldOrder.Location = new System.Drawing.Point(192, 76);
            this.btLeftFieldOrder.Name = "btLeftFieldOrder";
            this.btLeftFieldOrder.Size = new System.Drawing.Size(45, 23);
            this.btLeftFieldOrder.TabIndex = 13;
            this.btLeftFieldOrder.Text = "<";
            this.btLeftFieldOrder.UseVisualStyleBackColor = true;
            // 
            // btRightFieldOrder
            // 
            this.btRightFieldOrder.Location = new System.Drawing.Point(192, 47);
            this.btRightFieldOrder.Name = "btRightFieldOrder";
            this.btRightFieldOrder.Size = new System.Drawing.Size(45, 23);
            this.btRightFieldOrder.TabIndex = 12;
            this.btRightFieldOrder.Text = ">";
            this.btRightFieldOrder.UseVisualStyleBackColor = true;
            // 
            // lvOrder
            // 
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(255, 23);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(149, 167);
            this.lvOrder.TabIndex = 11;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(252, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Порядок сортировки";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Выбранные поля";
            // 
            // lvSelectedFields2
            // 
            this.lvSelectedFields2.HideSelection = false;
            this.lvSelectedFields2.Location = new System.Drawing.Point(7, 23);
            this.lvSelectedFields2.Name = "lvSelectedFields2";
            this.lvSelectedFields2.Size = new System.Drawing.Size(170, 167);
            this.lvSelectedFields2.TabIndex = 8;
            this.lvSelectedFields2.UseCompatibleStateImageBehavior = false;
            // 
            // tpRestult
            // 
            this.tpRestult.Location = new System.Drawing.Point(4, 22);
            this.tpRestult.Name = "tpRestult";
            this.tpRestult.Size = new System.Drawing.Size(547, 196);
            this.tpRestult.TabIndex = 3;
            this.tpRestult.Text = "Результат";
            this.tpRestult.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btExecute);
            this.panel1.Controls.Add(this.btShowSQL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 34);
            this.panel1.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(468, 7);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btExecute
            // 
            this.btExecute.Location = new System.Drawing.Point(349, 7);
            this.btExecute.Name = "btExecute";
            this.btExecute.Size = new System.Drawing.Size(113, 23);
            this.btExecute.TabIndex = 1;
            this.btExecute.Text = "Выполнить запрос";
            this.btExecute.UseVisualStyleBackColor = true;
            // 
            // btShowSQL
            // 
            this.btShowSQL.Location = new System.Drawing.Point(248, 7);
            this.btShowSQL.Name = "btShowSQL";
            this.btShowSQL.Size = new System.Drawing.Size(95, 23);
            this.btShowSQL.TabIndex = 0;
            this.btShowSQL.Text = "Показать SQL";
            this.btShowSQL.UseVisualStyleBackColor = true;
            // 
            // fNonStandartRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.ListView lvAllFields;
        private System.Windows.Forms.Button btAllLeftFieldFields;
        private System.Windows.Forms.Button btAllRightFieldFields;
        private System.Windows.Forms.Button btLeftFieldFields;
        private System.Windows.Forms.Button btRightFieldFields;
        private System.Windows.Forms.ListView lvSelectedFields1;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.RadioButton ebDecreasing;
        private System.Windows.Forms.RadioButton rbIncreasing;
        private System.Windows.Forms.Button btAllLeftFieldOrder;
        private System.Windows.Forms.Button btAllRightFieldOrder;
        private System.Windows.Forms.Button btLeftFieldOrder;
        private System.Windows.Forms.Button btRightFieldOrder;
        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView lvSelectedFields2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

