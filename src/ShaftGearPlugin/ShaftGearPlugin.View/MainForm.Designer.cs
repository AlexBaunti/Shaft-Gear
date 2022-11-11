
namespace ShaftGearPlugin.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InputParameters = new System.Windows.Forms.GroupBox();
            this.DefaultParameters = new System.Windows.Forms.GroupBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.MinSizeButton = new System.Windows.Forms.Button();
            this.AvgSizeButton = new System.Windows.Forms.Button();
            this.MaxSizeButton = new System.Windows.Forms.Button();
            this.ShaftGearBlueprint = new System.Windows.Forms.PictureBox();
            this.DefaultParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShaftGearBlueprint)).BeginInit();
            this.SuspendLayout();
            // 
            // InputParameters
            // 
            this.InputParameters.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.InputParameters.Location = new System.Drawing.Point(12, 12);
            this.InputParameters.Name = "InputParameters";
            this.InputParameters.Size = new System.Drawing.Size(400, 300);
            this.InputParameters.TabIndex = 0;
            this.InputParameters.TabStop = false;
            this.InputParameters.Text = "Input Parameters";
            // 
            // DefaultParameters
            // 
            this.DefaultParameters.Controls.Add(this.MaxSizeButton);
            this.DefaultParameters.Controls.Add(this.AvgSizeButton);
            this.DefaultParameters.Controls.Add(this.MinSizeButton);
            this.DefaultParameters.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.DefaultParameters.Location = new System.Drawing.Point(12, 329);
            this.DefaultParameters.Name = "DefaultParameters";
            this.DefaultParameters.Size = new System.Drawing.Size(400, 220);
            this.DefaultParameters.TabIndex = 1;
            this.DefaultParameters.TabStop = false;
            this.DefaultParameters.Text = "Default Parameters";
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.BuildButton.Location = new System.Drawing.Point(422, 483);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(350, 45);
            this.BuildButton.TabIndex = 2;
            this.BuildButton.Text = "Build Model";
            this.BuildButton.UseVisualStyleBackColor = true;
            // 
            // MinSizeButton
            // 
            this.MinSizeButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.MinSizeButton.Location = new System.Drawing.Point(19, 32);
            this.MinSizeButton.Name = "MinSizeButton";
            this.MinSizeButton.Size = new System.Drawing.Size(360, 45);
            this.MinSizeButton.TabIndex = 0;
            this.MinSizeButton.Text = "Set Minimum Size";
            this.MinSizeButton.UseVisualStyleBackColor = true;
            // 
            // AvgSizeButton
            // 
            this.AvgSizeButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.AvgSizeButton.Location = new System.Drawing.Point(19, 93);
            this.AvgSizeButton.Name = "AvgSizeButton";
            this.AvgSizeButton.Size = new System.Drawing.Size(360, 45);
            this.AvgSizeButton.TabIndex = 0;
            this.AvgSizeButton.Text = "Set Average Size";
            this.AvgSizeButton.UseVisualStyleBackColor = true;
            // 
            // MaxSizeButton
            // 
            this.MaxSizeButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.MaxSizeButton.Location = new System.Drawing.Point(19, 154);
            this.MaxSizeButton.Name = "MaxSizeButton";
            this.MaxSizeButton.Size = new System.Drawing.Size(360, 45);
            this.MaxSizeButton.TabIndex = 0;
            this.MaxSizeButton.Text = "Set Maximum Size";
            this.MaxSizeButton.UseVisualStyleBackColor = true;
            // 
            // ShaftGearBlueprint
            // 
            this.ShaftGearBlueprint.Location = new System.Drawing.Point(422, 19);
            this.ShaftGearBlueprint.Name = "ShaftGearBlueprint";
            this.ShaftGearBlueprint.Size = new System.Drawing.Size(350, 447);
            this.ShaftGearBlueprint.TabIndex = 3;
            this.ShaftGearBlueprint.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ShaftGearBlueprint);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.DefaultParameters);
            this.Controls.Add(this.InputParameters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ShaftGearPlugin";
            this.DefaultParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShaftGearBlueprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox InputParameters;
        private System.Windows.Forms.GroupBox DefaultParameters;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Button MaxSizeButton;
        private System.Windows.Forms.Button AvgSizeButton;
        private System.Windows.Forms.Button MinSizeButton;
        private System.Windows.Forms.PictureBox ShaftGearBlueprint;
    }
}

