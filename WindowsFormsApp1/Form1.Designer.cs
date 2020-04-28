namespace WindowsFormsApp1
{
	partial class Form1
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.panelProducts = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.panelMaterials = new System.Windows.Forms.Panel();
			this.tabProducts = new System.Windows.Forms.TabControl();
			this.dgv_Result = new System.Windows.Forms.DataGridView();
			this.btn_addProduct = new System.Windows.Forms.Button();
			this.btn_Save = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.btn_Calc = new System.Windows.Forms.Button();
			this.btn_addMaterial = new System.Windows.Forms.Button();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColRound = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.panelProducts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).BeginInit();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(1026, 33);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(142, 20);
			this.dateTimePicker1.TabIndex = 105;
			// 
			// panelProducts
			// 
			this.panelProducts.AutoScroll = true;
			this.panelProducts.Controls.Add(this.label9);
			this.panelProducts.Controls.Add(this.dateTimePicker2);
			this.panelProducts.Controls.Add(this.label8);
			this.panelProducts.Controls.Add(this.textBox3);
			this.panelProducts.Controls.Add(this.comboBox3);
			this.panelProducts.Controls.Add(this.label7);
			this.panelProducts.Controls.Add(this.textBox2);
			this.panelProducts.Controls.Add(this.label6);
			this.panelProducts.Controls.Add(this.label5);
			this.panelProducts.Controls.Add(this.panelMaterials);
			this.panelProducts.Controls.Add(this.comboBox2);
			this.panelProducts.Controls.Add(this.tabProducts);
			this.panelProducts.Controls.Add(this.label4);
			this.panelProducts.Controls.Add(this.dgv_Result);
			this.panelProducts.Controls.Add(this.label1);
			this.panelProducts.Controls.Add(this.comboBox1);
			this.panelProducts.Controls.Add(this.label2);
			this.panelProducts.Controls.Add(this.label3);
			this.panelProducts.Controls.Add(this.dateTimePicker1);
			this.panelProducts.Controls.Add(this.textBox1);
			this.panelProducts.Location = new System.Drawing.Point(12, 12);
			this.panelProducts.Name = "panelProducts";
			this.panelProducts.Size = new System.Drawing.Size(1188, 546);
			this.panelProducts.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 129);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 13);
			this.label5.TabIndex = 112;
			this.label5.Text = "Список сырья";
			// 
			// panelMaterials
			// 
			this.panelMaterials.AutoScroll = true;
			this.panelMaterials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMaterials.Location = new System.Drawing.Point(3, 145);
			this.panelMaterials.Name = "panelMaterials";
			this.panelMaterials.Size = new System.Drawing.Size(226, 383);
			this.panelMaterials.TabIndex = 103;
			this.panelMaterials.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelMaterials_Scroll);
			// 
			// tabProducts
			// 
			this.tabProducts.Location = new System.Drawing.Point(235, 14);
			this.tabProducts.Name = "tabProducts";
			this.tabProducts.SelectedIndex = 0;
			this.tabProducts.Size = new System.Drawing.Size(461, 514);
			this.tabProducts.TabIndex = 102;
			// 
			// dgv_Result
			// 
			this.dgv_Result.AllowUserToAddRows = false;
			this.dgv_Result.AllowUserToDeleteRows = false;
			this.dgv_Result.AllowUserToOrderColumns = true;
			this.dgv_Result.AllowUserToResizeColumns = false;
			this.dgv_Result.AllowUserToResizeRows = false;
			this.dgv_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColCalc,
            this.ColRound,
            this.ColPrice,
            this.ColSum});
			this.dgv_Result.Location = new System.Drawing.Point(720, 122);
			this.dgv_Result.Name = "dgv_Result";
			this.dgv_Result.Size = new System.Drawing.Size(465, 410);
			this.dgv_Result.TabIndex = 101;
			this.dgv_Result.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgv_Result_Scroll);
			// 
			// btn_addProduct
			// 
			this.btn_addProduct.Location = new System.Drawing.Point(241, 575);
			this.btn_addProduct.Name = "btn_addProduct";
			this.btn_addProduct.Size = new System.Drawing.Size(150, 22);
			this.btn_addProduct.TabIndex = 0;
			this.btn_addProduct.Text = "Добавить изделие";
			this.btn_addProduct.UseVisualStyleBackColor = true;
			this.btn_addProduct.Click += new System.EventHandler(this.btn_addProduct_Click);
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(1044, 576);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(150, 21);
			this.btn_Save.TabIndex = 100;
			this.btn_Save.Text = "Сохранить";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1025, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 102;
			this.label1.Text = "Дата составления";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 103;
			this.label2.Text = "Организация";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(198, 20);
			this.textBox1.TabIndex = 104;
			this.textBox1.Text = "Рога и Копыта";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 106;
			this.label3.Text = "Подразделение";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Подразделение А",
            "Подразделение Б",
            "Подразделение В"});
			this.comboBox1.Location = new System.Drawing.Point(7, 82);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(198, 21);
			this.comboBox1.TabIndex = 107;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(723, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 13);
			this.label4.TabIndex = 108;
			this.label4.Text = "Наряд-заказ составил";
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Иванов И.И.",
            "Петров А.К.",
            "Трофимов П.И."});
			this.comboBox2.Location = new System.Drawing.Point(723, 82);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(139, 21);
			this.comboBox2.TabIndex = 109;
			// 
			// btn_Calc
			// 
			this.btn_Calc.Location = new System.Drawing.Point(876, 576);
			this.btn_Calc.Name = "btn_Calc";
			this.btn_Calc.Size = new System.Drawing.Size(150, 21);
			this.btn_Calc.TabIndex = 110;
			this.btn_Calc.Text = "Рассчитать";
			this.btn_Calc.UseVisualStyleBackColor = true;
			this.btn_Calc.Click += new System.EventHandler(this.btn_Calc_Click);
			// 
			// btn_addMaterial
			// 
			this.btn_addMaterial.Location = new System.Drawing.Point(9, 574);
			this.btn_addMaterial.Name = "btn_addMaterial";
			this.btn_addMaterial.Size = new System.Drawing.Size(150, 22);
			this.btn_addMaterial.TabIndex = 111;
			this.btn_addMaterial.Text = "Добавить сырьё";
			this.btn_addMaterial.UseVisualStyleBackColor = true;
			this.btn_addMaterial.Click += new System.EventHandler(this.btn_addMaterial_Click_1);
			// 
			// ColumnName
			// 
			this.ColumnName.HeaderText = "Наименование";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.Width = 130;
			// 
			// ColCalc
			// 
			this.ColCalc.HeaderText = "По расчёту";
			this.ColCalc.Name = "ColCalc";
			this.ColCalc.ReadOnly = true;
			this.ColCalc.Width = 70;
			// 
			// ColRound
			// 
			this.ColRound.HeaderText = "Округл.";
			this.ColRound.Name = "ColRound";
			this.ColRound.ReadOnly = true;
			this.ColRound.Width = 60;
			// 
			// ColPrice
			// 
			this.ColPrice.HeaderText = "Цена (руб)";
			this.ColPrice.Name = "ColPrice";
			this.ColPrice.Width = 80;
			// 
			// ColSum
			// 
			this.ColSum.HeaderText = "Сумма (руб)";
			this.ColSum.Name = "ColSum";
			this.ColSum.ReadOnly = true;
			this.ColSum.Width = 80;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(720, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 13);
			this.label6.TabIndex = 113;
			this.label6.Text = "Номер документа";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(723, 36);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(122, 20);
			this.textBox2.TabIndex = 114;
			this.textBox2.Text = "125";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(874, 65);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 13);
			this.label7.TabIndex = 115;
			this.label7.Text = "Утверждён";
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "Иванов И.И.",
            "Петров А.К.",
            "Трофимов П.И."});
			this.comboBox3.Location = new System.Drawing.Point(875, 81);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(139, 21);
			this.comboBox3.TabIndex = 119;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(1026, 82);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(142, 20);
			this.textBox3.TabIndex = 120;
			this.textBox3.Text = "Главный менеджер";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(1025, 66);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 13);
			this.label8.TabIndex = 121;
			this.label8.Text = "Должность утверждающего";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(874, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 13);
			this.label9.TabIndex = 122;
			this.label9.Text = "Дата утверждеия";
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(875, 33);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(142, 20);
			this.dateTimePicker2.TabIndex = 123;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1212, 617);
			this.Controls.Add(this.btn_addMaterial);
			this.Controls.Add(this.btn_Calc);
			this.Controls.Add(this.btn_addProduct);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.panelProducts);
			this.Location = new System.Drawing.Point(-300, -300);
			this.Name = "Form1";
			this.Text = "Наряд-заказ  на изготовление кондитерских и других изделий";
			this.panelProducts.ResumeLayout(false);
			this.panelProducts.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Panel panelProducts;
		private System.Windows.Forms.Button btn_addProduct;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.DataGridView dgv_Result;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button btn_Calc;
		private System.Windows.Forms.Panel panelMaterials;
		private System.Windows.Forms.TabControl tabProducts;
		private System.Windows.Forms.Button btn_addMaterial;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCalc;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColRound;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColSum;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
	}
}

