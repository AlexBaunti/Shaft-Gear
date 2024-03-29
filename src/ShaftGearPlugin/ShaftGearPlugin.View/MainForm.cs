﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using ShaftGearPlugin.Model;
using ShaftGearPlugin.Wrapper;

namespace ShaftGearPlugin.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры вал-шестерни.
        /// </summary>
        private readonly ShaftGearParameters _parameters;

        /// <summary>
        /// Текстовые поля и ошибки в них.
        /// </summary>
        private readonly Dictionary<TextBox, string> _textBoxAndError;

        /// <summary>
        /// Соответствующий каждому полю тип параметра.
        /// </summary>
        private readonly Dictionary<TextBox, ShaftGearParametersType> _textBoxToParameterType;

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
            _parameters = new ShaftGearParameters();
            _textBoxToParameterType = new Dictionary<TextBox, ShaftGearParametersType>
            {
                { GearWidth, ShaftGearParametersType.GearWidth },
                { GearDiameter, ShaftGearParametersType.GearDiameter },
                { ConnectorDiameter, ShaftGearParametersType.ConnectorDiameter },
                { BaseDiameter, ShaftGearParametersType.BaseDiameter },
                { TipDiameter, ShaftGearParametersType.TipDiameter },
                { TipLength, ShaftGearParametersType.TipLength },
                { RotationAngle, ShaftGearParametersType.RotationAngle }
            };
            _textBoxAndError = new Dictionary<TextBox, string>
            {
                { GearWidth, "" },
                { GearDiameter, "" },
                { ConnectorDiameter, "" },
                { BaseDiameter, "" },
                { TipDiameter, "" },
                { TipLength, "" },
                { RotationAngle, "" }
            };
        }

        /// <summary>
        /// Устанавливает значения по умолчанию при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultValues(145, 95, 95, 90, 38, 50, 25);
        }

        /// <summary>
        /// Устанавливает значения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetParameter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var isType = _textBoxToParameterType.TryGetValue(textBox, out var type);
            double.TryParse(textBox.Text, out var value);
            if (!isType) return;
            try
            {
                _parameters.SetParameterValue(type, value);
                _textBoxAndError[textBox] = "";
                textBox.BackColor = _correctColor;
                errorProvider.Clear();
            }
            catch (Exception textBoxError)
            {
                _textBoxAndError[textBox] = textBoxError.Message;
                textBox.BackColor = _errorColor;
                errorProvider.SetError(textBox, textBoxError.Message);
            }
        }

        /// <summary>
        /// Устанавливает значения по умолчанию.
        /// </summary>
        private void SetDefaultValues(double GearWidthValue, double GearDiameterValue,
            double ConnectorDiameterValue, double BaseDiameterValue, double TipDiameterValue, 
            double TipLengthValue, double RotationAngleValue)
        {
            _parameters.SetParameterValue(ShaftGearParametersType.GearWidth, GearWidthValue);
            _parameters.SetParameterValue(ShaftGearParametersType.GearDiameter, GearDiameterValue);
            _parameters.SetDefaultParameterValue(ShaftGearParametersType.ConnectorDiameter, ConnectorDiameterValue);
            _parameters.SetParameterValue(ShaftGearParametersType.BaseDiameter, BaseDiameterValue);
            _parameters.SetDefaultParameterValue(ShaftGearParametersType.TipDiameter, TipDiameterValue);
            _parameters.SetParameterValue(ShaftGearParametersType.TipLength, TipLengthValue);
            _parameters.SetParameterValue(ShaftGearParametersType.RotationAngle, RotationAngleValue);

            GearWidth.Text = GearWidthValue.ToString();
            GearDiameter.Text = GearDiameterValue.ToString();
            ConnectorDiameter.Text = ConnectorDiameterValue.ToString();
            BaseDiameter.Text = BaseDiameterValue.ToString();
            TipDiameter.Text = TipDiameterValue.ToString();
            TipLength.Text = TipLengthValue.ToString();
            RotationAngle.Text = RotationAngleValue.ToString();
        }

        /// <summary>
        /// Устанавливает минимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinSizeButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(70, 70, 85, 80, 20, 30, 0);
        }

        /// <summary>
        /// Устанавливает средние размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AvgSizeButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(145, 95, 95, 90, 38, 50, 25);
        }

        /// <summary>
        /// Устанавливает максимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxSizeButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(200, 120, 105, 100, 55, 75, 45);
        }

        /// <summary>
        /// Проверяет заполнены ли текстовые поля.
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            var isError = true;
            foreach (var item in _textBoxAndError.Where(item => item.Value != ""))
            {
                isError = false;
                errorProvider.SetError(item.Key, item.Value);
            }
            return isError;
        }

        /// <summary>
        /// Кнопка построения модели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                var builder = new ShaftGearBuilder();
                builder.BuildDetail(_parameters);
            }
            else
            {
                MessageBox.Show("Fill All Required Parameters Correctly");
            }
        }

        /// <summary>
        /// Кнопка выхода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close Plugin?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
