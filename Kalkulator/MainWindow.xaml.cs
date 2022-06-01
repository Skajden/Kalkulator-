using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator
{
    public partial class MainWindow
    {
        private string firstNum = "";
        private string secondNum = "";
        private string power = "";

        private bool isOnFirstNum = true;
        private bool isAdding;
        private bool isSubtracting;
        private bool isMultiplying;
        private bool isDividing;
        private bool isCarreting;
        private int counter;

        public MainWindow()
        {
            InitializeComponent();
            
            AddKeyEvents();
        }

        private void AddKeyEvents()
        {
            KeyDown += (sender, args) =>
            {
                switch (args.Key)
                {
                    case Key.NumPad1:
                        DisplayNumber(1);
                        break;
                    case Key.NumPad2:
                        DisplayNumber(2);
                        break;
                    case Key.NumPad3:
                        DisplayNumber(3);
                        break;
                    case Key.NumPad4:
                        DisplayNumber(4);
                        break;
                    case Key.NumPad5:
                        DisplayNumber(5);
                        break;
                    case Key.NumPad6:
                        DisplayNumber(6);
                        break;
                    case Key.NumPad7:
                        DisplayNumber(7);
                        break;
                    case Key.NumPad8:
                        DisplayNumber(8);
                        break;
                    case Key.NumPad9:
                        DisplayNumber(9);
                        break;
                    case Key.NumPad0:
                        DisplayNumber(0);
                        break;
                    case Key.Back:
                        BackSpace(sender, args);
                        break;
                    case Key.Enter:
                        Equals(sender, args);
                        break;
                    case Key.Add:
                        Add(sender, args);
                        break;
                    case Key.Subtract:
                        Subtract(sender, args);
                        break;
                    case Key.Multiply:
                        Multiply(sender, args);
                        break;
                    case Key.Divide:
                        Divide(sender, args);
                        break;
                    case Key.D1:
                        DisplayNumber(1);
                        break;
                    case Key.D2:
                        DisplayNumber(2);
                        break;
                    case Key.D3:
                        DisplayNumber(3);
                        break;
                    case Key.D4:
                        DisplayNumber(4);
                        break;
                    case Key.D5:
                        DisplayNumber(5);
                        break;
                    case Key.D6:
                        DisplayNumber(6);
                        break;
                    case Key.D7:
                        DisplayNumber(7);
                        break;
                    case Key.D8:
                        DisplayNumber(8);
                        break;
                    case Key.D9:
                        DisplayNumber(9);
                        break;
                    case Key.D0:
                        DisplayNumber(0);
                        break;
                    case Key.Decimal:
                        Decimal(sender, args);
                        break;
                    case Key.OemPeriod:
                        Decimal(sender, args);
                        break;
                    case Key.OemMinus:
                        Subtract(sender, args);
                        break;
                    case Key.OemPlus:
                        Add(sender, args);
                        break;
                }
            };
        }

        private void Equals(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            try
            {
                if (BottomTextBox.Text.Equals("")) return;
                if (firstNum.Equals("-"))
                {
                    firstNum = "0";
                }
                if (secondNum.Equals("-"))
                {
                    secondNum = "0";
                }

                if (isCarreting)
                {
                    if (isOnFirstNum)
                    {
                        int index = BottomTextBox.Text.IndexOf("^", StringComparison.Ordinal);
                        firstNum = BottomTextBox.Text.Substring(0, index);
                        double total = Math.Pow(Double.Parse(firstNum), Double.Parse(power));
                        TopTextBox.Clear();
                        secondNum = "";
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                    else
                    {
                        double total = Math.Pow(Double.Parse(secondNum), Double.Parse(power));
                        TopTextBox.Clear();
                        secondNum = "";
                        BottomTextBox.Text = total.ToString();
                        secondNum = total.ToString();
                    }
                }
                if (isMultiplying)
                {
                    if (counter > 1)
                    {
                        double total = Double.Parse(firstNum) * Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = total.ToString();
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                    else
                    {
                        double total = Double.Parse(firstNum) * Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = "";
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                }
                if (isDividing)
                {
                    if (counter > 1)
                    {
                        double total = Double.Parse(firstNum) / Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = total.ToString();
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                    else
                    {
                        double total = Double.Parse(firstNum) / Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = "";
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                }
                if (isAdding)
                {
                    if (counter > 1)
                    {
                        double total = Double.Parse(firstNum) + Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = total.ToString();
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                    else
                    {
                        double total = Double.Parse(firstNum) + Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = "";
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                }
                else if (isSubtracting)
                {
                    if (counter > 1)
                    {
                        double total = Double.Parse(firstNum) - Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = total.ToString();
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                    else
                    {
                        double total = Double.Parse(firstNum) - Double.Parse(secondNum);
                        TopTextBox.Clear();
                        secondNum = "";
                        BottomTextBox.Text = total.ToString();
                        firstNum = total.ToString();
                    }
                }

                isOnFirstNum = true;
                isAdding = false;
                isSubtracting = false;
                isMultiplying = false;
                isDividing = false;
                isCarreting = false;
                power = "";
                counter = 0;
                EqualsButton.IsTabStop = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ClearDisplay(sender, routedEventArgs);
                BottomTextBox.Text = "Error";
            }
        }

        private void Caret(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (!isCarreting)
            {
                if (isOnFirstNum)
                {
                    if (firstNum.Equals("") || firstNum.Contains("^")) return;
                    BottomTextBox.AppendText("^");
                    isCarreting = true;
                }
                else
                {
                    if (secondNum.Equals("") || secondNum.Contains("^")) return;
                    BottomTextBox.AppendText("^");
                    isCarreting = true;
                }
            }
            CaretButton.IsTabStop = false;
        }

        private void Inverse(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (isOnFirstNum)
            {
                if (firstNum.Equals("")) return;
                firstNum = (1 / Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            else
            {
                if (secondNum.Equals("")) return;
                secondNum = (1 / Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            InverseButton.IsTabStop = false;
        }

        private void SquareRoot(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (isOnFirstNum)
            {
                if (firstNum.Equals("")) return;
                firstNum = Math.Sqrt(Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            else
            {
                if (secondNum.Equals("")) return;
                secondNum = Math.Sqrt(Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = secondNum;
            }
            SqrRootButton.IsTabStop = false;
        }

        private void Square(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (isOnFirstNum)
            {
                if (firstNum.Equals("")) return;
                firstNum = (Double.Parse(firstNum) * Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            else
            {
                if (secondNum.Equals("")) return;
                secondNum = (Double.Parse(secondNum) * Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = secondNum;
            }
            SqrButton.IsTabStop = false;
        }

        private void SwitchSigns(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (!isCarreting)
            {
                if (isOnFirstNum)
                {
                    if (!firstNum.Equals(""))
                    {
                        if (firstNum.Substring(0, 1).Equals("-"))
                        {
                            if (firstNum.Equals("-"))
                            {
                                firstNum = "";
                                BottomTextBox.Text = firstNum;
                            }
                            else
                            {
                                firstNum = (Double.Parse(firstNum) * -1).ToString();
                                BottomTextBox.Text = firstNum;
                            }
                        }
                        else
                        {
                            firstNum = (Double.Parse(firstNum) * -1).ToString();
                            BottomTextBox.Text = firstNum;
                        }
                    }
                    else
                    {
                        firstNum = "-";
                        BottomTextBox.Text = firstNum;
                    }
                }
                else
                {
                    if (!secondNum.Equals(""))
                    {
                        if (secondNum.Substring(0, 1).Equals("-"))
                        {
                            if (secondNum.Equals("-"))
                            {
                                secondNum = "";
                                BottomTextBox.Text = secondNum;
                            }
                            else
                            {
                                secondNum = (-Double.Parse(secondNum)).ToString();
                                BottomTextBox.Text = secondNum;
                            }
                        }
                        else
                        {
                            secondNum = (Double.Parse(secondNum) * -1).ToString();
                            BottomTextBox.Text = secondNum;
                        }
                    }
                    else
                    {
                        secondNum = "-";
                        BottomTextBox.Text = secondNum;
                    }
                }
            }
            else
            {
                if (power.Equals(""))
                {
                    power = "-";
                    BottomTextBox.AppendText(power);
                }
                else if (power.Equals("-"))
                {
                    string currentString = BottomTextBox.Text.Substring(0, BottomTextBox.Text.Length - 1);
                    power = "";
                    BottomTextBox.Text = currentString;
                }
                else if (power.Contains("-"))
                {
                    string currentString = BottomTextBox.Text.Substring(0, BottomTextBox.Text.Length - power.Length);
                    power = (-Double.Parse(power)).ToString();
                    BottomTextBox.Text = currentString + power;
                }
                else
                {
                    string currentString = BottomTextBox.Text.Substring(0, BottomTextBox.Text.Length - power.Length);
                    power = (-Double.Parse(power)).ToString();
                    BottomTextBox.Text = currentString + power;
                }
            }
            SwitchSignButton.IsTabStop = false;
        }

        private void Decimal(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (isOnFirstNum)
            {
                if (firstNum.Contains(".")) return;
                if (!firstNum.Equals(""))
                {
                    if (!firstNum.Equals("0."))
                    {
                        firstNum += ".";
                        BottomTextBox.AppendText(".");
                    }
                }
                else
                {
                    firstNum = "0.";
                    BottomTextBox.Text = "0.";
                }
            }
            else
            {
                if (secondNum.Contains(".")) return;
                if (!secondNum.Equals(""))
                {
                    if (!secondNum.Equals("0."))
                    {
                        secondNum += ".";
                        BottomTextBox.AppendText(".");
                    }
                }
                else
                {
                    secondNum = "0.";
                    BottomTextBox.Text = "0.";
                }
            }
            DecimalButton.IsTabStop = false;
        }

        private void Add(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (BottomTextBox.Text.Equals("")) return;
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }

            if (counter < 1)
            {
                ClearOperators();
                isAdding = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" + ");
            }
            else
            {
                isOnFirstNum = false;
                Equals(sender, routedEventArgs);
                isAdding = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" + ");
            }

            counter++;
            PlusButton.IsTabStop = false;
        }

        private void Subtract(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (BottomTextBox.Text.Equals("")) return;
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }

            if (counter < 1)
            {
                ClearOperators();
                isSubtracting = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" - ");
            }
            else
            {
                isOnFirstNum = false;
                Equals(sender, routedEventArgs);
                isSubtracting = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" - ");
            }

            counter++;
            MinusButton.IsTabStop = false;
        }

        private void Multiply(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (BottomTextBox.Text.Equals("")) return;
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }

            if (counter < 1)
            {
                ClearOperators();
                isMultiplying = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" * ");
            }
            else
            {
                isOnFirstNum = false;
                Equals(sender, routedEventArgs);
                isMultiplying = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" * ");
            }

            counter++;
            MultiplyButton.IsTabStop = false;
        }

        private void Divide(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            if (BottomTextBox.Text.Equals("")) return;
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }

            if (counter < 1)
            {
                ClearOperators();
                isDividing = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" / ");
            }
            else
            {
                isOnFirstNum = false;
                Equals(sender, routedEventArgs);
                isDividing = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" / ");
            }

            counter++;
            DivideButton.IsTabStop = false;
        }

        private void DisplayNumber(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            var tag = ((Button)sender).Tag;

            if (isCarreting)
            {
                power += tag.ToString();
            }
            if (isOnFirstNum)
            {
                BottomTextBox.AppendText(tag.ToString());
                firstNum = BottomTextBox.Text;
            }
            else
            {
                BottomTextBox.AppendText(tag.ToString());
                if (!isCarreting)
                {
                    secondNum = BottomTextBox.Text;
                }
            }

            OneButton.IsTabStop = false;
            TwoButton.IsTabStop = false;
            ThreeButton.IsTabStop = false;
            FourButton.IsTabStop = false;
            FiveButton.IsTabStop = false;
            SixButton.IsTabStop = false;
            SevenButton.IsTabStop = false;
            EightButton.IsTabStop = false;
            NineButton.IsTabStop = false;
            ZeroButton.IsTabStop = false;
        }

        private void DisplayNumber(int num)
        {
            RemoveError();
            if (isCarreting)
            {
                power += num.ToString();
            }
            if (isOnFirstNum)
            {
                BottomTextBox.AppendText(num.ToString());
                firstNum = BottomTextBox.Text;
                Console.WriteLine(1);
            }
            else
            {
                BottomTextBox.AppendText(num.ToString());
                if (!isCarreting)
                {
                    secondNum = BottomTextBox.Text;
                }
            }

            OneButton.IsTabStop = false;
            TwoButton.IsTabStop = false;
            ThreeButton.IsTabStop = false;
            FourButton.IsTabStop = false;
            FiveButton.IsTabStop = false;
            SixButton.IsTabStop = false;
            SevenButton.IsTabStop = false;
            EightButton.IsTabStop = false;
            NineButton.IsTabStop = false;
            ZeroButton.IsTabStop = false;
        }

        private void BackSpace(object sender, RoutedEventArgs routedEventArgs)
        {
            RemoveError();
            string currentString;
            int textLength;

            if (isOnFirstNum)
            {
                if (!BottomTextBox.Text.Equals(""))
                {
                    textLength = BottomTextBox.Text.Length;
                    currentString = BottomTextBox.Text.Substring(0, textLength - 1);
                    BottomTextBox.Text = currentString;
                    firstNum = currentString;
                    Console.WriteLine(1);
                }
            }
            else
            {
                if (!BottomTextBox.Text.Equals(""))
                {
                    textLength = BottomTextBox.Text.Length;
                    currentString = BottomTextBox.Text.Substring(0, textLength - 1);
                    BottomTextBox.Text = currentString;
                    secondNum = currentString;
                }
            }

            if (isCarreting && !BottomTextBox.Text.Contains("^"))
            {
                isCarreting = false;
            }

            BackButton.IsTabStop = false;
        }

        private void ClearDisplay(object sender, RoutedEventArgs routedEventArgs)
        {
            TopTextBox.Clear();
            BottomTextBox.Clear();
            firstNum = "";
            secondNum = "";
            power = "";
            isOnFirstNum = true;

            isAdding = false;
            isSubtracting = false;
            isMultiplying = false;
            isDividing = false;
            isCarreting = false;
            counter = 0;
        }

        private void ClearOperators()
        {
            isAdding = false;
            isSubtracting = false;
            isMultiplying = false;
            isDividing = false;
        }

       

        private void RemoveError()
        {
            if (BottomTextBox.Text.Equals("Error", StringComparison.CurrentCultureIgnoreCase))
            {
                BottomTextBox.Clear();
                TopTextBox.Clear();
                firstNum = "";
                secondNum = "";
            }
        }
    }
}