namespace ESDentalLab
{
    public class frmGiris : Form
    {
        private readonly TextBox txtKullaniciAdi = new();
        private readonly TextBox txtSifre = new();
        private readonly Label lblHata = new();

        public frmGiris()
        {
            Text = "ES Dental Lab — Giriş";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(420, 380);
            BackColor = Color.FromArgb(243, 247, 249);
            Font = new Font("Segoe UI", 10F);
            AcceptButton = null;
            KeyPreview = true;
            KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GirisDene();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            Panel ust = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = ArayuzTema.Baslik
            };

            Label lblMarka = new Label
            {
                Text = "ES DENTAL LAB",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(96, 28)
            };

            Label lblAlt = new Label
            {
                Text = "Devam etmek için giriş yapın",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(202, 221, 235),
                AutoSize = true,
                Location = new Point(98, 68)
            };

            ust.Controls.Add(lblMarka);
            ust.Controls.Add(lblAlt);
            ArayuzTema.BaslikLogosuEkle(ust, solaYasla: true, maksimumBoyut: 72);

            Label lblKullanici = new Label
            {
                Text = "Kullanıcı adı",
                AutoSize = true,
                Location = new Point(40, 140),
                ForeColor = Color.FromArgb(37, 58, 75)
            };

            txtKullaniciAdi.Location = new Point(40, 165);
            txtKullaniciAdi.Size = new Size(340, 30);
            txtKullaniciAdi.PlaceholderText = "admin";

            Label lblSifre = new Label
            {
                Text = "Şifre",
                AutoSize = true,
                Location = new Point(40, 210),
                ForeColor = Color.FromArgb(37, 58, 75)
            };

            txtSifre.Location = new Point(40, 235);
            txtSifre.Size = new Size(340, 30);
            txtSifre.UseSystemPasswordChar = true;
            txtSifre.PlaceholderText = "••••";

            lblHata.AutoSize = false;
            lblHata.Size = new Size(340, 36);
            lblHata.Location = new Point(40, 275);
            lblHata.ForeColor = Color.FromArgb(180, 40, 40);
            lblHata.Font = new Font("Segoe UI", 9F);
            lblHata.Text = "";

            Button btnGiris = new Button
            {
                Text = "Giriş Yap",
                Size = new Size(340, 42),
                Location = new Point(40, 315),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = ArayuzTema.Vurgu,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.Click += (_, _) => GirisDene();
            AcceptButton = btnGiris;

            Controls.Add(ust);
            Controls.Add(lblKullanici);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(lblSifre);
            Controls.Add(txtSifre);
            Controls.Add(lblHata);
            Controls.Add(btnGiris);

            Shown += (_, _) => txtKullaniciAdi.Focus();
        }

        private void GirisDene()
        {
            (bool basarili, string mesaj) = VeriDeposu.GirisYap(txtKullaniciAdi.Text, txtSifre.Text);
            if (!basarili)
            {
                lblHata.Text = mesaj;
                txtSifre.SelectAll();
                txtSifre.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
