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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace BookManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   
        public partial class MainWindow : Window
        {
            public ObservableCollection<Book> BookCollection { get; set; } = new ObservableCollection<Book>();
            public Book SelectedBook { get; set; }

            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }

            private void AddBook_Click(object sender, RoutedEventArgs e)
            {
                Book newBook = ShowBookForm();
                if (newBook != null)
                {
                    BookCollection.Add(newBook);
                }
            }

            private void EditBook_Click(object sender, RoutedEventArgs e)
            {
                if (SelectedBook != null)
                {
                    Book editedBook = ShowBookForm(SelectedBook);
                    if (editedBook != null)
                    {
                        int index = BookCollection.IndexOf(SelectedBook);
                        BookCollection[index] = new Book
                        {
                            Title = editedBook.Title,
                            Author = editedBook.Author,
                            Year = editedBook.Year,
                            Genre = editedBook.Genre,
                            PageCount = editedBook.PageCount
                        };
                    }
                }
            }

            private void DeleteBook_Click(object sender, RoutedEventArgs e)
            {
                if (SelectedBook != null)
                {
                    BookCollection.Remove(SelectedBook);
                }
            }

            private Book ShowBookForm(Book book = null)
            {
                var bookForm = new BookForm(book);
                if (bookForm.ShowDialog() == true)
                {
                    return bookForm.Book;
                }
                return null;
            }
        }
    }
