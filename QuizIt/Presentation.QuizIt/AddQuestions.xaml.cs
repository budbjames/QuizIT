using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Infrastructure.DependencyInjection;
using Microsoft.Practices.Unity;

namespace Presentation.QuizIt
{
    /// <summary>
    /// Interaction logic for AddQuestions.xaml
    /// </summary>
    public partial class AddQuestions : Window
    {
        public AddQuestions()
        {
            InitializeComponent();
        }

        private void PrepareDependencyInjectionContainer()
        {
        
        }

        private void PrepareDatabinding()
        {

        }
        
    }
}
