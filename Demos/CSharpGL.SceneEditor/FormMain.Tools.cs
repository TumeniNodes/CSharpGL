﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain 
    {

        private void thisFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this)).Show();
        }

        private void gLCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.glCanvas1)).Show();
        }

        private void cameraManipulaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.cameraManipulater)).Show();
        }

    }
}