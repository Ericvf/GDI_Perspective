namespace PerspectiveTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Renderer = new System.Windows.Forms.Timer(this.components);
            this.cb_DrawVertices = new System.Windows.Forms.CheckBox();
            this.cb_UseShading = new System.Windows.Forms.CheckBox();
            this.cb_UseCulling = new System.Windows.Forms.CheckBox();
            this.cb_DrawFaces = new System.Windows.Forms.CheckBox();
            this.cb_AntiAlias = new System.Windows.Forms.CheckBox();
            this.perspectiveControl1 = new Perspective.PerspectiveControl();
            this.SuspendLayout();
            // 
            // Renderer
            // 
            this.Renderer.Enabled = true;
            this.Renderer.Interval = 1;
            this.Renderer.Tick += new System.EventHandler(this.Renderer_Tick);
            // 
            // cb_DrawVertices
            // 
            this.cb_DrawVertices.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_DrawVertices.AutoSize = true;
            this.cb_DrawVertices.Location = new System.Drawing.Point(489, 82);
            this.cb_DrawVertices.Name = "cb_DrawVertices";
            this.cb_DrawVertices.Size = new System.Drawing.Size(92, 17);
            this.cb_DrawVertices.TabIndex = 1;
            this.cb_DrawVertices.Text = "Draw Vertices";
            this.cb_DrawVertices.UseVisualStyleBackColor = true;
            // 
            // cb_UseShading
            // 
            this.cb_UseShading.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_UseShading.AutoSize = true;
            this.cb_UseShading.Checked = true;
            this.cb_UseShading.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_UseShading.Location = new System.Drawing.Point(489, 105);
            this.cb_UseShading.Name = "cb_UseShading";
            this.cb_UseShading.Size = new System.Drawing.Size(87, 17);
            this.cb_UseShading.TabIndex = 1;
            this.cb_UseShading.Text = "Use Shading";
            this.cb_UseShading.UseVisualStyleBackColor = true;
            // 
            // cb_UseCulling
            // 
            this.cb_UseCulling.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_UseCulling.AutoSize = true;
            this.cb_UseCulling.Checked = true;
            this.cb_UseCulling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_UseCulling.Location = new System.Drawing.Point(489, 128);
            this.cb_UseCulling.Name = "cb_UseCulling";
            this.cb_UseCulling.Size = new System.Drawing.Size(79, 17);
            this.cb_UseCulling.TabIndex = 1;
            this.cb_UseCulling.Text = "Use Culling";
            this.cb_UseCulling.UseVisualStyleBackColor = true;
            // 
            // cb_DrawFaces
            // 
            this.cb_DrawFaces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_DrawFaces.AutoSize = true;
            this.cb_DrawFaces.Checked = true;
            this.cb_DrawFaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_DrawFaces.Location = new System.Drawing.Point(489, 151);
            this.cb_DrawFaces.Name = "cb_DrawFaces";
            this.cb_DrawFaces.Size = new System.Drawing.Size(83, 17);
            this.cb_DrawFaces.TabIndex = 1;
            this.cb_DrawFaces.Text = "Draw Faces";
            this.cb_DrawFaces.UseVisualStyleBackColor = true;
            // 
            // cb_AntiAlias
            // 
            this.cb_AntiAlias.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_AntiAlias.AutoSize = true;
            this.cb_AntiAlias.Location = new System.Drawing.Point(489, 174);
            this.cb_AntiAlias.Name = "cb_AntiAlias";
            this.cb_AntiAlias.Size = new System.Drawing.Size(68, 17);
            this.cb_AntiAlias.TabIndex = 1;
            this.cb_AntiAlias.Text = "Anti-alias";
            this.cb_AntiAlias.UseVisualStyleBackColor = true;
            // 
            // perspectiveControl1
            // 
            this.perspectiveControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.perspectiveControl1.AntiAlias = true;
            this.perspectiveControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.perspectiveControl1.DrawFaces = true;
            this.perspectiveControl1.DrawLines = true;
            this.perspectiveControl1.DrawVertices = false;
            this.perspectiveControl1.Location = new System.Drawing.Point(12, 12);
            this.perspectiveControl1.Name = "perspectiveControl1";
            this.perspectiveControl1.Scale = 100;
            this.perspectiveControl1.Size = new System.Drawing.Size(471, 421);
            this.perspectiveControl1.TabIndex = 0;
            this.perspectiveControl1.UseCulling = true;
            this.perspectiveControl1.UseShading = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 445);
            this.Controls.Add(this.cb_AntiAlias);
            this.Controls.Add(this.cb_DrawFaces);
            this.Controls.Add(this.cb_UseCulling);
            this.Controls.Add(this.cb_UseShading);
            this.Controls.Add(this.cb_DrawVertices);
            this.Controls.Add(this.perspectiveControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Perspective.PerspectiveControl perspectiveControl1;
        private System.Windows.Forms.Timer Renderer;
        private System.Windows.Forms.CheckBox cb_DrawVertices;
        private System.Windows.Forms.CheckBox cb_UseShading;
        private System.Windows.Forms.CheckBox cb_UseCulling;
        private System.Windows.Forms.CheckBox cb_DrawFaces;
        private System.Windows.Forms.CheckBox cb_AntiAlias;
    }
}

