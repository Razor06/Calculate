using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {
        private double _firstNumber;
        private OperationType _type = OperationType.None;
        public Form1()
        {
            InitializeComponent();
            RegisterEvents();
        }
    }
}