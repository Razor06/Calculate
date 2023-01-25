using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1
    {
        private bool IsTextEmpty => textBox.Text == "";
        enum OperationType
        {
            Plus,
            Minus,
            Multiplay,
            Devision,
            Persent,
            None,
        }
        
        public void RegisterEvents()
        {
            Controls.OfType<Button>().Take(10).ToList().ForEach(item => item.Click += OnNumericButtonClick);
            buttonPlus.Click += OnButtonPlusClick;
            buttonMinus.Click += OnButtonMinusClick;
            buttonMultiplay.Click += OnButtonMultiplayClick;
            buttonDivision.Click += OnButtonDivisionClick;
            buttonResult.Click += OnButtonResultClick;
            buttonClear.Click += OnButtonClearClick;
            buttonErase.Click += ButtonEraseOnClick;
            buttonComma.Click += OnNumericButtonClick;
            buttonPersent.Click += ButtonPersentOnClick;
        }

        private void ButtonEraseOnClick(object sender, EventArgs e)
        {
            if (textBox.Text.Length < 1)
                return;
            int s = textBox.Text.Length - 1;
            textBox.Text = textBox.Text.Remove(s, 1);
        }

        private void OnButtonClearClick(object sender, EventArgs e)
        {
            labelTempResult.Text = null;
            textBox.Text = null;
            _type = OperationType.None;
        }

        private void OnButtonResultClick(object sender, EventArgs e)
        {
            switch (_type)
            {
                case OperationType.Plus:
                    _firstNumber += double.Parse(textBox.Text);
                    ProcessResult();
                    break;
                case OperationType.Minus:
                    _firstNumber -= double.Parse(textBox.Text);
                    ProcessResult();
                    break;
                case OperationType.Multiplay:
                    _firstNumber *= double.Parse(textBox.Text);
                    ProcessResult();
                    break;
                case OperationType.Devision:
                    _firstNumber /= double.Parse(textBox.Text);
                    ProcessResult();
                    break;
                case OperationType.Persent:
                    _firstNumber = 100 * _firstNumber / double.Parse(textBox.Text);
                    ProcessResult();
                    textBox.Text += GetOperationSimbol();
                    break;
            }
        }

        private void ProcessResult()
        {
            _firstNumber = Math.Round(_firstNumber, 2);
            textBox.Text = _firstNumber.ToString();
            _firstNumber = 0;
            labelTempResult.ResetText();
        }

        private void ButtonPersentOnClick(object sender, EventArgs e)
        {
            if (IsTextEmpty)
                return;
            _type = OperationType.Persent;
            TryToRideInClearTextbox();
        }
        private void OnButtonDivisionClick(object sender, EventArgs e)
        {
            if (IsTextEmpty)
                return;
            _type = OperationType.Devision;
            TryToRideInClearTextbox();
        }



        private void OnButtonMultiplayClick(object sender, EventArgs e)
        {
            if (IsTextEmpty)
                return;
            _type = OperationType.Multiplay;
            TryToRideInClearTextbox();
        }

        private void OnButtonMinusClick(object sender, EventArgs e)
        {
            if (IsTextEmpty)
                return;
            _type = OperationType.Minus;
            TryToRideInClearTextbox();
        }


        private void OnButtonPlusClick(object sender, EventArgs e)
        {
            if (IsTextEmpty)
                return;
            _type = OperationType.Plus;
            TryToRideInClearTextbox();
        }
        private void OnNumericButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            textBox.Text += button.Text;
        }
        private void TryToRideInClearTextbox()
        {
            if (IsTextEmpty)
                return;
            _firstNumber += double.Parse(textBox.Text);
            labelTempResult.Text = $"{_firstNumber} {GetOperationSimbol()}";
            textBox.Clear();
        }

        private char GetOperationSimbol()
        {
            return _type switch
            {
                OperationType.Plus => '+',
                OperationType.Minus => '-',
                OperationType.Multiplay => '*',
                OperationType.Devision => '/',
                OperationType.Persent => '%',
                OperationType.None => '=',
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
