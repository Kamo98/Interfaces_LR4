using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		List<Product> products;
		List<Material> materials;
		Dictionary<string, string> mater2key = new Dictionary<string, string>();

		int countMaterials = 0;
		List<string> units = new List<string>() { "кг", "г", "мл", "л" };
		List<double> unitsKoef = new List<double>() { 1000, 1, 1, 1000 };

		//int countProd = 0;
		int heightProd = 220;
		int heightMaterial = 50;
		const int startPosMaterial = 0;

		public Form1()
		{
			InitializeComponent();
			loadHandbooks();

			init_tableMaterial();

			add_product();

			//export_to_excel();

		}


		private void init_tableMaterial()
		{
			//dgv_Mateials.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgv_Mateials_EditingControlShowing);

			foreach (string pr in units)
				ColUnit.Items.Add(pr);

			foreach (Material pr in materials)
				ColNameMaterial.Items.Add(pr.ToString());
			dgv_Mateials.RowHeadersVisible = false;
			dgv_Result.RowHeadersVisible = false;
		}



		private void export_to_excel()
		{
			Excel.Application excelApp = new Excel.Application();

			excelApp.Workbooks.Open("H:\\Университет\\8 сем - FINISH!!!\\ЧМИ\\L2\\WindowsFormsApp2\\LAW26677_24_20200117_133423.XLS");

			Excel.Worksheet worksheet = excelApp.Workbooks[1].Worksheets[1];

			worksheet.Cells[6, "A"] = textBox1.Text;
			worksheet.Cells[8, "A"] = comboBox1.Text;
			worksheet.Cells[13, "AW"] = textBox2.Text;
			worksheet.Cells[21, "CC"] = comboBox2.Text;
			worksheet.Cells[15, "CB"] = comboBox3.Text;
			worksheet.Cells[13, "BW"] = textBox3.Text;

			//worksheet.Cells[13, "BW"] = dateTimePicker2.Text;
			worksheet.Cells[13, "BE"] = dateTimePicker1.Text;



			for (int i = 0; i < dgv_Mateials.RowCount; i++)
			{
				if (dgv_Mateials.Rows[i].Cells[0].Value != null)
					worksheet.Cells[37 + i, "D"] = dgv_Mateials.Rows[i].Cells[0].Value.ToString();
				if (dgv_Mateials.Rows[i].Cells[1].Value != null)
					worksheet.Cells[37 + i, "L"] = dgv_Mateials.Rows[i].Cells[1].Value.ToString();
				if (dgv_Mateials.Rows[i].Cells[2].Value != null)
					worksheet.Cells[37 + i, "O"] = dgv_Mateials.Rows[i].Cells[2].Value.ToString();
				worksheet.Cells[37 + i, "R"] = "163";
			}
			


			
			//Заполняем таблицы в Excel
			int j = 'U' - 'A' + 1;

			for (int i = 0; i < tabProducts.TabCount; i++)
			{
				string prod = ((ComboBox)tabProducts.TabPages[i].Controls.Find("cb_nameProduct", true)[0]).Text;
				string[] prod1 = prod.Split('(');
				string nameProd = prod1[0].Trim();
				string keyProd = prod1[1].Substring(0, prod1[1].Length - 1);

				worksheet.Cells[21, j] = nameProd;
				worksheet.Cells[22, j] = keyProd;


				worksheet.Cells[24, j] = 1;
				worksheet.Cells[25, j] = ((TextBox)tabProducts.TabPages[i].Controls.Find("tb_Mass", true)[0]).Text;
				worksheet.Cells[26, j] = ((TextBox)tabProducts.TabPages[i].Controls.Find("tb_Count", true)[0]).Text;
				worksheet.Cells[27, j] = ((TextBox)tabProducts.TabPages[i].Controls.Find("tb_Count", true)[0]).Text;
				worksheet.Cells[28, j] = ((TextBox)tabProducts.TabPages[i].Controls.Find("tb_Price", true)[0]).Text;
				worksheet.Cells[29, j] = ((TextBox)tabProducts.TabPages[i].Controls.Find("tb_Sum", true)[0]).Text;
				worksheet.Cells[30, j] = ((TextBox)tabProducts.TabPages[i].Controls.Find("tb_Fact", true)[0]).Text;


				DataGridView dgvMatPr = (DataGridView)tabProducts.TabPages[i].Controls.Find("dgv_MaterialsPr", true)[0];

				for (int k = 0; k < dgv_Mateials.RowCount; k++)
				{
					if (dgvMatPr.Rows[k].Cells[0].Value != null && dgvMatPr.Rows[k].Cells[1].Value != null)
					{
						worksheet.Cells[37 + k, j] = dgvMatPr.Rows[k].Cells[0].Value.ToString();
						worksheet.Cells[37 + k, j + 2] = dgvMatPr.Rows[k].Cells[1].Value.ToString();
					}
				}

					//break;
				j += 5;
			}



			for (int i = 0; i < dgv_Result.RowCount; i++)
			{
				if (dgv_Result.Rows[i].Cells[1].Value != null)
					worksheet.Cells[37 + i, "BO"] = dgv_Result.Rows[i].Cells[1].Value.ToString();


				if (dgv_Result.Rows[i].Cells[2].Value != null)
					worksheet.Cells[37 + i, "BT"] = dgv_Result.Rows[i].Cells[2].Value.ToString();


				if (dgv_Result.Rows[i].Cells[3].Value != null)
					worksheet.Cells[37 + i, "BZ"] = dgv_Result.Rows[i].Cells[3].Value.ToString();


				if (dgv_Result.Rows[i].Cells[4].Value != null)
					worksheet.Cells[37 + i, "CF"] = dgv_Result.Rows[i].Cells[4].Value.ToString();
			}


			excelApp.Visible = true;
			excelApp.UserControl = true;
		}


		private void add_material()
		{
			DataGridViewRow row = new DataGridViewRow();
			dgv_Mateials.Rows.Add(row);


			for (int i = 0; i < tabProducts.TabCount; i++)
				copy_material(i, countMaterials);
			
			countMaterials++;
			row = new DataGridViewRow();
			dgv_Result.Rows.Add(row);
		}

		private void copy_material (int indexProduct, int indexMaterial)
		{
			DataGridView dgv_Materials = (DataGridView)tabProducts.Controls.Find("dgv_MaterialsPr", true)[indexProduct];

			dgv_Materials.Rows.Add();
		}

		private void add_product()
		{
			TabPage newTabPage = new TabPage("Продукт");

			Label label1 = new System.Windows.Forms.Label();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(10, 15);
			label1.Text = "Наименование (код)";

			ComboBox cb_nameProduct = new System.Windows.Forms.ComboBox();
			cb_nameProduct.FormattingEnabled = true;
			cb_nameProduct.Location = new System.Drawing.Point(10, 30);
			cb_nameProduct.Name = "cb_nameProduct";
			cb_nameProduct.Size = new System.Drawing.Size(150, 21);
			cb_nameProduct.TabIndex = 1;
			cb_nameProduct.SelectedIndexChanged += new System.EventHandler(this.cb_nameProduct_SelectedIndexChanged);
			foreach (Product pr in products)
				cb_nameProduct.Items.Add(pr.ToString());



			Label label2 = new System.Windows.Forms.Label();
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(180, 15);
			label2.Text = "Количество";

			TextBox tb_Count = new System.Windows.Forms.TextBox();
			tb_Count.Location = new System.Drawing.Point(180, 30);
			tb_Count.Name = "tb_Count";
			tb_Count.Size = new System.Drawing.Size(80, 20);
			tb_Count.TabIndex = 2;
			tb_Count.KeyPress += new KeyPressEventHandler(integer_tb_validator);
			tb_Count.TextChanged += new EventHandler(tb_count_textChanged);



			Label label3 = new System.Windows.Forms.Label();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(280, 15);
			label3.Text = "Цена продажи";

			TextBox tb_Price = new System.Windows.Forms.TextBox();
			tb_Price.Location = new System.Drawing.Point(280, 30);
			tb_Price.Name = "tb_Price";
			tb_Price.Size = new System.Drawing.Size(80, 20);
			tb_Price.TabIndex = 3;
			tb_Price.KeyPress += new KeyPressEventHandler(float_tb_validator);
			tb_Price.TextChanged += new EventHandler(tb_priceProd_textChanged);

			Label labelSPriceUnit = new System.Windows.Forms.Label();
			labelSPriceUnit.AutoSize = true;
			labelSPriceUnit.Location = new System.Drawing.Point(365, 30);
			labelSPriceUnit.Text = "руб";



			Label labelFact = new System.Windows.Forms.Label();
			labelFact.AutoSize = true;
			labelFact.Location = new System.Drawing.Point(10, 60);
			labelFact.Text = "Факт. выпуск";

			TextBox tb_Fact = new System.Windows.Forms.TextBox();
			tb_Fact.Location = new System.Drawing.Point(10, 75);
			tb_Fact.Name = "tb_Fact";
			tb_Fact.Size = new System.Drawing.Size(80, 20);
			tb_Fact.TabIndex = 3;
			tb_Fact.KeyPress += new KeyPressEventHandler(integer_tb_validator);



			Label labelMass = new System.Windows.Forms.Label();
			labelMass.AutoSize = true;
			labelMass.Location = new System.Drawing.Point(180, 60);
			labelMass.Text = "Масса 1 шт";

			TextBox tb_Mass = new System.Windows.Forms.TextBox();
			tb_Mass.Location = new System.Drawing.Point(180, 75);
			tb_Mass.Name = "tb_Mass";
			//tb_Mass.ReadOnly = true;
			tb_Mass.Size = new System.Drawing.Size(80, 20);
			tb_Mass.TabStop = false;
			tb_Mass.KeyPress += new KeyPressEventHandler(float_tb_validator);
			//tb_Mass.Text = "100";

			Label labelMassUnit = new System.Windows.Forms.Label();
			labelMassUnit.AutoSize = true;
			labelMassUnit.Location = new System.Drawing.Point(265, 75);
			labelMassUnit.Text = "г.";



			Label labelSum = new System.Windows.Forms.Label();
			labelSum.AutoSize = true;
			labelSum.Location = new System.Drawing.Point(280, 60);
			labelSum.Text = "Сумма";

			TextBox tb_Sum = new System.Windows.Forms.TextBox();
			tb_Sum.Location = new System.Drawing.Point(280, 75);
			tb_Sum.Name = "tb_Sum";
			tb_Sum.ReadOnly = true;
			tb_Sum.Size = new System.Drawing.Size(80, 20);
			tb_Sum.TabStop = false;

			Label labelSumUnit = new System.Windows.Forms.Label();
			labelSumUnit.AutoSize = true;
			labelSumUnit.Location = new System.Drawing.Point(365, 75);
			labelSumUnit.Text = "руб";



			Button btn_Close = new System.Windows.Forms.Button();
			btn_Close.Location = new System.Drawing.Point(tabProducts.Width - 30, 0);
			btn_Close.Name = "btn_CloseProduct";
			btn_Close.Size = new System.Drawing.Size(20, 20);
			btn_Close.TabStop = false;
			btn_Close.Text = "X";
			btn_Close.Click += new System.EventHandler(this.btn_CloseProduct_Click);




			DataGridViewTextBoxColumn Col_Norma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			DataGridViewComboBoxColumn Col_unit = new System.Windows.Forms.DataGridViewComboBoxColumn();
			DataGridViewTextBoxColumn Col_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();

			// 
			// Col_Norma
			// 
			Col_Norma.HeaderText = "Норма";
			Col_Norma.Name = "Col_Norma";
			Col_Norma.Width = 215;
			// 
			// Col_sum
			// 
			Col_sum.HeaderText = "Всего";
			Col_sum.Name = "Col_sum";
			Col_sum.ReadOnly = true;
			Col_sum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			Col_sum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			Col_sum.Width = 185;

			

			DataGridView dgv_MaterialsPr_1 = new System.Windows.Forms.DataGridView();
			dgv_MaterialsPr_1.Location = new Point(10, 121);
			((System.ComponentModel.ISupportInitialize)(dgv_MaterialsPr_1)).BeginInit();
			dgv_MaterialsPr_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_MaterialsPr_1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			Col_Norma,
			Col_sum});
			dgv_MaterialsPr_1.Name = "dgv_MaterialsPr"; // + tabProducts.TabCount;
			dgv_MaterialsPr_1.Size = new System.Drawing.Size(440, 384);
			dgv_MaterialsPr_1.TabIndex = 125;
			dgv_MaterialsPr_1.AllowUserToAddRows = false;
			dgv_MaterialsPr_1.AllowUserToDeleteRows = false;
			dgv_MaterialsPr_1.AllowUserToOrderColumns = false;
			dgv_MaterialsPr_1.AllowUserToResizeColumns = false;
			dgv_MaterialsPr_1.AllowUserToResizeRows = false;
			
			dgv_MaterialsPr_1.RowHeadersVisible = false;
			dgv_MaterialsPr_1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MateialsPr_CellValueChanged);
			//dgv_MaterialsPr_1.ColumnHeadersHeight = 40;
			((System.ComponentModel.ISupportInitialize)(dgv_MaterialsPr_1)).EndInit();


			newTabPage.Controls.Add(label1);
			newTabPage.Controls.Add(cb_nameProduct);
			newTabPage.Controls.Add(label2);
			newTabPage.Controls.Add(label3);

			newTabPage.Controls.Add(labelMass);
			newTabPage.Controls.Add(tb_Mass);
			newTabPage.Controls.Add(labelMassUnit);

			newTabPage.Controls.Add(tb_Count);
			newTabPage.Controls.Add(tb_Price);
			newTabPage.Controls.Add(labelSPriceUnit);

			newTabPage.Controls.Add(labelFact);
			newTabPage.Controls.Add(tb_Fact);

			newTabPage.Controls.Add(labelSum);
			newTabPage.Controls.Add(tb_Sum);
			newTabPage.Controls.Add(labelSumUnit);

			newTabPage.Controls.Add(btn_Close);
			
			newTabPage.Controls.Add(dgv_MaterialsPr_1);

			newTabPage.ResumeLayout(false);
			newTabPage.PerformLayout();

			tabProducts.TabPages.Add(newTabPage);

			tabProducts.SelectedTab = newTabPage;

			//panelMaterials.VerticalScroll.Value = panelMaterials.VerticalScroll.Value;

			for (int j = 0; j < countMaterials; j++)
				copy_material(tabProducts.TabCount - 1, j);
		}

		private void loadHandbooks()
		{
			XmlSerializer formatterProd = new XmlSerializer(typeof(List<Product>));

			// десериализация
			using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
			{
				products = (List<Product>)formatterProd.Deserialize(fs);
			}

			formatterProd = new XmlSerializer(typeof(List<Material>));
			using (FileStream fs = new FileStream("materials.xml", FileMode.OpenOrCreate))
			{
				materials = (List<Material>)formatterProd.Deserialize(fs);
			}

			foreach (Material m in materials)
				mater2key.Add(m.Name, m.Code);

		}


		private void generate_products()
		{
			List<Product> products = new List<Product>();
			products.Add(new Product("Творожные булочки", "101Б", 1));
			products.Add(new Product("Шоколадный торт", "104A", 2));
			products.Add(new Product("Желейный торт", "110A", 3));
			products.Add(new Product("Тирамису", "100A", 4));
			products.Add(new Product("Арабские сказки", "31A", 5));
			products.Add(new Product("Творожные шарики", "206В", 6));

			// передаем в конструктор тип класса
			XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, products);

				Console.WriteLine("Объект сериализован");
			}
		}
		private void generate_materials()
		{
			List<Material> products = new List<Material>();
			products.Add(new Material("Мука", "40M"));
			products.Add(new Material("Яйца", "41M"));
			products.Add(new Material("Сахар", "42M"));
			products.Add(new Material("Ванилин", "43M"));
			products.Add(new Material("Разрыхлитель", "44M"));
			products.Add(new Material("Каккао-порошок", "45M"));
			products.Add(new Material("Творог", "46M"));
			products.Add(new Material("Сливки", "47M"));

			// передаем в конструктор тип класса
			XmlSerializer formatter = new XmlSerializer(typeof(List<Material>));

			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("materials.xml", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, products);

				Console.WriteLine("Объект сериализован");
			}
		}





		private void btn_addProduct_Click(object sender, EventArgs e)
		{
			add_product();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			calculate();
			export_to_excel();
		}

		private void btn_addMaterial_Click_1(object sender, EventArgs e)
		{
			add_material();
		}
		
		private void btn_CloseProduct_Click(object sender, EventArgs e)
		{
			tabProducts.TabPages.Remove(tabProducts.SelectedTab);
		}

		private void integer_tb_validator(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
			{
				e.Handled = true;
			}
		}

		private void float_tb_validator(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
			{
				e.Handled = true;
			}
		}



		//Изменение кол-ва продукта
		private void tb_count_textChanged(object sender, EventArgs e)
		{
			TextBox tb_sum = (TextBox)tabProducts.SelectedTab.Controls.Find("tb_Sum", true)[0];
			
			int countPr;
			Int32.TryParse(((TextBox)sender).Text, out countPr);
			

			//Рассчёт стоимости
			double price;
			Double.TryParse(((TextBox)tabProducts.SelectedTab.Controls.Find("tb_Price", true)[0]).Text, out price);

			tb_sum.Text = (price * countPr).ToString();
			
			DataGridView dgvPr = (DataGridView)tabProducts.SelectedTab.Controls.Find("dgv_MaterialsPr", true)[0];

			for (int i = 0; i < dgvPr.RowCount; i++)
			{
				int norma = 0;
				if (dgvPr.Rows[i].Cells[0].Value != null)
					norma = Int32.Parse(dgvPr.Rows[i].Cells[0].Value.ToString());
				dgvPr.Rows[i].Cells[1].Value = norma * countPr;
			}
			
		}

		

		//Изменение цены продукта
		private void tb_priceProd_textChanged(object sender, EventArgs e)
		{
			TextBox tb_sum = (TextBox)tabProducts.SelectedTab.Controls.Find("tb_Sum", true)[0];
			
			int countPr;
			Int32.TryParse(((TextBox)tabProducts.SelectedTab.Controls.Find("tb_Count", true)[0]).Text, out countPr);


			//Рассчёт стоимости
			double price;
			Double.TryParse(((TextBox)sender).Text, out price);

			tb_sum.Text = (price * countPr).ToString();
		}

		

		private void dgv_MateialsPr_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			if (e.RowIndex >= 0 && e.RowIndex < dgv.RowCount)
			{
				if (e.ColumnIndex == 0 && dgv.Rows[e.RowIndex].Cells[0].Value != null)
				{
					string countS = ((TextBox)tabProducts.SelectedTab.Controls.Find("tb_Count", true)[0]).Text;
					if (countS != "")
					{
						double norma = Double.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
						int count = Int32.Parse(countS);
						dgv.Rows[e.RowIndex].Cells[1].Value = norma * count;
					}
				}
			}
		}



		//=================================
		//Рассчёт
		private void btn_Calc_Click(object sender, EventArgs e)
		{
			calculate();

		}

		private void calculate ()
		{
			for (int i = 0; i < dgv_Mateials.RowCount; i++)
			{
				double totalCount = 0.0;
				for (int j = 0; j < tabProducts.TabCount; j++)
				{
					DataGridView dgvPr = (DataGridView)tabProducts.TabPages[j].Controls.Find("dgv_MaterialsPr", true)[0];

					if (dgvPr.Rows[i].Cells[1].Value != null)
						totalCount += Double.Parse(dgvPr.Rows[i].Cells[1].Value.ToString());
				}

				dgv_Result.Rows[i].Cells[0].Value = dgv_Mateials.Rows[i].Cells[0].Value;
				dgv_Result.Rows[i].Cells[1].Value = totalCount;
				dgv_Result.Rows[i].Cells[2].Value = Math.Round(totalCount);

				if (dgv_Result.Rows[i].Cells[3].Value != null && dgv_Result.Rows[i].Cells[1].Value != null)
				{
					double price = Double.Parse(dgv_Result.Rows[i].Cells[3].Value.ToString());
					double count = Double.Parse(dgv_Result.Rows[i].Cells[1].Value.ToString());
					dgv_Result.Rows[i].Cells[4].Value = price * count;
				}
			}
		}

		//Изменение наименования продукта
		private void cb_nameProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			tabProducts.SelectedTab.Text = ((ComboBox)sender).Text;
		}

		//Изменение наименования сырья в строке
		private void cb_nameMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cb = (ComboBox)sender;
			int indMaterial = Int32.Parse(cb.Name.Split('_')[2]);
			dgv_Result.Rows[indMaterial].Cells[0].Value = cb.Text;
		}

		private void dgv_Mateials_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex < dgv_Mateials.ColumnCount)
			{
				if (e.ColumnIndex == 0 && dgv_Mateials.Rows[e.RowIndex].Cells[0].Value != null)
				{
					string nameMaterial = dgv_Mateials.Rows[e.RowIndex].Cells[0].Value.ToString();
					dgv_Mateials.Rows[e.RowIndex].Cells[1].Value = mater2key[nameMaterial];
				}
			}
		}
	}
}
