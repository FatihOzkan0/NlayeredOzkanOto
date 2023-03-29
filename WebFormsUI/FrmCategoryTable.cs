using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
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
    public partial class FrmCategoryTable : Form
    {
        public FrmCategoryTable()
        {
            InitializeComponent();
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        ICategoryService _categoryService;
        private void FrmCategoryTable_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            dataGridView1.DataSource = _categoryService.Listele();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            _categoryService.Add(new Category
            {
                CategoryName = txtCategoryName.Text
            });
            MessageBox.Show("Kategori Eklendi");
            GetAll();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _categoryService.Update(new Category
            {
                CategoryId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value),
                CategoryName = txtUpdateCategory.Text

            });
            MessageBox.Show("Güncelleme İşlemi Yapıldı");
            GetAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateCategory.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtCategorySearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _categoryService.CategorySearch(txtCategorySearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _categoryService.Delete(new Category
            {
                CategoryId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("kayıt Silindi");
            GetAll();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaMenu frm = new AnaMenu();
            frm.Show();
            this.Hide();
        }
    }
}
