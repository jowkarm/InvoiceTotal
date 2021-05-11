//Mohammad Jokar-Konavi
//May 10, 2021
//Exercise 7-1


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
	public partial class frmInvoiceTotal : Form
	{
        public frmInvoiceTotal()
		{
			InitializeComponent();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			decimal subtotal = 0;
			try      //A try-catch statement for the ToDecimal method
			{

				//The Subtotal text box requirs a value
				if (txtSubtotal.Text == "")
				{
					MessageBox.Show("This field is required, " +
						"please enter a value.", "Required field");
				}

				else 
				{
					subtotal = Decimal.Parse(txtSubtotal.Text);

					// This block range checks the entry
					if (subtotal < 0 || subtotal > 10000)
					{
						MessageBox.Show("Please enter a value greater than zero and less than 10000",
							"Range error");
					}
				}

				
			}

			catch
			{
				//It shows a message for non-valid entries
				MessageBox.Show("Please enter a valid number " +
					"for the Subtotal field.", "Entry Error");
			}
			decimal discountPercent = .25m;
			decimal discountAmount = subtotal * discountPercent;
			decimal invoiceTotal = subtotal - discountAmount;

			discountAmount = Math.Round(discountAmount, 2);
			invoiceTotal = Math.Round(invoiceTotal, 2);

			txtDiscountPercent.Text = discountPercent.ToString("p1");
			txtDiscountAmount.Text = discountAmount.ToString();
			txtTotal.Text = invoiceTotal.ToString();

			txtSubtotal.Focus();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}