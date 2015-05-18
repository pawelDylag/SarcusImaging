using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarcusImaging
{
    public partial class SingleImageForm : Form
    {
        public SingleImageForm(Bitmap bitmap)
        {
            InitializeComponent();
            boxPicture.Image = bitmap;
        }
    }
}
