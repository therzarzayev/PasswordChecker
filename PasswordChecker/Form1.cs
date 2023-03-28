using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms;

namespace PasswordChecker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void label11_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (textBox1.Text.Length != 0)
			{
				string password = textBox1.Text;
				int passUzunluq = 0;
				string BoyukHerhler = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				string KicikHerfler = "abcdefghijklmnopqrstuvwxyz";
				string reqemler = "0123456789";
				string Simvollar = ")!@#$%^&*(";
				foreach (char sim in password)
				{
					passUzunluq++;
				}//parolun uzunlugu
				int uzunluqbal = passUzunluq * 4;
				textBox2.Text = passUzunluq.ToString();
				textBox15.Text = "+" + uzunluqbal.ToString();

				int BoyukHerfSay = 0;
				int boyukHerfbal;
				foreach (char herf1 in BoyukHerhler)
				{
					foreach (char pasboyukherf in password)
						if (herf1 == pasboyukherf)
						{
							BoyukHerfSay++;
						}//paroldaki boyuk herf sayi
				}
				if (BoyukHerfSay == 0)
				{
					boyukHerfbal = 0;
				}
				else
				{
					boyukHerfbal = (passUzunluq - BoyukHerfSay) * 2;
				}
				textBox3.Text = BoyukHerfSay.ToString();
				textBox14.Text = "+" + boyukHerfbal.ToString();

				int KicikHerfSay = 0;
				int kicikHerfBal;
				foreach (char herf2 in KicikHerfler)
				{
					foreach (char paskicikherf in password)
						if (herf2 == paskicikherf)
						{
							KicikHerfSay++;
						}//paroldaki kicik herf sayi
				}
				if (KicikHerfSay == 0)
				{
					kicikHerfBal = 0;
				}
				else
				{
					kicikHerfBal = (passUzunluq - KicikHerfSay) * 2;
				}
				textBox4.Text = KicikHerfSay.ToString();
				textBox13.Text = "+" + kicikHerfBal.ToString();

				int ReqemSay = 0;
				int reqemBal;
				foreach (char reqem in reqemler)
				{
					foreach (char passreqem in password)
						if (reqem == passreqem)
						{
							ReqemSay++;
						}//paroldaki reqem sayi
				}
				if (ReqemSay == passUzunluq)
				{
					reqemBal = 0;
				}
				else
				{
					reqemBal = ReqemSay * 4;
				}

				textBox5.Text = ReqemSay.ToString();
				textBox12.Text = "+" + reqemBal.ToString();

				int SimvolSay = 0;
				int simvolBal;
				foreach (char simvol in Simvollar)
				{
					foreach (char passimvol in password)
						if (simvol == passimvol)
						{
							SimvolSay++;
						}//paroldaki simvol sayi
				}
				simvolBal = SimvolSay * 6;
				textBox6.Text = SimvolSay.ToString();
				textBox11.Text = "+" + simvolBal.ToString();

				int OrtaSimReqSay = 0;
				int ortaSimReqBal;
				foreach (char orsimreq in reqemler + Simvollar)
				{
					foreach (char passOrtSimReq in password)
						if (orsimreq == passOrtSimReq)
						{
							OrtaSimReqSay++;
						}//paroldaki simvol+reqem sayi
					if (orsimreq == password[0]) { OrtaSimReqSay = OrtaSimReqSay - 1; }
					if (orsimreq == password[passUzunluq - 1]) { OrtaSimReqSay = OrtaSimReqSay - 1; }
				}
				ortaSimReqBal = OrtaSimReqSay * 2;
				textBox7.Text = OrtaSimReqSay.ToString();
				textBox10.Text = "+" + ortaSimReqBal.ToString();

				int minteleb = 0;
				int mintelebBal;
				if (uzunluqbal >= 32) { minteleb = minteleb + 1; }
				if (boyukHerfbal != 0) { minteleb = minteleb + 1; }
				if (kicikHerfBal != 0) { minteleb = minteleb + 1; }
				if (reqemBal != 0) { minteleb = minteleb + 1; }
				if (simvolBal != 0) { minteleb = minteleb + 1; }
				if (minteleb > 3) { mintelebBal = minteleb * 2; }
				else { mintelebBal = 0; }
				textBox8.Text = minteleb.ToString();
				textBox9.Text = "+" + mintelebBal.ToString();
				int umumiBal = uzunluqbal + kicikHerfBal + boyukHerfbal + reqemBal + simvolBal + ortaSimReqBal + mintelebBal;
				int boyukicik = BoyukHerfSay + KicikHerfSay;
				if (boyukicik == passUzunluq)
				{
					umumiBal = umumiBal - boyukicik;
					textBox29.Text = boyukicik.ToString();
					textBox22.Text = "-" + boyukicik.ToString();
				}
				else
				{
					textBox29.Text = "0";
					textBox22.Text = "-0";
				}

				if (ReqemSay == passUzunluq)
				{
					umumiBal = umumiBal - ReqemSay;
					textBox28.Text = ReqemSay.ToString();
					textBox21.Text = "-" + ReqemSay.ToString();
				}
				else
				{
					textBox28.Text = "0";
					textBox21.Text = "-0";
				}

				int ardicil_boyuk_herf = 0, ardicil_kicik_herf = 0, ardicil_reqem = 0, unikal_simvol_sayi = 0, tekrar_simvol_sayi = 0;
				double tekrar_bali = 0;
				bool prevIsLower = false, prevIsUpper = false, prevIsNumber = false;
				for (int a = 0; a < password.Length; a++)
				{
					var bCharExists = false;
					if (char.IsUpper(password[a]))
					{
						if (prevIsUpper)
						{
							ardicil_boyuk_herf++;
							prevIsLower = false;
							prevIsNumber = false;
						}
						prevIsUpper = true;
					}
					else if (char.IsLower(password[a]))
					{
						if (prevIsLower)
						{
							ardicil_kicik_herf++;
							prevIsUpper = false;
							prevIsNumber = false;
						}
						prevIsLower = true;
					}
					else if (char.IsDigit(password[a]))
					{
						if (prevIsNumber)
						{
							ardicil_reqem++;
							prevIsLower = false;
							prevIsUpper = false;
						}
						prevIsNumber = true;
					}


					for (var b = 0; b < password.Length; b++)
					{
						if (password[a] == password[b] && a != b)
						{
							bCharExists = true;
							tekrar_bali += Math.Abs(password.Length / (b - a));
						}
					}
					if (bCharExists)
					{
						tekrar_simvol_sayi++;
						unikal_simvol_sayi = password.Length - tekrar_simvol_sayi;
						tekrar_bali = unikal_simvol_sayi > 0
						  ? Math.Ceiling(tekrar_bali / unikal_simvol_sayi)
						  : Math.Ceiling(tekrar_bali);
					}
				}
				int ArdkicikHerfBal = ardicil_kicik_herf * 2;
				int ArdboyukHerfBal = ardicil_boyuk_herf * 2;
				int ArdReqemBal = ardicil_reqem * 2;
				textBox27.Text = tekrar_simvol_sayi.ToString();
				textBox20.Text = "-" + tekrar_bali.ToString();

				textBox26.Text = ardicil_boyuk_herf.ToString();
				textBox19.Text = "-" + ArdboyukHerfBal.ToString();

				textBox25.Text = ardicil_kicik_herf.ToString();
				textBox18.Text = "-" + ArdkicikHerfBal.ToString();

				textBox24.Text = ArdReqemBal.ToString();
				textBox17.Text = "-" + ArdReqemBal.ToString();
				int tekrarBal = (int)tekrar_bali;
				umumiBal = umumiBal - (tekrarBal + ArdboyukHerfBal + ArdkicikHerfBal + ArdReqemBal);

				int ar3herfsay = 0;
				string boyukPass = password.ToUpper();
				for (int s = 0; s < 23; s++)
				{
					string UcHerf = BoyukHerhler.Substring(s, 3);
					string eksUcHerf = "";
					for (int d = UcHerf.Length - 1; d >= 0; d--)
					{
						eksUcHerf += UcHerf[d];
					}
					if (boyukPass.IndexOf(UcHerf) != -1 || boyukPass.IndexOf(eksUcHerf) != -1) { ar3herfsay++; }
				}
				int ar3herfBal = ar3herfsay * 3;
				umumiBal = umumiBal - ar3herfBal;
				textBox23.Text = ar3herfsay.ToString();
				textBox16.Text = "-" + ar3herfBal;

				int ar3reqemsay = 0;
				for (int h = 0; h < 7; h++)
				{
					string UcReq = reqemler.Substring(h, 3);
					string eksUcReq = "";
					for (int z = UcReq.Length - 1; z >= 0; z--)
					{
						eksUcReq += UcReq[z];
					}
					if (password.IndexOf(UcReq) != -1 || password.IndexOf(eksUcReq) != -1) { ar3reqemsay++; }
				}
				int ar3ReqemBal = ar3reqemsay * 3;
				umumiBal = umumiBal - ar3ReqemBal;
				textBox33.Text = ar3reqemsay.ToString();
				textBox31.Text = "-" + ar3ReqemBal;

				int ar3simvsay = 0;
				for (int g = 0; g < 7; g++)
				{
					string UcSimv = Simvollar.Substring(g, 3);
					string eksUcSimv = "";
					for (int l = UcSimv.Length - 1; l >= 0; l--)
					{
						eksUcSimv += UcSimv[l];
					}
					if (password.IndexOf(UcSimv) != -1 || password.IndexOf(eksUcSimv) != -1) { ar3simvsay++; }
				}
				int ar3SimvBal = ar3simvsay * 3;
				umumiBal = umumiBal - ar3SimvBal;
				textBox32.Text = ar3simvsay.ToString();
				textBox30.Text = "-" + ar3SimvBal;

				if (umumiBal >= 0 && umumiBal <= 100) { textBox34.Text = umumiBal.ToString() + "%"; }
				if (umumiBal < 0) { textBox34.Text = "0%"; }
				if (umumiBal > 100) { textBox34.Text = "100%"; }
				if (umumiBal >= 80) { textBox34.BackColor = Color.LimeGreen; label23.Text = "Çox güclü"; }
				if (umumiBal < 80 && umumiBal >= 60) { textBox34.BackColor = Color.LawnGreen; label23.Text = "Güclü"; }
				if (umumiBal < 60 && umumiBal >= 40) { textBox34.BackColor = Color.LightGreen; label23.Text = "Yaxşı"; }
				if (umumiBal < 40 && umumiBal >= 20) { textBox34.BackColor = Color.Red; label23.Text = "Zəif"; }
				if (umumiBal < 20) { textBox34.BackColor = Color.DarkRed; label23.Text = "Çox zəif"; }
			}
			else
			{
				MessageBox.Show("Zəhmət olmasa şifrə daxil edin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox34.BackColor = DefaultBackColor;
			label23.Text = "";
			ClearAllTextbx(this);
		}
		void ClearAllTextbx(Control txtbox)
		{
			foreach (Control c in txtbox.Controls)
			{
				if (c is TextBox)
					((TextBox)c).Clear();
				else
					ClearAllTextbx(c);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
