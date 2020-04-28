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
			add_product();

			//export_to_excel();

		}


		private void export_to_excel()
		{
			Excel.Application excelApp = new Excel.Application();

			excelApp.Workbooks.Open("H:\\Университет\\8 сем - FINISH!!!\\ЧМИ\\L2\\WindowsFormsApp2\\LAW26677_24_20200117_133423.XLS");

			Excel.Worksheet worksheet = excelApp.Workbooks[1].Worksheets[1];

			worksheet.Cells[5, 'H' - 'A' + 1] = "fdgfd";

			excelApp.Visible = true;
			excelApp.UserControl = true;
		}


		private void add_material()
		{
			int posY = heightMaterial * countMaterials + startPosMaterial;

			//Label labelMaterial = new System.Windows.Forms.Label();
			//labelMaterial.AutoSize = true;
			//labelMaterial.Location = new System.Drawing.Point(5, 10 + posY);
			//labelMaterial.Text = "Сырьё";

			ComboBox cb_nameMaterial = new System.Windows.Forms.ComboBox();
			cb_nameMaterial.Location = new System.Drawing.Point(20, posY + 30);
			cb_nameMaterial.Name = "cb_nameMaterial_" + countMaterials;
			cb_nameMaterial.Size = new System.Drawing.Size(150, 21);
			cb_nameMaterial.TabIndex = 1 * countMaterials;
			cb_nameMaterial.SelectedIndexChanged += new System.EventHandler(this.cb_nameMaterial_SelectedIndexChanged);
			foreach (Material pr in materials)
				cb_nameMaterial.Items.Add(pr.ToString());			


			for (int i = 0; i < tabProducts.TabCount; i++)
				copy_material(i, countMaterials);

			panelMaterials.Controls.Add(cb_nameMaterial);
			countMaterials++;

			DataGridViewRow row = new DataGridViewRow();
			row.Height = heightMaterial;
			dgv_Result.Rows.Add(row);
		}

		private void copy_material (int indexProduct, int indexMaterial)
		{
			int posY = heightMaterial * indexMaterial;

			Label labelNorm = new System.Windows.Forms.Label();
			labelNorm.AutoSize = true;
			labelNorm.Location = new System.Drawing.Point(20, posY + 10);
			labelNorm.Text = "Норма";

			TextBox tb_Norma = new System.Windows.Forms.TextBox();
			tb_Norma.Location = new System.Drawing.Point(20, posY + 30);
			tb_Norma.Name = "tb_Norma_" + indexProduct + "_" + countMaterials;
			tb_Norma.Size = new System.Drawing.Size(100, 20);
			tb_Norma.TabIndex = 3 * countMaterials;
			tb_Norma.KeyPress += new KeyPressEventHandler(float_tb_validator);
			tb_Norma.TextChanged += new EventHandler(tb_normMaterial_textChanged);

			ComboBox cb_Unit = new System.Windows.Forms.ComboBox();
			cb_Unit.Location = new System.Drawing.Point(160, posY + 30);
			cb_Unit.Name = "cb_Unit_" + indexProduct + "_" + countMaterials;
			cb_Unit.Size = new Size(50, 21);
			cb_Unit.TabIndex = 4 * countMaterials;
			foreach (string pr in units)
				cb_Unit.Items.Add(pr);


			Label labelTotal = new System.Windows.Forms.Label();
			labelTotal.AutoSize = true;
			labelTotal.Location = new System.Drawing.Point(270, posY + 10);
			labelTotal.Text = "Всего";

			TextBox tb_Total = new System.Windows.Forms.TextBox();
			tb_Total.Location = new System.Drawing.Point(270, posY + 30);
			tb_Total.Name = "tb_Total_" + indexProduct + "_" + countMaterials;
			tb_Total.Size = new System.Drawing.Size(60, 20);
			tb_Total.ReadOnly = true;
			tb_Total.TabStop = false; //2 * countMaterials[product];


			Control panelMaterial = tabProducts.Controls.Find("panel_materials", true)[indexProduct];
			panelMaterial.Controls.Add(labelNorm);
			panelMaterial.Controls.Add(tb_Norma);

			panelMaterial.Controls.Add(cb_Unit);

			panelMaterial.Controls.Add(labelTotal);
			panelMaterial.Controls.Add(tb_Total);

			//tabProducts.TabPages[indexProduct].Controls.Add(tb_Total);
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
			tb_Mass.ReadOnly = true;
			tb_Mass.Size = new System.Drawing.Size(80, 20);
			tb_Mass.TabStop = false;
			tb_Mass.KeyPress += new KeyPressEventHandler(float_tb_validator);
			tb_Mass.Text = "100";

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


			Panel panelMaterials = new Panel();
			panelMaterials.Location = new Point(10, 110);
			panelMaterials.Name = "panel_materials";
			panelMaterials.AutoScroll = true;
			panelMaterials.BorderStyle = BorderStyle.FixedSingle;
			panelMaterials.Size = new Size(430, 370);
			panelMaterials.Scroll += new ScrollEventHandler(this.panelMaterialsInProd_Scroll);

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
			newTabPage.Controls.Add(panelMaterials);

			newTabPage.ResumeLayout(false);
			newTabPage.PerformLayout();

			tabProducts.TabPages.Add(newTabPage);

			tabProducts.SelectedTab = newTabPage;

			panelMaterials.VerticalScroll.Value = panelMaterials.VerticalScroll.Value;

			for (int j = 0; j < countMaterials; j++)
				copy_material(tabProducts.TabCount - 1, j);

			//countMaterials.Add(0);
			//add_material(countProd);
			//countProd++;
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
			MessageBox.Show(((TextBox)panelProducts.Controls.Find("tb_Price_2", true)[0]).Text);
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
			//string name = ((TextBox)sender).Name;
			//int iProd = Int32.Parse(name.Split('_')[2]);

			//int countPr;
			//Int32.TryParse(((TextBox)sender).Text, out countPr);

			//for (int i = 0; i < countMaterials[iProd]; i++)
			//{
			//	TextBox tbTotal = (TextBox)panelProducts.Controls.Find("tb_Total_" + iProd + "_" + i, true)[0];
			//	double norma;
			//	Double.TryParse(
			//		((TextBox)panelProducts.Controls.Find("tb_Norma_" + iProd + "_" + i, true)[0]).Text,
			//		out norma);

			//	tbTotal.Text = (norma * countPr).ToString();
			//}


			////Рассчёт стоимости
			//double price;
			//Double.TryParse(((TextBox)panelProducts.Controls.Find("tb_Price_" + iProd, true)[0]).Text,
			//	out price);

			//TextBox tbSum = (TextBox)panelProducts.Controls.Find("tb_Sum_" + iProd, true)[0];
			//tbSum.Text = (price * countPr).ToString();
		}


		//Изменение цены продукта
		private void tb_priceProd_textChanged(object sender, EventArgs e)
		{
			//string name = ((TextBox)sender).Name;
			//int iProd = Int32.Parse(name.Split('_')[2]);

			//int countPr;
			//Int32.TryParse(((TextBox)panelProducts.Controls.Find("tb_Count_" + iProd, true)[0]).Text,
			//	out countPr);

			////Рассчёт стоимости
			//double price;
			//Double.TryParse(((TextBox)sender).Text, out price);

			//TextBox tbSum = (TextBox)panelProducts.Controls.Find("tb_Sum_" + iProd, true)[0];
			//tbSum.Text = (price * countPr).ToString();
		}

		
		//Изменение нормы сырья
		private void tb_normMaterial_textChanged(object sender, EventArgs e)
		{
			//string name = ((TextBox)sender).Name;
			//int iP = Int32.Parse(name.Split('_')[2]);
			//int jM = Int32.Parse(name.Split('_')[3]);

			//double norma;
			//Double.TryParse((((TextBox)sender)).Text, out norma);
			//int countPr;
			//Int32.TryParse(((TextBox)panelProducts.Controls.Find("tb_Count_" + iP, true)[0]).Text, out countPr);

			//TextBox tbTotal = (TextBox)panelProducts.Controls.Find("tb_Total_" + iP + "_" + jM, true)[0];
			//tbTotal.Text = (norma * countPr).ToString();
		}

		private void btn_Calc_Click(object sender, EventArgs e)
		{
			//for (int k = 0; k < dgv_Result.Rows.Count; k++)
			//{
			//	string material = dgv_Result.Rows[k].Cells[0].Value.ToString();
			//	double curSum = 0.0;

			//	for (int i = 0; i < countProd; i++)
			//		for (int j = 0; j < countMaterials[i]; j++)
			//		{
			//			ComboBox cb = (ComboBox)panelProducts.Controls.Find("cb_nameMaterial_" + i + "_" + j, true)[0];
			//			if (material == cb.Text)
			//			{
			//				double totalM;
			//				Double.TryParse(((TextBox)panelProducts.Controls.Find("tb_Total_" + i + "_" + j, true)[0]).Text, out totalM);
			//				curSum += totalM;
			//			}
			//		}

			//	dgv_Result.Rows[k].Cells[1].Value = curSum;
			//	dgv_Result.Rows[k].Cells[2].Value = Math.Round(curSum, 2);
			//}

		}



		//События скролов
		private void panelMaterials_Scroll(object sender, ScrollEventArgs e)
		{
			for (int i = 0; i < tabProducts.TabCount; i++)
				((Panel)tabProducts.TabPages[i].Controls.Find("panel_materials", true)[0]).VerticalScroll.Value = panelMaterials.VerticalScroll.Value;
			dgv_Result.FirstDisplayedScrollingRowIndex = panelMaterials.VerticalScroll.Value / heightMaterial;
		}

		private void panelMaterialsInProd_Scroll(object sender, ScrollEventArgs e)
		{
			panelMaterials.VerticalScroll.Value = ((Panel)sender).VerticalScroll.Value;
			panelMaterials_Scroll(panelMaterials, e);
		}

		private void dgv_Result_Scroll(object sender, ScrollEventArgs e)
		{
			int val = dgv_Result.FirstDisplayedScrollingRowIndex * heightMaterial;
			for (int i = 0; i < tabProducts.TabCount; i++)
				((Panel)tabProducts.TabPages[i].Controls.Find("panel_materials", true)[0]).VerticalScroll.Value = val;
			panelMaterials.VerticalScroll.Value = val;
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
	}
}
