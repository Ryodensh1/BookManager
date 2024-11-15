using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookManager
{
    public partial class BookForm : Window
    {
        public Book Book { get; private set; }

        public BookForm(Book book = null)
        {
            InitializeComponent();
            if (book == null)
            {
                Book = new Book();
            }
            else
            {
                Book = book;
            }
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
