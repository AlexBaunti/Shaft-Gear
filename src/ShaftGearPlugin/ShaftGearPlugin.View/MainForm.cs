using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using ShaftGearPlugin.Model;

namespace ShaftGearPlugin.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры вал-шестерни.
        /// </summary>
        private readonly ShaftGearParameters Parameters;

        /// <summary>
        /// Текстовые поля и ошибки в них.
        /// </summary>
        private readonly Dictionary<TextBox, string> TextBoxAndError;

        /// <summary>
        /// Соответствующий каждому полю тип параметра.
        /// </summary>
        private readonly Dictionary<TextBox, ShaftGearParametersType> TextBoxToParameterType;

        /// <summary>
        /// Константа для корректного цвета. 
        /// </summary>
        private readonly Color _correctColor = Color.White;

        /// <summary>
        /// Константа для цвета ошибки.
        /// </summary>
        private readonly Color _errorColor = Color.LightCoral;

        public MainForm()
        {
            InitializeComponent();
            Parameters = new ShaftGearParameters();
            TextBoxToParameterType = new Dictionary<TextBox, ShaftGearParametersType>
            {
                { GearWidth, ShaftGearParametersType.GearWidth },
                { GearDiameter, ShaftGearParametersType.GearDiameter },
                { ConnectorDiameter, ShaftGearParametersType.ConnectorDiameter },
                { BaseDiameter, ShaftGearParametersType.BaseDiameter },
                { TipDiameter, ShaftGearParametersType.TipDiameter },
                { TipLength, ShaftGearParametersType.TipLength }
            };
            TextBoxAndError = new Dictionary<TextBox, string>
            {
                { GearWidth, "" },
                { GearDiameter, "" },
                { ConnectorDiameter, "" },
                { BaseDiameter, "" },
                { TipDiameter, "" },
                { TipLength, "" }
            };
        }

        /// <summary>
        /// Устанавливает значения по умолчанию при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultValues(145, 95, 97, 92, 38, 50);
        }

        /// <summary>
        /// Устанавливает значения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetParameter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var isType = TextBoxToParameterType.TryGetValue(textBox, out var type);
            double.TryParse(textBox.Text, out var value);
            if (!isType) return;
            try
            {
                Parameters.SetParameterValue(type, value);
                TextBoxAndError[textBox] = "";
                textBox.BackColor = _correctColor;
                errorProvider.Clear();
            }
            catch (Exception textBoxError)
            {
                TextBoxAndError[textBox] = textBoxError.Message;
                textBox.BackColor = _errorColor;
                errorProvider.SetError(textBox, textBoxError.Message);
            }
        }

        /// <summary>
        /// Устанавливает значения по умолчанию.
        /// </summary>
        private void SetDefaultValues(double GearWidthValue, double GearDiameterValue,
            double ConnectorDiameterValue, double BaseDiameterValue, double TipDiameterValue, double TipLengthValue)
        {
            Parameters.SetParameterValue(ShaftGearParametersType.GearWidth, GearWidthValue);
            Parameters.SetParameterValue(ShaftGearParametersType.GearDiameter, GearDiameterValue);
            Parameters.SetParameterValue(ShaftGearParametersType.ConnectorDiameter, ConnectorDiameterValue);
            Parameters.SetParameterValue(ShaftGearParametersType.BaseDiameter, BaseDiameterValue);
            Parameters.SetParameterValue(ShaftGearParametersType.TipDiameter, TipDiameterValue);
            Parameters.SetParameterValue(ShaftGearParametersType.TipLength, TipLengthValue);

            GearWidth.Text = GearWidthValue.ToString();
            GearDiameter.Text = GearDiameterValue.ToString();
            ConnectorDiameter.Text = ConnectorDiameterValue.ToString();
            BaseDiameter.Text = BaseDiameterValue.ToString();
            TipDiameter.Text = TipDiameterValue.ToString();
            TipLength.Text = TipLengthValue.ToString();
        }

        /// <summary>
        /// Устанавливает минимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinSizeButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(70, 70, 85, 80, 20, 30);
        }

        /// <summary>
        /// Устанавливает средние размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AvgSizeButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(145, 95, 97, 92, 38, 50);
        }

        /// <summary>
        /// Устанавливает максимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxSizeButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(200, 120, 110, 105, 55, 75);
        }

        /// <summary>
        /// Проверяет заполнены ли текстовые поля
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            var isError = true;
            foreach (var item in TextBoxAndError.Where(item => item.Value != ""))
            {
                isError = false;
                errorProvider.SetError(item.Key, item.Value);
            }
            return isError;
        }

        /// <summary>
        /// Проверка перед построением модели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                // Start Build
            }
            else
            {
                MessageBox.Show("Fill All Required Parameters Correctly");
            }
        }
    }
}
