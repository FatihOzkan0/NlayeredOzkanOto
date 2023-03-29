using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebFormsUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            _productService= new ProductManager(new EfProductDal());
           
        }
        IProductService _productService;
        Context context = new Context();
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            UrunCesidSayısı();
            ToplamStok();

            
            

        }
                                            //METHODLAR
        
        public void Listele()
        {
            dataGridView1.DataSource = _productService.Listeler();       //NORMAL LİSTELEME YAPAR
            this.dataGridView1.Columns["Category"].Visible = false;      //İkincil anahtar atadığımız için fazladan category sutunu gözüküyor onu kapatıyoruz.

        }


        public void DatabaseKayıt()
        {
                  //İLK BAŞTA VERİ TABANI KAYITI OLUŞTURMAMIZI SAĞLAR
             
            context.Database.Create();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                  //İSME GÖRE LİSTELEME İŞLEMİ

            dataGridView1.DataSource = _productService.UrunArama(txtProductSearch.Text);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryId = Convert.ToInt16(txtKategoriId.Text),
                ProductName = txtUrun.Text,
                UnitPrice = Convert.ToDecimal(txtUrunFiyat.Text),
                ProductStock = Convert.ToInt16(txtUrunStok.Text)

            });
            MessageBox.Show("Kayıt Eklendi");
            Listele();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {

                ProductId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value),    //DELETE İŞLEMİ İÇİN BİZE Bİ ID GEREKMEKTEDİR ONU SEÇİCEĞİMİZ SATIRA TIKLAYRAK ALIYORUZ.
                CategoryId = Convert.ToInt16(txtUpdateCategory.Text),
                ProductName = txtUpdateProduct.Text,
                UnitPrice = Convert.ToDecimal(txtUpdatePrice.Text),
                ProductStock = Convert.ToInt16(txtUpdateStock.Text)
            });
            MessageBox.Show("Kayıt Güncellendi");
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateCategory.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUpdateProduct.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtUpdatePrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtUpdateStock.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();    //Seçili satırın hücresine gidip değerini yazıyoruz.
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            {
                ProductId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("Kayıt Silindi");
            Listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //ANA SAYFAYA DÖNME İŞLEMİ
         
            AnaMenu frm= new AnaMenu();
            frm.Show();
            this.Hide();
        }

                                  //LINQ SORGULAR

         public void UrunCesidSayısı()
        {
            
            int sayı = context.Products.Count();
            lblUrunCesit.Text = Convert.ToString(sayı);
            
        }

        public void ToplamStok()
        {
            var stock =context.Products.Sum(p => p.ProductStock);
            lblProductStock.Text = stock.ToString();

        }

    }


}
