
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InputParameters = new System.Windows.Forms.GroupBox();
            this.TipDiameterLabel = new System.Windows.Forms.Label();
            this.TipLengthLabel = new System.Windows.Forms.Label();
            this.BaseDiameterLabel = new System.Windows.Forms.Label();
            this.ConnectorDiameterLabel = new System.Windows.Forms.Label();
            this.TipDiameter = new System.Windows.Forms.TextBox();
            this.TipLength = new System.Windows.Forms.TextBox();
            this.BaseDiameter = new System.Windows.Forms.TextBox();
            this.ConnectorDiameter = new System.Windows.Forms.TextBox();
            this.GearDiameterLabel = new System.Windows.Forms.Label();
            this.GearDiameter = new System.Windows.Forms.TextBox();
            this.GearWidthLabel = new System.Windows.Forms.Label();
            this.GearWidth = new System.Windows.Forms.TextBox();
            this.DefaultParameters = new System.Windows.Forms.GroupBox();
            this.MaxSizeButton = new System.Windows.Forms.Button();
            this.AvgSizeButton = new System.Windows.Forms.Button();
            this.MinSizeButton = new System.Windows.Forms.Button();
            this.BuildButton = new System.Windows.Forms.Button();
            this.ShaftGearBlueprint = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.InputParameters.SuspendLayout();
            this.DefaultParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShaftGearBlueprint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // InputParameters
            // 
            this.InputParameters.Controls.Add(this.TipDiameterLabel);
            this.InputParameters.Controls.Add(this.TipLengthLabel);
            this.InputParameters.Controls.Add(this.BaseDiameterLabel);
            this.InputParameters.Controls.Add(this.ConnectorDiameterLabel);
            this.InputParameters.Controls.Add(this.TipDiameter);
            this.InputParameters.Controls.Add(this.TipLength);
            this.InputParameters.Controls.Add(this.BaseDiameter);
            this.InputParameters.Controls.Add(this.ConnectorDiameter);
            this.InputParameters.Controls.Add(this.GearDiameterLabel);
            this.InputParameters.Controls.Add(this.GearDiameter);
            this.InputParameters.Controls.Add(this.GearWidthLabel);
            this.InputParameters.Controls.Add(this.GearWidth);
            this.InputParameters.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.InputParameters.Location = new System.Drawing.Point(12, 12);
            this.InputParameters.Name = "InputParameters";
            this.InputParameters.Size = new System.Drawing.Size(370, 310);
            this.InputParameters.TabIndex = 0;
            this.InputParameters.TabStop = false;
            this.InputParameters.Text = "Input Parameters";
            // 
            // TipDiameterLabel
            // 
            this.TipDiameterLabel.AutoSize = true;
            this.TipDiameterLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.TipDiameterLabel.Location = new System.Drawing.Point(20, 205);
            this.TipDiameterLabel.Name = "TipDiameterLabel";
            this.TipDiameterLabel.Size = new System.Drawing.Size(171, 20);
            this.TipDiameterLabel.TabIndex = 1;
            this.TipDiameterLabel.Text = "Shaft Tip Diameter (D4)";
            // 
            // TipLengthLabel
            // 
            this.TipLengthLabel.AutoSize = true;
            this.TipLengthLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.TipLengthLabel.Location = new System.Drawing.Point(20, 245);
            this.TipLengthLabel.Name = "TipLengthLabel";
            this.TipLengthLabel.Size = new System.Drawing.Size(150, 20);
            this.TipLengthLabel.TabIndex = 1;
            this.TipLengthLabel.Text = "Shaft Tip Length (L1)";
            // 
            // BaseDiameterLabel
            // 
            this.BaseDiameterLabel.AutoSize = true;
            this.BaseDiameterLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.BaseDiameterLabel.Location = new System.Drawing.Point(20, 165);
            this.BaseDiameterLabel.Name = "BaseDiameterLabel";
            this.BaseDiameterLabel.Size = new System.Drawing.Size(188, 20);
            this.BaseDiameterLabel.TabIndex = 1;
            this.BaseDiameterLabel.Text = "Shaft Base Diameter (D3)";
            // 
            // ConnectorDiameterLabel
            // 
            this.ConnectorDiameterLabel.AutoSize = true;
            this.ConnectorDiameterLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.ConnectorDiameterLabel.Location = new System.Drawing.Point(20, 125);
            this.ConnectorDiameterLabel.Name = "ConnectorDiameterLabel";
            this.ConnectorDiameterLabel.Size = new System.Drawing.Size(193, 20);
            this.ConnectorDiameterLabel.TabIndex = 1;
            this.ConnectorDiameterLabel.Text = "Connector Diameter (D2)";
            // 
            // TipDiameter
            // 
            this.TipDiameter.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.TipDiameter.Location = new System.Drawing.Point(229, 205);
            this.TipDiameter.Name = "TipDiameter";
            this.TipDiameter.Size = new System.Drawing.Size(110, 24);
            this.TipDiameter.TabIndex = 0;
            this.TipDiameter.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // TipLength
            // 
            this.TipLength.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.TipLength.Location = new System.Drawing.Point(229, 245);
            this.TipLength.Name = "TipLength";
            this.TipLength.Size = new System.Drawing.Size(110, 24);
            this.TipLength.TabIndex = 0;
            this.TipLength.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // BaseDiameter
            // 
            this.BaseDiameter.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.BaseDiameter.Location = new System.Drawing.Point(229, 165);
            this.BaseDiameter.Name = "BaseDiameter";
            this.BaseDiameter.Size = new System.Drawing.Size(110, 24);
            this.BaseDiameter.TabIndex = 0;
            this.BaseDiameter.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // ConnectorDiameter
            // 
            this.ConnectorDiameter.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.ConnectorDiameter.Location = new System.Drawing.Point(229, 125);
            this.ConnectorDiameter.Name = "ConnectorDiameter";
            this.ConnectorDiameter.Size = new System.Drawing.Size(110, 24);
            this.ConnectorDiameter.TabIndex = 0;
            this.ConnectorDiameter.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // GearDiameterLabel
            // 
            this.GearDiameterLabel.AutoSize = true;
            this.GearDiameterLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.GearDiameterLabel.Location = new System.Drawing.Point(20, 85);
            this.GearDiameterLabel.Name = "GearDiameterLabel";
            this.GearDiameterLabel.Size = new System.Drawing.Size(151, 20);
            this.GearDiameterLabel.TabIndex = 1;
            this.GearDiameterLabel.Text = "Gear Diameter (D1)";
            // 
            // GearDiameter
            // 
            this.GearDiameter.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.GearDiameter.Location = new System.Drawing.Point(229, 85);
            this.GearDiameter.Name = "GearDiameter";
            this.GearDiameter.Size = new System.Drawing.Size(110, 24);
            this.GearDiameter.TabIndex = 0;
            this.GearDiameter.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // GearWidthLabel
            // 
            this.GearWidthLabel.AutoSize = true;
            this.GearWidthLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.GearWidthLabel.Location = new System.Drawing.Point(20, 45);
            this.GearWidthLabel.Name = "GearWidthLabel";
            this.GearWidthLabel.Size = new System.Drawing.Size(130, 20);
            this.GearWidthLabel.TabIndex = 1;
            this.GearWidthLabel.Text = "Gear Width (W1)";
            // 
            // GearWidth
            // 
            this.GearWidth.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.GearWidth.Location = new System.Drawing.Point(229, 45);
            this.GearWidth.Name = "GearWidth";
            this.GearWidth.Size = new System.Drawing.Size(110, 24);
            this.GearWidth.TabIndex = 0;
            this.GearWidth.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // DefaultParameters
            // 
            this.DefaultParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultParameters.Controls.Add(this.MaxSizeButton);
            this.DefaultParameters.Controls.Add(this.AvgSizeButton);
            this.DefaultParameters.Controls.Add(this.MinSizeButton);
            this.DefaultParameters.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.DefaultParameters.Location = new System.Drawing.Point(12, 329);
            this.DefaultParameters.Name = "DefaultParameters";
            this.DefaultParameters.Size = new System.Drawing.Size(370, 220);
            this.DefaultParameters.TabIndex = 1;
            this.DefaultParameters.TabStop = false;
            this.DefaultParameters.Text = "Default Parameters";
            // 
            // MaxSizeButton
            // 
            this.MaxSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxSizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MaxSizeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MaxSizeButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.MaxSizeButton.Location = new System.Drawing.Point(19, 154);
            this.MaxSizeButton.Name = "MaxSizeButton";
            this.MaxSizeButton.Size = new System.Drawing.Size(330, 45);
            this.MaxSizeButton.TabIndex = 0;
            this.MaxSizeButton.Text = "Set Maximum Size";
            this.MaxSizeButton.UseVisualStyleBackColor = false;
            this.MaxSizeButton.Click += new System.EventHandler(this.MaxSizeButton_Click);
            // 
            // AvgSizeButton
            // 
            this.AvgSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AvgSizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AvgSizeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AvgSizeButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.AvgSizeButton.Location = new System.Drawing.Point(19, 93);
            this.AvgSizeButton.Name = "AvgSizeButton";
            this.AvgSizeButton.Size = new System.Drawing.Size(330, 45);
            this.AvgSizeButton.TabIndex = 0;
            this.AvgSizeButton.Text = "Set Average Size";
            this.AvgSizeButton.UseVisualStyleBackColor = false;
            this.AvgSizeButton.Click += new System.EventHandler(this.AvgSizeButton_Click);
            // 
            // MinSizeButton
            // 
            this.MinSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MinSizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MinSizeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MinSizeButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.MinSizeButton.Location = new System.Drawing.Point(19, 32);
            this.MinSizeButton.Name = "MinSizeButton";
            this.MinSizeButton.Size = new System.Drawing.Size(330, 45);
            this.MinSizeButton.TabIndex = 0;
            this.MinSizeButton.Text = "Set Minimum Size";
            this.MinSizeButton.UseVisualStyleBackColor = false;
            this.MinSizeButton.Click += new System.EventHandler(this.MinSizeButton_Click);
            // 
            // BuildButton
            // 
            this.BuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BuildButton.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.BuildButton.Location = new System.Drawing.Point(402, 483);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(370, 45);
            this.BuildButton.TabIndex = 2;
            this.BuildButton.Text = "Build Model";
            this.BuildButton.UseVisualStyleBackColor = false;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ShaftGearBlueprint
            // 
            this.ShaftGearBlueprint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShaftGearBlueprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShaftGearBlueprint.Image = ((System.Drawing.Image)(resources.GetObject("ShaftGearBlueprint.Image")));
            this.ShaftGearBlueprint.InitialImage = ((System.Drawing.Image)(resources.GetObject("ShaftGearBlueprint.InitialImage")));
            this.ShaftGearBlueprint.Location = new System.Drawing.Point(402, 20);
            this.ShaftGearBlueprint.Name = "ShaftGearBlueprint";
            this.ShaftGearBlueprint.Size = new System.Drawing.Size(370, 447);
            this.ShaftGearBlueprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShaftGearBlueprint.TabIndex = 3;
            this.ShaftGearBlueprint.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
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
            this.MaximumSize = new System.Drawing.Size(1050, 900);
            this.MinimumSize = new System.Drawing.Size(790, 600);
            this.Name = "MainForm";
            this.Text = "ShaftGearPlugin";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.InputParameters.ResumeLayout(false);
            this.InputParameters.PerformLayout();
            this.DefaultParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShaftGearBlueprint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.Label GearWidthLabel;
        private System.Windows.Forms.TextBox GearWidth;
        private System.Windows.Forms.Label TipDiameterLabel;
        private System.Windows.Forms.Label TipLengthLabel;
        private System.Windows.Forms.Label BaseDiameterLabel;
        private System.Windows.Forms.Label ConnectorDiameterLabel;
        private System.Windows.Forms.TextBox TipDiameter;
        private System.Windows.Forms.TextBox TipLength;
        private System.Windows.Forms.TextBox BaseDiameter;
        private System.Windows.Forms.TextBox ConnectorDiameter;
        private System.Windows.Forms.Label GearDiameterLabel;
        private System.Windows.Forms.TextBox GearDiameter;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

