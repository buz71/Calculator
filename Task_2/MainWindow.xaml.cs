//Подключение необходимых библиотек
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using Operations;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        //Вспомогательные переменные
        private const int MAX_LENGHT = 15;
        private StringBuilder _firstNum = new StringBuilder();
        private StringBuilder _secondNum = new StringBuilder();
        private StringBuilder _showString = new StringBuilder();
        private StringBuilder _showOperation = new StringBuilder();
        private bool _operationActive = false;
        private char _currentOperation;
        private bool _isDouble = false;
        private string _result;

        //Метод для установки стартового состояния
        private void SetStartCondition()
        {
            _operationActive = false;
            _currentOperation = ' ';
            _isDouble = false;
            _firstNum.Clear();
            _secondNum.Clear();
            _showString.Clear();
            _showOperation.Clear();
        }

        //Главный метод программы
        public MainWindow()
        {
            InitializeComponent();
        }

        //Действия при нажатии кнопок

        //Нажатие числовых кнопок
        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            if (_showString.Length == MAX_LENGHT)
            {
                return;
            }
            _showString.Append((sender as Button).Content);
            _showOperation.Append((sender as Button).Content);
            ShowTextBox.Text = _showOperation.ToString();
            InputTextBox.Text = _showString.ToString();

            if (!_operationActive)
            {
                _firstNum.Append((sender as Button).Content);
            }
            else
            {
                _secondNum.Append((sender as Button).Content);
            }
        }

        //Нажатие кнопок с операциями
        private void OperationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_firstNum.Length == 0)
            {
                SetStartCondition();
                return;
            }
            _operationActive = true;
            _currentOperation = char.Parse((sender as Button).Content.ToString());
            _showOperation.Append((sender as Button).Content);
            ShowTextBox.Text = _showOperation.ToString();
            _showString.Clear();
        }

        //Кнопка равно
        private void ResultButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_firstNum.Length == 0 || _secondNum.Length == 0)
            {
                return;
            }

            switch (_currentOperation)
            {
                case '+':
                    Operation.Sum(_firstNum, _secondNum, _isDouble, ref _result);
                    InputTextBox.Text = _result;
                    SetStartCondition();
                    break;
                case '-':
                    Operation.Sub(_firstNum, _secondNum, _isDouble, ref _result);
                    InputTextBox.Text = _result;
                    SetStartCondition();
                    break;
                case '*':
                    Operation.Multip(_firstNum, _secondNum, _isDouble, ref _result);
                    InputTextBox.Text = _result;
                    SetStartCondition();
                    break;
                case '/':
                    Operation.Div(_firstNum, _secondNum, _isDouble, ref _result);
                    InputTextBox.Text = _result;
                    SetStartCondition();
                    break;
                default:
                    break;
            }
        }

        //Кнопка очистить ввод
        private void ButtonCE_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_operationActive)
            {
                _firstNum.Clear();
            }

            if (_operationActive)
            {
                _secondNum.Clear();
            }
            _showString.Clear();
            InputTextBox.Text = "";

        }

        //Кнопка сброса операции
        private void ButtonC_OnClick(object sender, RoutedEventArgs e)
        {
            SetStartCondition();
            InputTextBox.Text = "";
            ShowTextBox.Text = "";

        }

        //Кнопка "точки"
        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            _isDouble = true;

            if (_showString.Length == 0)
            {
                _showString.Append("0");
            }

            if (!_operationActive)
            {
                _showString.Append((sender as Button).Content);
                InputTextBox.Text = _showString.ToString();
                _firstNum.Append((sender as Button).Content);
            }
            else
            {
                _showString.Append((sender as Button).Content);
                InputTextBox.Text = _showString.ToString();
                _secondNum.Append((sender as Button).Content);
            }
        }

        //Кнопка удалить символ
        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            if (_showString.Length==0)
            {
                return;
            }
            if (!_operationActive)
            {
                _showString.Remove(_showString.Length-1,1);
                _showOperation.Remove(_showOperation.Length - 1, 1);
                InputTextBox.Text = _showString.ToString();
                ShowTextBox.Text=_showOperation.ToString();
            }

            if (_operationActive)
            {
                _secondNum.Remove(_firstNum.Length - 1, 1);
                _showOperation.Remove(_showOperation.Length - 1, 1);
                InputTextBox.Text = _showString.ToString();
                ShowTextBox.Text = _showOperation.ToString();
            }
        }
    }
}
