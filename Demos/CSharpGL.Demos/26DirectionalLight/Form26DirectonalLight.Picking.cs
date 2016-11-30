﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form26DirectionalLight
    {
        private PickedGeometry pickedGeometry;
        private Point lastMousePosition;
        private PickingGeometryType pickingGeometryType = PickingGeometryType.Triangle;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                //rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex

            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition == e.Location) { return; }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.MouseMove(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
            }
            else
            {
                TryPicking(e);
            }

            this.lastMousePosition = e.Location;
        }

        private void TryPicking(MouseEventArgs e)
        {
            List<Tuple<Point, PickedGeometry>> allPickedGeometrys = this.scene.Pick(
              e.Location, pickingGeometryType);
            PickedGeometry pickedGeometry = null;
            if (allPickedGeometrys != null && allPickedGeometrys.Count > 0)
            { pickedGeometry = allPickedGeometrys[0].Item2; }

            if (pickedGeometry != null)
            {
                {
                    var modelRenderer = pickedGeometry.FromRenderer as DirectonalLightRenderer;
                    if (modelRenderer != null)
                    {
                        var script = modelRenderer.BindingSceneObject.GetScript<ModelScript>();
                        script.Bind();
                    }
                }

                this.glCanvas1.Cursor = Cursors.Hand;
            }
            else
            {
                this.glCanvas1.Cursor = Cursors.Default;
            }
            this.pickedGeometry = pickedGeometry;
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (pickedGeometry != null)
                {
                    var modelRenderer = pickedGeometry.FromRenderer as DirectonalLightRenderer;
                    if (modelRenderer != null)
                    {
                        var script = modelRenderer.BindingSceneObject.GetScript<ModelScript>();
                        script.Unbind();
                    }
                }
            }

            this.lastMousePosition = e.Location;
        }

    }
}