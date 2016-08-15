using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calculate : System.Web.UI.Page
{
    public int Add(int Value1, int Value2)
    {
        return Value1 + Value2;
    }
    public int Subtract(int Value1, int Value2)
    {
        return Value1 - Value2;
    }
    public int Multiply(int Value1, int Value2)
    {
        return Value1 * Value2;
    }
    public double Divide(int Value1, int Value2)
    {
        return Value1 / Value2;
    }
    public string Percentage(int Value1, int Value2)
    {
        Value1 = Value1 * 100;

        return Divide(Value1, Value2) + "%";
    }
}

public partial class Calculator : Calculate
{
    Calculate _Calculate;

    protected void Page_Load(object sender, EventArgs e)
    {
        _Calculate = new Calculate();
    }

    protected void Button0_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "0";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "1";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "2";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "3";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "4";
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "5";
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "6";
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "7";
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "8";
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + "9";
    }

    protected void ButtonComa_Click(object sender, EventArgs e)
    {
        calc_result.Value = calc_result.Value + ",";
    }

    protected void ButtonPlusMinus_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            calc_result.Value = "-" + calc_result.Value;
        }
    }

    protected void ButtonPlus_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            ViewState["Value1"] = calc_result.Value;
            ViewState["Operation"] = "Addition";
            calc_result.Value = string.Empty;
        }
    }

    protected void ButtonMinus_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            ViewState["Value1"] = calc_result.Value;
            ViewState["Operation"] = "Subtraction";
            calc_result.Value = string.Empty;
        }
    }

    protected void ButtonMultiply_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            ViewState["Value1"] = calc_result.Value;
            ViewState["Operation"] = "Multiplication";
            calc_result.Value = string.Empty;
        }
    }

    protected void ButtonDivide_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            ViewState["Value1"] = calc_result.Value;
            ViewState["Operation"] = "Division";
            calc_result.Value = string.Empty;
        }
    }

    protected void ButtonPercentage_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            ViewState["Value1"] = calc_result.Value;
            ViewState["Operation"] = "Percentage";
            calc_result.Value = string.Empty;
        }
    }

    protected void ButtonCE_Click(object sender, EventArgs e)
    {
        if ((string)ViewState["Operation"] != null)
        {
            ViewState["Operation"] = null;
            calc_result.Value = string.Empty;
        }
        else if (calc_result.Value != null)
        {
            ViewState["Value1"] = calc_result.Value;
            ViewState["Value1"] = null;
            calc_result.Value = string.Empty;
        }
    }

    protected void ButtonReturn_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            string CharactersInTextBox = calc_result.Value;
            string FinalCharactersInTextBox = string.Empty;

            for (int i = 0; i < CharactersInTextBox.Length - 1; i++)
            {
                FinalCharactersInTextBox = FinalCharactersInTextBox + CharactersInTextBox[i];
            }

            calc_result.Value = FinalCharactersInTextBox;
        }
    }

    protected void ButtonEquals_Click(object sender, EventArgs e)
    {
        if (calc_result.Value == string.Empty)
        {
            Response.Write("<script>alert('Introdueix un número.')</script>");
        }
        else
        {
            ViewState["Value2"] = calc_result.Value;
            calc_result.Value = string.Empty;

            try
            {
                if ((string)ViewState["Operation"] == "Addition")
                {
                    calc_result.Value = _Calculate.Add(Convert.ToInt32(ViewState["Value1"]), Convert.ToInt32(ViewState["Value2"])).ToString();
                }
                else if ((string)ViewState["Operation"] == "Subtraction")
                {
                    calc_result.Value = _Calculate.Subtract(Convert.ToInt32(ViewState["Value1"]), Convert.ToInt32(ViewState["Value2"])).ToString();
                }
                else if ((string)ViewState["Operation"] == "Multiplication")
                {
                    calc_result.Value = _Calculate.Multiply(Convert.ToInt32(ViewState["Value1"]), Convert.ToInt32(ViewState["Value2"])).ToString();
                }
                else if ((string)ViewState["Operation"] == "Division")
                {
                    calc_result.Value = _Calculate.Divide(Convert.ToInt32(ViewState["Value1"]), Convert.ToInt32(ViewState["Value2"])).ToString();
                }
                else if ((string)ViewState["Operation"] == "Percentage")
                {
                    calc_result.Value = _Calculate.Percentage(Convert.ToInt32(ViewState["Value1"]), Convert.ToInt32(ViewState["Value2"])).ToString();
                }
                else Response.Write("<script>alert('Introdueix una operació.')</script>");
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('No s'ha pogut fer la operació.')</script>");
            }
        }
    }
}

