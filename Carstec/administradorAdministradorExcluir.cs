﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carstec
{
    public partial class administradorAdministradorExcluir : Form
    {
        public string id = "";
        public administradorAdministradorExcluir(string i)
        {
            InitializeComponent();
            id = i;
        }
    }
}
