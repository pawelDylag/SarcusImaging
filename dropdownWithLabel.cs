using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    public partial class dropdownWithLabel : Component
    {
        public dropdownWithLabel()
        {
            InitializeComponent();
        }

        public dropdownWithLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
