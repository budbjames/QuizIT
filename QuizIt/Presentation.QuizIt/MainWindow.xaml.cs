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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUnityContainer _unityContainer;
        private int SelectedQuizIndex;

        public MainWindow()
        {
            InitializeComponent();
            _unityContainer = UnityContainerFactory.GetUnityContainer();
            PrepareViewModel();
        }

        private void PrepareViewModel()
        {
            PrepareDatabinding();
        }

        private void PrepareDatabinding()
        {
            //this.DataContext = _viewModel;
            //lstQuizes.ItemsSource = _viewModel;
        }

        private void btnCreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            var addQuestionsView = _unityContainer.Resolve<AddQuestions>();

            addQuestionsView.ShowDialog();

            RefreshView();
        }

        private void RefreshView()
        {
            PrepareDatabinding();
        }

        private void btnTakeQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (lstQuizes.SelectedIndex > -1)
                SelectedQuizIndex = lstQuizes.SelectedIndex;
        }
    }
}
